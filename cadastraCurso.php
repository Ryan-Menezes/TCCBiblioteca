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

	if(isset($_POST["nome"]) && isset($_POST["turmas"]) && isset($_POST["periodos"]) && isset($_POST["moduloSeries"]) && isset($_POST["tipo"]) && isset($_POST["instituicao"]) && isset($_POST['g-recaptcha-response'])){
		
		$response = $reCaptcha->verifyResponse($_SERVER['REMOTE_ADDR'], $_POST['g-recaptcha-response']);

		if($response != null && $response->success){
			try{
				$nome = trim(addslashes($_POST["nome"]));
				$turmas = explode(",", trim(addslashes($_POST["turmas"])));
				$periodos = explode(",", trim(addslashes($_POST["periodos"])));
				$moduloSeries = explode(",", trim(addslashes($_POST["moduloSeries"])));
				$tipo = trim(addslashes($_POST["tipo"]));
				$instituicao = trim(addslashes($_POST["instituicao"]));

				for($i = 0; $i < count($turmas); $i++){
					$comando = $conexao->prepare("INSERT INTO curso (nome_curso, modulo_serie, periodo, turma, tipo, id_instituicao_curso) VALUES (:nome, :modulo, :periodo, :turma, :tipo, :id)");

					$comando->bindParam(":nome", $nome);
					$comando->bindParam(":modulo", $moduloSeries[$i]);
					$comando->bindValue(":periodo", $periodos[$i]);
					$comando->bindValue(":turma", $turmas[$i]);
					$comando->bindParam(":tipo", $tipo);
					$comando->bindParam(":id", $instituicao);

					$comando->execute();
				}

				$msgFinal = "Curso cadastrado com sucesso";
					
			}catch(Exception $ex){
				$msgFinal = "Curso não cadastrado, Ocorreu um erro na operação de cadastro!";
			}
		}else{
			$msgFinal = "Recaptcha Inválido";
		}

	}else{
		header("location: cadCurso.php");
	}

	if($msgFinal == "Curso cadastrado com sucesso"){
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
				<button onclick='deletaMoldal(true)'>OK</button>
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
				<button onclick='deletaMoldal(false)'>OK</button>
			</main>";
	}
?>