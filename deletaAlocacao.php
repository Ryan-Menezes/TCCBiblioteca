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

	if(isset($_POST["codA"]) && isset($_POST["senha"])){
		try{
			$codigoA = trim(addslashes($_POST["codA"]));
			$senha = md5(trim(addslashes($_POST["senha"])));

			if($senha == $dadosUsuario->getSenha()){
				$comando = $conexao->prepare("DELETE FROM locacao WHERE id_locacao = :id LIMIT 1");

				$comando->bindParam(":id", $codigoA);

				$comando->execute();

				if($comando->rowCount() > 0){
					$msgFinal = "Alocação finalizada com sucesso";
				}else{
					$msgFinal = "Alocação não finalizada, Ocorreu um erro na operação para desalocar o livro";
				}
			}else{
				$msgFinal = "Senha inválida, não foi possivel desalocar este livro";
			}
		}catch(Execption $ex){
			$msgFinal = "Alocação não finalizada, Ocorreu um erro na operação para desalocar o livro";
		}
	}else{
		header("location: Inicio.php");
	}

	if($msgFinal == "Alocação finalizada com sucesso"){
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