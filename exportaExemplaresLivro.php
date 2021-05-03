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

	if($nivelAcesso != "A"){
		header("location: index.php");
	}

	//Código acima - verificação de login

	$msgFinal = null;

	//Configurações sobre o recaptcha

	$chaveSecreta = $codChaveRe;
	$response = null;
    $reCaptcha = new reCaptcha($chaveSecreta);

	if(isset($_POST["instituicao"]) && isset($_POST["exemplares"]) && isset($_POST["cod_livro"]) && isset($_POST["cod_exemplar"]) && isset($_POST["exemplaresTot"]) && isset($_POST['g-recaptcha-response'])){

		$response = $reCaptcha->verifyResponse($_SERVER['REMOTE_ADDR'], $_POST['g-recaptcha-response']);

		if($response != null && $response->success){
			try{
				$exemplares = trim(addslashes($_POST["exemplares"]));
				$instituicao = trim(addslashes($_POST["instituicao"]));
				$codLivro = trim(addslashes($_POST["cod_livro"]));
				$codExemplar = trim(addslashes($_POST["cod_exemplar"]));
				$exemplaresTot = trim(addslashes($_POST["exemplaresTot"]));
				$exemplaresRes = $exemplaresTot - $exemplares;

				$comando = $conexao->prepare("SELECT id_exemplares, quantidade FROM exemplares WHERE livro_tombo_exemplares = :livro AND id_instituicao = :id LIMIT 1");

				$comando->bindParam(":livro", $codLivro);
				$comando->bindParam(":id", $instituicao);

				$comando->execute();

				$dadosExemplares = $comando->fetchAll();

				//Descontando valor

				if($exemplaresRes > 0){
					$comando = $conexao->prepare("UPDATE exemplares SET quantidade = :qtde WHERE id_exemplares = :id LIMIT 1");

					$comando->bindParam(":qtde", $exemplaresRes);
					$comando->bindParam(":id", $codExemplar);

					$comando->execute();
				}else{
					$comando = $conexao->prepare("DELETE FROM exemplares WHERE id_exemplares = :id LIMIT 1");

					$comando->bindParam(":id", $codExemplar);

					$comando->execute();
				}

				if(count($dadosExemplares) == 0){

					//Adicionando os exemplares
					
					$comando = $conexao->prepare("INSERT INTO exemplares (quantidade, livro_tombo_exemplares, id_instituicao)  VALUES (:qtde, :livro, :id)");

					$comando->bindParam(":qtde", $exemplares);
					$comando->bindParam(":livro", $codLivro);
					$comando->bindParam(":id", $instituicao);

					$comando->execute();

					if($comando->rowCount() > 0){
						$msgFinal = "Exemplares exportados com sucesso!";
					}else{
						$msgFinal = "Não foi possivel exportar os exemplares, Ocorreu um erro no processo";
					}

				}else{

					//Adicionando os exemplares

					$id = htmlspecialchars($dadosExemplares[0][0]);
					$quantidade = (htmlspecialchars($dadosExemplares[0][1]) + $exemplares);
					
					$comando = $conexao->prepare("UPDATE exemplares SET quantidade = :qtde WHERE id_exemplares = :id LIMIT 1");

					$comando->bindParam(":qtde", $quantidade);
					$comando->bindParam(":id", $id);

					$comando->execute();
				}

				$msgFinal = "Exemplares exportados com sucesso!";
				
			}catch(Exception $ex){
				$msgFinal = "Não foi possivel exportar os exemplares, Ocorreu um erro no processo";
			}
		}else{
			$msgFinal = "Recaptcha Inválido";
		}

		if($msgFinal == "Exemplares exportados com sucesso!"){
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
					<button onclick='deletaMoldal(1)'>OK</button>
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
					<button onclick='deletaMoldal(2)'>OK</button>
				</main>";
		}
	}else{
		header("location: livros.php");
	}

?>