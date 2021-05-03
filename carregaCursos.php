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

	if(isset($_POST["min"]) && isset($_POST["txt"]) && isset($_POST['inst'])){
		$conexao = conexao::getConexao();

		$min = addslashes($_POST["min"]);
		$texto = htmlspecialchars(trim(addslashes($_POST["txt"])));
		$instituicao = addslashes($_POST['inst']);

		$comando = $conexao->prepare("SELECT * FROM curso");

		$comando->execute();

		$dados = $comando->fetchAll();

		if(count($dados) > 0){
			$comando = $conexao->prepare("SELECT id_curso, nome_curso, modulo_serie, periodo, turma FROM curso WHERE nome_curso LIKE :txt AND id_instituicao_curso = :ins ORDER BY nome_curso LIMIT $min, 10");

			$comando->bindValue(":txt", "%$texto%");
			$comando->bindParam(":ins", $instituicao);

			$comando->execute();

			$dados = $comando->fetchAll();

			$html = null;

			if(count($dados) > 0){
				foreach($dados as $value) {
					$codigo = htmlspecialchars($value[0]);
					$nome = htmlspecialchars($value[1]);
					$moduloSerie = htmlspecialchars($value[2]);
					$periodo = null;

					if (htmlspecialchars($value[3]) == "M") $periodo = "Manhã";
					else if (htmlspecialchars($value[3]) == "T") $periodo = "Tarde";
					else if (htmlspecialchars($value[3]) == "N") $periodo = "Noite";
					else $periodo = "Integral";

					$turma = htmlspecialchars($value[4]);

					$html .= "<tr ondblclick='selecionaCurso($codigo, `$nome - Módulo/Série: $moduloSerie - Periodo: $periodo - Turma: $turma`)'>
								<td>$nome</td>
								<td>$moduloSerie</td>
								<td>$periodo</td>
								<td>$turma</td>
							</tr>";
				}
			}else{
				$html = "";
			}

			echo $html;
		}else{
			echo "";
		}
	}else{
		header("location: cadAluno.php");
	}

?>