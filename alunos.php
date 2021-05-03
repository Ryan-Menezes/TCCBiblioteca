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
	$cursos = null;

	try{
		//Pegando instituicoes

		$etecs = implode(",", $dadosUser->getInstituicoes());

		$comando = $conexao->prepare("SELECT id_instituicao, nome_instituicao FROM instituicao WHERE id_instituicao IN($etecs)");

		$comando->execute();

		$dados = $comando->fetchAll();

		$inst = $dados[0][0];

		foreach($dados as $valor){
			$cod = htmlspecialchars($valor[0]);
			$nome = htmlspecialchars($valor[1]);

			$instituicoes .= "<option value='$cod'>$nome</option>";
		}

		//Pegando cursos

		$comando = $conexao->prepare("SELECT * FROM curso WHERE id_instituicao_curso = $inst ORDER BY nome_curso");

		$comando->execute();

		$dados = $comando->fetchAll();

		foreach($dados as $valor){
			$codigo = htmlspecialchars($valor[0]);
			$nome = htmlspecialchars($valor[1]);
			$moduloSerie = htmlspecialchars($valor[2]);
			$periodo = null;

			if (htmlspecialchars($valor[3]) == "M") $periodo = "Manhã";
			else if (htmlspecialchars($valor[3]) == "T") $periodo = "Tarde";
			else if (htmlspecialchars($valor[3]) == "N") $periodo = "Noite";
			else $periodo = "Integral";
			
			$turma = htmlspecialchars($valor[4]);

			$cursos .= "<option value='$codigo'>$nome - $moduloSerie º Módulo/Série $turma | $periodo</option>";
		}
	}catch(Exception $ex){

	}

?>

