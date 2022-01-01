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

	try{
		$conexao = conexao::getConexao();

		$codigo = null;

		if(isset($_GET["cod_livro"])){
			$codigo = trim(addslashes($_GET["cod_livro"]));
		}else{
			header("location: Inicio.php");
		}

		//Verificando se o código passado está associado há algum livro no sistema

		$comando = $conexao->prepare("SELECT titulo, idioma, img_livro, pdf_livro, (SELECT AVG(avaliacao_estrelas) FROM avaliacao WHERE livro_tombo_avaliacao = l.cod_livro) FROM livro AS l WHERE cod_livro = :cod LIMIT 1");

		$comando->bindParam(":cod", $codigo);

		$comando->execute();

		$dadosLivro = $comando->fetchAll();

		$autores = null;
		$generos = null;
		$exemplaresD = 0;
		$instituicoes = null;

		if(count($dadosLivro) > 0){
			//Buscando os autores

			$comando = $conexao->prepare("SELECT a.nome_autor FROM autor AS a INNER JOIN autor_livro AS l ON a.id_autor = l.id_autor_tombo WHERE l.id_livro_tombo = :cod");

			$comando->bindParam(":cod", $codigo);

			$comando->execute();

			$dadosAutor = $comando->fetchAll();

			foreach ($dadosAutor as $valor) {
				$autores .= htmlspecialchars($valor[0]) . ", ";
			}

			$autores = substr($autores, 0, (strlen($autores) - 2));

			//Buscando generos

		    $comando = $conexao->prepare("SELECT g.nome_genero FROM genero AS g INNER JOIN genero_livro AS l ON g.id_genero = l.id_genero_tombo WHERE l.id_livro_tombo = :cod");

			$comando->bindParam(":cod", $codigo);

			$comando->execute();

			$dadosGenero = $comando->fetchAll();

			foreach ($dadosGenero as $valor) {
				$generos .= htmlspecialchars($valor[0]) . ", ";
			}

			$generos = substr($generos, 0, (strlen($generos) - 2));

			//Instituição Inicial

			$comando = $conexao->prepare("SELECT i.id_instituicao FROM instituicao AS i INNER JOIN exemplares AS e ON i.id_instituicao = e.id_instituicao WHERE e.livro_tombo_exemplares = :cod LIMIT 1");

			$comando->bindParam(":cod", $codigo);

			$comando->execute();

			$dadosInstituicao = $comando->fetchAll();

			$instituicaoI = null;

			foreach ($dadosInstituicao as $valor) {
				$instituicaoI = htmlspecialchars($valor[0]);
				break;
			}

			//Pegando instituições

			$comando = $conexao->prepare("SELECT i.id_instituicao, i.nome_instituicao FROM instituicao AS i INNER JOIN exemplares AS e ON i.id_instituicao = e.id_instituicao WHERE e.livro_tombo_exemplares = :cod");

			$comando->bindParam(":cod", $codigo);

			$comando->execute();

			$instituicoes = $comando->fetchAll();

			//Pegando exemplares disponiveis

			if($instituicaoI != null){
				$comando = $conexao->prepare("SELECT (e.quantidade - (SELECT COUNT(*) FROM locacao AS l WHERE l.id_exemplares = e.id_exemplares)) FROM exemplares AS e WHERE e.livro_tombo_exemplares = :cod AND e.id_instituicao = :codE LIMIT 1");

				$comando->bindParam(":cod", $codigo);
				$comando->bindParam(":codE", $instituicaoI);

				$comando->execute();

				$dadosExemplares = $comando->fetchAll();

				foreach ($dadosExemplares as $valor) {
					$exemplaresD = (htmlspecialchars($valor[0]) >= 0) ? htmlspecialchars($valor[0]) : 0;
				}
			}
		}else{
			header("location: Inicio.php");
		}
	}catch(PDOException $ex){
		header("location: Inicio.php");
	}

	//Pegando os dados armazenados no array dos livros

	foreach ($dadosLivro as $valor) {
		$titulo = htmlspecialchars($valor[0]);
		$idioma = htmlspecialchars($valor[1]);
		$img = base64_encode($valor[2]);
		$pdf = htmlspecialchars($valor[3]);
		$avaliacao = (strlen(htmlspecialchars($valor[4])) > 0) ? htmlspecialchars($valor[4]) : 0;

		$avaliacao = number_format($avaliacao, 1);

		break;
	}
?>

<!DOCTYPE html>
<html lang="pt-br">
<head>
	<title><?php echo Info::$nomeSistema ?> - <?php echo $titulo ?></title>
	<meta charset="utf-8">
	<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">

	<script src="./scripts/jquery.min.js"></script>
	<script type="text/javascript" src="./scripts/telaLivro.js"></script>
	<script src="https://www.google.com/recaptcha/api.js" async defer></script>

	<link rel="stylesheet" type="text/css" href="./css/fontawesome-free-5.12.1-web/css/all.min.css">
	<link rel="stylesheet" type="text/css" href="./css/fontawesome-free-5.12.1-web/css/brands.min.css">
	<link rel="stylesheet" type="text/css" href="./css/fontawesome-free-5.12.1-web/css/solid.min.css">
	<link rel="stylesheet" type="text/css" href="./css/fontawesome-free-5.12.1-web/css/svg-with-js.min.css">
	<link rel="stylesheet" type="text/css" href="./css/fontawesome-free-5.12.1-web/css/regular.min.css">
	<link rel="stylesheet" type="text/css" href="./css/fontawesome-free-5.12.1-web/css/v4-shims.min.css">
	<link rel="shortcut icon" type="image/jpg" <?php echo "href='".Info::$logoSistema."'" ?> sizes="50x50">

	<link rel="stylesheet" type="text/css" href="./css/config.css">
	<link rel="stylesheet" type="text/css" href="./css/generosInicio.css">	
	<link rel="stylesheet" type="text/css" href="./css/TelaLivro.css">
