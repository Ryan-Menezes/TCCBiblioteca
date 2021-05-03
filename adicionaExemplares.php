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

	//Pegando instituições

	try{
		$etecs = implode(",", $dados->getInstituicoes());

		$comando = $conexao->prepare("SELECT id_instituicao, nome_instituicao FROM instituicao WHERE id_instituicao IN($etecs)");

		$comando->execute();

		$instituicoesOP = null;

		foreach($comando->fetchAll() as $valor){
			$cod = htmlspecialchars($valor[0]);
			$nome = htmlspecialchars($valor[1]);

			$instituicoesOP .= "<option value='$cod'>$nome</option>";
		}
	}catch(Exception $ex){
		header("location: livros.php");
	}
	
?>

<!DOCTYPE html>
<html lang="pt-br">
<head>
	<title><?php echo Info::$nomeSistema ?> - Adicionar Exemplares</title>
	<meta charset="utf-8">
	<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">

	<script src="./scripts/jquery.min.js"></script>
	<script src="./scripts/MaskaraJquery/jquery.mask.js"></script>
	<script src="./scripts/adicionaExemplares.js"></script>
	<script src="./scripts/controleEditora.js"></script>
	<script src="./scripts/carregaLivroMoldal.js"></script>
	<script type="text/javascript" src="./scripts/recaptcha.js"></script>

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

	<!--Moldal da editora-->

	<section class="MoldalOpcoes">
		
		<section class="telas">

			<div class="fechaMoldalOpcoes">&times;</div>

			<header>
				<div>
					<img <?php echo "src='". Info::$logoSistema ."'" ?>>
					<h5><?php echo Info::$nomeSistema; ?> - Selecionar Editora</h5>
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
					<input type="text" name="textPesquisa" placeholder="Pesquisar editora..." onkeyup="pesquisaEditora(this)">
					<button><i class='fas fa-search'></i></button>
				</main>
				<table>
					<thead>
						<tr>
							<th>Nome</th>
							<th>CNPJ</th>
							<th class='opcoesMoldalTable'>Opcões</th>
						</tr>
					</thead>
					<tbody id="editoraT"></tbody>
				</table>

				<footer>
					<div><button class="adicionar" onclick="abreMoldalEditora(1, null)">Adicionar Editora</button></div>
					<div><button class="btns carregarMaisT" onclick="carregaMaisEditoras(this)"><i class='fas fa-plus' title="Carregar Mais"></i></button></div>
				</footer>
			</section>
		</section>
	</section>

	<!--Moldal da editora-->

	<section class="MoldalOpcoes">
		
		<section class="telas">

			<div class="fechaMoldalOpcoes">&times;</div>

			<header>
				<div>
					<img <?php echo "src='". Info::$logoSistema ."'" ?>>
					<h5><?php echo Info::$nomeSistema; ?> - Selecionar Livro</h5>
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
					<input type="text" name="textPesquisa" placeholder="Pesquisar livro..." onchange="pesquisaLivro(this)">
					<button><i class='fas fa-search'></i></button>
				</main>
				<table>
					<thead>
						<tr>
							<th>Capa</th>
							<th>Titulo</th>
						</tr>
					</thead>
					<tbody id="livroT"></tbody>
				</table>

				<footer style="grid-template-columns: 1fr">
					<div style="display: flex; align-items: center; justify-content: center;">
						<button class="btns carregarMaisT" onclick="carregaLivros(this)"><i class='fas fa-plus' title="Carregar Mais"></i></button>
					</div>
				</footer>
			</section>
		</section>
	</section>

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
					<input type="text" name="cnpj" placeholder="CNPJ" maxlength="14" class="inputsE" id="cnpjEditora">
					<br><br>

					<input type="submit" value="Cadastrar Editora" class="btnCadSub">
				</form>
			</section>
		</section>

	</section>

	<section class="MoldaCad"> <!--Pegar tombo-->
		
		<section class="telas">

			<div class="fechaMoldalCad" onclick="fechaMoldalCad()">&times;</div>

			<header>
				<div>
					<img <?php echo "src='". Info::$logoSistema ."'" ?>>
					<h5><?php echo Info::$nomeSistema; ?> - Outros dados</h5>
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

					<p style="color: white">Este livro não possui nenhum tombo e ISBN cadastrado!, pois se trata de um livro que está disponível somente em pdf, portanto informe o tombo e o ISBN dos exemplares que você irá adicionar!</p><br>

					<input type="text" name="tombo" class="inputTomboCad" placeholder="Tombo" maxlength="10">

					<br><span class="spanCad spanTombo">Digite o tombo do livro</span><br>

					<input type="text" name="isbn" class="inputTomboCad"placeholder="ISBN" maxlength="14">

					<br><span class="spanCad spanTombo">Digite o ISBN do livro</span><br>

					<input type="submit" value="Cadastrar Dados" class="btnCadSub" onclick="informaTombo()">
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

			<input type="hidden" name="tombo" id="inputTombo" value="">
			<input type="hidden" name="isbn" id="inputISBN" value="">

			<div class="inputs" id="input2" style="padding: 20px;">

				<div>
					<div class="dividePDF" style="margin: 0; display: grid; grid-template-columns: 1fr 50px">
						<input type="text" id="livro" name="livro" placeholder="Livro" class="inputV" readonly><button class="btnAbreMoldalLivro">...</button>
						<input type="hidden" name="livroCodigo" id="livroCodigo">
					</div>

					<br><span class="spanAlerta">Selecione um livro</span><br><br>
				</div>
				
				<div class="divide">
					<div>
						<div class="inputFlexContainer">
							<input type="number" name="exemplares" placeholder="Exemplares" class="inputV" min="1">
						</div>

						<br><span class="spanAlerta">Digite os exemplares</span><br><br>
					</div>

					<div>
						<div>
							<select name="instituicao">
								<?php echo $instituicoesOP; ?>
							</select>

							<br><br><br>
						</div>
					</div>
				</div>
				

				<div>
					<div class="inputComBTN">
							
						<select size='5' id='editorasSelecionados'></select>
							
						<input type="hidden" name="editoras" id="editoras">
						<button class="btnAbreMoldal">Adicionar Editora</button>
					</div>	

					<br><span class="spanAlerta">Selecione pelo menos uma editora</span><br><br>
				</div>
				
				<div style="overflow: hidden;">
					<div class="g-recaptcha" <?php echo "data-sitekey='$codChaveDiv'"; ?>></div>
				</div>	
			</div>

			<div id="btnCad">
				<input type="submit" name="btnCadLivro" value="Adicionar Exemplares" onclick="adicionaExemplares()">
			</div>
		</form>
	</section>

	<!--Botão para ajuda-->

	<a href="ajuda.php#AdicionarExemplares"><div id="btnhelp" title="Ajuda" style="bottom: 40px"><i class="fas fa-question"></i></div></a>

	<footer><h5><?php echo Info::$copyright; ?></h5></footer>

</body>
</html>