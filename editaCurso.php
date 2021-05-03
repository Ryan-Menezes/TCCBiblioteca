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

	if(isset($_POST["nome"]) && isset($_POST["turma"]) && isset($_POST["periodo"]) && isset($_POST["moduloSerie"]) && isset($_POST["tipo"]) && isset($_POST["instituicao"]) && isset($_POST["codCurso"]) && isset($_POST['g-recaptcha-response'])){

		$response = $reCaptcha->verifyResponse($_SERVER['REMOTE_ADDR'], $_POST['g-recaptcha-response']);

		if($response != null && $response->success){
			try{
				$nome = trim(addslashes($_POST["nome"]));
				$turma = strtoupper(trim(addslashes($_POST["turma"])));
				$periodo = trim(addslashes($_POST["periodo"]));
				$moduloSerie = trim(addslashes($_POST["moduloSerie"]));
				$tipo = trim(addslashes($_POST["tipo"]));
				$instituicao = trim(addslashes($_POST["instituicao"]));
				$idCurso = trim(addslashes($_POST["codCurso"]));

				$comando = $conexao->prepare("UPDATE curso SET nome_curso = :nome, modulo_serie = :modulo, periodo = :periodo, turma = :turma, tipo = :tipo, id_instituicao_curso = :id WHERE id_curso = :idCurso LIMIT 1");

				$comando->bindParam(":nome", $nome);
				$comando->bindParam(":modulo", $moduloSerie);
				$comando->bindParam(":periodo", $periodo);
				$comando->bindParam(":turma", $turma);
				$comando->bindParam(":tipo", $tipo);
				$comando->bindParam(":id", $instituicao);
				$comando->bindParam(":idCurso", $idCurso);

				$comando->execute();

				$msgFinal = "Turma editada com sucesso";
					
			}catch(Exception $ex){
				$msgFinal = "Turma não editada, Ocorreu um erro na operação de edição!";
			}
		}else{
			$msgFinal = "Recaptcha Inválido";
		}

	}else{
		header("location: cadCurso.php");
	}

	if($msgFinal == "Turma editada com sucesso"){
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