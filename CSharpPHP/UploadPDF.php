<?php

	include_once "../conexao.php";

	if(isset($_FILES["file"]) && isset($_GET["a"]) && isset($_GET["cod"])){

		$arquivo = trim(addslashes($_GET["a"]));
		$codigo = trim(addslashes($_GET["cod"]));

		$conexao = conexao::getConexao();

		$comando = $conexao->prepare("SELECT * FROM livro WHERE cod_livro = :cod LIMIT 1");
		$comando->bindParam(":cod", $codigo);
		$comando->execute();

		if(count($comando->fetchAll()) > 0){
			if(!file_exists("../PDFS/$arquivo")){
				move_uploaded_file($_FILES["file"]["tmp_name"], "../PDFS/$arquivo");
			}
		}

	}else{
		header("location: ../index.php");
	}

?>