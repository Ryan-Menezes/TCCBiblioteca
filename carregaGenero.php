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

	if(isset($_POST["min"])){
		$conexao = conexao::getConexao();

		$min = addslashes($_POST["min"]);

		$comando = $conexao->prepare("SELECT * FROM genero ORDER BY nome_genero LIMIT $min, 10");

		$comando->execute();

		$dados = $comando->fetchAll();

		$html = null;

		foreach($dados as $value) {
			$codigo = htmlspecialchars($value[0]);
			$nome = htmlspecialchars($value[1]);

			$html .= "<tr ondblclick='selecionaGenero($codigo, `$nome`)'><td>$nome</td></tr>";
		}

		echo $html;
	}else{
		header("location: cadLivros.php");
	}

?>