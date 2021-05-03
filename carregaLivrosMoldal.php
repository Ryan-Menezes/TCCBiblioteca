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
		try{
			$conexao = conexao::getConexao();

			$min = addslashes($_POST["min"]);
			$texto = addslashes($_POST["txt"]);

			$comando = $conexao->prepare("SELECT cod_livro, tombo, titulo, img_livro FROM livro WHERE titulo LIKE :texto ORDER BY titulo LIMIT $min, 10");

			$comando->bindValue(":texto", "%$texto%");

			$comando->execute();

			$dados = $comando->fetchAll();

			if(count($dados) > 0){
				$dadosLivro = null;

				foreach($dados as $valor){
					$cod = trim(addslashes($valor[0]));
					$tombo = trim(addslashes($valor[1]));
					$titulo = trim(addslashes($valor[2]));
					$img = base64_encode($valor[3]);

					$dadosLivro .= "<tr ondblclick='selecionaLivro($cod, `$titulo`, `$tombo`)' class='livrosT'>
										<td><img src='data:image/jpg;base64,$img'></td>
										<td>$titulo</td>
									</tr>";
				}

				echo $dadosLivro;
			}else{
				echo "";
			}
		}catch(Exception $ex){
			echo "";
		}
	}else{
		header("location: cadAluno.php");
	}

?>