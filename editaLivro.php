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

					$imagem = (strlen($_FILES["imagem"]["tmp_name"]) > 0) ? file_get_contents($_FILES["imagem"]["tmp_name"]) : null;
					$tombo = (isset($_POST["tombo"])) ? trim(addslashes($_POST["tombo"])) : null;
					$titulo = trim(addslashes($_POST["titulo"]));
					$data = trim(addslashes($_POST["datapublicacao"]));
					$generos = explode(",", trim(addslashes($_POST["generos"])));
					$volume = (trim(addslashes($_POST["volume"])) > 0) ? trim(addslashes($_POST["volume"])) : null;
					$edicao = (trim(addslashes($_POST["edicao"])) > 0) ? trim(addslashes($_POST["edicao"])) : null;
					$exemplares = (isset($_POST["exemplares"])) ? trim(addslashes($_POST["exemplares"])) : null;
					$isbn = (isset($_POST["isbn"])) ? trim(addslashes($_POST["isbn"])) : null;
					$idioma = trim(addslashes($_POST["idioma"]));
					$editoras = (isset($_POST["editoras"])) ? explode(",", trim(addslashes($_POST["editoras"]))) : null;
					$autores = explode(",", trim(addslashes($_POST["autores"])));

					$codLivro = trim(addslashes($_POST["cod_livro"]));
					$codExemplar = (isset($_POST["cod_exemplar"] )) ? trim(addslashes($_POST["cod_exemplar"])) : null;
					$pdfOriginal = trim(addslashes($_POST["pdfOriginal"]));
					$pdfUrl = trim(addslashes($_POST["pdf_url"]));
					$tomboOriginal = (isset($_POST["tomboOriginal"] )) ? trim(addslashes($_POST["tomboOriginal"])) : null;

					$result = 0;

					if($tombo != null){
						$comando = $conexao->prepare("SELECT * FROM livro WHERE tombo = :tombo");

						$comando->bindParam(":tombo", $tombo);

						$comando->execute();

						$result = $comando->fetchAll();
					}

					if(count($result) == 0 || ($tombo == $tomboOriginal)){

						$novo_nome = $pdfUrl;

						if(strlen($_FILES["pdf_livro"]["name"]) > 0){
							//Deletando arquivo antigo

							if(strlen($pdfOriginal) > 0){
								unlink("./PDFS/$pdfOriginal");
							}

							//Adicionando novo

							$diretorio = "PDFS/";
							$extensao = "." . pathinfo($_FILES["pdf_livro"]["name"], PATHINFO_EXTENSION);
							$novo_nome = md5(time().rand(0, 9999).rand(0, 9999)).$extensao;

							move_uploaded_file($_FILES["pdf_livro"]["tmp_name"], $diretorio.$novo_nome);
						}else if(strlen($_FILES["pdf_livro"]["name"]) == 0 && strlen($pdfUrl) == 0){
							if(strlen($pdfOriginal) > 0){
								unlink("./PDFS/$pdfOriginal");
							}

							$novo_nome = null;
						}

						if($imagem != null){
							$comando = $conexao->prepare("UPDATE livro SET tombo = :tombo, titulo = :titulo, ano_publicacao = :data, volume = :volume, edicao = :edicao, isbn = :isbn, idioma = :idioma, img_livro = :img, pdf_livro = :pdf WHERE cod_livro = :cod LIMIT 1");

							$comando->bindParam(":tombo", $tombo);
							$comando->bindParam(":titulo", $titulo);
							$comando->bindParam(":data", $data);
							$comando->bindParam(":volume", $volume);
							$comando->bindParam(":edicao", $edicao);
							$comando->bindParam(":isbn", $isbn);
							$comando->bindParam(":idioma", $idioma);
							$comando->bindParam(":img", $imagem);
							$comando->bindParam(":pdf", $novo_nome);
							$comando->bindParam(":cod", $codLivro);

							$comando->execute();
						}else{
							$comando = $conexao->prepare("UPDATE livro SET tombo = :tombo, titulo = :titulo, ano_publicacao = :data, volume = :volume, edicao = :edicao, isbn = :isbn, idioma = :idioma, pdf_livro = :pdf WHERE cod_livro = :cod LIMIT 1");

							$comando->bindParam(":tombo", $tombo);
							$comando->bindParam(":titulo", $titulo);
							$comando->bindParam(":data", $data);
							$comando->bindParam(":volume", $volume);
							$comando->bindParam(":edicao", $edicao);
							$comando->bindParam(":isbn", $isbn);
							$comando->bindParam(":idioma", $idioma);
							$comando->bindParam(":pdf", $novo_nome);
							$comando->bindParam(":cod", $codLivro);

							$comando->execute();
						}

						//Deletando editoras, autores e generos

						$comando = $conexao->prepare("DELETE FROM genero_livro WHERE id_livro_tombo = :id");

						$comando->bindParam(":id", $codLivro);

						$comando->execute();

						//Editora

						$comando = $conexao->prepare("DELETE FROM editora_livro WHERE cod_livro = :id");

						$comando->bindParam(":id", $codLivro);

						$comando->execute();

						//Autor

						$comando = $conexao->prepare("DELETE FROM autor_livro WHERE id_livro_tombo = :id");

						$comando->bindParam(":id", $codLivro);

						$comando->execute();

						//Editando os generos do livro

						$comando = $conexao->prepare("INSERT INTO genero_livro (id_genero_tombo, id_livro_tombo) VALUES (:genero, :livro)");

						for($i = 0; $i < count($generos); $i++){
							$comando->bindParam(":genero", $generos[$i]);
							$comando->bindParam(":livro", $codLivro);

							$comando->execute();
						}

						//Editando os autores do livro

						$comando = $conexao->prepare("INSERT INTO autor_livro (id_autor_tombo, id_livro_tombo) VALUES (:autor, :livro)");

						for($i = 0; $i < count($autores); $i++){
							$comando->bindParam(":autor", $autores[$i]);
							$comando->bindParam(":livro", $codLivro);

							$comando->execute();
						}

						if($tombo != null && $exemplares != null && $isbn != null && $editoras != null){
							//Editando exemplares

							$comando = $conexao->prepare("UPDATE exemplares SET quantidade = :qtde WHERE id_exemplares = :id LIMIT 1");

							$comando->bindParam(":qtde", $exemplares);
							$comando->bindParam(":id", $codExemplar);

							$comando->execute();

							//Editando editora

							$comando = $conexao->prepare("INSERT INTO editora_livro (id_editora, cod_livro) VALUES (:editora, :livro)");

							for($i = 0; $i < count($editoras); $i++){
								$comando->bindParam(":editora", $editoras[$i]);
								$comando->bindParam(":livro", $codLivro);

								$comando->execute();
							}
						}

						$msgFinal = "Livro editado com sucesso";
							
					}else{
						$msgFinal = "Já existe um livro cadastrado com este tombo!";
					}
				}catch(PDOException $ex){
					$msgFinal = "Não foi possivel finalizar a edição, Ocorreu um erro na edição!";
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

	if($msgFinal == "Livro editado com sucesso"){
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