<!DOCTYPE html>
<html lang="pt-br">
<head>
	<title><?php echo Info::$nomeSistema ?> - Alunos</title>
	<meta charset="utf-8">
	<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">

	<script src="./scripts/jquery.min.js"></script>
	<script type="text/javascript" src="./scripts/Menu.js"></script>
	<script type="text/javascript" src="./scripts/audio.js"></script>
	<script type="text/javascript" src="./scripts/moldalMsg.js"></script>
	<script type="text/javascript" src="./scripts/controleAluno.js"></script>

	<link rel="stylesheet" type="text/css" href="./css/fontawesome-free-5.12.1-web/css/all.min.css">
	<link rel="stylesheet" type="text/css" href="./css/fontawesome-free-5.12.1-web/css/brands.min.css">
	<link rel="stylesheet" type="text/css" href="./css/fontawesome-free-5.12.1-web/css/solid.min.css">
	<link rel="stylesheet" type="text/css" href="./css/fontawesome-free-5.12.1-web/css/svg-with-js.min.css">
	<link rel="stylesheet" type="text/css" href="./css/fontawesome-free-5.12.1-web/css/regular.min.css">
	<link rel="stylesheet" type="text/css" href="./css/fontawesome-free-5.12.1-web/css/v4-shims.min.css">
	<link rel="shortcut icon" type="image/jpg" <?php echo "href='".Info::$logoSistema."'" ?> sizes="50x50">

	<link rel="stylesheet" type="text/css" href="./css/config.css">
	<link rel="stylesheet" type="text/css" href="./css/telas.css">
	<link rel="stylesheet" type="text/css" href="./css/usuarios.css">

	
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
							<option value="R">RM</option>
							<option value="C">CPF</option>
							<option value="N" selected>Nome</option>
						</select>
					</fieldset>


					<fieldset><legend>Status</legend>
						<select id="statusOP">
							<option value="T" selected>Todos</option>
							<option value="B">Bloqueado</option>
							<option value="D">Desbloqueado</option>
						</select>
					</fieldset>

					<fieldset><legend>Sexo</legend>
						<select id="sexoOP">
							<option value="T" selected>Todos</option>
							<option value="M">Masculino</option>
							<option value="F">Feminino</option>
							<option value="O">Outros</option>
						</select>
					</fieldset>

					<fieldset><legend>Instituição</legend>
						<select id="instituicaoOP" onchange="selecionaInstituicao(this)">
							<?php
								echo $instituicoes;
							?>
						</select>
					</fieldset>

					<fieldset><legend>Turma</legend>
						<select id="cursosOP">
							<option value="T" selected>Todas</option>
							<?php
								echo $cursos;
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
		    <a href='livros.php'><li><i class='fas fa-book'></i> Livros</li></a>
			<a href='alunos.php'><li id='MarcadoItem'><i class='fas fa-users'></i> Alunos</li></a>
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

	<!--Moldal para enviar mensagem-->

	<section class="MoldalMensagens">
		<section class="telas" id="MoldalMensagensView">
			<div class="fechaMoldalMsg" onclick="fechaMoldalMsg(2)">&times;</div>

			<header>
				<div>
					<img <?php echo "src='". Info::$logoSistema ."'" ?>>
					<h5><?php echo Info::$nomeSistema; ?> - Enviar Mensagem</h5>
				</div>

				<div>
					<?php

						echo "<img title='". Info::$nomeEtec ."' src='". Info::$logoEtec ."'>
						      <img title='". Info::$nomeCentro ."' src='". Info::$logoCentro ."'>";

					?>
				</div>
			</header>
			
			<section class="tabelaMsg" id="itensMsg">
				<main>
					<div class='dadosRemetente' id="dadosRemetenteAviso"></div>
					<br>
					<form action='javascript: void(0)'>
						<input type="text" name="titulo" placeholder="Titulo" id="tituloAviso"><br><br>
						<textarea name="msgUserAviso" placeholder="Mensagem" id="textBoxMensagem"></textarea>
						<input type="hidden" id="codUsuarioAviso">

						<input type="submit" value="Enviar mensagem" onclick="enviaMensagem()">
					</form>
				</main>
			</section>
		</section>
	</section>

	<!--Botão para ajuda-->

	<a href="ajuda.php#Alunos"><div id="btnhelp" title="Ajuda"><i class="fas fa-question"></i></div></a>

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
						<input type="submit" value="Deletar Aluno" onclick="excluirAluno()">
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

				<table>
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
							<th><input type="checkbox" class="checkboxTable" value="15" checked></th>
							<th><input type="checkbox" class="checkboxTable" value="16" checked></th>
						</tr>
						<tr class="thHeader">
							<th colspan="3">
								<?php 
									echo "<img src='". Info::$logoEtec ."'>
										  <img src='". Info::$logoSistema ."'>
										  <img src='". Info::$logoCentro ."'>";
								?>
							</th>
							<th colspan="16">
								<input type="text" name="tituloRelatorio" placeholder="Titulo" id="tituloRelatorio">
							</th>
						</tr>
						<tr>
							<th>Foto</th>
							<th>RM</th>
							<th>Nome</th>
							<th>CPF</th>
							<th>Sexo</th>
							<th>Data do Cadastro</th>
							<th>Status</th>
							<th>Telefone</th>
							<th>Celular</th>
							<th>E-Mail</th>
							<th>CEP</th>
							<th>Logradouro</th>
							<th>Número</th>
							<th>Bairro</th>
							<th>Cidade</th>
							<th>Complemento</th>
							<th>Curso(s)</th>
						</tr>
					</thead>
					
					<tbody id="tbodyRelatorio"></tbody>
				</table>
				
			</section>

			<footer>
				<span>*Não serão incluidas imagens nos relatórios salvos como .xls(Excel)</span><br><br>

				<form action="geraPDF.php" method="POST" target="_blank" onsubmit="return geraPDF()">
					<input type="submit" name="enviaPDF" id="enviaPDF" style="display: none;">
					<input type="hidden" name="tipo" value="1">
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

	<!--Tela Visivel-->

	<section id="principal">
		
		<div class="ferramentas">
			
			<div><input type="text" placeholder="Pesquisar aluno..." id="pesquisaInput" onchange="pesquisaAluno()"><button><i class='fas fa-search'></i></button></div>

			<main>
				<button id="relatorio" onclick="abreMoldalRelatorio()">Emitir Relatório <i class='fas fa-file'></i></button>
				<a href="cadAluno.php"><button id="cadastro">Cadastrar Aluno <i class='fas fa-user'></i></button></a>
				<button id="filtro" onclick="abreMoldalFiltro()">Selecionar Filtro <i class='fas fa-search'></i></button>
			</main>
		</div>

		<section style="overflow: auto;">
			<table>
			
				<thead>	
					<tr>
						<th>Seleção</th>
						<th>Foto</th>
						<th>RM</th>
						<th>Nome</th>
						<th>CPF</th>
						<th>Data do Cadastro</th>
						<th>Sexo</th>
						<th>Status</th>
						<th>Opções</th>
					</tr>
				</thead>

				<tbody id="dadosCarregados" class="dadoInfo">
					<tr id="carregarMaisTable">
						<td colspan="12"><button class="loading"></button></td>
					</tr>
				</tbody>

			</table>
		</section>

	</section>

</body>
</html>