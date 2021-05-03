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

	if(isset($_GET["codL"]) && isset($_GET["codE"])){
		try{
			$codL = trim(addslashes($_GET["codL"]));
			$codE = trim(addslashes($_GET["codE"]));
			$instituicoesOP = null;

			$comando = $conexao->prepare("SELECT l.titulo, l.img_livro, e.quantidade, e.id_instituicao FROM livro AS l INNER JOIN exemplares AS e ON e.livro_tombo_exemplares = l.cod_livro WHERE l.cod_livro = :codL AND e.id_exemplares = :codE AND l.tombo IS NOT NULL LIMIT 1");

			$comando->bindParam(":codL", $codL);
			$comando->bindParam(":codE", $codE);

			$comando->execute();

			$dadosLivro = $comando->fetchAll();

			//Dados do livro

			if(count($dadosLivro) > 0){
				$titulo = htmlspecialchars($dadosLivro[0][0]);
				$img = base64_encode($dadosLivro[0][1]);
				$qtde = htmlspecialchars($dadosLivro[0][2]);
				$instituicao = htmlspecialchars($dadosLivro[0][3]);

				//Pegando instituições

				$comando = $conexao->prepare("SELECT id_instituicao, nome_instituicao FROM instituicao WHERE id_instituicao != :id");

				$comando->bindParam(":id", $instituicao);

				$comando->execute();

				$dadosInst = $comando->fetchAll();

				if(count($dadosInst) > 0){
					foreach($dadosInst as $valor){
						$cod = htmlspecialchars($valor[0]);
						$nome = htmlspecialchars($valor[1]);

						$instituicoesOP .= "<option value='$cod'>$nome</option>";
					}
				}else{
					header("location: livros.php");
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
	<title><?php echo Info::$nomeSistema ?> - Exportar Exemplares</title>
	<meta charset="utf-8">
	<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">

	<script src="./scripts/jquery.min.js"></script>
	<script src="./scripts/MaskaraJquery/jquery.mask.js"></script>
	<script src="./scripts/exportarExemplares.js"></script>
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

	<style type="text/css">
		#campoLivro{
			background-color: #141313;
			padding: 10px;
			border-radius: 3px;
			color: white;
			display: grid;
			grid-template-columns: 50px 1fr;
		}
		#campoLivro img{
			height: 50px;
			border-radius: 3px;
		}
	</style>
</head>
<body>

	<section id='MoldalAviso'></section>

	<!--Moldal de Loading-->

	<section id="moldalLoading">
		<div></div>
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

			<div class="inputs" id="input2" style="padding: 20px;">
				<input type="hidden" name="cod_livro" <?php echo "value='$codL'" ?>>
				<input type="hidden" name="cod_exemplar" <?php echo "value='$codE'" ?>>
				<input type="hidden" name="exemplaresTot" id="exemplaresTot" <?php echo "value='$qtde'" ?>>

				<div id='campoLivro'>
					<img <?php echo "src='data:image/jpg;base64,$img'" ?>>
					<div>
						<h5><?php echo "$titulo" ?></h5><br>
						<h5><?php echo "Total de Exemplares: <span id='exemplaresTotal'>$qtde</span>" ?></h5>
					</div>
				</div>

				<br><br><br>
				
				<div>
					<div>
						<div class="inputFlexContainer">
							<input style="width: 96%" type="number" id="exemplaresEx" name="exemplares" placeholder="Exemplares a serem exportados" class="inputV" min="1" onkeyup="atualizaExemplares()" onchange="atualizaExemplares()" <?php echo "max='$qtde'" ?>>
						</div>

						<br><span class="spanAlerta">Informe o número de exemplares que você deseja exportar</span><br><br>
					</div>
				</div>
				
				<div>
					<div>
						<fieldset><legend>Instituição</legend>
							<select name="instituicao">
								<?php echo $instituicoesOP; ?>
							</select>
						</fieldset>

						<br><br><br>
					</div>
				</div>

				<div style="overflow: hidden;">
					<div class="g-recaptcha" <?php echo "data-sitekey='$codChaveDiv'"; ?>></div>
				</div>
			</div>

			<div id="btnCad">
				<input type="submit" name="btnCadLivro" value="Exportar Exemplares" onclick="exportaExemplares()">
			</div>
		</form>
	</section>

	<!--Botão para ajuda-->

	<a href="ajuda.php#ExportarExemplares"><div id="btnhelp" title="Ajuda" style="bottom: 40px"><i class="fas fa-question"></i></div></a>

	<footer><h5><?php echo Info::$copyright; ?></h5></footer>

</body>
</html>