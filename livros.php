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

	$dadosUser = $_SESSION["usuario"];

	$nivelAcesso = $dadosUser->getNivelAcesso();

	if($nivelAcesso != "A"){
		header("location: index.php");
	}

	//Código acima - verificação de login

	$instituicoes = null;
	$generos = "<option value='T'>Todos</option>";

	try{
		//Pegando instituicoes

		$etecs = implode(",", $dadosUser->getInstituicoes());

		$comando = $conexao->prepare("SELECT id_instituicao, nome_instituicao FROM instituicao WHERE id_instituicao IN($etecs)");

		$comando->execute();

		$dados = $comando->fetchAll();

		foreach($dados as $valor){
			$cod = htmlspecialchars($valor[0]);
			$nome = htmlspecialchars($valor[1]);

			$instituicoes .= "<option value='$cod'>$nome</option>";
		}

		//Pegando os generos

		$comando = $conexao->prepare("SELECT * FROM genero");

		$comando->execute();

		$dados = $comando->fetchAll();

		foreach($dados as $valor){
			$cod = htmlspecialchars($valor[0]);
			$nome = htmlspecialchars($valor[1]);

			$generos .= "<option value='$cod'>$nome</option>";
		}

	}catch(Exception $ex){
		$instituicoes = null;
		$generos = "<option value='T'>Todos</option>";
	}

?>

<!DOCTYPE html>
<html lang="pt-br">
<head>
	<title><?php echo Info::$nomeSistema ?> - Livros</title>
	<meta charset="utf-8">
	<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">

	<script src="./scripts/jquery.min.js"></script>
	<script type="text/javascript" src="./scripts/Menu.js"></script>
	<script type="text/javascript" src="./scripts/audio.js"></script>
	<script type="text/javascript" src="./scripts/moldalMsg.js"></script>
	<script type="text/javascript" src="./scripts/controleLivro.js"></script>

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
		#opcoes{
			position: relative;
			height: 30px;
		}
		#opcoes li{
			display: block;
			position: relative;
		}
		#opcoes ul{
			width: 110%;
			position: absolute;
			height: 120px;
			background-color: #0a0a0a;
			border-radius: 3px;
			margin-left: -10%;
			box-shadow: 0px 0px 5px gray;
			margin-top: 15px;
			display: none;
			z-index: 99999;
		}
		#opcoes ul li{
			display: block;
			width: auto;
			height: 20px;
			background-color: #0a0a0a;
			color: white;
			padding: 10px;
			cursor: pointer;
			display: flex;
			align-items: center;
			justify-content: center;
			border-radius: 3px;
			position: relative;
			transition-duration: 0.3s;
			font-size: 12px;
		}
		#opcoes ul li:hover{
			background-color: #1a1a1a;
		}
		#opcoes ul li i{
			margin-right: 10px;
		}
		#opcoes button{
			width: 95%;
			height: 100%
		}
		#tbodyRelatorio td img{
			height: 40px;
			width: 25px;
			border-radius: 2px;
		}
		@media(max-width: 1100px){
			#principal table{
				width: 1200px;
			}
		}
	</style>
