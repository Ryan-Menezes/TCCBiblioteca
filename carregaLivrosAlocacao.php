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

	if(isset($_POST["min"]) && isset($_POST["txt"]) && isset($_POST["idInst"])){
		try{
			$conexao = conexao::getConexao();

			$min = trim(addslashes($_POST["min"]));
			$texto = trim(addslashes($_POST["txt"]));
			$idInst = trim(addslashes($_POST["idInst"]));

			$comando = $conexao->prepare("SELECT e.id_exemplares, l.titulo, l.img_livro, (e.quantidade - (SELECT COUNT(*) FROM locacao AS al WHERE al.id_exemplares = e.id_exemplares)) FROM livro AS l INNER JOIN exemplares AS e ON e.livro_tombo_exemplares = l.cod_livro WHERE titulo LIKE :texto AND tombo IS NOT NULL AND e.id_instituicao = :id AND (e.quantidade - (SELECT COUNT(*) FROM locacao AS al WHERE al.id_exemplares = e.id_exemplares)) > 0 ORDER BY l.titulo LIMIT $min, 10");

			$comando->bindValue(":texto", "%$texto%");
			$comando->bindValue(":id", $idInst);

			$comando->execute();

			$dados = $comando->fetchAll();

			if(count($dados) > 0){
				$dadosLivro = null;

				foreach($dados as $valor){
					$cod = trim(addslashes($valor[0]));
					$titulo = trim(addslashes($valor[1]));
					$img = base64_encode($valor[2]);
					$qtde = trim(addslashes($valor[3]));

					$dadosLivro .= "<tr ondblclick='selecionaLivro($cod, `$titulo`)' class='livrosT'>
										<td><img src='data:image/jpg;base64,$img'></td>
										<td>$titulo</td>
										<td>$qtde</td>
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