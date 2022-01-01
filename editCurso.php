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

	$nomeC = null;
	$moduloSerie = null;
	$periodo = null;
	$turma = null;
	$tipo = null;
	$id_instituicao = null;
	$instituicoes = null;

	if(isset($_GET["codC"])){
		try{
			$codigoC = trim(addslashes($_GET["codC"]));

			//Pegando dados do curso

			$comando = $conexao->prepare("SELECT * FROM curso WHERE id_curso = :id LIMIT 1");

			$comando->bindParam(":id", $codigoC);

			$comando->execute();

			$dadosCurso = $comando->fetchAll();

			if(count($dadosCurso) > 0){
				$nomeC = htmlspecialchars($dadosCurso[0][1]);
				$moduloSerie = htmlspecialchars($dadosCurso[0][2]);
				$periodo = htmlspecialchars($dadosCurso[0][3]);
				$turma = htmlspecialchars($dadosCurso[0][4]);
				$tipo = htmlspecialchars($dadosCurso[0][5]);
				$id_instituicao = htmlspecialchars($dadosCurso[0][6]);

				//Pegando instituicoes

				$etecs = implode(",", $dados->getInstituicoes());

				$comando = $conexao->prepare("SELECT id_instituicao, nome_instituicao FROM instituicao WHERE id_instituicao IN($etecs)");

				$comando->execute();

				$dados = $comando->fetchAll();

				foreach($dados as $valor){
					$cod = htmlspecialchars($valor[0]);
					$nome = htmlspecialchars($valor[1]);

					if($cod == $id_instituicao){
						$instituicoes .= "<option value='$cod' selected>$nome</option>";
					}else{
						$instituicoes .= "<option value='$cod'>$nome</option>";
					}
				}
			}else{
				header("location: instituicoes.php");
			}
		}catch(Exception $ex){
			header("location: instituicoes.php");
		}
	}else{
		header("location: instituicoes.php");
	}
	
?>

<!DOCTYPE html>
<html lang="pt-br">
<head>
	<title><?php echo Info::$nomeSistema ?> - Editar Turma</title>
	<meta charset="utf-8">
	<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">

	<script src="./scripts/jquery.min.js"></script>
	<script src="./scripts/MaskaraJquery/jquery.mask.js"></script>
	<script src="./scripts/editaCurso.js"></script>
	<script src="https://www.google.com/recaptcha/api.js" async defer></script>

	<link rel="stylesheet" type="text/css" href="./css/fontawesome-free-5.12.1-web/css/all.min.css">
	<link rel="stylesheet" type="text/css" href="./css/fontawesome-free-5.12.1-web/css/brands.min.css">
	<link rel="stylesheet" type="text/css" href="./css/fontawesome-free-5.12.1-web/css/solid.min.css">
	<link rel="stylesheet" type="text/css" href="./css/fontawesome-free-5.12.1-web/css/svg-with-js.min.css">
	<link rel="stylesheet" type="text/css" href="./css/fontawesome-free-5.12.1-web/css/regular.min.css">
	<link rel="stylesheet" type="text/css" href="./css/fontawesome-free-5.12.1-web/css/v4-shims.min.css">
	<link rel="shortcut icon" type="image/jpg" <?php echo "href='".Info::$logoSistema."'" ?> sizes="50x50">

	<link rel="stylesheet" type="text/css" href="./css/config.css">
	<link rel="stylesheet" type="text/css" href="./css/cadUsuarios.css">
