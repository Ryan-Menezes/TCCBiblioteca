<?php

	include_once "conexao.php";
	include_once "Usuario.php";
	if(!isset($_SESSION)) session_start();

	$conexao = conexao::getConexao();

	if(!isset($_SESSION["usuario"])){
		header("location: index.php");
	}

	$dadosUsuario = $_SESSION["usuario"];

	$nivelAcesso = $dadosUsuario->getNivelAcesso();

	if($nivelAcesso != "A"){
		header("location: index.php");
	}

	if(isset($_POST["cod"]) && isset($_POST["type"])){
		try{
			$cod = trim(addslashes($_POST["cod"]));
			$tipo = trim(addslashes($_POST["type"]));
			$dadoMsg = null;

			if($tipo == "A"){
				$comando = $conexao->prepare("SELECT nome, sobrenome, img_aluno FROM aluno WHERE id_usuario_aluno = :id LIMIT 1");

				$comando->bindParam(":id", $cod);

				$comando->execute();

				$dadoMsg = $comando->fetchAll();
			}else if($tipo == "P"){
				$comando = $conexao->prepare("SELECT nome, sobrenome, img_professor FROM professor WHERE id_usuario_professor = :id LIMIT 1");

				$comando->bindParam(":id", $cod);

				$comando->execute();

				$dadoMsg = $comando->fetchAll();
			}else{
				$comando = $conexao->prepare("SELECT nome, sobrenome, img_funcionario FROM funcionario WHERE id_usuario_funcionario = :id LIMIT 1");

				$comando->bindParam(":id", $cod);

				$comando->execute();

				$dadoMsg = $comando->fetchAll();
			}

			$html = null;

			if(count($dadoMsg) > 0){
				//Alterando situação da mensagem, para visulizado

				$comando = $conexao->prepare("UPDATE avisos SET situacao = 'V' WHERE id_aviso = :idM LIMIT 1");
				
				$comando->bindParam(":idM", $codM);

				$comando->execute();

				//Exibindo-a

				$nome = htmlspecialchars($dadoMsg[0][0]) . " " . htmlspecialchars($dadoMsg[0][1]);
				$img = base64_encode($dadoMsg[0][2]);

				$html .= "<img src='data:image/jpg;base64,$img'>
						  <div>
								<h5>$nome</h5>
						  </div>";
			}
			
			echo $html;

		}catch(Exeption $ex){
			echo null;
		}
	}else{
		header("location: Inicio.php");
	}

?>