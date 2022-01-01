<?php
	include_once "conexao.php";
	include_once "Usuario.php";
	include_once "codigosRecaptcha.php";
	include_once "dadosSistema.php";
	include_once "verificaTempoSessao.php";

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

	//Buscando dados do livro

	if(isset($_GET["codL"])){
		try{
			$codL = trim(addslashes($_GET["codL"]));
			$autores = null;
			$generos = null;

			$comando = $conexao->prepare("SELECT l.tombo, l.titulo, l.ano_publicacao, l.volume, l.edicao, l.isbn, l.idioma, l.img_livro, l.pdf_livro FROM livro AS l WHERE l.cod_livro = :codL AND l.tombo IS NULL LIMIT 1");

			$comando->bindParam(":codL", $codL);

			$comando->execute();

			$dadosLivro = $comando->fetchAll();

			if(count($dadosLivro) > 0){
				//Dados do livro

				$tombo = htmlspecialchars($dadosLivro[0][0]);
				$titulo = htmlspecialchars($dadosLivro[0][1]);
				$data = htmlspecialchars($dadosLivro[0][2]);
				$volume = htmlspecialchars($dadosLivro[0][3]);
				$edicao = htmlspecialchars($dadosLivro[0][4]);
				$isbn = htmlspecialchars($dadosLivro[0][5]);
				$idioma = htmlspecialchars($dadosLivro[0][6]);
				$img = base64_encode($dadosLivro[0][7]);	
				$pdf = htmlspecialchars($dadosLivro[0][8]);

				//Buscando autores

				$comando = $conexao->prepare("SELECT a.id_autor, a.nome_autor FROM autor AS a INNER JOIN autor_livro AS al ON al.id_autor_tombo = a.id_autor WHERE al.id_livro_tombo = :codL");

				$comando->bindParam(":codL", $codL);

				$comando->execute();

				$dados = $comando->fetchAll();

				foreach($dados as $valor){
					$id = htmlspecialchars($valor[0]);
					$nome = htmlspecialchars($valor[1]);

					$autores .= "<option ondblclick='removeAutorLista($id, this)' value='$id'>$nome</option>";
				}

				//Buscando genêros

				$comando = $conexao->prepare("SELECT g.id_genero, g.nome_genero FROM genero AS g INNER JOIN genero_livro AS gl ON gl.id_genero_tombo = g.id_genero WHERE gl.id_livro_tombo = :codL");

				$comando->bindParam(":codL", $codL);

				$comando->execute();

				$dados = $comando->fetchAll();

				foreach($dados as $valor){
					$id = htmlspecialchars($valor[0]);
					$nome = htmlspecialchars($valor[1]);

					$generos .= "<option ondblclick='removeGeneroLista($id, this)' value='$id'>$nome</option>";
				}
			}else{
				header("location: livros.php");
			}
		}catch(Exception $ex){
			header("location: livros.php");
		}
	}else{
		header("location: livros.php");
	}
?>

<!DOCTYPE html>
<html lang="pt-br">
<head>
	<title><?php echo Info::$nomeSistema ?> - Editar Livro</title>
	<meta charset="utf-8">
	<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">

	<script src="./scripts/jquery.min.js"></script>
	<script src="./scripts/MaskaraJquery/jquery.mask.js"></script>
	<script src="./scripts/edicaoLivroPDF.js"></script>
	<script src="./scripts/controleGeneros.js"></script>
	<script src="./scripts/controleAutor.js"></script>
	<script src="https://www.google.com/recaptcha/api.js" async defer></script>

	<link rel="stylesheet" type="text/css" href="./css/fontawesome-free-5.12.1-web/css/all.min.css">
	<link rel="stylesheet" type="text/css" href="./css/fontawesome-free-5.12.1-web/css/brands.min.css">
	<link rel="stylesheet" type="text/css" href="./css/fontawesome-free-5.12.1-web/css/solid.min.css">
	<link rel="stylesheet" type="text/css" href="./css/fontawesome-free-5.12.1-web/css/svg-with-js.min.css">
	<link rel="stylesheet" type="text/css" href="./css/fontawesome-free-5.12.1-web/css/regular.min.css">
	<link rel="stylesheet" type="text/css" href="./css/fontawesome-free-5.12.1-web/css/v4-shims.min.css">
	<link rel="shortcut icon" type="image/jpg" <?php echo "href='".Info::$logoSistema."'" ?> sizes="50x50">

	<link rel="stylesheet" type="text/css" href="./css/config.css">
	<link rel="stylesheet" type="text/css" href="./css/cadLivro.css">
