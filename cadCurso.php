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

	$instituicoes = null;

	try{
		//Pegando instituicoes

		$etecs = implode(",", $dados->getInstituicoes());

		$comando = $conexao->prepare("SELECT id_instituicao, nome_instituicao FROM instituicao WHERE id_instituicao IN($etecs)");

		$comando->execute();

		$dados = $comando->fetchAll();

		$inst = $dados[0][0];

		foreach($dados as $valor){
			$cod = htmlspecialchars($valor[0]);
			$nome = htmlspecialchars($valor[1]);

			$instituicoes .= "<option value='$cod'>$nome</option>";
		}
	}catch(Exception $ex){
		header("location: instituicoes.php");
	}
	
?>

<!DOCTYPE html>
<html lang="pt-br">
<head>
	<title><?php echo Info::$nomeSistema ?> - Cadastro de Cursos</title>
	<meta charset="utf-8">
	<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">

	<script src="./scripts/jquery.min.js"></script>
	<script src="./scripts/MaskaraJquery/jquery.mask.js"></script>
	<script src="./scripts/cadastroCurso.js"></script>
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

	<section class="MoldaCad"> <!--Turma-->
		
		<section class="telas">

			<div class="fechaMoldalCad" onclick="fechaMoldalCad()">&times;</div>

			<header>
				<div>
					<img <?php echo "src='". Info::$logoSistema ."'" ?>>
					<h5><?php echo Info::$nomeSistema; ?> - <span class="tituloCad">Turma</span></h5>
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
					<div class="inputFlexContainer">
						<input type="number" name="moduloSerie" class="inputsT" placeholder="Módulo/Série" min="1">
					</div>

					<br><span class="spanCad">Digite o módulo/série</span><br>

					<div class="inputFlexContainer">
						<input type="text" name="turma" placeholder="Turma" id="turma" class="inputsT" maxlength="1" onkeyup="transformaMaisucula(this)">
					</div>
					<br><span class="spanCad">Digite a turma</span><br>

					<div>
						<fieldset><legend>Periodo</legend>
							<select name="periodo" id="periodo">
								<option value="M" selected>Manhã</option>
								<option value="T">Tarde</option>
								<option value="N">Noite</option>
								<option value="I">Integral</option>
							</select>
						</fieldset>

						<br><br><br>
					</div>

					<input type="submit" value="Adicionar" class="btnCadSub">
				</form>
			</section>
		</section>

	</section>

	<nav id="menu">
		<ul>
			<li id="mn"><a href="javascript: history.go(-1)"><span><i class="fas fa-arrow-left"></i></span></a> <h5>Cursos da Instituição</h5></li>
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
					
				<div>
					<div class="inputFlexContainer">
						<input type="text" name="nome" placeholder="Nome do curso" maxlength="40" class="inputV" maxlength="40">
					</div>

					<br><span class="spanAlerta">Digite o nome do curso</span><br><br>
				</div>

				<div>
					<div class="inputComBTN">
						<select class="inputV" size="5" id="turmasSelecionados"></select>
						<input type="hidden" name="moduloSeries" id="moduloSeries">
						<input type="hidden" name="turmas" id="turmas">
						<input type="hidden" name="periodos" id="periodos">
						<button class="btnAbreMoldal">Adicionar Turma</button>
					</div>	

					<br><span class="spanAlerta">Adicione pelo menos uma turma para este curso</span><br><br>
				</div>

				<div class="divide">
					<div>
						<div>
							<fieldset><legend>Tipo</legend>
								<select name="tipo">
									<option value="EM">Ensino Médio(EM)</option>
									<option value="ETIM">Ensino técnico integrado ao médio(ETIM)</option>
									<option value="MOD" selected>Modular(MOD)</option>
									<option value="NOV">Novotec(NOV)</option>
								</select>
							</fieldset>
						</div>

						<br><br><br>
					</div>

					<div>
						<div>
							<fieldset><legend>Instituição</legend>
								<select name="instituicao">
									<?php
										echo $instituicoes;
									?>
								</select>
							</fieldset>
						</div>

						<br><br><br>
					</div>
				</div>

				<div style="overflow: hidden;">
					<div class="g-recaptcha" <?php echo "data-sitekey='$codChaveDiv'"; ?>></div>
				</div>

			</div>

			<div id="btnCad">
				<input type="submit" value="Cadastrar Curso" onclick="executaCadastro()">
			</div>

		</form>
	</section>

	<!--Botão para ajuda-->

	<a href="ajuda.php#CadCurso"><div id="btnhelp" title="Ajuda" style="bottom: 40px"><i class="fas fa-question"></i></div></a>

	<footer><h5><?php echo Info::$copyright; ?></h5></footer>

</body>
</html>