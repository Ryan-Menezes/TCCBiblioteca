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

	if(isset($_POST["cod"]) && isset($_POST["codC"]) && isset($_POST["nome"]) && isset($_POST["nacio"]) && isset($_POST["cola"])){
		try{
			$conexao = conexao::getConexao();

			$codigo = trim(addslashes($_POST["cod"]));
			$codigoC = trim(addslashes($_POST["codC"]));
			$nome = trim(addslashes($_POST["nome"]));
			$nacionalidade = trim(addslashes($_POST["nacio"]));
			$colaboradores = trim(addslashes($_POST["cola"]));

			//Editando colaborador

			$comandoC = $conexao->prepare("UPDATE colaboradores SET nomes = :cola WHERE cod_colaborador = :codc LIMIT 1");

			$comandoC->bindParam(":cola", $colaboradores);
			$comandoC->bindParam(":codc", $codigoC);

			$comandoC->execute();

			//Editando autor

			$comando = $conexao->prepare("UPDATE autor SET nome_autor = :nome, nacionalidade = :nacio WHERE id_autor = :cod LIMIT 1");

			$comando->bindParam(":nome", $nome);
			$comando->bindParam(":nacio", $nacionalidade);
			$comando->bindParam(":cod", $codigo);

			$comando->execute();

			
			$msgFinal = "Autor editado com sucesso";
			
		}catch(PDOException $e){
			$msgFinal = "Não foi possivel editar este autor, Ocorreu um erro na operação de edição ou você não alterou nenhum dado para edição!";
		}
	}else{
		header("location: cadLivros.php");
	}

	if($msgFinal == "Autor editado com sucesso"){
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