</head>
<body>

	<section id='MoldalAviso'></section>

	<!--Moldal de Loading-->

	<section id="moldalLoading">
		<div></div>
	</section>

	<!--Moldal de gêneros-->

	<section class="MoldalOpcoes">
		
		<section class="telas">

			<div class="fechaMoldalOpcoes">&times;</div>

			<header>
				<div>
					<img <?php echo "src='". Info::$logoSistema ."'" ?>>
					<h5><?php echo Info::$nomeSistema; ?> - Selecionar Genêro</h5>
				</div>

				<div>
					<?php

						echo "<img title='". Info::$nomeEtec ."' src='". Info::$logoEtec ."'>
						      <img title='". Info::$nomeCentro ."' src='". Info::$logoCentro ."'>";

					?>
				</div>
			</header>
			
			<section style="grid-template-rows: 1fr 70px;">
				<table>
					<thead>
						<tr>
							<th>Nome</th>
						</tr>
					</thead>
					<tbody id="generosT"></tbody>
				</table>

				<footer style="display: flex;align-items: center;justify-content: center;">
					<div><button class="btns carregarMaisT" onclick="carregaMaisGeneros(this)"><i class='fas fa-plus' title="Carregar Mais"></i></button></div>
				</footer>
			</section>
		</section>
	</section>

	<!--Moldal do autor-->

	<section class="MoldalOpcoes">
		
		<section class="telas">

			<div class="fechaMoldalOpcoes">&times;</div>

			<header>
				<div>
					<img <?php echo "src='". Info::$logoSistema ."'" ?>>
					<h5><?php echo Info::$nomeSistema; ?> - Selecionar Autor</h5>
				</div>

				<div>
					<?php

						echo "<img title='". Info::$nomeEtec ."' src='". Info::$logoEtec ."'>
						      <img title='". Info::$nomeCentro ."' src='". Info::$logoCentro ."'>";

					?>
				</div>
			</header>
			
			<section>
				<main>
					<input type="text" name="textPesquisa" placeholder="Pesquisar autor..." onkeyup="pesquisaAutor(this)">
					<button><i class='fas fa-search'></i></button>
				</main>
				<table>
					<thead>
						<tr>
							<th>Nome</th>
							<th>Nacionalidade</th>
							<th>Colaboradores</th>
							<th class='opcoesMoldalTable'>Opcões</th>
						</tr>
					</thead>
					<tbody id="autorT"></tbody>
				</table>

				<footer>
					<div><button class="adicionar" onclick="abreMoldalAutor(1, null)">Adicionar Autor</button></div>
					<div><button class="btns carregarMaisT" onclick="carregaMaisAutor(this)"><i class='fas fa-plus' title="Carregar Mais"></i></button></div>
				</footer>
			</section>
		</section>
	</section>

	<section class="MoldalOpcoes"></section>

	<!--Moldals de cadastro-->

	<section class="MoldaCad"> <!--Editora-->
		
		<section class="telas">

			<div class="fechaMoldalCad" onclick="fechaMoldalCad()">&times;</div>

			<header>
				<div>
					<img <?php echo "src='". Info::$logoSistema ."'" ?>>
					<h5><?php echo Info::$nomeSistema; ?> - <span class="tituloCad">Cadastro da Editora</span></h5>
				</div>

				<div>
					<?php

						echo "<img title='". Info::$nomeEtec ."' src='". Info::$logoEtec ."'>
						      <img title='". Info::$nomeCentro ."' src='". Info::$logoCentro ."'>";

					?>
				</div>
			</header>
			
			<section>
				<form action="javascript: void(0)">
					<input type="text" name="nome" placeholder="Nome" class="inputsE" maxlength="100" onkeyup="limpaCamposE(0)">
					<br><span class="spanCad spanCadE">Digite o nome da editora</span><br>
					<input type="text" name="cnpj" placeholder="CNPJ" maxlength="14" class="inputsE">
					<br><br>

					<input type="submit" value="Cadastrar Editora" class="btnCadSub">
				</form>
			</section>
		</section>

	</section>

	<section class="MoldaCad"> <!--Autor-->
		
		<section class="telas">

			<div class="fechaMoldalCad" onclick="fechaMoldalCad()">&times;</div>

			<header>
				<div>
					<img <?php echo "src='". Info::$logoSistema ."'" ?>>
					<h5><?php echo Info::$nomeSistema; ?> - <span class="tituloCad">Cadastro do Autor</span></h5>
				</div>

				<div>
					<?php

						echo "<img title='". Info::$nomeEtec ."' src='". Info::$logoEtec ."'>
						      <img title='". Info::$nomeCentro ."' src='". Info::$logoCentro ."'>";

					?>
				</div>
			</header>
			
			<section>
				<form action="javascript: void(0)">
					<input type="text" name="nome" placeholder="Nome" class="inputsA" maxlength="100" onkeyup="limpaCamposA(0)">
					<br><span class="spanCad spanCadA">Digite o nome do autor</span><br>

					<input type="text" name="nacionalidade" placeholder="Nacionalidade" class="inputsA" maxlength="40" onkeyup="limpaCamposA(1)">
					<br><span class="spanCad spanCadA">Digite a nacionalidade do autor</span><br>

					<input type="text" name="colaboradores" placeholder="Colaboradores" maxlength="255" class="inputsA">
					<br><br><br>

					<input type="submit" value="Cadastrar Autor" class="btnCadSub">
				</form>
			</section>
		</section>

	</section>

	<nav id="menu">
		<ul>
			<li id="mn"><a href="javascript: history.go(-1)"><span><i class="fas fa-arrow-left"></i></span></a> <h5>Livros</h5></li>
			<li id="imgInicial">
				<?php

					echo "<a href='". Info::$siteEtec ."' target='_blank'><img title='". Info::$nomeEtec ."' src='". Info::$logoEtec ."'></a>
						  <a href='Inicio.php'><img title='". Info::$nomeSistema ."' src='". Info::$logoSistema ."'></a>
						  <a href='". Info::$siteCentro ."' target='_blank'><img title='". Info::$nomeCentro ."' src='". Info::$logoCentro ."'></a>";

				?>
			</li>
		</ul>
	</nav>

	<section id="container">
		<form action="javascript: void(0)" name="formCad" id="formCad">

			<input type="hidden" name="cod_livro" <?php echo "value='$codL'" ?>>
			<input type="hidden" name="pdfOriginal" <?php echo "value='$pdf'" ?>>
		
			<div id="containerImg">
				<label for="imagem"><img <?php echo "src='data:image/jpg;base64,$img'" ?> id="imagemPreview"></label>
				<input type="file" name="imagem" id="imagem" accept="Image/jpeg" onchange="preview()">
			</div>

			<div class="inputs" id="input1">
				<div class="inputFlexContainer">
					<input type="text" name="titulo" placeholder="Titulo" class="inputV" maxlength="100" <?php echo "value='$titulo'" ?>>
				</div>
				
				<span class="spanAlerta"><br>Digite o titulo</span><br><br>

				<fieldset class="inputFlexContainer"><legend>Data de Publicação</legend>
					<input type="date" name="datapublicacao" class="inputV" alt="8" <?php echo "value='$data'" ?>>
				</fieldset>

				<br><span class="spanAlerta">Digite a data de publicação</span><br><br>
			</div>

			<div class="inputs" id="input2">

				<div>
					<div class="inputComBTN">
						<?php echo "<select class='inputV' size='5' id='generosSelecionados'>$generos</select>"; ?>
						<input type="hidden" name="generos" id="generos">
						<button class="btnAbreMoldal">Adicionar Genêro</button>
					</div>
					<br><span class="spanAlerta">Selecione pelo menos um genêro</span><br><br>
				</div>

				<div class="divide">
					
					<div>
						<div class="inputFlexContainer">
							<input type="number" name="volume" placeholder="Volume" min="0" id="volume" <?php echo "value='$volume'" ?>>
						</div>

						<br><br><br>
					</div>

					<div>
						<div class="inputFlexContainer">
							<input type="number" name="edicao" placeholder="Edição" min="0" id="edicao" <?php echo "value='$edicao'" ?>>
						</div>

						<br><br><br>
					</div>

				</div>

				<div id="exemplares">

					<div>
						<div class="inputFlexContainer">
							<input type="text" name="idioma" placeholder="Idioma" class="inputV" maxlength="30" <?php echo "value='$idioma'" ?>>
						</div>

						<br><span class="spanAlerta">Digite o idioma</span><br><br>
					</div>

				</div>

				<div style="grid-column: 3/1">

					<div>
						<div class="dividePDF" style="margin: 0" class="inputFlexContainer">
							<input type="text" id="pdf_url" name="pdf_url" placeholder="PDF do Livro" readonly class="inputV" <?php echo "value='$pdf'" ?>><label for="pdf_livro">...</label>
							<input type="file" id="pdf_livro" name="pdf_livro" accept="application/pdf">
						</div>

						<br><span class="spanAlerta">Selecione o PDF do livro</span><br><br>
					</div>
					
				</div>

				<div class="divide">

					<div style="grid-column: 3/1">
						<div class="inputComBTN">
							<?php echo "<select class='inputV' size='5' id='autoresSelecionados'>$autores</select>"; ?>
							<input type="hidden" name="autores" id="autores">
							<button class="btnAbreMoldal">Adicionar Autor</button>
						</div>	

						<br><span class="spanAlerta">Selecione pelo menos um autor</span><br><br>
					</div>

				</div>

				<div style="overflow: hidden;">
					<div class="g-recaptcha" <?php echo "data-sitekey='$codChaveDiv'"; ?>></div>
				</div>
				
			</div>

			<div id="btnCad">
				<input type="submit" name="btnCadLivro" value="Salvar Edições" onclick="executaEdicao()">
			</div>

		</form>
	</section>

	<!--Botão para ajuda-->

	<a href="ajuda.php#CadLivroPDF"><div id="btnhelp" title="Ajuda" style="bottom: 40px"><i class="fas fa-question"></i></div></a>

	<footer><h5><?php echo Info::$copyright; ?></h5></footer>

</body>
</html>