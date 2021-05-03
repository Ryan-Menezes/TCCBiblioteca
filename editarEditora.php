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

	if(isset($_POST["cod"]) && isset($_POST["nome"]) && isset($_POST["cnpj"])){
		try{
			$conexao = conexao::getConexao();

			$codigo = trim(addslashes($_POST["cod"]));
			$nome = trim(addslashes($_POST["nome"]));
			$cnpj = str_ireplace(".", "", str_ireplace("-", "", str_ireplace("/", "", trim(addslashes($_POST["cnpj"])))));

			$comando = $conexao->prepare("UPDATE editora SET nome_editora = :nome, cnpj = :cnpj WHERE id_editora = :cod LIMIT 1");

			$comando->bindParam(":nome", $nome);
			$comando->bindParam(":cnpj", $cnpj);
			$comando->bindParam(":cod", $codigo);

			$comando->execute();
		
			$msgFinal = "Editora editada com sucesso";
		}catch(PDOException $e){
			$msgFinal = "Não foi possivel editar esta editora, Ocorreu um erro na operação de edição!";
		}
	}else{
		header("location: cadLivros.php");
	}

	if($msgFinal == "Editora editada com sucesso"){
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