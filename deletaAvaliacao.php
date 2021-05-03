<?php

	include_once "conexao.php";
	include_once "Usuario.php";
	if(!isset($_SESSION)) session_start();

	$conexao = conexao::getConexao();

	if(!isset($_SESSION["usuario"])){
		header("location: index.php");
	}

	$dadosUsuario = $_SESSION["usuario"];

	//Código acima - verificação de login

	$msgFinal = null;

	if(isset($_POST["cod"])){
		try{
			$codigo = trim(addslashes($_POST["cod"]));

			
			$comando = $conexao->prepare("SELECT a.id_usuario_avaliacao FROM avaliacao AS a INNER JOIN usuario AS u ON u.id_usuario = a.id_usuario_avaliacao WHERE a.id_avaliacao = :id LIMIT 1");

			$comando->bindParam(":id", $codigo);

			$comando->execute();

			$dadoUser = $comando->fetchAll();

			if(count($dadoUser) > 0){
				$codU = htmlspecialchars($dadoUser[0][0]);
				$codUser = $dadosUsuario->getCodUsuario();

				if($codU == $codUser){
					$comando = $conexao->prepare("DELETE FROM avaliacao WHERE id_avaliacao = :id LIMIT 1");

					$comando->bindParam(":id", $codigo);

					$comando->execute();

					if($comando->rowCount() > 0){
						$msgFinal = "Avaliação deletada com sucesso!";
					}else{
						$msgFinal = "Avaliação não deletada, Ocorreu um erro no processo de exclusão!";
					}
				}else{
					$msgFinal = "Avaliação não deletada, Ocorreu um erro no processo de exclusão!";
				}
			}else{
				$msgFinal = "Avaliação não deletada, Ocorreu um erro no processo de exclusão!";
			}
		}catch(Execption $ex){
			$msgFinal = "Avaliação não deletada, Ocorreu um erro no processo de exclusão!";
		}
	}else{
		header("location: Inicio.php");
	}

	if($msgFinal == "Avaliação deletada com sucesso!"){
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