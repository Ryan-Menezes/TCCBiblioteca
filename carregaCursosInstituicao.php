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

	if(isset($_POST["cod"])){
		$conexao = conexao::getConexao();

		$cod = trim(addslashes($_POST["cod"]));

		try{
			$cursos = "<option value='T' selected>Todos</option>";

			//Pegando cursos

			$comando = $conexao->prepare("SELECT * FROM curso WHERE id_instituicao_curso = $cod ORDER BY nome_curso");

			$comando->execute();

			$dados = $comando->fetchAll();

			foreach($dados as $valor){
				$codigo = htmlspecialchars($valor[0]);
				$nome = htmlspecialchars($valor[1]);
				$moduloSerie = htmlspecialchars($valor[2]);
				$turma = htmlspecialchars($valor[4]);

				$cursos .= "<option value='$codigo'>$nome - $moduloSerie º Módulo/Série $turma</option>";
			}

			echo $cursos;
		}catch(Exception $ex){
			echo "<option value='T' selected>Todos</option>";
		}
	}else{
		header("location: alunos.php");
	}

?>