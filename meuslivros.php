<?php
	include_once "conexao.php";
	include_once "Usuario.php";
	include_once "dadosSistema.php";
	include_once "enviaNotificacaoDeAtraso.php";
	include_once "verificaTempoSessao.php";
	if(!isset($_SESSION)) session_start();

	$conexao = conexao::getConexao();

	if(!isset($_SESSION["usuario"])){
		header("location: index.php");
	}

	$dados = $_SESSION["usuario"];

	$nivelAcesso = $dados->getNivelAcesso();
?>

<!DOCTYPE html>
<html lang="pt-br">
<head>
	<title><?php echo Info::$nomeSistema ?> - Meus Livros</title>
	<meta charset="utf-8">
	<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">

	<script src="./scripts/jquery.min.js"></script>
	<script type="text/javascript" src="./scripts/Menu.js"></script>
	<script type="text/javascript" src="./scripts/audio.js"></script>
	<script type="text/javascript" src="./scripts/moldalMsg.js"></script>
	<script type="text/javascript" src="./scripts/meuslivros.js"></script>

	<link rel="stylesheet" type="text/css" href="./css/fontawesome-free-5.12.1-web/css/all.min.css">
	<link rel="stylesheet" type="text/css" href="./css/fontawesome-free-5.12.1-web/css/brands.min.css">
	<link rel="stylesheet" type="text/css" href="./css/fontawesome-free-5.12.1-web/css/solid.min.css">
	<link rel="stylesheet" type="text/css" href="./css/fontawesome-free-5.12.1-web/css/svg-with-js.min.css">
	<link rel="stylesheet" type="text/css" href="./css/fontawesome-free-5.12.1-web/css/regular.min.css">
	<link rel="stylesheet" type="text/css" href="./css/fontawesome-free-5.12.1-web/css/v4-shims.min.css">
	<link rel="shortcut icon" type="image/jpg" <?php echo "href='".Info::$logoSistema."'" ?> sizes="50x50">	

	<link rel="stylesheet" type="text/css" href="./css/config.css">
	<link rel="stylesheet" type="text/css" href="./css/telas.css">

	<style type="text/css">
		
		#principal .ferramentas{
			display: grid;
			grid-template-columns: 1fr;
		}

	</style>
