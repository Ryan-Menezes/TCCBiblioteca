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

	if(isset($_POST["titulo"]) && isset($_POST['g-recaptcha-response'])){

		$response = $reCaptcha->verifyResponse($_SERVER['REMOTE_ADDR'], $_POST['g-recaptcha-response']);

		if($response != null && $response->success){
			if($_FILES["imagem"]["size"] < 1048576){
				try{
					$conexao = conexao::getConexao();

					$imagem = file_get_contents($_FILES["imagem"]["tmp_name"]);
					$tombo = (isset($_POST["tombo"])) ? trim(addslashes($_POST["tombo"])) : null;
					$titulo = trim(addslashes($_POST["titulo"]));
					$data = trim(addslashes($_POST["datapublicacao"]));
					$generos = explode(",", trim(addslashes($_POST["generos"])));
					$instituicao = (isset($_POST["instituicao"])) ? trim(addslashes($_POST["instituicao"])) : null;
					$volume = (trim(addslashes($_POST["volume"])) > 0) ? trim(addslashes($_POST["volume"])) : null;
					$edicao = (trim(addslashes($_POST["edicao"])) > 0) ? trim(addslashes($_POST["edicao"])) : null;
					$exemplares = (isset($_POST["exemplares"])) ? trim(addslashes($_POST["exemplares"])) : null;
					$isbn = (isset($_POST["isbn"])) ? trim(addslashes($_POST["isbn"])) : null;
					$idioma = trim(addslashes($_POST["idioma"]));
					$editoras = (isset($_POST["editoras"])) ? explode(",", trim(addslashes($_POST["editoras"]))) : null;
					$autores = explode(",", trim(addslashes($_POST["autores"])));

					$comando = $conexao->prepare("SELECT * FROM livro WHERE tombo = :tombo LIMIT 1");

					$comando->bindParam(":tombo", $tombo);

					$comando->execute();

					$result = $comando->fetchAll();

					if(count($result) == 0){

						$novo_nome = null;

						if(strlen($_FILES["pdf_livro"]["name"]) > 0){
							$diretorio = "PDFS/";
							$extensao = "." . pathinfo($_FILES["pdf_livro"]["name"], PATHINFO_EXTENSION);

							$novo_nome = null;

							do{
								$novo_nome = md5(time().rand(0, 9999).rand(0, 9999)).$extensao;
							}while(file_exists("PDFS/$novo_nome"));

							move_uploaded_file($_FILES["pdf_livro"]["tmp_name"], $diretorio.$novo_nome);
						}

						$comando = $conexao->prepare("INSERT INTO livro (tombo, titulo, ano_publicacao, volume, edicao, insercao, isbn, idioma, img_livro, pdf_livro) VALUES (:tombo, :titulo, :data, :volume, :edicao, CURDATE(), :isbn, :idioma, :img, :pdf)");

						$comando->bindParam(":tombo", $tombo);
						$comando->bindParam(":titulo", $titulo);
						$comando->bindParam(":data", $data);
						$comando->bindParam(":volume", $volume);
						$comando->bindParam(":edicao", $edicao);
						$comando->bindParam(":isbn", $isbn);
						$comando->bindParam(":idioma", $idioma);
						$comando->bindParam(":img", $imagem);
						$comando->bindParam(":pdf", $novo_nome);

						$comando->execute();

						if($comando->rowCount() > 0){
							$cod_livro = $conexao->lastInsertId();

							//Cadastrando os generos do livro

							$comando = $conexao->prepare("INSERT INTO genero_livro (id_genero_tombo, id_livro_tombo) VALUES (:genero, :livro)");

							for($i = 0; $i < count($generos); $i++){
								$comando->bindParam(":genero", $generos[$i]);
								$comando->bindParam(":livro", $cod_livro);

								$comando->execute();
							}

							//cadastrando os autores do livro

							$comando = $conexao->prepare("INSERT INTO autor_livro (id_autor_tombo, id_livro_tombo) VALUES (:autor, :livro)");

							for($i = 0; $i < count($autores); $i++){
								$comando->bindParam(":autor", $autores[$i]);
								$comando->bindParam(":livro", $cod_livro);

								$comando->execute();
							}

							if($tombo != null && $exemplares != null && $isbn != null && $editoras != null){
								//Cadastrando exemplares

								$comando = $conexao->prepare("INSERT INTO exemplares (quantidade, livro_tombo_exemplares, id_instituicao) VALUES (:qtde, :livro, :instituicao)");

								$comando->bindParam(":qtde", $exemplares);
								$comando->bindParam(":livro", $cod_livro);
								$comando->bindValue(":instituicao", $instituicao);

								$comando->execute();

								//Editando editora

								$comando = $conexao->prepare("INSERT INTO editora_livro (id_editora, cod_livro) VALUES (:editora, :livro)");

								for($i = 0; $i < count($editoras); $i++){
									$comando->bindParam(":editora", $editoras[$i]);
									$comando->bindParam(":livro", $cod_livro);

									$comando->execute();
								}
							}

							$msgFinal = "Livro cadastrado com sucesso";
							
						}else{
							$msgFinal = "Não foi possivel finalizar o cadastro, Ocorreu um erro no cadastro!";
						}
					}else{
						$msgFinal = "Já existe um livro cadastrado com este tombo!";
					}
				}catch(PDOException $ex){
					$msgFinal = "Não foi possivel finalizar o cadastro, Ocorreu um erro no cadastro!";
				}
			}else{
				$msgFinal = "A imagem selecionada é muito grande!, selecione outra imagem!";
			}
		}else{
			$msgFinal = "Recaptcha Inválido";
		}
	}else{
		header("location: livros.php");
	}

	if($msgFinal == "Livro cadastrado com sucesso"){
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