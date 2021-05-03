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

		//Pegando o codigo do autor

		$comando = $conexao->prepare("SELECT id_autor FROM autor WHERE cod_colaborador = :cod LIMIT 1");

		$comando->bindValue(":cod", $codigo);

		$comando->execute();

		$dados = $comando->fetchAll();

		$cod_autor = null;

		foreach ($dados as $valor) {
			$cod_autor = $valor[0];
		}

		//Pesquisando autor nos livros

		$comando = $conexao->prepare("SELECT * FROM autor_livro WHERE id_autor_tombo = :cod LIMIT 1");

		$comando->bindParam(":cod", $cod_autor);

		$comando->execute();

		$dados = $comando->fetchAll();

		if(count($dados) == 0){
			$codigo = addslashes($_POST["cod"]);

			$comando = $conexao->prepare("DELETE FROM colaboradores WHERE cod_colaborador = :cod LIMIT 1");

			$comando->bindParam(":cod", $codigo);

			$comando->execute();

			if($comando->rowCount() > 0){
				$msgFinal = "Autor deletado com sucesso";
			}else{
				$msgFinal = "Não foi possivel deletar este autor, Ocorreu um erro no procedimento";
			}
		}else{
			$msgFinal = "Não foi possivel deletar este autor, pois ele se encontra cadastrado a um livro";
		}
	}else{
		header("location: cadLivros.php");
	}

	if($msgFinal == "Autor deletado com sucesso"){
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