</head>
<body>

	<section id='MoldalAviso'></section>

	<section id="moldalLoading">
		<div></div>
	</section>

	<section id="MoldalLivros">	
		<div class="livrosM">
			<button onclick="fechaMoldalLivroPesquisa()">&times;</button>

			<input type="text" placeholder="Pesquisar livro..." class="pesqLivro" onkeyup="copiaTexto(this)">

			<select id="tipoPesquisaLivro" onchange="defineTipoPesquisa()">
				<option value="T">Todos</option>
				<option value="F">Livros Fisicos</option>
				<option value="P">Livros em PDF</option>
			</select>

			<section id="dadosPesquisados">
				<div class="loading"></div>
			</section>
		</div>
	</section>

	<nav id="menu">
		<ul>
			<li id="mn"><span onclick="abrirMenu()">&#9776;</span></li>
			<li id="barraPesquisa">
				<input type="text" name="barraPesquisa" class="barra" id="barra" placeholder="Pesquisar livro..." onkeyup="copiaTexto(this)">
				<div title="Pesquisar" class="textPesq" onclick="pesquisarLivroI()"><i class="fas fa-search"></i></div>
				<div title="Pesquisar por voz" id="microfonePesq"><i class="fas fa-microphone"></i></div>
			</li>
			<li id="imgInicial">
				<?php

					echo "<a href='". Info::$siteEtec ."' target='_blank'><img title='". Info::$nomeEtec ."' src='". Info::$logoEtec ."'></a>
						  <a href='Inicio.php'><img title='". Info::$nomeSistema ."' src='". Info::$logoSistema ."'></a>
						  <a href='". Info::$siteCentro ."' target='_blank'><img title='". Info::$nomeCentro ."' src='". Info::$logoCentro ."'></a>";

				?>
			</li>
		</ul>
	</nav>

	<nav id="menu2">
		<div>
			<span title="Fechar Menu" onclick="fechaMenu()">&times;</span>
			<?php
				echo "<img src='data:image/jpg;base64,{$dados->getImg()}'>";
				echo "<p>{$dados->getNome()}  {$dados->getSobrenome()}</p>";
			?>
		</div>
		<ul>
			<?php

				if($nivelAcesso == "A"){
					echo "<a href='Inicio.php'><li><i class='fas fa-home'></i> Inicio</li></a>
						  <a href='dados.php'><li><i class='fas fa-user'></i> Dados Pessoais</li></a>
						  <a href='meuslivros.php'><li id='MarcadoItem'><i class='fas fa-book-open'></i> Meus Livros</li></a>
						  <a href='minhalista.php'><li><i class='fas fa-list'></i> Minha Lista</li></a>
						  <a href='livros.php'><li><i class='fas fa-book'></i> Livros</li></a>
						  <a href='alunos.php'><li><i class='fas fa-users'></i> Alunos</li></a>
						  <a href='professores.php'><li><i class='fas fa-user-tie'></i> Professores</li></a>
						  <a href='funcionarios.php'><li><i class='fas fa-user-circle'></i> Funcionários</li></a>
						  <a href='instituicoes.php'><li><i class='fas fa-school'></i> Cursos da Instituição</li></a>
						  <a href='alocacoes.php'><li><i class='fas fa-location-arrow'></i> Alocações</li></a>
						  <a href='sair.php'><li><i class='fas fa-sign-out-alt'></i> Sair</li></a>";
				}else{
					echo "<a href='Inicio.php'><li><i class='fas fa-home'></i> Inicio</li></a>
						  <a href='dados.php'><li><i class='fas fa-user'></i> Dados Pessoais</li></a>
						  <a href='meuslivros.php'><li id='MarcadoItem'><i class='fas fa-book-open'></i> Meus Livros</li></a>
						  <a href='minhalista.php'><li><i class='fas fa-list'></i> Minha Lista</li></a>
						  <a href='sair.php'><li><i class='fas fa-sign-out-alt'></i> Sair</li></a>";
				}

			?>
		</ul><br><br>
	</nav>

	<!--Moldal que exibirá o microfone-->

	<section id="MoldalVoz">
		
		<div class="containerMicro">
			
			<div><i class="fas fa-microphone"></i></div>

			<h4>Estou te ouvindo...</h4>

		</div>

	</section>

	<!--Moldal que exibirá as mensagens do usuário-->

	<section class="MoldalMensagens">
		<section class="telas">
			<div class="fechaMoldalMsg" onclick="fechaMoldalMsg(0)">&times;</div>

			<header>
				<div>
					<img <?php echo "src='". Info::$logoSistema ."'" ?>>
					<h5><?php echo Info::$nomeSistema; ?> - Mensagens</h5>
				</div>

				<div>
					<?php

						echo "<img title='". Info::$nomeEtec ."' src='". Info::$logoEtec ."'>
						      <img title='". Info::$nomeCentro ."' src='". Info::$logoCentro ."'>";

					?>
				</div>
			</header>
			
			<section class="tabelaMsg">
				<table>
			
					<thead>
						<tr>
							<th>Data</th>
							<th>Titulo</th>
							<th>Situação</th>
							<th class="columnOp">Opções</th>
						</tr>
					</thead>
					<tbody id='tbodyMsgAviso'>
						<tr id="trMsgLoading">
							<td colspan="4"><button class="loading"></button></td>
						</tr>
					</tbody>
				</table>
			</section>
		</section>
	</section>

	<section class="MoldalMensagens">
		<section class="telas" id="MoldalMensagensView">
			<div class="fechaMoldalMsg" onclick="fechaMoldalMsg(1)">&times;</div>

			<header>
				<div>
					<img <?php echo "src='". Info::$logoSistema ."'" ?>>
					<h5><?php echo Info::$nomeSistema; ?> - Mensagens</h5>
				</div>

				<div>
					<?php

						echo "<img title='". Info::$nomeEtec ."' src='". Info::$logoEtec ."'>
						      <img title='". Info::$nomeCentro ."' src='". Info::$logoCentro ."'>";

					?>
				</div>
			</header>
			
			<section class="tabelaMsg" id="itensMsg"></section>
		</section>
	</section>

	<!--Botão para ajuda-->

	<a href="ajuda.php#MeusLivros"><div id="btnhelp" title="Ajuda"><i class="fas fa-question"></i></div></a>

	<!--Sino de notificação-->

	<div id="sinoNotificacao" title="Notificações">
		<?php
			$cod = $dados->getCodUsuario();

			$comando = $conexao->prepare("SELECT * FROM avisos WHERE id_usuario_avisos = :id AND situacao = 'N'");

			$comando->bindParam(":id", $cod);

			$comando->execute();

			$dadoMsg = $comando->fetchAll();

			if(count($dadoMsg) > 0 && count($dadoMsg) <= 99){
				echo "<div>".count($dadoMsg)."</div>";
			}else if(count($dadoMsg) > 99){
				echo "<div>+99</div>";
			}
		?>
		
		<i class="fas fa-bell"></i>
	</div>

	<section id="principal">
		
		<div class="ferramentas">
			
			<div><input type="text" placeholder="Pesquisar livro..." id="pesqLivroMeu" onchange="pesquisaLivro()"><button><i class='fas fa-search'></i></button></div>

		</div>

		<section style="overflow: auto;">
			<table>	
				<thead>	
					<tr>
						<th>Capa</th>
						<th>Titulo</th>
						<th>Instituição</th>
						<th>Data Alocação</th>
						<th>Data Devolução</th>
						<th>Situação</th>
					</tr>
				</thead>

				<tbody id="tbodyAlocacoes">
					<tr id='carregarMaisTable'>
						<td colspan='6'><button class='loading'></button></td>
					</tr>
				</tbody>
			</table>
		</section><br><br>

		<fieldset><legend>Situação</legend>
			<div class="situa">
				<div style="border-right: 2px solid gray">
					<div class="dgreen"></div>
					Normal
				</div>
				<div style="margin-left: 10px;">
					<div class="dred"></div>
					Atrasado
				</div>
			</div>
		</fieldset>

	</section>

</body>
</html>