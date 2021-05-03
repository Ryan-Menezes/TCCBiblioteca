<?php

	include_once "conexao.php";
	include_once "Usuario.php";
	if(!isset($_SESSION)) session_start();

	$conexao = conexao::getConexao();

	if(!isset($_SESSION["usuario"])){
		header("location: index.php");
	}

	$dadosUsuario = $_SESSION["usuario"];

	$nivelAcesso = $dadosUsuario->getNivelAcesso();

	if($nivelAcesso != "A"){
		header("location: index.php");
	}

	$msgFinal = null;

	if(isset($_POST["cod"]) && isset($_POST["mensagem"]) && isset($_POST["title"])){
		try{
			$cod = trim(addslashes($_POST["cod"]));
			$msg = trim(addslashes($_POST["mensagem"]));
			$titulo = trim(addslashes($_POST["title"]));
			$codAdmin = $dadosUsuario->getCodUsuario();
			
			//Enviando a mensagem

			$comando = $conexao->prepare("INSERT INTO avisos (titulo, mensagem, situacao, data_envio, id_usuario_avisos, id_usuarioRemetente_avisos) VALUES (:titulo, :msg, 'N', CURDATE(), :idU, :idA)");

			$comando->bindParam(":titulo", $titulo);
			$comando->bindParam(":msg", $msg);
			$comando->bindParam(":idU", $cod);
			$comando->bindParam(":idA", $codAdmin);

			$comando->execute();

			if($comando->rowCount() > 0){
				$msgFinal = "Mensagem enviada com sucesso";
			}else{
				$msgFinal = "Mensagem não enviada!, Ocorreu um erro ao enviar esta mensagem";
			}
		}catch(Exeption $ex){
			$msgFinal = "Mensagem não enviada!, Ocorreu um erro ao enviar esta mensagem";
		}
	}else{
		header("location: Inicio.php");
	}

	if($msgFinal == "Mensagem enviada com sucesso"){
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