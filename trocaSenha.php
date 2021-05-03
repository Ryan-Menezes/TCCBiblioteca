<?php

	include_once "conexao.php";
	include_once "codigosRecaptcha.php";
	include_once "dadosSistema.php";
	if(!isset($_SESSION)) session_start();

	$conexao = conexao::getConexao();

	if(isset($_GET["hash"]) && isset($_GET["chave"]) && isset($_GET['e'])){
		$hash = trim(addslashes($_GET["hash"]));
		$rm = str_ireplace('.', '', str_ireplace('-', '', trim(addslashes($_GET["chave"]))));
		$entrada = null;

		if(password_verify(0, trim(addslashes($_GET["e"])))) $entrada = 0;
		else if(password_verify(1, trim(addslashes($_GET["e"])))) $entrada = 1;
		else $entrada = 2;

		$entradaHash = trim(addslashes($_GET["e"]));

		$senha = null;
		$email = null;
		$nome = null;
		$img = null;

		if($entrada == 0){ //Aluno

			$comando = $conexao->prepare("SELECT u.senha, c.email, CONCAT(a.nome, CONCAT(' ', a.sobrenome)), a.img_aluno FROM usuario AS u INNER JOIN aluno AS a ON a.id_usuario_aluno = u.id_usuario INNER JOIN contato_aluno AS c ON c.rm_aluno_contato = a.rm_aluno WHERE a.rm_aluno = :rm LIMIT 1");

			$comando->bindParam(":rm", $rm);

			$comando->execute();

			$result = $comando->fetchAll();

			if(count($result) > 0){
				$senha = $result[0][0];
				$email = htmlspecialchars($result[0][1]);
				$nome = htmlspecialchars($result[0][2]);
				$img = base64_encode($result[0][3]);
			}else{
				header("location: index.php");
			}
		}else if($entrada == 1){ //Professor

			$comando = $conexao->prepare("SELECT u.senha, c.email, CONCAT(p.nome, CONCAT(' ', p.sobrenome)), p.img_professor FROM usuario AS u INNER JOIN professor AS p ON p.id_usuario_professor = u.id_usuario INNER JOIN contato_professor AS c ON c.rm_professor_contato = p.rm_professor WHERE p.rm_professor = :rm LIMIT 1");

			$comando->bindParam(":rm", $rm);

			$comando->execute();

			$result = $comando->fetchAll();

			if(count($result) > 0){
				$senha = $result[0][0];
				$email = htmlspecialchars($result[0][1]);
				$nome = htmlspecialchars($result[0][2]);
				$img = base64_encode($result[0][3]);
			}else{
				header("location: index.php");
			}
		}else{//Funcionário

			$comando = $conexao->prepare("SELECT u.senha, c.email, CONCAT(f.nome, CONCAT(' ', f.sobrenome)), f.img_funcionario FROM usuario AS u INNER JOIN funcionario AS f ON f.id_usuario_funcionario = u.id_usuario INNER JOIN contato_funcionario AS c ON c.cpf_funcionario = f.cpf WHERE f.cpf = :cpf LIMIT 1");

			$comando->bindParam(":cpf", $rm);

			$comando->execute();

			$result = $comando->fetchAll();

			if(count($result) > 0){
				$senha = $result[0][0];
				$email = htmlspecialchars($result[0][1]);
				$nome = htmlspecialchars($result[0][2]);
				$img = base64_encode($result[0][3]);
			}else{
				header("location: index.php");
			}
		}
	}else{
		header("location: index.php");
	}

	if(!password_verify($senha.$email.$rm.$entrada, $hash)){
		header("location: index.php");
	}

?>

<!DOCTYPE html>
<html lang="pt-br">
<head>
	<title><?php echo Info::$nomeSistema ?> - Trocar senha</title>
	<meta charset="utf-8">
	<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">

	<link rel="shortcut icon" type="image/jpg" <?php echo "href='".Info::$logoSistema."'" ?> sizes="50x50">
	
	<script type="text/javascript" src="./scripts/recaptcha.js"></script>
	<style type="text/css">
		*{
			margin: 0;
			padding: 0;
			font-family: arial;
		}
		section{
			position: absolute;
			width: 100%;
			height: 100%;
			display: flex;
			align-items: center;
			justify-content: center;
			background-image: url("./Imagens/fundoTroca.jpg"); 
			background-size: cover;
			background-repeat: no-repeat;
		}
		section form{
			padding: 40px;
			width: 300px;
			box-shadow: 0px 0px 10px black;
			border-radius: 3px;
			display: flex;
			flex-direction: column;
			background-color: white;
		}
		section form input[type=password]{
			padding: 10px;
			outline: none;
			border: 1px solid gray;
			border-radius: 3px;
			margin-bottom: 20px;
		}
		section form input[type=submit]{
			padding: 10px;
			outline: none;
			border: none;
			cursor: pointer;
			background-color: #4287f5;
			color: white;
			border-radius: 3px;
			transition-duration: 0.3s;
		}
		section form input[type=submit]:hover{
			background-color: #0c3d8a;
		}
		section form main{
			display: flex;
			flex-direction: row;
			align-items: center;
			justify-content: flex-start;
			padding: 10px;
			border: 1px solid gray;
			border-radius: 3px;
			margin-bottom: 20px;
		}
		section form main h5{
			margin-left: 15px;
		}
		section form main img{
			width: 40px;
			height: 40px;
			border-radius: 50%;
		}
		section form span{
			color: #5e0101;
			display: none;
			text-align: center;
		}

		/*Responsividade*/

		@media(max-width: 390px){
			section form{
				padding: 20px;
				width: auto;
			}
		}
	</style>
</head>
<body>

	<section>
		<form action="trocaSenhaUser.php" name="formSenha" method="post" onsubmit="return verificaSenha()">
			<main>
				<img <?php echo "src='data:image/jpg;base64,$img'" ?>>
				<h5><?php echo $nome; ?></h5>
			</main>

			<input type="password" name="senha" placeholder="Nova senha" onkeyup="limpaSenha()">
		
			<input type="password" name="Rsenha" placeholder="Repetir nova senha" onkeyup="limpaSenha()">
		
			<input type="hidden" name="chave" <?php echo "value='$rm'"; ?>>
			<input type="hidden" name="hash" <?php echo "value='$hash'"; ?>>
			<input type="hidden" name="entrada" <?php echo "value='$entradaHash'"; ?>>

			<div class="g-recaptcha" <?php echo "data-sitekey='$codChaveDiv'"; ?>></div><br>

			<span id="spanAlerta"></span><br>
		
			<input type="submit" value="Solicitar troca">
		</form>
	</section>

	<script type="text/javascript">
		
		function verificaSenha(){
			let senha = formSenha.senha.value.trim()
			let senhaRe = formSenha.Rsenha.value.trim()

			let span = window.document.getElementById('spanAlerta')

			let verifica = true

			if(senha.length < 8){
				span.innerText = "Digite a senha com pelo menos 8 digítos"
				span.style.display = "inline"
				verifica = false
			}else if(senha != senhaRe){
				span.innerText = "As senhas digitadas não são iguais!"
				span.style.display = "inline"
				verifica = false
			}

			return verifica
		}

		function limpaSenha(){
			window.document.getElementById('spanAlerta').style.display = "none"
		}

	</script>

</body>
</html>