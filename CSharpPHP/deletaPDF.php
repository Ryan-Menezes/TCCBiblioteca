<?php

	include_once "../conexao.php";

	if(isset($_POST["arquivo"])){

		$arquivo = trim(addslashes($_POST["arquivo"]));

		$conexao = conexao::getConexao();

		$comando = $conexao->prepare("SELECT * FROM livro WHERE pdf_livro = :arquivo LIMIT 1");
		$comando->bindParam(":arquivo", $arquivo);
		$comando->execute();

		if(count($comando->fetchAll()) == 0 || isset($_POST["code"])){
			if(file_exists("../PDFS/$arquivo")){
				unlink("../PDFS/$arquivo");
			}
		}

	}else{
		header("location: ../index.php");
	}

?>