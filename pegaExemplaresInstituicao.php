<?php

	include_once "conexao.php";
	include_once "Usuario.php";
	if(!isset($_SESSION)) session_start();

	$conexao = conexao::getConexao();

	if(!isset($_SESSION["usuario"])){
		header("location: index.php");
	}

	//Verificação de login acima

	if(isset($_POST["codI"]) && isset($_POST["codL"])){
		$codI = trim(addslashes($_POST["codI"]));
		$codL = trim(addslashes($_POST["codL"]));

		$comando = $conexao->prepare("SELECT (e.quantidade - (SELECT COUNT(*) FROM locacao AS l WHERE l.id_exemplares = e.id_exemplares)) AS 'exemplares' FROM exemplares AS e WHERE e.livro_tombo_exemplares = :cod AND e.id_instituicao = :codE LIMIT 1");

		$comando->bindParam(":cod", $codL);
		$comando->bindParam(":codE", $codI);

		$comando->execute();

		$dadosExemplares = $comando->fetchAll();

		echo $dadosExemplares[0][0];
	}

?>