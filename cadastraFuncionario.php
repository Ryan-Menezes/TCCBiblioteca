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

	if(isset($_POST["cpf"]) && isset($_POST['g-recaptcha-response'])){

		$response = $reCaptcha->verifyResponse($_SERVER['REMOTE_ADDR'], $_POST['g-recaptcha-response']);

		if($response != null && $response->success){
			if($_FILES["imagem"]["size"] < 1048576){
				try{
					$imagem = (strlen($_FILES["imagem"]["name"]) > 0) ? file_get_contents($_FILES["imagem"]["tmp_name"]) : file_get_contents("./Imagens/anonimo.png");
					$nome = trim(addslashes($_POST["nome"]));
					$sobrenome = trim(addslashes($_POST["sobrenome"]));
					$instituicoes = explode(",", trim(addslashes($_POST["instituicoes"])));
					$cpf = trim(addslashes($_POST["cpf"]));
					$telefone = trim(addslashes($_POST["telefone"]));
					$celular = trim(addslashes($_POST["celular"]));
					$sexo = (trim(addslashes($_POST["sexo"])) == "P") ? null : trim(addslashes($_POST["sexo"]));
					$email = trim(addslashes($_POST["email"]));
					$logradouro = trim(addslashes($_POST["logradouro"]));
					$cep = trim(addslashes($_POST["cep"]));
					$numero = trim(addslashes($_POST["numero"]));
					$bairro = trim(addslashes($_POST["bairro"]));
					$cidade = trim(addslashes($_POST["cidade"]));
					$complemento = trim(addslashes($_POST["complemento"]));

					//Verificando CPF

					$cpf = str_ireplace('.', '', $cpf);
					$cpf = str_ireplace('-', '', $cpf);

					$comando = $conexao->prepare("SELECT * FROM funcionario AS f WHERE f.cpf = :cpf_f");

					$comando->bindParam(":cpf_f", $cpf);

					$comando->execute();

					$resultCpf = $comando->fetchAll();

					if(count($resultCpf) == 0){

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

							$comando = $conexao->prepare("INSERT INTO funcionario (cpf, nome, sobrenome, sexo, data_cadastro, img_funcionario, id_usuario_funcionario) VALUES (:cpf, :nome, :sobrenome, :sexo, CURDATE(), :img_funcionario, :id)");

							$comando->bindParam(":cpf", $cpf);
							$comando->bindParam(":nome", $nome);
							$comando->bindParam(":sobrenome", $sobrenome);
							$comando->bindParam(":sexo", $sexo);
							$comando->bindParam(":img_funcionario", $imagem);
							$comando->bindParam(":id", $cod_usuario);

							$comando->execute();		

							if($comando->rowCount() > 0){

								$comando = $conexao->prepare("INSERT INTO endereco_funcionario (cep, logradouro, numero, bairro, cidade, complemento, cpf_funcionario_endereco) VALUES (:cep, :logradouro, :numero, :bairro, :cidade, :complemento, :cpf)");

								$cep = str_ireplace('-', '', $cep);

								$comando->bindParam(":cep", $cep);
								$comando->bindParam(":logradouro", $logradouro);
								$comando->bindParam(":numero", $numero);
								$comando->bindParam(":bairro", $bairro);
								$comando->bindParam(":cidade", $cidade);
								$comando->bindParam(":complemento", $complemento);
								$comando->bindParam(":cpf", $cpf);

								$comando->execute();

								if($comando->rowCount() > 0){
									$comando = $conexao->prepare("INSERT INTO contato_funcionario (telefone, celular, email, cpf_funcionario) VALUES (:telefone, :celular, :email, :cpf)");

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
									$comando->bindParam(":cpf", $cpf);

									$comando->execute();

									//Cadastrando cursos

									foreach($instituicoes as $i){
										$comando = $conexao->prepare("INSERT INTO instituicao_usuario (situacao, id_usuario, id_instituicao) VALUES (NULL, :user, :id)");

										$comando->bindParam(":user", $cod_usuario);
										$comando->bindParam(":id", $i);

										$comando->execute();
									}

									//Enviando uma mensagem de boas vindas para este usuario que acabou de ser cadastrado!

									$comando = $conexao->prepare("INSERT INTO avisos (titulo, mensagem, situacao, data_envio, id_usuario_avisos, id_usuarioRemetente_avisos) VALUES ('Saudações', 'Seja bem vindo ao sistema da biblioteca $nomeSistema, aqui além de você poder consultar os livros de sua ETEC, você também terá acesso a consulta de diversos livros de outras ETECs(caso essas ETECs estejam incluidas no sistema)', 'N', CURDATE(), :usuario, :userRem)");

									$comando->bindParam(":usuario", $cod_usuario);
									$comando->bindParam(":userRem", $codUserLogado);

									$comando->execute();

									$msgFinal = "Funcionário cadastrado com sucesso";
								}else{
									deletaUsuario($cod_usuario);
									$msgFinal = "Funcionário não cadastrado!, Ocorreu um erro no cadastro!";
								}
							}else{
								deletaUsuario($cod_usuario);
								$msgFinal = "Funcionário não cadastrado!, Ocorreu um erro no cadastro!";
							}
						}else{
							deletaUsuario($cod_usuario);
							$msgFinal = "Funcionário não cadastrado!, Ocorreu um erro no cadastro!";
						}
					}else{	
						$msgFinal = "Já existe um usuário cadastrado com este CPF";
					}
				}catch(PDOException $ex){
					deletaUsuario($cod_usuario);
					$msgFinal = "Funcionário não cadastrado!, Ocorreu um erro no cadastro!";
				}
			}else{
				$msgFinal = "A imagem selecionada é muito grande!, selecione outra imagem!";
			}
		}else{
			$msgFinal = "Recaptcha Inválido";
		}
	}else{
		header("location: cadFuncionario.php");
	}

	if($msgFinal == "Funcionário cadastrado com sucesso"){
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