<?php
	include_once "Usuario.php";
	include_once "codigosRecaptcha.php";
	include_once "dadosSistema.php";
	if(!isset($_SESSION)) session_start();

	if(isset($_SESSION["usuario"])){
		header("location: Inicio.php");
	}
?>

<!DOCTYPE html>
<html lang="pt-br">
<head>
	<title><?php echo Info::$nomeSistema ?> - Login</title>

	<script src="./scripts/jquery.min.js"></script>
	<script src="./scripts/MaskaraJquery/jquery.mask.js"></script>
	<script type="text/javascript" src="./scripts/recaptcha.js"></script>
	<script type="text/javascript" src="./scripts/login.js"></script>
	

	<link rel="stylesheet" type="text/css" href="./css/fontawesome-free-5.12.1-web/css/all.min.css">
	<link rel="stylesheet" type="text/css" href="./css/fontawesome-free-5.12.1-web/css/brands.min.css">
	<link rel="stylesheet" type="text/css" href="./css/fontawesome-free-5.12.1-web/css/solid.min.css">
	<link rel="stylesheet" type="text/css" href="./css/fontawesome-free-5.12.1-web/css/svg-with-js.min.css">
	<link rel="stylesheet" type="text/css" href="./css/fontawesome-free-5.12.1-web/css/regular.min.css">
	<link rel="stylesheet" type="text/css" href="./css/fontawesome-free-5.12.1-web/css/v4-shims.min.css">
	<link rel="shortcut icon" type="image/jpg" <?php echo "href='".Info::$logoSistema."'" ?> sizes="50x50">

	<link rel="stylesheet" type="text/css" href="./css/login.css">

	<meta charset="utf-8">
	<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">

	<style type="text/css">
		footer a{
			text-decoration: none;
			color: white;
		}
		footer h4:hover{
			color: #1374ba;
		}
	</style>
</head>
<body>
	<?php

		if(isset($_SESSION["msg"])){
			$msg = $_SESSION["msg"];

			if($msg != "Senha alterada com sucesso" && $msg != "Um link foi enviado para seu E-mail"){
				echo "<section id='MoldalAviso'>
						<main>
							<div class='containeAv'>
								<div>
									<h4>$msg</h4>
								</div>
								<div>
									<i class='fas fa-times-circle'></i>
								</div>
							</div>
							<hr>
							<button onclick='deletaMoldal()'>OK</button>
						</main>
					</section>";
			}else{
				echo "<section id='MoldalAviso'>
						<main>
							<div class='containeAv'>
								<div>
									<h4>$msg</h4>
								</div>
								<div>
									<i class='fas fa-check-circle'></i>
								</div>
							</div>
							<hr>
							<button onclick='deletaMoldal()'>OK</button>
						</main>
					</section>";
			}
			

			unset($_SESSION["msg"]);
		}

	?>

	<!--Moldal de Loading-->

	<section id="moldalLoading">
		<div></div>
	</section>

	<!--Moldal de Trocar a senha-->

	<section class="Moldal">
		<section>
			<div id="imagemLateral">
				<br><br>
				<div class="cadeado" style="margin: auto; margin-bottom: 50px;">
					<img draggable="false" src="./Imagens/cadeado.svg" width="45" height="45">
				</div>
			</div>
			<form action="enviaEmail.php" method="post" name="formTrocaSenha">
				<button id="btnFechaMoldal" onclick="fechaMoldal()">&times;</button>

				<section>
					<main>
						<input type="number" name="rmTroca" id="rmTroca" placeholder="RM" required><br>
					</main>
					<main>
						<fieldset><legend>Enviar como:</legend>
						    <select name="entrada" onchange="selecionaEntradaMoldal(this)">
							    <option value="0" selected>Aluno</option>
							   	<option value="1">Professor</option>
							    <option value="2">Funcionário</option>
						    </select>
						</fieldset>
					</main>
					<main style="overflow: hidden;">
						<div class="g-recaptcha" <?php echo "data-sitekey='$codChaveDiv'"; ?>></div>
					</main>
				</section>	

				<section>
			    	<input type="submit" value="Enviar">
				</section>
			</form>
		</section>
	</section>

	<section id="principal">
		<header>
			<?php echo "<img title='". Info::$nomeSistema ."' src='". Info::$logoSistema ."'>" ?>
			<h4><?php echo Info::$nomeSistema; ?> - Login</h4>
			<?php

				echo "<a href='". Info::$siteEtec ."' target='_blank'><img title='". Info::$nomeEtec ."' src='". Info::$logoEtec ."'></a>
					  <a href='". Info::$siteCentro ."' target='_blank'><img title='". Info::$nomeCentro ."' src='". Info::$logoCentro ."'></a>";

			?>
		</header>

		<form action="verificaLogin.php" method="post" name="formLogin" id="formLogin" onsubmit="return verifica()">
			<div id="tela">
				<div class="cadeado">
					<img  src="./Imagens/cadeado.svg" width="45" height="45">
				</div>
			</div>
			<div id="inputs">
				<div>

					<div class="cadeado" style="margin: auto; margin-bottom: 50px;">
						<img draggable="false" src="./Imagens/cadeado.svg" width="45" height="45">
					</div>

					<label class="in">
						<div style="display: grid; grid-template-columns: 30px 1fr">
							<i class="fas fa-key"></i>							
							<input class="inputsV" id="rm" type="number" name="rm" placeholder="RM" min="1" max="999999999999" onkeyup="limpa(0)" onchange="limpa(0)">
						</div>
				    </label>

					<br><span class="SpanAlerta">Digite o RA<br></span><br>

					<label class="in" id="inputSenha">
						<div style="display: grid; grid-template-columns: 30px 1fr 20px;">
							<i class="fas fa-lock"></i>
							<input id="senha" class="inputsV" type="password" name="senha" placeholder="Senha" onkeyup="limpa(1)">
							<span><i class="fas fa-eye" onclick="verSenha(this)"></i></span>
						</div>
				    </label>

				    <br><span class="SpanAlerta">Digite a senha</span><br><br>

				    <main>
				    	<div style="overflow: hidden;">
							<div class="g-recaptcha" <?php echo "data-sitekey='$codChaveDiv'"; ?>></div>
						</div>

				    	<div class="entrarC">
				    		<fieldset><legend>Entrar como:</legend>
						    	<select name="entrada" onchange="selecionaEntrada(this)">
							    	<option value="0" selected>Aluno</option>
							    	<option value="1">Professor</option>
							    	<option value="2">Funcionário</option>
							    </select>
						    </fieldset>
				    	</div>
				    </main>

				</div>

				<div id="baixo">
					<br><br><p>Esqueceu sua senha? <a href="javascript: void(0)" onclick="abrirMoldal()">clique aqui</a></p>
					<input type="submit" value="Logar">
				</div>
			</div>

			<section style="clear: left;"></section>
		</form>

		<footer><h5><a href="info.php"><?php echo Info::$copyright; ?></a><h5></footer>
	</section>
</body>
</html>