</head>
<body>

	<section id='MoldalAviso'></section>

	<!--Moldal de Loading-->

	<section id="moldalLoading">
		<div></div>
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

			<input type="hidden" name="codCurso" <?php echo "value='$codigoC'"; ?>>

			<div class="inputs" id="input2" style="padding: 20px;">

				<div class="divide">
					
					<div>
						<div class="inputFlexContainer">
							<input type="text" name="nome" placeholder="Nome" class="inputV" maxlength="40" <?php echo "value='$nomeC'"; ?>>
						</div>

						<br><span class="spanAlerta">Digite o nome</span><br><br>
					</div>

					<div>
						<div class="inputFlexContainer">
							<input type="text" name="turma" placeholder="Turma" class="inputV" maxlength="1" onkeyup="transformaMaisucula(this)" <?php echo "value='$turma'"; ?>>
						</div>

						<br><span class="spanAlerta">Digite a turma</span><br><br>
					</div>

				</div>

				<div>
					<div>
						<div class="inputFlexContainer">
							<input type="number" name="moduloSerie" placeholder="Módulo/Série" class="inputV" min="1" max="9" <?php echo "value='$moduloSerie'"; ?>>
						</div>

						<br><span class="spanAlerta">Digite o módulo/série</span><br><br>
					</div>
				</div>

				<div class="divide">
					<div>
						<fieldset><legend>Periodo</legend>
							<select name="periodo">
								<?php

									if($periodo == "M"){
										echo "<option value='M' selected>Manhã</option>
											  <option value='T'>Tarde</option>
											  <option value='N'>Noite</option>
											  <option value='I'>Integral</option>";
									}else if($periodo == "T"){
										echo "<option value='M'>Manhã</option>
											  <option value='T' selected>Tarde</option>
											  <option value='N'>Noite</option>
											  <option value='I'>Integral</option>";
									}else if($periodo == "N"){
										echo "<option value='M'>Manhã</option>
											  <option value='T'>Tarde</option>
											  <option value='N' selected>Noite</option>
											  <option value='I'>Integral</option>";
									}else{
										echo "<option value='M'>Manhã</option>
											  <option value='T'>Tarde</option>
											  <option value='N'>Noite</option>
											  <option value='I' selected>Integral</option>";
									}

								?>
							</select>
						</fieldset>

						<br><br><br>
					</div>
					<div>
						<div>
							<fieldset><legend>Tipo</legend>
								<select name="tipo">
									<?php

										if($tipo == "EM"){
											echo "<option value='EM' selected>Ensino Médio(EM)</option>
												  <option value='ETIM'>Ensino técnico integrado ao médio(ETIM)</option>
												  <option value='MOD'>Modular(MOD)</option>
												  <option value='NOV'>Novotec(NOV)</option>";
										}else if($tipo == "ETIM"){
											echo "<option value='EM'>Ensino Médio(EM)</option>
												  <option value='ETIM' selected>Ensino técnico integrado ao médio(ETIM)</option>
												  <option value='MOD'>Modular(MOD)</option>
												  <option value='NOV'>Novotec(NOV)</option>";
										}else if($tipo == "MOD"){
											echo "<option value='EM'>Ensino Médio(EM)</option>
												  <option value='ETIM'>Ensino técnico integrado ao médio(ETIM)</option>
												  <option value='MOD' selected>Modular(MOD)</option>
												  <option value='NOV'>Novotec(NOV)</option>";
										}else{
											echo "<option value='EM'>Ensino Médio(EM)</option>
												  <option value='ETIM'>Ensino técnico integrado ao médio(ETIM)</option>
												  <option value='MOD'>Modular(MOD)</option>
												  <option value='NOV' selected>Novotec(NOV)</option>";
										}

									?>	
								</select>
							</fieldset>
						</div>

						<br><br><br>
					</div>
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

				<div style="overflow: hidden;">
					<div class="g-recaptcha" <?php echo "data-sitekey='$codChaveDiv'"; ?>></div>
				</div>
			</div>

			<div id="btnCad">
				<input type="submit" value="Salvar Edições" onclick="executaCadastro()">
			</div>

		</form>
	</section>

	<!--Botão para ajuda-->

	<a href="ajuda.php#EditaTurma"><div id="btnhelp" title="Ajuda" style="bottom: 40px"><i class="fas fa-question"></i></div></a>

	<footer><h5><?php echo Info::$copyright; ?></h5></footer>

</body>
</html>