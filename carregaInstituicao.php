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

	if(isset($_POST["min"]) && isset($_POST["txt"])){
		$conexao = conexao::getConexao();

		$min = trim(addslashes($_POST["min"]));
		$texto = htmlspecialchars(trim(addslashes($_POST["txt"])));

		$comando = $conexao->prepare("SELECT * FROM instituicao");

		$comando->execute();

		$dados = $comando->fetchAll();

		if(count($dados) > 0){
			$comando = $conexao->prepare("SELECT * FROM instituicao WHERE nome_instituicao LIKE :txt LIMIT $min, 10");

			$comando->bindValue(":txt", "%$texto%");

			$comando->execute();

			$dados = $comando->fetchAll();

			$html = null;

			if(count($dados) > 0){
				foreach($dados as $value) {
					$codigo = htmlspecialchars($value[0]);
					$nome = htmlspecialchars($value[1]);

					$html .= "<tr ondblclick='selecionaInstituicao($codigo, `$nome`)'>
								<td>$nome</td>
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