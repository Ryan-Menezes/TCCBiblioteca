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
	<title><?php echo Info::$nomeSistema ?> - Alocar Livros</title>
	<meta charset="utf-8">
	<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">

	<script src="./scripts/jquery.min.js"></script>
	<script src="./scripts/MaskaraJquery/jquery.mask.js"></script>
	<script src="./scripts/carregaLivroAlocacao.js"></script>
	<script src="./scripts/cadastroAlocacao.js"></script>
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

	<style type="text/css">
		.selectIn{
			display: flex;
			align-items: center;
			padding: 25px;
		}
		.selectIn select{
			width: 150px;
			padding: 8px;
			border: none;
			border-radius: 3px;
			outline: none;
			background-color: #1c1c1b;
			color: white;
		}
	</style>
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

			<div class="fechaMoldalOpcoes" onclick="fechaMoldal()">&times;</div>

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
			
			<section style="grid-template-rows: 70px 30px 1fr">
				<main>
					<input type="text" name="textPesquisa" placeholder="Pesquisar livro..." onchange="pesquisaLivro(this)">
					<button><i class='fas fa-search'></i></button>
				</main>

				<div class="selectIn">
					<select name="instituicoes" id="instituicoes" onchange="selecionaInstituicao()">
						<?php echo $instituicoesOP; ?>
					</select>
				</div>

				<table>
					<thead>
						<tr>
							<th>Capa</th>
							<th>Titulo</th>
							<th>Exemplares Disponíveis</th>
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

	<nav id="menu">
		<ul>
			<li id="mn"><a href="javascript: history.go(-1)"><span><i class="fas fa-arrow-left"></i></span></a> <h5>Alocações</h5></li>
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
				<div class="divide">
					<div>
						<div>
							<fieldset class="inputFlexContainer"><legend>Data da Alocação</legend>
								<input type="date" name="dataAlocacao">
							</fieldset>
						</div>

						<br><br><br>
					</div>

					<div>
						<div>
							<fieldset class="inputFlexContainer"><legend>Data da Devolução</legend>
								<input type="date" name="dataDevolucao">
							</fieldset>
						</div>

						<br><br><br>
					</div>
				</div>

				<div>
					<div class="inputComBTN">
						<select class="inputV" size="5" id="livrosSelecionados"></select>
						<button class="btnAbreMoldal" onclick="abreMoldal(0)">Adicionar Livro</button>

						<input type="hidden" name="livros" id="livrosCodigos">
					</div>
					<br><span class="spanAlerta">Selecione pelo menos um livro para alocar</span><br><br>
				</div>

				<div>
					<fieldset><legend>Tipo de usuário</legend>
						<select name="tipoUser" onchange="selecionaTipo(this)">
							<option value="A">Aluno</option>
							<option value="P">Professor</option>
							<option value="F">Funcionário</option>
						</select>
					</fieldset>

					<br><br><br>
				</div>
				
				<div>
					<div class="inputFlexContainer">
						<input type="text" name="rmCpf" placeholder="RM" id="rmCpf" class="inputV">
					</div>

					<br><span class="spanAlerta">Digite o RM</span><br><br>
				</div>

				<div style="overflow: hidden;">
					<div class="g-recaptcha" <?php echo "data-sitekey='$codChaveDiv'"; ?>></div>
				</div>
			</div>

			<div id="btnCad">
				<input type="submit" name="btnCadLivro" value="Cadastrar Alocação" onclick="cadastraAlocacao()">
			</div>
		</form>
	</section>

	<!--Botão para ajuda-->

	<a href="ajuda.php#CadAlocacao"><div id="btnhelp" title="Ajuda" style="bottom: 40px"><i class="fas fa-question"></i></div></a>

	<footer><h5><?php echo Info::$copyright; ?></h5></footer>

</body>
</html>