<?php

	include_once "Usuario.php";
	session_start();

	unset($_SESSION["usuario"]);
	unset($_SESSION["tempo_limite"]);
	unset($_SESSION["tempo_atual"]);

	header("location: index.php");

?>