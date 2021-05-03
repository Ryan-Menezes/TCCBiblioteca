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

	//Código acima - verificação de login

	$msgFinal = null;

	if(isset($_POST["codC"]) && isset($_POST["senha"])){
		try{
			$codigoC = trim(addslashes($_POST["codC"]));
			$senha = md5(trim(addslashes($_POST["senha"])));

			if($senha == $dadosUsuario->getSenha()){
				$comando = $conexao->prepare("SELECT * FROM curso_usuario WHERE curso_id_curso = :cod LIMIT 1");

				$comando->bindParam(":cod", $codigoC);

				$comando->execute();

				if(count($comando->fetchAll()) == 0){
					
					//Deletando usuario

					$comando = $conexao->prepare("DELETE FROM curso WHERE id_curso = :cod LIMIT 1");

					$comando->bindParam(":cod", $codigoC);

					$comando->execute();

					if($comando->rowCount() > 0){
						$msgFinal = "Turma deletada com sucesso";
					}else{
						$msgFinal = "Turma não deletada, Ocorreu um erro na operação de exclusão";
					}
				}else{
					$msgFinal = "Esta turma está associada há diversos alunos, portanto não é possivel deletá-la!";
				}
				
			}else{
				$msgFinal = "Senha inválida, não foi possivel deletar essa turma";
			}
		}catch(Execption $ex){
			$msgFinal = "Turma não deletada, Ocorreu um erro na operação de exclusão";
		}
	}else{
		header("location: Inicio.php");
	}

	if($msgFinal == "Turma deletada com sucesso"){
		echo "<main>
				<div class='containeAv'>
					<div>
						<h4>$msgFinal</h4>
					</div>
					<div>
						<i class='fas fa-check-circle'></i>
					</div>
				</div>
				<hr>
				<button onclick='deletaMoldal()'>OK</button>
			</main>";
	}else{
		echo "<main>
				<div class='containeAv'>
					<div>
						<h4>$msgFinal</h4>
					</div>
					<div>
						<i class='fas fa-times-circle'></i>
					</div>
				</div>
				<hr>
				<button onclick='deletaMoldal()'>OK</button>
			</main>";
	}
?>