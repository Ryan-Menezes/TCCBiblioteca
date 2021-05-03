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

	if(isset($_POST["nome"]) && isset($_POST["nacio"]) && isset($_POST["cola"])){
		try{
			$conexao = conexao::getConexao();

			$nome = trim(addslashes($_POST["nome"]));
			$nacionalidade = trim(addslashes($_POST["nacio"]));
			$colaboradores = trim(addslashes($_POST["cola"]));

			$comando = $conexao->prepare("INSERT INTO colaboradores (nomes) VALUES (:nomes)");

			$comando->bindParam(":nomes", $colaboradores);

			$comando->execute();

			if($comando->rowCount() > 0){
				$cod_colaborador = $conexao->lastInsertId();

				//Finalizando cadastro

				$comando = $conexao->prepare("INSERT INTO autor (nome_autor, nacionalidade, cod_colaborador) VALUES (:nome, :nacio, :cod)");

				$comando->bindParam(":nome", $nome);
				$comando->bindParam(":nacio", $nacionalidade);
				$comando->bindParam(":cod", $cod_colaborador);

				$comando->execute();

				if($comando->rowCount() > 0){
					$msgFinal = "Autor cadastrado com sucesso";
				}
			}else{
				$msgFinal = "Não foi possivel cadastrar este autor, Ocorreu um erro na operação de cadastro!";
			}
		}catch(PDOException $e){
			$msgFinal = "Não foi possivel cadastrar este autor, Ocorreu um erro na operação de cadastro!";
		}
	}else{
		header("location: cadLivros.php");
	}

	if($msgFinal == "Autor cadastrado com sucesso"){
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