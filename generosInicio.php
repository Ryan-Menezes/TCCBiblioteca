<?php

	include_once "conexao.php";
	include_once "Usuario.php";
	include_once "dadosSistema.php";
	include_once "verificaTempoSessao.php";
	if(!isset($_SESSION)) session_start();

	$conexao = conexao::getConexao();

	if(!isset($_SESSION["usuario"])){
		header("location: index.php");
	}

	try{
		$codigo = null;

		if(isset($_GET["cod_genero"])){
			$codigo = trim(addslashes($_GET["cod_genero"]));
		}else{
			header("location: Inicio.php");
		}

		$comando = $conexao->prepare("SELECT nome_genero FROM genero AS g LEFT JOIN genero_livro AS gl ON g.id_genero = gl.id_genero_tombo WHERE g.id_genero = :cod LIMIT 1");

		$comando->bindParam(":cod", $codigo);

		$comando->execute();

		$dados = $comando->fetchAll();

		$html = null;

		if(count($dados) > 0){
			$tituloGenero = $dados[0][0];

			//Verificando se o código passado está associado há algum livro no sistema

			$comando = $conexao->prepare("SELECT l.cod_livro, l.titulo, l.idioma, l.img_livro, (SELECT AVG(avaliacao_estrelas) FROM avaliacao WHERE livro_tombo_avaliacao = l.cod_livro) FROM livro AS l INNER JOIN genero_livro AS g ON g.id_livro_tombo = l.cod_livro WHERE g.id_genero_tombo = :cod LIMIT 10");

			$comando->bindParam(":cod", $codigo);

			$comando->execute();

			$dadosLivro = $comando->fetchAll();

			if(count($dadosLivro) > 0){
				
				foreach($dadosLivro as $value){
					$codigoL = htmlspecialchars($value[0]);
					$titulo = htmlspecialchars($value[1]);
					$idioma = htmlspecialchars($value[2]);
					$img = base64_encode($value[3]);
					$avaliacao = (strlen(htmlspecialchars($value[4])) > 0) ? htmlspecialchars($value[4]) : 0;

					$avaliacao = number_format($avaliacao, 1);

					$tituloCompleto = htmlspecialchars($value[1]);

					if(strlen($titulo) > 20){
						$titulo = substr($titulo, 0, 40) . "...";
					}

					$html .= "<a href='telaLivro.php?cod_livro=$codigoL'>
								<main>
									<img src='data:image/jpg;base64,$img'>
									<div>
										<div>
											<h4 title='$tituloCompleto'>$titulo</h4><br>
											<p>$avaliacao <i class='fas fa-star'></i> | $idioma <i class='fas fa-language'></i></p>
										</div>
									</div>
								</main>
							</a>";
				}

				if(count($dadosLivro) >= 10){
					$html .= "<div id='loadingCont'>
								<div class='carregarMais' title='Carregar Mais Livros' onclick='carregaMaisLivrosGen($codigo, this)'><i class='fas fa-plus'></i></div>
							  </div>";
				}

			}else{
				$html = "<h4 style='color: white'>Não há livros cadastrados a este genêro</h4>";
			}
		}else{
			header("location: Inicio.php");
		}

	}catch(PDOException $ex){
		header("location: Inicio.php");
	}
?>

<!DOCTYPE html>
<html lang="pt-br">
<head>
	<title><?php echo Info::$nomeSistema ?> - <?php echo $tituloGenero; ?></title>
	<meta charset="utf-8">
	<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">

	<script src="./scripts/jquery.min.js"></script>
	<script src="./scripts/MaskaraJquery/jquery.mask.js"></script>
	<script src="./scripts/generosInicio.js"></script>

	<link rel="stylesheet" type="text/css" href="./css/fontawesome-free-5.12.1-web/css/all.min.css">
	<link rel="stylesheet" type="text/css" href="./css/fontawesome-free-5.12.1-web/css/brands.min.css">
	<link rel="stylesheet" type="text/css" href="./css/fontawesome-free-5.12.1-web/css/solid.min.css">
	<link rel="stylesheet" type="text/css" href="./css/fontawesome-free-5.12.1-web/css/svg-with-js.min.css">
	<link rel="stylesheet" type="text/css" href="./css/fontawesome-free-5.12.1-web/css/regular.min.css">
	<link rel="stylesheet" type="text/css" href="./css/fontawesome-free-5.12.1-web/css/v4-shims.min.css">
	<link rel="shortcut icon" type="image/jpg" <?php echo "href='".Info::$logoSistema."'" ?> sizes="50x50">

	<link rel="stylesheet" type="text/css" href="./css/config.css">
	<link rel="stylesheet" type="text/css" href="./css/generosInicio.css">
</head>
<body>

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

	<section id="livrosGenero">
		
		<?php
			echo "<h2>$tituloGenero</h2>";

			echo "<section class='livrosG'>";

			echo $html;

			echo "</section>";
		?>

	</section>

	<!--Botão para ajuda-->

	<a href="ajuda.php#Inicio"><div id="btnhelp" title="Ajuda" style="bottom: 40px"><i class="fas fa-question"></i></div></a>

</body>
</html>