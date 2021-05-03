<?php

	include_once "conexao.php";
	include_once "Usuario.php";
	include_once "recaptcha.php";
	include_once "codigosRecaptcha.php";
	if(!isset($_SESSION)) session_start();

	$conexao = conexao::getConexao();

	if(!isset($_SESSION["usuario"])){
		header("location: index.php");
	}

	$dados = $_SESSION["usuario"];

	$nivelAcesso = $dados->getNivelAcesso();
	$codUserLogado = $dados->getCodUsuario();

	if($nivelAcesso != "A"){
		header("location: index.php");
	}

	//Código acima - verificação de login
	
	$msgFinal = null;

	//Configurações sobre o recaptcha

	$chaveSecreta = $codChaveRe;
	$response = null;
    $reCaptcha = new reCaptcha($chaveSecreta);

	//Verificações para cadastro

	if(isset($_POST["dataDevolucao"]) && isset($_POST["codA"]) && isset($_POST['g-recaptcha-response'])){

		$response = $reCaptcha->verifyResponse($_SERVER['REMOTE_ADDR'], $_POST['g-recaptcha-response']);

		if($response != null && $response->success){
			try{
				$dataDevolucao = trim(addslashes($_POST["dataDevolucao"]));

				$codigoA = trim(addslashes($_POST["codA"]));
				
				$comando = $conexao->prepare("UPDATE locacao SET data_devolucao = :data, notificado = FALSE WHERE id_locacao = :id LIMIT 1");

				$comando->bindParam(":data", $dataDevolucao);
				$comando->bindParam(":id", $codigoA);

				$comando->execute();

				$msgFinal = "Alocação editada com sucessso";

			}catch(PDOException $ex){
				$msgFinal = "Não foi possivel editar esta alocação, Ocorreu um erro na operação de edição";
			}
		}else{
			$msgFinal = "Recaptcha Inválido";
		}
		
	}else{
		header("location: cadAluno.php");
	}

	if($msgFinal == "Alocação editada com sucessso"){
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