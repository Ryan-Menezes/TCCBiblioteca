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

		$comando = $conexao->prepare("SELECT * FROM autor");

		$comando->execute();

		$dados = $comando->fetchAll();

		if(count($dados) > 0){
			$comando = $conexao->prepare("SELECT a.id_autor, a.nome_autor, a.nacionalidade, c.cod_colaborador, c.nomes FROM autor AS a INNER JOIN colaboradores AS c ON a.cod_colaborador = c.cod_colaborador WHERE a.nome_autor LIKE :txt ORDER BY a.nome_autor LIMIT $min, 10");

			$comando->bindValue(":txt", "%$texto%");

			$comando->execute();

			$dados = $comando->fetchAll();

			$html = null;

			if(count($dados) > 0){
				foreach($dados as $value) {
					$codigoA = htmlspecialchars($value[0]);
					$nome = htmlspecialchars($value[1]);
					$nacionalidade = htmlspecialchars($value[2]);
					$codigo = htmlspecialchars($value[3]);
					$nomes = htmlspecialchars($value[4]);

					$info = [$nome, $nacionalidade, $nomes, $codigoA, $codigo];
					$info = json_encode($info);

					$html .= "<tr ondblclick='selecionaAutor($codigoA, `$nome`)'>
								<td>$nome</td>
								<td>$nacionalidade</td>
								<td>$nomes</td>
								<td class='opcoesMoldalTable'>
									<i class='fas fa-trash-alt' title='Excluir' onclick='deletaAutor($codigo, $codigoA)'></i>
									<i class='fas fa-pencil-alt' title='Editar' onclick='abreMoldalAutor(2, $info)'></i>
								</td>
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
		header("location: cadLivros.php");
	}

?>