<?php

	include_once "conexao.php";
	include_once "Usuario.php";
	if(!isset($_SESSION)) session_start();

	$conexao = conexao::getConexao();

	if(!isset($_SESSION["usuario"])){
		header("location: index.php");
	}

	$dadosUser = $_SESSION["usuario"];
	$msgFinal = null;

	try{
		$conexao = conexao::getConexao();

		if(isset($_POST["cod"])){
			$codigo = trim(addslashes($_POST["cod"]));

			//Verificando se o código passado está associado há algum livro no sistema

			$comando = $conexao->prepare("DELETE FROM lista WHERE id_lista = :cod LIMIT 1");

			$comando->bindValue(":cod", $codigo);

			$comando->execute();

			if($comando->rowCount() > 0){
				$msgFinal = "Livro removido da lista com sucesso!";
			}else{
				$msgFinal = "Ocorreu um erro ao tentar remover este livro de sua lista";
			}
			
		}else{
			header("location: Inicio.php");
		}
	}catch(PDOException $ex){
		$msgFinal = "Ocorreu um erro ao tentar remover este livro de sua lista";
	}

	if($msgFinal == "Livro removido da lista com sucesso!"){
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