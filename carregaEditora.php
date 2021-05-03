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

	//Função que coloca maskara nos inputs

	function Mask($mask, $str){
	    $str = str_ireplace(" ", "", $str);

	    for($i = 0; $i < strlen($str); $i++){
	        $mask[strpos($mask,"#")] = $str[$i];
	    }

	    return $mask;
	}

	//Código acima - verificação de login

	if(isset($_POST["min"]) && isset($_POST["txt"])){
		$conexao = conexao::getConexao();

		$min = trim(addslashes($_POST["min"]));
		$texto = htmlspecialchars(trim(addslashes($_POST["txt"])));

		$comando = $conexao->prepare("SELECT * FROM editora");

		$comando->execute();

		$dados = $comando->fetchAll();

		if(count($dados) > 0){
			$comando = $conexao->prepare("SELECT * FROM editora WHERE nome_editora LIKE :txt ORDER BY nome_editora LIMIT $min, 10");

			$comando->bindValue(":txt", "%$texto%");

			$comando->execute();

			$dados = $comando->fetchAll();

			$html = null;

			if(count($dados) > 0){
				foreach($dados as $value) {
					$codigo = htmlspecialchars($value[0]);
					$nome = htmlspecialchars($value[1]);
					$cnpj = htmlspecialchars($value[2]);

					$info = [$nome, $cnpj, $codigo];
					$info = json_encode($info);

					$cnpj = (strlen($cnpj) > 0) ? Mask("##.###.###/####-##", $cnpj) : "";

					$html .= "<tr ondblclick='selecionaEditora($codigo, `$nome`)'>
								<td>$nome</td>
								<td>$cnpj</td>
								<td class='opcoesMoldalTable'>
									<i class='fas fa-trash-alt' title='Excluir' onclick='deletaEditora($codigo)'></i>
									<i class='fas fa-pencil-alt' title='Editar' onclick='abreMoldalEditora(2, $info)'></i>
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