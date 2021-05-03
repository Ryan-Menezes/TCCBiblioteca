<?php

	include_once "conexao.php";
	include_once "Usuario.php";
	
	if(!isset($_SESSION)) session_start();

	$conexao = conexao::getConexao();

	if(!isset($_SESSION["usuario"])){
		header("location: index.php");
	}

	if(isset($_SESSION["tempo_limite"]) && isset($_SESSION["tempo_atual"])){

		$segundos = time() - $_SESSION["tempo_atual"];

		if($segundos > $_SESSION["tempo_limite"]){
			$_SESSION["msg"] = "Seu tempo de sessão expirou!";
			header("location: sair.php");
		}else{
			$_SESSION["tempo_atual"] = time();
		}
	}else{
		$_SESSION["tempo_limite"] = 1800;
		$_SESSION["tempo_atual"] = time();
	}
?>