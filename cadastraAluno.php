<?php

	include_once "conexao.php";
	include_once "Usuario.php";
	include_once "recaptcha.php";
	include_once "codigosRecaptcha.php";
	include_once "dadosSistema.php";
	if(!isset($_SESSION)) session_start();

	$conexao = conexao::getConexao();

	if(!isset($_SESSION["usuario"])){
		header("location: index.php");
	}

	$dados = $_SESSION["usuario"];

	$nivelAcesso = $dados->getNivelAcesso();
	$codUserLogado = $dados->getCodUsuario();

	if($nivelAcesso != "A"){
		header("location: index.php");
	}

	//Código acima - verificação de login

	//Função que irá deletar os dados, caso ouver um erro no processo de cadastro

	function deletaUsuario($cod){
		if($cod != null){
			try{
				$conexao = conexao::getConexao();

				$comando = $conexao->prepare("DELETE FROM usuario WHERE id_usuario = $cod LIMIT 1");

				$comando->execute();
			}catch(PDOException $ex){
				//Erro
			}
		}
	}

	$cod_usuario = null;
	$msgFinal = null;
	$nomeSistema = Info::$nomeSistema;

	//Configurações sobre o recaptcha

	$chaveSecreta = $codChaveRe;
	$response = null;
    $reCaptcha = new reCaptcha($chaveSecreta);

	//Verificações para cadastro

	if(isset($_POST["rm"]) && isset($_POST['g-recaptcha-response'])){

		$response = $reCaptcha->verifyResponse($_SERVER['REMOTE_ADDR'], $_POST['g-recaptcha-response']);

		if($response != null && $response->success){
			if($_FILES["imagem"]["size"] < 1048576){
				try{
					$imagem = (strlen($_FILES["imagem"]["name"]) > 0) ? file_get_contents($_FILES["imagem"]["tmp_name"]) : file_get_contents("./Imagens/anonimo.png");
					$nome = trim(addslashes($_POST["nome"]));
					$sobrenome = trim(addslashes($_POST["sobrenome"]));
					$curso = explode(",", trim(addslashes($_POST["cursos"])));
					$cpf = trim(addslashes($_POST["cpf"]));
					$telefone = trim(addslashes($_POST["telefone"]));
					$celular = trim(addslashes($_POST["celular"]));
					$sexo = (trim(addslashes($_POST["sexo"])) == "P") ? null : trim(addslashes($_POST["sexo"]));
					$rm = trim(addslashes($_POST["rm"]));
					$email = trim(addslashes($_POST["email"]));
					$logradouro = trim(addslashes($_POST["logradouro"]));
					$cep = trim(addslashes($_POST["cep"]));
					$numero = trim(addslashes($_POST["numero"]));
					$bairro = trim(addslashes($_POST["bairro"]));
					$cidade = trim(addslashes($_POST["cidade"]));
					$complemento = trim(addslashes($_POST["complemento"]));

					//Verificando RM

					$comando = $conexao->prepare("SELECT * FROM usuario AS u INNER JOIN aluno AS a ON a.id_usuario_aluno = u.id_usuario WHERE a.rm_aluno = :rm_a LIMIT 1");

					$comando->bindParam(":rm_a", $rm);

					$comando->execute();

					$result = $comando->fetchAll();

					if(count($result) == 0){

						$cpf = str_ireplace('.', '', $cpf);
						$cpf = str_ireplace('-', '', $cpf);

						$comando = $conexao->prepare("INSERT INTO usuario (senha, nivel_acesso, status_usuario) VALUES (:senha, 'U', 'D')");

						$senha = (String) md5($cpf);

						$comando->bindParam(":senha", $senha);

						$comando->execute();

						//Codigo do usuario cadastrado acima

						$cod_usuario = null;

						if($comando->rowCount() > 0){
							$cod_usuario = $conexao->lastInsertId();

							$comando = $conexao->prepare("INSERT INTO aluno (rm_aluno, nome, sobrenome, cpf, sexo, data_cadastro, img_aluno, id_usuario_aluno) VALUES (:rm, :nome, :sobrenome, :cpf, :sexo, CURDATE(), :img_aluno, :id)");

							$comando->bindParam(":rm", $rm);
							$comando->bindParam(":nome", $nome);
							$comando->bindParam(":sobrenome", $sobrenome);
							$comando->bindParam(":cpf", $cpf);
							$comando->bindParam(":sexo", $sexo);
							$comando->bindParam(":img_aluno", $imagem);
							$comando->bindParam(":id", $cod_usuario);

							$comando->execute();				

							if($comando->rowCount() > 0){
								$comando = $conexao->prepare("INSERT INTO endereco_aluno (cep, logradouro, numero, bairro, cidade, complemento, rm_aluno_endereco) VALUES (:cep, :logradouro, :numero, :bairro, :cidade, :complemento, :rm)");

								$cep = str_ireplace('-', '', $cep);

								$comando->bindParam(":cep", $cep);
								$comando->bindParam(":logradouro", $logradouro);
								$comando->bindParam(":numero", $numero);
								$comando->bindParam(":bairro", $bairro);
								$comando->bindParam(":cidade", $cidade);
								$comando->bindParam(":complemento", $complemento);
								$comando->bindParam(":rm", $rm);

								$comando->execute();

								if($comando->rowCount() > 0){
									$comando = $conexao->prepare("INSERT INTO contato_aluno (telefone, celular, email, rm_aluno_contato) VALUES (:telefone, :celular, :email, :rm)");

									//Retirando maskara dos dados

									$telefone = str_ireplace('(', '', $telefone);
									$telefone = str_ireplace(')', '', $telefone);
									$telefone = str_ireplace('-', '', $telefone);

									$celular = str_ireplace('(', '', $celular);
									$celular = str_ireplace(')', '', $celular);
									$celular = str_ireplace('-', '', $celular);

									//Executando cadastro

									$comando->bindParam(":telefone", $telefone);
									$comando->bindParam(":celular", $celular);
									$comando->bindParam(":email", $email);
									$comando->bindParam(":rm", $rm);

									$comando->execute();

									if($comando->rowCount() > 0){
										foreach($curso as $valor){
											$comando = $conexao->prepare("INSERT INTO curso_usuario (usuario_id_usuario, curso_id_curso) VALUES (:usuario, :cursos)");

											$comando->bindParam(":usuario", $cod_usuario);
											$comando->bindParam(":cursos", $valor);

											$comando->execute();
										}

										//Enviando uma mensagem de boas vindas para este usuario que acabou de ser cadastrado!

										$comando = $conexao->prepare("INSERT INTO avisos (titulo, mensagem, situacao, data_envio, id_usuario_avisos, id_usuarioRemetente_avisos) VALUES ('Saudações', 'Seja bem vindo ao sistema da biblioteca $nomeSistema, aqui além de você poder consultar os livros de sua ETEC, você também terá acesso a consulta de diversos livros de outras ETECs(caso essas ETECs estejam incluidas no sistema)', 'N', CURDATE(), :usuario, :userRem)");

										$comando->bindParam(":usuario", $cod_usuario);
										$comando->bindParam(":userRem", $codUserLogado);

										$comando->execute();


										$msgFinal = "Aluno cadastrado com sucesso";
									}else{
										deletaUsuario($cod_usuario);
										$msgFinal = "Aluno não cadastrado!, Ocorreu um erro no cadastro!";
									}
								}else{
									deletaUsuario($cod_usuario);
									$msgFinal = "Aluno não cadastrado!, Ocorreu um erro no cadastro!";
								}
							}else{
								deletaUsuario($cod_usuario);
								$msgFinal = "Aluno não cadastrado!, Ocorreu um erro no cadastro!";
							}
						}else{
							deletaUsuario($cod_usuario);
							$msgFinal = "Aluno não cadastrado!, Ocorreu um erro no cadastro!";
						}
					}else{		
						$msgFinal = "Já existe um aluno cadastrado com este RM";
					}
				}catch(PDOException $ex){
					deletaUsuario($cod_usuario);
					$msgFinal = "Aluno não cadastrado!, Ocorreu um erro no cadastro!";
				}
			}else{
				$msgFinal = "A imagem selecionada é muito grande!, selecione outra imagem!";
			}
		}else{
			$msgFinal = "Recaptcha Inválido";
		}
	}else{
		header("location: cadAluno.php");
	}

	if($msgFinal == "Aluno cadastrado com sucesso"){
		echo "<main>
				<div class='containeAv'>
					<div>
						<h4>$msgFinal</h4>
					</div>
					<div>
						<i class='fas fa-check-circle'></i>
					</div>
				</div>
				<hr>
				<button onclick='deletaMoldal(true)'>OK</button>
			</main>";
	}else{
		echo "<main>
				<div class='containeAv'>
					<div>
						<h4>$msgFinal</h4>
					</div>
					<div>
						<i class='fas fa-times-circle'></i>
					</div>
				</div>
				<hr>
				<button onclick='deletaMoldal(false)'>OK</button>
			</main>";
	}
?>