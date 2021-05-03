<?php

	include_once "conexao.php";
	include_once "Usuario.php";
	include_once "recaptcha.php";
	include_once "codigosRecaptcha.php";
	if(!isset($_SESSION)) session_start();

	$conexao = conexao::getConexao();

	//Configurações sobre o recaptcha

	$chaveSecreta = $codChaveRe;
	$response = null;
    $reCaptcha = new reCaptcha($chaveSecreta);

	if(isset($_POST["rm"]) && isset($_POST["senha"]) && isset($_POST["entrada"]) && isset($_POST['g-recaptcha-response'])){
		$rm = str_ireplace('.', '', str_ireplace('-', '', trim(addslashes($_POST["rm"]))));
		$senha = md5(trim(addslashes($_POST["senha"])));
		$entrada = trim(addslashes($_POST["entrada"]));

		$response = $reCaptcha->verifyResponse($_SERVER['REMOTE_ADDR'], $_POST['g-recaptcha-response']);

		if($response != null && $response->success){
			if($entrada == 0){ //Aluno

				$comando = $conexao->prepare("SELECT a.nome, a.sobrenome, a.img_aluno, a.cpf, u.nivel_acesso, u.senha, u.status_usuario, u.id_usuario FROM usuario AS u INNER JOIN aluno AS a ON a.id_usuario_aluno = u.id_usuario WHERE a.rm_aluno = :rm AND u.senha = :senha LIMIT 1");

				$comando->bindParam(":rm", $rm);

				$comando->bindParam(":senha", $senha);

				$comando->execute();

				$result = $comando->fetchAll();

				if(count($result) > 0){
					if($result[0][6] != "B"){
						//Pegando as instituições do usuário

						$comando = $conexao->prepare("SELECT c.id_instituicao_curso FROM curso AS c INNER JOIN curso_usuario as u ON u.curso_id_curso = c.id_curso WHERE u.usuario_id_usuario = :cod GROUP BY c.id_instituicao_curso");

						$comando->bindParam(":cod", $result[0][7]);

						$comando->execute();

						$instituicoes = [];

						foreach ($comando->fetchAll() as $valor){
							array_push($instituicoes, htmlspecialchars($valor[0]));
						}

						//Instanciando um objeto da classe Usuario e guardando na sessão

						$usuario = new Usuario(htmlspecialchars($rm), htmlspecialchars($result[0][3]), htmlspecialchars($result[0][0]), htmlspecialchars($result[0][1]), base64_encode($result[0][2]), htmlspecialchars($result[0][5]), htmlspecialchars($result[0][4]), $instituicoes, htmlspecialchars($result[0][7]));

						$_SESSION["usuario"] = $usuario;
						$_SESSION["tempo_limite"] = 1800;
						$_SESSION["tempo_atual"] = time();

						header("location: Inicio.php");
					}else{
						$_SESSION["msg"] = "Não é possivel completar o login, pois este usuário está bloqueado pelo sistema!";
						header("location: index.php");
					}
				}else{
					$_SESSION["msg"] = "RM ou senha inválidos!";
					header("location: index.php");
				}
			}else if($entrada == 1){ //Professor

				$comando = $conexao->prepare("SELECT p.nome, p.sobrenome, p.img_professor, p.cpf, u.nivel_acesso, u.senha, u.status_usuario, u.id_usuario FROM usuario AS u INNER JOIN professor AS p ON p.id_usuario_professor = u.id_usuario WHERE p.rm_professor = :rm AND u.senha = :senha LIMIT 1");

				$comando->bindParam(":rm", $rm);

				$comando->bindParam(":senha", $senha);

				$comando->execute();

				$result = $comando->fetchAll();

				if(count($result) > 0){
					if($result[0][6] != "B"){
						//Pegando as instituições do usuário

						$comando = $conexao->prepare("SELECT i.id_instituicao FROM instituicao AS i INNER JOIN instituicao_usuario as iu ON iu.id_instituicao = i.id_instituicao WHERE iu.id_usuario = :cod GROUP BY iu.id_instituicao");

						$comando->bindParam(":cod", $result[0][7]);

						$comando->execute();

						$instituicoes = [];

						foreach ($comando->fetchAll() as $valor){
							array_push($instituicoes, htmlspecialchars($valor[0]));
						}

						//Instanciando um objeto da classe Usuario e guardando na sessão

						$usuario = new Usuario(htmlspecialchars($rm), htmlspecialchars($result[0][3]), htmlspecialchars($result[0][0]), htmlspecialchars($result[0][1]), base64_encode($result[0][2]), htmlspecialchars($result[0][5]), htmlspecialchars($result[0][4]), $instituicoes, htmlspecialchars($result[0][7]));

						$_SESSION["usuario"] = $usuario;
						$_SESSION["tempo_limite"] = 1800;
						$_SESSION["tempo_atual"] = time();

						header("location: Inicio.php");
					}else{
						$_SESSION["msg"] = "Não é possivel completar o login, pois este usuário está bloqueado pelo sistema!";
						header("location: index.php");
					}
				}else{
					$_SESSION["msg"] = "RM ou senha inválidos!";
					header("location: index.php");
				}
			}else{//Funcionário

				$comando = $conexao->prepare("SELECT f.nome, f.sobrenome, f.img_funcionario, f.cpf, u.nivel_acesso, u.senha, u.status_usuario, u.id_usuario FROM usuario AS u INNER JOIN funcionario AS f ON f.id_usuario_funcionario = u.id_usuario WHERE f.cpf = :cpf AND u.senha = :senha LIMIT 1");

				$comando->bindParam(":cpf", $rm);

				$comando->bindParam(":senha", $senha);

				$comando->execute();

				$result = $comando->fetchAll();

				if(count($result) > 0){
					if($result[0][6] != "B"){
						//Pegando as instituições do usuário

						$comando = $conexao->prepare("SELECT i.id_instituicao FROM instituicao AS i INNER JOIN instituicao_usuario as iu ON iu.id_instituicao = i.id_instituicao WHERE iu.id_usuario = :cod GROUP BY iu.id_instituicao");

						$comando->bindParam(":cod", $result[0][7]);

						$comando->execute();

						$instituicoes = [];

						foreach ($comando->fetchAll() as $valor){
							array_push($instituicoes, htmlspecialchars($valor[0]));
						}

						//Instanciando um objeto da classe Usuario e guardando na sessão

						$usuario = new Usuario(null, htmlspecialchars($result[0][3]), htmlspecialchars($result[0][0]), htmlspecialchars($result[0][1]), base64_encode($result[0][2]), htmlspecialchars($result[0][5]), htmlspecialchars($result[0][4]), $instituicoes, htmlspecialchars($result[0][7]));

						$_SESSION["usuario"] = $usuario;
						$_SESSION["tempo_limite"] = 1800;
						$_SESSION["tempo_atual"] = time();

						header("location: Inicio.php");
					}else{
						$_SESSION["msg"] = "Não é possivel completar o login, pois este usuário está bloqueado pelo sistema!";
						header("location: index.php");
					}
				}else{
					$_SESSION["msg"] = "CPF ou senha inválidos!";
					header("location: index.php");
				}
			}
		}else{
			$_SESSION["msg"] = "Recaptcha Inválido";
			header("location: index.php");
		}
	}else{
		header("location: index.php");
	}

?>