<?php

	include_once "conexao.php";
	include_once "Usuario.php";
	if(!isset($_SESSION)) session_start();

	$conexao = conexao::getConexao();

	if(!isset($_SESSION["usuario"])){
		header("location: index.php");
	}

	$dados = $_SESSION["usuario"];
	$msgFinal = null;

	if(isset($_POST["senha"]) && isset($_POST["novaSenha"])){
		try{
			$senha = md5(trim(addslashes($_POST["senha"])));
			$novaSenha = md5(htmlspecialchars(trim(addslashes($_POST["novaSenha"]))));
			$usuario = $dados->getCodUsuario();
			$senhaAntiga = $dados->getSenha();

			if($senhaAntiga == $senha){
				if($novaSenha != $senha){
					$comando = $conexao->prepare("UPDATE usuario SET senha = :senha WHERE id_usuario = :id LIMIT 1");

					$comando->bindParam(":senha", $novaSenha);
					$comando->bindParam(":id", $usuario);

					$comando->execute();

					
					$dados->setSenha($novaSenha);
					$msgFinal = "Senha alterada com sucesso";
				}else{
					$msgFinal = "Não foi possivel alterar a senha, Sua nova senha deve ser diferente da atual!";
				}
			}else{
				$msgFinal = "Não foi possivel alterar a senha, pois sua senha atual não é igual a senha digitada!";
			}
		}catch(Exception $ex){
			$msgFinal = "Não foi possivel alterar a senha!, ocorreu um erro na operação";
		}
	}else{
		header("location: dados.php");
	}

	if($msgFinal == "Senha alterada com sucesso"){
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