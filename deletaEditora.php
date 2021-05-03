<?php

	include_once "conexao.php";
	include_once "Usuario.php";
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

	if(isset($_POST["cod"])){
		$conexao = conexao::getConexao();

		$codigo = addslashes($_POST["cod"]);

		$comando = $conexao->prepare("SELECT * FROM editora_livro WHERE id_editora = :cod LIMIT 1");

		$comando->bindValue(":cod", $codigo);

		$comando->execute();

		$dados = $comando->fetchAll();

		if(count($dados) == 0){
			$comando = $conexao->prepare("DELETE FROM editora WHERE id_editora = :cod LIMIT 1");

			$comando->bindValue(":cod", $codigo);

			$comando->execute();

			if($comando->rowCount() > 0){
				$msgFinal = "Editora deletada com sucesso";
			}else{
				$msgFinal = "Não foi possivel deletar esta editora, Ocorreu um erro no procedimento";
			}
		}else{
			$msgFinal = "Não foi possivel deletar esta editora, pois ela se encontra cadastrada a um livro";
		}
	}else{
		header("location: cadLivros.php");
	}

	if($msgFinal == "Editora deletada com sucesso"){
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
				<button onclick='deletaMoldal(false)'>OK</button>
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