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

	if(isset($_POST["livroCodigo"]) && isset($_POST['g-recaptcha-response'])){
		$response = $reCaptcha->verifyResponse($_SERVER['REMOTE_ADDR'], $_POST['g-recaptcha-response']);

		if($response != null && $response->success){
			try{
				$codLivro = trim(addslashes($_POST["livroCodigo"]));
				$exemplares = trim(addslashes($_POST["exemplares"]));
				$instituicao = trim(addslashes($_POST["instituicao"]));
				$tombo = (strlen(trim(addslashes($_POST["tombo"]))) > 0) ? trim(addslashes($_POST["tombo"])) : null;
				$isbn = (strlen(trim(addslashes($_POST["isbn"]))) > 0) ? trim(addslashes($_POST["isbn"])) : null;
				$editoras = (isset($_POST["editoras"])) ? explode(",", trim(addslashes($_POST["editoras"]))) : null;

				$comando = $conexao->prepare("SELECT * FROM exemplares WHERE livro_tombo_exemplares = :livro AND id_instituicao = :id LIMIT 1");

				$comando->bindParam(":livro", $codLivro);
				$comando->bindParam(":id", $instituicao);

				$comando->execute();

				$dados = $comando->fetchAll();

				//Verificando tombo

				$tomboExiste = true;

				if($tombo != null && $isbn != null){
					$comando = $conexao->prepare("SELECT * FROM livro WHERE tombo = :tombo LIMIT 1");

					$comando->bindParam(":tombo", $tombo);

					$comando->execute();

					$tomboExiste = (count($comando->fetchAll()) > 0) ? false : true;
				}

				if(count($dados) == 0 && $tomboExiste){

					if($editoras != null){

						//Cadastrando editora

						for($i = 0; $i < count($editoras); $i++){
							//Procurando editora

							$comando = $conexao->prepare("SELECT * FROM editora_livro WHERE id_editora = :id AND cod_livro = :livro LIMIT 1");

							$comando->bindParam(":id", $editoras[$i]);
							$comando->bindParam(":livro", $codLivro);

							$comando->execute();

							//Inserindo a editora

							if(count($comando->fetchAll()) == 0){
								$comando = $conexao->prepare("INSERT INTO editora_livro (id_editora, cod_livro) VALUES (:editora, :livro)");
								
								$comando->bindParam(":editora", $editoras[$i]);
								$comando->bindParam(":livro", $codLivro);

								$comando->execute();
							}
						}
					}

					//Atualizando tombo, caso seja preciso

					if($tombo != null && $isbn != null){
						$comando = $conexao->prepare("UPDATE livro SET tombo = :tombo, isbn = :isbn WHERE cod_livro = :livro LIMIT 1");

						$comando->bindParam(":tombo", $tombo);
						$comando->bindParam(":isbn", $isbn);
						$comando->bindParam(":livro", $codLivro);

						$comando->execute();
					}

					//Adicionando os exemplares
					
					$comando = $conexao->prepare("INSERT INTO exemplares (quantidade, livro_tombo_exemplares, id_instituicao)  VALUES (:qtde, :livro, :id)");

					$comando->bindParam(":qtde", $exemplares);
					$comando->bindParam(":livro", $codLivro);
					$comando->bindParam(":id", $instituicao);

					$comando->execute();

					if($comando->rowCount() > 0){
						$msgFinal = "Exemplares adicionados com sucesso!";
					}else{
						$msgFinal = "Não foi possivel adicionar os exemplares, Ocorreu um erro no processo";
					}

				}else{
					if(!$tomboExiste){
						$msgFinal = "Já existe um livro cadastrado com este tombo!";
					}else{
						$msgFinal = "Este livro já está cadastrado nessa instituição!";
					}
				}
				
			}catch(Exception $ex){
				$msgFinal = "Não foi possivel adicionar os exemplares, Ocorreu um erro no processo";
			}
		}else{
			$msgFinal = "Recaptcha Inválido";
		}

		if($msgFinal == "Exemplares adicionados com sucesso!"){
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
	}else{
		header("location: cadAluno.php");
	}

?>