</head>
<body>

	<section id='MoldalAviso'></section>

	<section id="moldalLoading">
		<div></div>
	</section>

	<section id="moldalAvaliacoes" class="moldal">

		<div class="fechaMoldal" onclick="fecharMoldal()">&times;</div>

		<main id="espaco">
			<select id="selectFiltro" onchange="selecionaFiltroAva()">
				<option value="T" selected>Todos</option>
				<option value="5">5 Estrelas</option>
				<option value="4">4 Estrelas</option>
				<option value="3">3 Estrelas</option>
				<option value="2">2 Estrelas</option>
				<option value="1">1 Estrela</option>
			</select>
		</main>

		<section id="avaliacoesDiv">
			<button id="loadingInicial"></button>
		</section>
		
	</section>

	<nav id="menu">
		<ul>
			<li id="mn"><a href="javascript: history.go(-1)"><span><i class="fas fa-arrow-left"></i></span></a> <h5>Voltar</h5></li>
			<li id="imgInicial">
				<?php

					echo "<a href='". Info::$siteEtec ."' target='_blank'><img title='". Info::$nomeEtec ."' src='". Info::$logoEtec ."'></a>
						  <a href='Inicio.php'><img title='". Info::$nomeSistema ."' src='". Info::$logoSistema ."'></a>
						  <a href='". Info::$siteCentro ."' target='_blank'><img title='". Info::$nomeCentro ."' src='". Info::$logoCentro ."'></a>";

				?>
			</li>
		</ul>
	</nav>

	<!--Botão para ajuda-->

	<a href="ajuda.php#TelaLivro"><div id="btnhelp" title="Ajuda" style="bottom: 40px"><i class="fas fa-question"></i></div></a>

	<button id="plusList" title="Adicionar a minha lista" onclick="adicionaLista(<?php echo $codigo; ?>)"><i class="fas fa-list"></i></button>

	<section id="principal">

		<section class="info">
			
			<?php

				echo "<img src='data:image/jpg;base64,$img'>";

				echo "<ul>
						<li><h2>$titulo</h2></li>
						<li><span><i class='fas fa-user-circle'></i></span> Autor(es): $autores</li>
						<li><span><i class='fas fa-language'></i></span> Idioma: $idioma</li>
						<li><span><i class='fas fa-stream'></i></span> Genêro(s): $generos</li>";

				if($instituicaoI != null){
					echo "<li id='exemplaresDis'><span><i class='fas fa-book'></i></span> Exemplares Disnoníveis: $exemplaresD</li>
						  <li><span><i class='fas fa-school'></i></span> Instituições: <select onchange='selecionaInstituicao(this, $codigo)'>";

					foreach ($instituicoes as $valor) {
						$id = htmlspecialchars($valor[0]);
						$nome = htmlspecialchars($valor[1]);

						echo "<option value='$id'>$nome</option>";
					}

					echo "</select></li>";
				}else{
					echo "<li>Disponível somente em PDF</li>";
				}

				if($pdf != null && strlen($pdf) > 0){
					echo "<li><a href='./PDFS/$pdf' download='$titulo'><button><i class='fas fa-download'></i> Baixar PDF</button></a></li></ul>";
				}else{
					echo "</ul>";
				}

			?>
		</section>
		
	</section>

	<section id="avaliacao">

		<div class="status">
			<h2><?php echo $avaliacao; ?></h2>
			<h4>Avaliações</h4>
		</div>

		<br>
		
		<div class="estrelas">
			<i class="fas fa-star"></i>
			<i class="fas fa-star"></i>
			<i class="fas fa-star"></i>
			<i class="fas fa-star"></i>
			<i class="fas fa-star"></i>
		</div>

		<button id="verAvaliacao">Ver avaliações</button>

	</section>

	<section id="avaliar">
		<form action="javascript: void(0)" method="post" id="formAvaliacao">

			<main>
				<div>
					<span>Selecionar uma estrela: (Obigatório)</span><br><br>

					<div class="estrelas">
						<div id="avisoEstrela">
							<p>Selecione pelo menos uma estrela</p>
							<div></div>
						</div>

						<label for="um"><i class="fas fa-star"></i></label>
						<label for="dois"><i class="fas fa-star"></i></label>
						<label for="tres"><i class="fas fa-star"></i></label>
						<label for="quatro"><i class="fas fa-star"></i></label>
						<label for="cinco"><i class="fas fa-star"></i></label>
					</div>
				</div>

				<div style="overflow: hidden; margin-bottom: 0;">
					<div class="g-recaptcha" <?php echo "data-sitekey='$codChaveDiv'"; ?>></div>
				</div>
			</main>
			
			<input type="radio" name="estrela" id="um" value="1">
			<input type="radio" name="estrela" id="dois" value="2">
			<input type="radio" name="estrela" id="tres" value="3">
			<input type="radio" name="estrela" id="quatro" value="4">
			<input type="radio" name="estrela" id="cinco" value="5">

			<input type="hidden" name="estrelas" id="estrelas">
			<input type="hidden" name="livro" id="codigoLivro" <?php echo "value='$codigo'"; ?>>

			<textarea placeholder="Digite sua avaliação (Opcional)" id="caixaTextoAva" name="txt" rows="1" onkeyup="resizeTextarea(this)"></textarea>

			<input type="submit" value="Enviar" onclick="enviaAvaliacao()">
		</form>
	</section>

</body>
</html>