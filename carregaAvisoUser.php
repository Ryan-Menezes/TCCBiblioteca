<?php

	include_once "conexao.php";
	include_once "Usuario.php";
	if(!isset($_SESSION)) session_start();

	$conexao = conexao::getConexao();

	if(!isset($_SESSION["usuario"])){
		header("location: index.php");
	}

	$dados = $_SESSION["usuario"];

	if(isset($_POST["cod"])){
		try{
			$codM = trim(addslashes($_POST["cod"]));
			$cod = $dados->getCodUsuario();
			$dadoMsg = null;

			$comando = $conexao->prepare("SELECT a.titulo, a.mensagem, a.data_envio, p.nome, p.sobrenome, p.img_professor FROM avisos AS a INNER JOIN professor AS p ON p.id_usuario_professor = a.id_usuarioRemetente_avisos WHERE a.id_usuario_avisos = :idU AND a.id_aviso = :idM LIMIT 1");

			$comando->bindParam(":idU", $cod);
			$comando->bindParam(":idM", $codM);

			$comando->execute();

			$dadoMsg = $comando->fetchAll();

			if(count($dadoMsg) == 0){

				$comando = $conexao->prepare("SELECT a.titulo, a.mensagem, a.data_envio, al.nome, al.sobrenome, al.img_aluno FROM avisos AS a INNER JOIN aluno AS al ON al.id_usuario_aluno = a.id_usuarioRemetente_avisos WHERE a.id_usuario_avisos = :idU AND a.id_aviso = :idM LIMIT 1");

				$comando->bindParam(":idU", $cod);
				$comando->bindParam(":idM", $codM);

				$comando->execute();

				$dadoMsg = $comando->fetchAll();

				if(count($dadoMsg) == 0){
					$comando = $conexao->prepare("SELECT a.titulo, a.mensagem, a.data_envio, f.nome, f.sobrenome, f.img_funcionario FROM avisos AS a INNER JOIN funcionario AS f ON f.id_usuario_funcionario = a.id_usuarioRemetente_avisos WHERE a.id_usuario_avisos = :idU AND a.id_aviso = :idM LIMIT 1");

					$comando->bindParam(":idU", $cod);
					$comando->bindParam(":idM", $codM);

					$comando->execute();

					$dadoMsg = $comando->fetchAll();
				}
			}

			$html = null;

			if(count($dadoMsg) > 0){
				//Alterando situação da mensagem, para visulizado

				$comando = $conexao->prepare("UPDATE avisos SET situacao = 'V' WHERE id_aviso = :idM LIMIT 1");
				
				$comando->bindParam(":idM", $codM);

				$comando->execute();

				//Exibindo-a

				$titulo = htmlspecialchars($dadoMsg[0][0]);
				$msg = htmlspecialchars($dadoMsg[0][1]);
				$data = explode("-", htmlspecialchars($dadoMsg[0][2]));
				$data = $data[2] . "/" . $data[1] . "/" . $data[0];
				$nome = htmlspecialchars($dadoMsg[0][3]) . " " . htmlspecialchars($dadoMsg[0][4]);
				$img = base64_encode($dadoMsg[0][5]);

				$html .= "<main>
							<div class='dadosRemetente'>
								<img src='data:image/jpg;base64,$img'>
								<div>
									<h5>$nome - $data</h5>
								</div>
							</div>
							<br><hr><br>
							<h4>$titulo</h4>
							<br>
							<form action='javascript: void(0)''>
								<textarea readonly>$msg</textarea>
							</form>
						</main>";
			}
			
			echo $html;

		}catch(Exeption $ex){
			echo null;
		}
	}else{
		header("location: Inicio.php");
	}

?>