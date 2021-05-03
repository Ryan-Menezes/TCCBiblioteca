<?php

	include_once "conexao.php";
	include_once "recaptcha.php";
	include_once "codigosRecaptcha.php";
	if(!isset($_SESSION)) session_start();

	$conexao = conexao::getConexao();

	//Configurações sobre o recaptcha

	$chaveSecreta = $codChaveRe;
	$response = null;
    $reCaptcha = new reCaptcha($chaveSecreta);

	if(isset($_POST["chave"]) && isset($_POST["entrada"]) && isset($_POST["hash"]) && isset($_POST['g-recaptcha-response'])){
		$rm = str_ireplace('.', '', str_ireplace('-', '', trim(addslashes($_POST["chave"]))));
		$entrada = null;

		if(password_verify(0, trim(addslashes($_POST["entrada"])))) $entrada = 0;
		else if(password_verify(1, trim(addslashes($_POST["entrada"])))) $entrada = 1;
		else $entrada = 2;

		$hash = trim(addslashes($_POST["hash"]));

		$senhaUser = md5(trim(addslashes($_POST["senha"])));

		$response = $reCaptcha->verifyResponse($_SERVER['REMOTE_ADDR'], $_POST['g-recaptcha-response']);

		if($response != null && $response->success){
			if($entrada == 0){ //Aluno

				$comando = $conexao->prepare("SELECT u.senha, c.email, u.id_usuario FROM usuario AS u INNER JOIN aluno AS a ON a.id_usuario_aluno = u.id_usuario INNER JOIN contato_aluno AS c ON c.rm_aluno_contato = a.rm_aluno WHERE a.rm_aluno = :rm LIMIT 1");

				$comando->bindParam(":rm", $rm);

				$comando->execute();

				$result = $comando->fetchAll();

				if(count($result) > 0){

					$senha = $result[0][0];
					$email = htmlspecialchars($result[0][1]);
					$id_usuario = trim(addslashes($result[0][2]));
					
					if(password_verify($senha.$email.$rm.$entrada, $hash)){
						$comando = $conexao->prepare("UPDATE usuario SET senha = :senha WHERE id_usuario = :id LIMIT 1");

						$comando->bindParam(":senha", $senhaUser);
						$comando->bindParam(":id", $id_usuario);

						$comando->execute();

						if($comando->rowCount() > 0){
							$_SESSION["msg"] = "Senha alterada com sucesso";
							header("location: index.php");
						}else{
							$_SESSION["msg"] = "Senha não alterada, Ocorreu um erro no processo de troca!";
							header("location: index.php");
						}
					}else{
						header("location: index.php");
					}

				}else{
					header("location: index.php");
				}
			}else if($entrada == 1){ //Professor

				$comando = $conexao->prepare("SELECT u.senha, c.email, u.id_usuario FROM usuario AS u INNER JOIN professor AS p ON p.id_usuario_professor = u.id_usuario INNER JOIN contato_professor AS c ON c.rm_professor_contato = p.rm_professor WHERE p.rm_professor = :rm LIMIT 1");

				$comando->bindParam(":rm", $rm);

				$comando->execute();

				$result = $comando->fetchAll();

				if(count($result) > 0){
					
					$senha = $result[0][0];
					$email = htmlspecialchars($result[0][1]);
					$id_usuario = trim(addslashes($result[0][2]));
					
					if(password_verify($senha.$email.$rm.$entrada, $hash)){
						$comando = $conexao->prepare("UPDATE usuario SET senha = :senha WHERE id_usuario = :id LIMIT 1");

						$comando->bindParam(":senha", $senhaUser);
						$comando->bindParam(":id", $id_usuario);

						$comando->execute();

						if($comando->rowCount() > 0){
							$_SESSION["msg"] = "Senha alterada com sucesso";
							header("location: index.php");
						}else{
							$_SESSION["msg"] = "Senha não alterada, Ocorreu um erro no processo de troca!";
							header("location: trocaSenha.php?hash=$hash&chave=$rm&e=$entrada");
						}
					}else{
						header("location: index.php");
					}

				}else{
					header("location: index.php");
				}
			}else{//Funcionário

				$comando = $conexao->prepare("SELECT u.senha, c.email, u.id_usuario FROM usuario AS u INNER JOIN funcionario AS f ON f.id_usuario_funcionario = u.id_usuario INNER JOIN contato_funcionario AS c ON c.cpf_funcionario = f.cpf WHERE f.cpf = :cpf LIMIT 1");

				$comando->bindParam(":cpf", $rm);

				$comando->execute();

				$result = $comando->fetchAll();

				if(count($result) > 0){
					
					$senha = $result[0][0];
					$email = htmlspecialchars($result[0][1]);
					$id_usuario = trim(addslashes($result[0][2]));
					
					if(password_verify($senha.$email.$rm.$entrada, $hash)){
						$comando = $conexao->prepare("UPDATE usuario SET senha = :senha WHERE id_usuario = :id LIMIT 1");

						$comando->bindParam(":senha", $senhaUser);
						$comando->bindParam(":id", $id_usuario);

						$comando->execute();

						if($comando->rowCount() > 0){
							$_SESSION["msg"] = "Senha alterada com sucesso";
							header("location: index.php");
						}else{
							$_SESSION["msg"] = "Senha não alterada, Ocorreu um erro no processo de troca!";
							header("location: index.php");
						}
					}else{
						header("location: index.php");
					}

				}else{
					header("location: index.php");
				}
			}
		}else{
			$_SESSION["msg"] = "Recaptcha Inválido";
			header("location: index.php");
		}
	}else{
		header("location: index.php");
	}
?>