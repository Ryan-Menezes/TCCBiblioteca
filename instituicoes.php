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

		foreach($dados as $valor){
			$cod = htmlspecialchars($valor[0]);
			$nome = htmlspecialchars($valor[1]);

			$instituicoes .= "<option value='$cod'>$nome</option>";
		}
	}catch(Exception $ex){
		
	}

?>

<!DOCTYPE html>
<html lang="pt-br">
<head>
	<title><?php echo Info::$nomeSistema ?> - Cursos da Instituição</title>
	<meta charset="utf-8">
	<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">

	<script src="./scripts/jquery.min.js"></script>
	<script type="text/javascript" src="./scripts/Menu.js"></script>
	<script type="text/javascript" src="./scripts/audio.js"></script>
	<script type="text/javascript" src="./scripts/moldalMsg.js"></script>
	<script type="text/javascript" src="./scripts/controleCursoInstituicao.js"></script>

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

	<style type="text/css">

		#principal .ferramentas main{
			display: grid;
			grid-template-columns: 177px 177px;
		}
		#principal .ferramentas{
			display: grid;
			grid-template-columns: 1fr 354px;
		}
		#principal .ferramentas select{
			outline: none;
			color: white;
			background-color: #1c1c1b;
			border: none;
			border-radius: 3px;
			margin-left: 15px;
		}
		@media(max-width: 950px){
			#principal .ferramentas{
				grid-template-columns: 1fr;
				grid-row-gap: 30px;
			}
		}
		@media(max-width: 550px){
			#principal .ferramentas main{
				grid-template-columns: 177px;
			}
			#principal .ferramentas select{
				margin: 0;
				padding: 8px;
				width: 170px;
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
			<a href='alunos.php'><li><i class='fas fa-users'></i> Alunos</li></a>
			<a href='professores.php'><li><i class='fas fa-user-tie'></i> Professores</li></a>
			<a href='funcionarios.php'><li><i class='fas fa-user-circle'></i> Funcionários</li></a>
			<a href='instituicoes.php'><li id='MarcadoItem'><i class='fas fa-school'></i> Cursos da Instituição</li></a>
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

	<a href="ajuda.php#CursosInstituicao"><div id="btnhelp" title="Ajuda"><i class="fas fa-question"></i></div></a>

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

			<div class="fechaMoldalOp" onclick="fechaMoldalSenha()">&times;</div>

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
						<input type="submit" value="Deletar Turma" onclick="excluirCurso()">
					<div>

				</form>
			</section>
			
		</section>
	</section>

	<!--Tela Visivel-->

	<section id="principal">
		
		<div class="ferramentas">
			
			<div><input type="text" placeholder="Pesquisar curso..." id="pesquisaInput" onchange="pesquisaCurso()"><button><i class='fas fa-search'></i></button></div>

			<main>
				<a href="cadCurso.php"><button id="cadastro">Cadastrar Curso <i class='fas fa-chalkboard-teacher'></i></button></a>
				<select id="instituicaoSelecionada" onchange="selecionaInstituicao()">
					<?php
						echo $instituicoes;
					?>
				</select>
			</main>
			
		</div>

		<section style="overflow: auto; display: flex; flex-direction: column;">
			
			<table>
				<thead>	
					<tr>
						<th>Nome</th>
						<th>Módulo/Série</th>
						<th>Periodo</th>
						<th>Turma</th>
						<th>Tipo</th>
						<th>Instituição</th>
						<th>Opções</th>
					</tr>
				</thead>

				<tbody id="dadosCarregados">
					<tr id="carregarMaisTable">
						<td colspan="7"><button class="loading"></button></td>
					</tr>
				</tbody>
			</table>

		</section>
		
	</section>

</body>
</html>