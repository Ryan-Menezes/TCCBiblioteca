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

	if(isset($_POST["rmTroca"]) && isset($_POST["entrada"]) && isset($_POST['g-recaptcha-response'])){
		$rm = str_ireplace('.', '', str_ireplace('-', '', trim(addslashes($_POST["rmTroca"]))));
		$entrada = trim(addslashes($_POST["entrada"]));

		$response = $reCaptcha->verifyResponse($_SERVER['REMOTE_ADDR'], $_POST['g-recaptcha-response']);

		if($response != null && $response->success){
			if($entrada == 0){ //Aluno

				$comando = $conexao->prepare("SELECT u.senha, c.email FROM usuario AS u INNER JOIN aluno AS a ON a.id_usuario_aluno = u.id_usuario INNER JOIN contato_aluno AS c ON c.rm_aluno_contato = a.rm_aluno WHERE a.rm_aluno = :rm LIMIT 1");

				$comando->bindParam(":rm", $rm);

				$comando->execute();

				$result = $comando->fetchAll();

				if(count($result) > 0){
					$senha = $result[0][0];
					$email = htmlspecialchars($result[0][1]);

					enviaEmail($senha, $email, $rm, $entrada);
				}else{
					$_SESSION["msg"] = "Não há nenhum aluno cadastrado com este RM!";
					header("location: index.php");
				}
			}else if($entrada == 1){ //Professor

				$comando = $conexao->prepare("SELECT u.senha, c.email FROM usuario AS u INNER JOIN professor AS p ON p.id_usuario_professor = u.id_usuario INNER JOIN contato_professor AS c ON c.rm_professor_contato = p.rm_professor WHERE p.rm_professor = :rm LIMIT 1");

				$comando->bindParam(":rm", $rm);

				$comando->execute();

				$result = $comando->fetchAll();

				if(count($result) > 0){
					$senha = $result[0][0];
					$email = htmlspecialchars($result[0][1]);

					enviaEmail($senha, $email, $rm, $entrada);
				}else{
					$_SESSION["msg"] = "Não há nenhum professor cadastrado com este RM!";
					header("location: index.php");
				}
			}else{//Funcionário

				$comando = $conexao->prepare("SELECT u.senha, c.email FROM usuario AS u INNER JOIN funcionario AS f ON f.id_usuario_funcionario = u.id_usuario INNER JOIN contato_funcionario AS c ON c.cpf_funcionario = f.cpf WHERE f.cpf = :cpf LIMIT 1");

				$comando->bindParam(":cpf", $rm);

				$comando->execute();

				$result = $comando->fetchAll();

				if(count($result) > 0){
					$senha = $result[0][0];
					$email = htmlspecialchars($result[0][1]);

					enviaEmail($senha, $email, $rm, $entrada);
				}else{
					$_SESSION["msg"] = "Não há nenhum funcionário cadastrado com este CPF!";
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

	function enviaEmail($s, $e, $r, $en){

		$hash = password_hash($s.$e.$r.$en, PASSWORD_DEFAULT);

		$to = $e;
		$assunto = "Solicitação de troca de senha do sistema da biblioteca";
		$message = "<a href='trocaSenha.php?hash=$hash&chave=$r&e=$en'>Clique aqui para alterar sua senha</a>";
		$header = "MIME-Version: 1.0\n";
		$header .= "Content-type: text/html; charset=iso-8859-1\n";
		$header .= "From: $e";

		$en = password_hash($en, PASSWORD_DEFAULT);

		//echo "<a href='trocaSenha.php?hash=$hash&chave=$r&e=$en'>Clique aqui para alterar sua senha</a>";

		if(mail($to, $assunto, $message, $header)){
			$_SESSION["msg"] = "Um link foi enviado para seu E-mail";
			header("location: index.php");
		}else{
			$_SESSION["msg"] = "Ocorreu um erro na operação para trocar senha!";
			header("location: index.php");
		}
	}

?>