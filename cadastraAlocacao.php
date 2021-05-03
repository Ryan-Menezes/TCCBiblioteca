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

	if(isset($_POST["rmCpf"]) && isset($_POST['g-recaptcha-response'])){

		$response = $reCaptcha->verifyResponse($_SERVER['REMOTE_ADDR'], $_POST['g-recaptcha-response']);

		if($response != null && $response->success){
			try{
				$dataAlocacao = (strlen(trim(addslashes($_POST["dataAlocacao"]))) == 10) ? trim(addslashes($_POST["dataAlocacao"])) : date("Y-m-d");
				$dataDevolucao = (strlen(trim(addslashes($_POST["dataDevolucao"]))) == 10) ? trim(addslashes($_POST["dataDevolucao"])) : date("Y-m-d", strtotime("+7 day", strtotime($dataAlocacao)));
				$tipo = trim(addslashes($_POST["tipoUser"]));
				$rmCpf = trim(addslashes($_POST["rmCpf"]));
				$livros = explode(",", trim(addslashes($_POST["livros"])));

				$rmCpf = str_ireplace('.', '', $rmCpf);
				$rmCpf = str_ireplace('-', '', $rmCpf);
					
				//Verificando RM

				$result = null;

				if($tipo == "A"){
					$comando = $conexao->prepare("SELECT u.id_usuario FROM usuario AS u LEFT JOIN aluno AS a ON a.id_usuario_aluno = u.id_usuario WHERE a.rm_aluno = :rm LIMIT 1");

					$comando->bindParam(":rm", $rmCpf);

					$comando->execute();

					$result = $comando->fetchAll();
				}else if($tipo == "P"){
					$comando = $conexao->prepare("SELECT u.id_usuario FROM usuario AS u LEFT JOIN professor AS p ON p.id_usuario_professor = u.id_usuario WHERE p.rm_professor = :rm LIMIT 1");

					$comando->bindParam(":rm", $rmCpf);

					$comando->execute();

					$result = $comando->fetchAll();
				}else{
					$comando = $conexao->prepare("SELECT u.id_usuario FROM usuario AS u INNER JOIN funcionario AS f ON f.id_usuario_funcionario = u.id_usuario WHERE f.cpf = :cpf LIMIT 1");

					$comando->bindParam(":cpf", $rmCpf);

					$comando->execute();

					$result = $comando->fetchAll();
				}

				if(count($result) > 0){
					$cod_usuario = htmlspecialchars($result[0][0]);

					foreach($livros as $cod){
						//Verificando exemplares do livro

						$comando = $conexao->prepare("SELECT * FROM livro AS l INNER JOIN exemplares AS e ON e.livro_tombo_exemplares = l.cod_livro WHERE e.id_exemplares = :id AND (e.quantidade - (SELECT COUNT(*) FROM locacao AS al WHERE al.id_exemplares = e.id_exemplares)) > 0 LIMIT 1");

						$comando->bindParam(":id", $cod);

						$comando->execute();

						if(count($comando->fetchAll()) > 0){
							$comando = $conexao->prepare("INSERT INTO locacao (data_locacao, data_devolucao, notificado, id_usuario_locacao, id_usuarioAdimin_locacao, id_exemplares) VALUES (:dataL, :dataD, FALSE, :usuario, :admin, :exemplar)");

							$comando->bindParam(":dataL", $dataAlocacao);
							$comando->bindParam(":dataD", $dataDevolucao);
							$comando->bindParam(":usuario", $cod_usuario);
							$comando->bindValue(":admin", $dados->getCodUsuario());
							$comando->bindParam(":exemplar", $cod);

							$comando->execute();
						}
					}

					$msgFinal = "Livro(s) alocado(s) com sucesso!";
				}else{
					if($tipo == "A"){
						$msgFinal = "Não foi possivel localizar nenhum aluno com este RM";
					}else if($tipo == "P"){
						$msgFinal = "Não foi possivel localizar nenhum professor com este RM";
					}else{
						$msgFinal = "Não foi possivel localizar nenhum funcionário com este CPF";
					}
				}
			}catch(PDOException $ex){
				$msgFinal = "Não foi possivel alocar este(s) livro(s), Ocorreu um erro na operação de alocar!";
			}
		}else{
			$msgFinal = "Recaptcha Inválido";
		}

	}else{
		header("location: cadAlocacao.php");
	}

	if($msgFinal == "Livro(s) alocado(s) com sucesso!"){
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