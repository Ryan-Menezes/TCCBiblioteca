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
		$cod = trim(addslashes($_POST["cod"]));

		//Pesquisando livro na lista

		$comando = $conexao->prepare("SELECT * FROM lista WHERE id_usuario_lista = :user AND livro_tombo_lista = :livro LIMIT 1");

		$comando->bindValue(":user", $dados->getCodUsuario());
		$comando->bindParam(":livro", $cod);

		$comando->execute();

		if(count($comando->fetchAll()) == 0){
			$comando = $conexao->prepare("INSERT INTO lista (id_usuario_lista, livro_tombo_lista) VALUES (:user, :livro)");

			$comando->bindValue(":user", $dados->getCodUsuario());
			$comando->bindParam(":livro", $cod);

			$comando->execute();

			if($comando->rowCount() > 0){
				$msgFinal = "Livro adicionado na sua lista com sucesso!";
			}else{
				$msgFinal = "Livro não adicionado!, Ocorreu um erro ao tentar adicionar este livro na sua lista!";
			}
		}else{
			$msgFinal = "Este livro já se encontra na sua lista, Não é possivel adicionar novemente!";
		}
		
	}else{
		header("location: telaLivro.php");
	}

	if($msgFinal == "Livro adicionado na sua lista com sucesso!"){
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