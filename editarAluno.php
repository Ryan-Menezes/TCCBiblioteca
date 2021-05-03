<?php

	include_once "conexao.php";
	include_once "Usuario.php";
	include_once "recaptcha.php";
	include_once "codigosRecaptcha.php";
	if(!isset($_SESSION)) session_start();

	$conexao = conexao::getConexao();

	if(!isset($_SESSION["usuario"])){
		header("location: index.php");
	}

	$dados = $_SESSION["usuario"];

	$nivelAcesso = $dados->getNivelAcesso();

	if($nivelAcesso != "A"){
		header("location: index.php");
	}

	//Código acima - verificação de login

	$msgFinal = null;

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
					$imagem = (strlen($_FILES["imagem"]["name"]) > 0) ? file_get_contents($_FILES["imagem"]["tmp_name"]) : null;
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
					$cod_usuario = trim(addslashes($_POST["id_usuario"]));
					$rmO = trim(addslashes($_POST["rm_original"]));
					$status = trim(addslashes($_POST["status"]));

					//Verificando RM

					$comando = $conexao->prepare("SELECT * FROM usuario AS u INNER JOIN aluno AS a ON a.id_usuario_aluno = u.id_usuario WHERE a.rm_aluno = :rm_a LIMIT 1");

					$comando->bindParam(":rm_a", $rm);

					$comando->execute();

					$result = $comando->fetchAll();

					if((count($result) == 1 && $rm == $rmO) || count($result) == 0){

						//Endereco

						$comando = $conexao->prepare("UPDATE endereco_aluno SET cep = :cep, logradouro = :logradouro, numero = :numero, bairro = :bairro, cidade = :cidade, complemento = :complemento WHERE rm_aluno_endereco = :rm LIMIT 1");

						$cep = str_ireplace('-', '', $cep);

						$comando->bindParam(":cep", $cep);
						$comando->bindParam(":logradouro", $logradouro);
						$comando->bindParam(":numero", $numero);
						$comando->bindParam(":bairro", $bairro);
						$comando->bindParam(":cidade", $cidade);
						$comando->bindParam(":complemento", $complemento);
						$comando->bindParam(":rm", $rmO);

						$comando->execute();

						//Contato

						$comando = $conexao->prepare("UPDATE contato_aluno SET telefone = :telefone, celular = :celular, email = :email WHERE rm_aluno_contato = :rm LIMIT 1");

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
						$comando->bindParam(":rm", $rmO);

						$comando->execute();

						//Aluno

						$comando = null;

						if($imagem != null){
							$comando = $conexao->prepare("UPDATE aluno SET rm_aluno = :rm, nome = :nome, sobrenome = :sobrenome, cpf = :cpf, sexo = :sexo, img_aluno = :imagem WHERE id_usuario_aluno = :id LIMIT 1");

							$cpf = str_ireplace('.', '', $cpf);
							$cpf = str_ireplace('-', '', $cpf);

							$comando->bindParam(":rm", $rm);
							$comando->bindParam(":nome", $nome);
							$comando->bindParam(":sobrenome", $sobrenome);
							$comando->bindParam(":cpf", $cpf);
							$comando->bindParam(":sexo", $sexo);
							$comando->bindParam(":imagem", $imagem);
							$comando->bindParam(":id", $cod_usuario);
						}else{
							$comando = $conexao->prepare("UPDATE aluno SET rm_aluno = :rm, nome = :nome, sobrenome = :sobrenome, cpf = :cpf, sexo = :sexo WHERE id_usuario_aluno = :id LIMIT 1");

							$cpf = str_ireplace('.', '', $cpf);
							$cpf = str_ireplace('-', '', $cpf);

							$comando->bindParam(":rm", $rm);
							$comando->bindParam(":nome", $nome);
							$comando->bindParam(":sobrenome", $sobrenome);
							$comando->bindParam(":cpf", $cpf);
							$comando->bindParam(":sexo", $sexo);
							$comando->bindParam(":id", $cod_usuario);
						}

						$comando->execute();

						//Cursos

						//Deletando cursos

						$comando = $conexao->prepare("DELETE FROM curso_usuario WHERE usuario_id_usuario = :id");

						$comando->bindParam(":id", $cod_usuario);

						$comando->execute();

						//Adicionando

						foreach($curso as $valor){
							$comando = $conexao->prepare("INSERT INTO curso_usuario (usuario_id_usuario, curso_id_curso) VALUES (:usuario, :curso)");

							$comando->bindParam(":usuario", $cod_usuario);
							$comando->bindParam(":curso", $valor);

							$comando->execute();
						}

						//Usuario

						$comando = $conexao->prepare("UPDATE usuario SET status_usuario = :status WHERE id_usuario = :id LIMIT 1");

						$comando->bindParam(":status", $status);
						$comando->bindParam(":id", $cod_usuario);

						$comando->execute();

						//MSG

						$msgFinal = "Aluno editado com sucesso";
					}else{
						$msgFinal = "Já existe um aluno cadastrado com este RM";
					}
				}catch(PDOException $ex){
					$msgFinal = "Não foi possivel editar este aluno!, Ocorreu um erro na edição!";
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

	if($msgFinal == "Aluno editado com sucesso"){
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
				<button onclick='deletaMoldal()'>OK</button>
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
				<button onclick='deletaMoldal()'>OK</button>
			</main>";
	}

?>