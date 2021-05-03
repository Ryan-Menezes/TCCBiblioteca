<?php

	include_once "conexao.php";
	include_once "Usuario.php";
	if(!isset($_SESSION)) session_start();

	$conexao = conexao::getConexao();

	if(!isset($_SESSION["usuario"])){
		header("location: index.php");
	}

	$dados = $_SESSION["usuario"];
	$msgFinal = null;

	if(isset($_POST["cod"])){
		try{
			$codM = trim(addslashes($_POST["cod"]));
			$cod = $dados->getCodUsuario();
			$dadoMsg = null;

			$comando = $conexao->prepare("DELETE FROM avisos WHERE id_aviso = :idM AND id_usuario_avisos = :idU LIMIT 1");
				
			$comando->bindParam(":idM", $codM);
			$comando->bindParam(":idU", $cod);

			$comando->execute();

			if($comando->rowCount() > 0){
				$msgFinal = "Mensagem deletada com sucesso!";
			}else{
				$msgFinal = "Mensagem não deletada, Ocorreu um erro no processo de exclusão!";
			}
		}catch(Exeption $ex){
			$msgFinal = "Mensagem não deletada, Ocorreu um erro no processo de exclusão!";
		}
	}else{
		header("location: Inicio.php");
	}

	if($msgFinal == "Mensagem deletada com sucesso!"){
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