</head>
<body>

	<section id='MoldalAviso'></section>

	<!--Moldal de Loading-->

	<section id="moldalLoading">
		<div></div>
	</section>

	<!--Moldal de Opções-->

	<section class="MoldalOp">
		<section class="telas">

			<div class="fechaMoldalOp">&times;</div>

			<header>
				<div>
					<img <?php echo "src='". Info::$logoSistema ."'" ?>>
					<h5><?php echo Info::$nomeSistema; ?> - Filtro</h5>
				</div>

				<div>
					<?php

						echo "<img title='". Info::$nomeEtec ."' src='". Info::$logoEtec ."'>
						      <img title='". Info::$nomeCentro ."' src='". Info::$logoCentro ."'>";

					?>
				</div>
			</header>

			<section class="selectI">
				<form action="javascript: void(0)">
					<fieldset><legend>Pesquisa</legend>
						<select id="pesqOP">
							<option value="T" selected>Titulo</option>
							<option value="TO">Tombo</option>
							<option value="I">ISBN</option>
						</select>
					</fieldset>

					<fieldset><legend>Genêro</legend>
						<select id="generosOP">
							<?php

								echo $generos;

							?>
						</select>
					</fieldset>

					<fieldset><legend>Instituição</legend>
						<select id="instituicaoOP">
							<?php
								echo $instituicoes;
							?>
						</select>
					</fieldset>

					<div>
						<input type="submit" value="Definir Filtro" onclick="defineFiltro()">
					<div>

				</form>
			</section>
			
		</section>
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
				echo "<img src='data:image/jpg;base64,{$dadosUser->getImg()}'>";
				echo "<p>{$dadosUser->getNome()}  {$dadosUser->getSobrenome()}</p>";
			?>
		</div>
		<ul>
			<a href='Inicio.php'><li><i class='fas fa-home'></i> Inicio</li></a>
			<a href='dados.php'><li><i class='fas fa-user'></i> Dados Pessoais</li></a>
			<a href='meuslivros.php'><li><i class='fas fa-book-open'></i> Meus Livros</li></a>
			<a href='minhalista.php'><li><i class='fas fa-list'></i> Minha Lista</li></a>
		    <a href='livros.php'><li id="MarcadoItem"><i class='fas fa-book'></i> Livros</li></a>
			<a href='alunos.php'><li><i class='fas fa-users'></i> Alunos</li></a>
			<a href='professores.php'><li><i class='fas fa-user-tie'></i> Professores</li></a>
			<a href='funcionarios.php'><li><i class='fas fa-user-circle'></i> Funcionários</li></a>
			<a href='instituicoes.php'><li><i class='fas fa-school'></i> Cursos da Instituição</li></a>
			<a href='alocacoes.php'><li><i class='fas fa-location-arrow'></i> Alocações</li></a>
			<a href='sair.php'><li><i class='fas fa-sign-out-alt'></i> Sair</li></a>
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

	<a href="ajuda.php#Livro"><div id="btnhelp" title="Ajuda"><i class="fas fa-question"></i></div></a>

	<!--Sino de notificação-->

	<div id="sinoNotificacao" title="Notificações">
		<?php
			$cod = $dadosUser->getCodUsuario();

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

	<!--Moldal de senha-->

	<section class="MoldalOp">
		<section class="telas" style="height: 230px;">

			<div class="fechaMoldalOp">&times;</div>

			<header>
				<div>
					<img <?php echo "src='". Info::$logoSistema ."'" ?>>
					<h5><?php echo Info::$nomeSistema; ?> - Senha</h5>
				</div>

				<div>
					<?php

						echo "<img title='". Info::$nomeEtec ."' src='". Info::$logoEtec ."'>
						      <img title='". Info::$nomeCentro ."' src='". Info::$logoCentro ."'>";

					?>
				</div>
			</header>

			<section class="selectI">
				<form action="javascript: void(0)">

					<input type="password" name="senha" placeholder="Senha" id="inputSenha" onkeyup="limpaCampoSenha()">

					<br><br><span id="spanSenha">Digite sua senha</span><br><br>

					<div>
						<input type="submit" value="Deletar Livro" onclick="excluirLivro()">
					<div>

				</form>
			</section>
			
		</section>
	</section>

	<!--Moldal de relatório-->

	<section class="MoldalOp">
		<section class="telas relatorio">

			<div class="fechaMoldalOp">&times;</div>

			<header>
				<div>
					<img <?php echo "src='". Info::$logoSistema ."'" ?>>
					<h5><?php echo Info::$nomeSistema; ?> - Relatório</h5>
				</div>

				<div>
					<?php

						echo "<img title='". Info::$nomeEtec ."' src='". Info::$logoEtec ."'>
						      <img title='". Info::$nomeCentro ."' src='". Info::$logoCentro ."'>";

					?>
				</div>
			</header>

			<section class="selectI">

				<table style="width: 1300px;">
					<thead>
						<tr class="checkboxC">
							<th><input type="checkbox" class="checkboxTable" value="0" checked></th>
							<th><input type="checkbox" class="checkboxTable" value="1" checked></th>
							<th><input type="checkbox" class="checkboxTable" value="2" checked></th>
							<th><input type="checkbox" class="checkboxTable" value="3" checked></th>
							<th><input type="checkbox" class="checkboxTable" value="4" checked></th>
							<th><input type="checkbox" class="checkboxTable" value="5" checked></th>
							<th><input type="checkbox" class="checkboxTable" value="6" checked></th>
							<th><input type="checkbox" class="checkboxTable" value="7" checked></th>
							<th><input type="checkbox" class="checkboxTable" value="8" checked></th>
							<th><input type="checkbox" class="checkboxTable" value="9" checked></th>
							<th><input type="checkbox" class="checkboxTable" value="10" checked></th>
							<th><input type="checkbox" class="checkboxTable" value="11" checked></th>
							<th><input type="checkbox" class="checkboxTable" value="12" checked></th>
							<th><input type="checkbox" class="checkboxTable" value="13" checked></th>
							<th><input type="checkbox" class="checkboxTable" value="14" checked></th>
						</tr>
						<tr class="thHeader">
							<th colspan="2">
								<?php 
									echo "<img src='". Info::$logoEtec ."'>
										  <img src='". Info::$logoSistema ."'>
										  <img src='". Info::$logoCentro ."'>";
								?>
							</th>
							<th colspan="13">
								<input type="text" name="tituloRelatorio" placeholder="Titulo" id="tituloRelatorio">
							</th>
						</tr>
						<tr>
							<th>Capa</th>
							<th>Tombo</th>
							<th>Titulo</th>
							<th>Volume</th>
							<th>Edição</th>
							<th>Autor(es)</th>
							<th>Genêro(s)</th>
							<th>Editora(s)</th>
							<th>Total de exemplares</th>
							<th>Exemplares disponíveis</th>
							<th>Data de inserção</th>
							<th>Data de publicação</th>
							<th>ISBN</th>
							<th>Idioma</th>
							<th>Instituição</th>
						</tr>
					</thead>
					
					<tbody id="tbodyRelatorio"></tbody>
				</table>
				
			</section>

			<footer>
				<span>*Não serão incluidas imagens nos relatórios salvos como .xls(Excel)</span><br><br>

				<form action="geraPDF.php" method="POST" target="_blank" onsubmit="return geraPDF()">
					<input type="submit" name="enviaPDF" id="enviaPDF" style="display: none;">
					<input type="hidden" name="tipo" value="4">
					<input type="hidden" name="columns" id="columnsPDF">
					<input type="hidden" name="rows" id="rowsPDF">
					<input type="hidden" name="title" id="titlePDF">
					<input type="hidden" name="op" id="OP">
					<input type="hidden" name="tp" id="TP">

					<label for="enviaPDF"><button id="btnPdf"><i class='fas fa-file-pdf'></i><span> Salvar em PDF</span></button></label>
				</form>

				<button id="btnExcel" onclick="geraExcel()"><i class='fas fa-file-excel'></i><span> Salvar em Excel</span></button>
				<button id="btnImprimir" onclick="Imprimir()"><i class='fas fa-print'></i><span> Imprimir Documento</span></button>

				<fieldset><legend>Opções para o PDF:</legend>
					<select id="tamanhoPaper">
						<option value="A0">A0</option>
						<option value="A1">A1</option>
						<option value="A2">A2</option>
						<option value="A3">A3</option>
						<option value="A4" selected>A4</option>
						<option value="A5">A5</option>
						<option value="A6">A6</option>
						<option value="A7">A7</option>
						<option value="A8">A8</option>
						<option value="A9">A9</option>
						<option value="A10">A10</option>

						<option value="B0">B0</option>
						<option value="B1">B1</option>
						<option value="B2">B2</option>
						<option value="B3">B3</option>
						<option value="B4">B4</option>
						<option value="B5">B5</option>
						<option value="B6">B6</option>
						<option value="B7">B7</option>
						<option value="B8">B8</option>
						<option value="B9">B9</option>
						<option value="B10">B10</option>
					</select>
					<select id="orientacaoPaper">
						<option value="portrait" selected>Retrato</option>
						<option value="landscape">Paisagem</option>
					</select>
				</fieldset>
			</footer>
			
		</section>
	</section>

	<section id="principal">
		
		<div class="ferramentas">
			
			<div><input type="text" placeholder="Pesquisar livro..." id="pesquisaInput" onchange="pesquisaLivro()"><button><i class='fas fa-search'></i></button></div>

			<main>
				<button id="relatorio" onclick="abreMoldalRelatorio()">Emitir Relatório <i class='fas fa-file'></i></button>
				<ul id="opcoes">
					<li>
						<button id="cadastro">Opções livro <i class='fas fa-cog'></i></button>

						<ul id="menuOp">
							<a href="cadLivros.php"><li><i class='fas fa-book'></i> Cadastrar novo livro</li></a>
							<a href="adicionaExemplares.php"><li><i class='fas fa-plus-circle'></i> Adicionar exemplares</li></a>
							<a href="cadLivrosPDF.php"><li><i class='fas fa-file-pdf'></i> Cadastrar novo livro PDF</li></a>
						</ul>
					</li>
				</ul>
				
				<button id="filtro" onclick="abreMoldalFiltro()">Selecionar Filtro <i class='fas fa-search'></i></button>
			</main>
		</div>

		<section style="overflow: auto;">
			<table>
			
				<thead>	
					<tr>
						<th>Seleção</th>
						<th>Capa</th>
						<th>Tombo</th>
						<th>Titulo</th>
						<th>Autor(es)</th>
						<th>Genêro(s)</th>
						<th>Exemplares Disponíveis</th>
						<th>Data de Inserção</th>
						<th>ISBN</th>
						<th>Opções</th>
					</tr>
				</thead>

				<tbody id="dadosCarregados">
					<tr id="carregarMaisTable">
						<td colspan="12"><button class="loading"></button></td>
					</tr>
				</tbody>

			</table>
		</section>
		

	</section>

	<script type="text/javascript">

		//Função para abrir o menu

		window.document.getElementById('cadastro').addEventListener("click", function(){
			let obj = window.document.getElementById("menuOp")

			if(obj.style.display == "block"){
				obj.style.display = "none"
			}else{
				obj.style.display = "block"
			}
		})

	</script>

</body>
</html>