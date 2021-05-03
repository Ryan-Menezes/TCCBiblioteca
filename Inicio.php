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
	<title><?php echo Info::$nomeSistema ?> - Inicio</title>
	<meta charset="utf-8">
	<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">

	<script src="./scripts/jquery.min.js"></script>
	<script type="text/javascript" src="./scripts/SubMenus.js"></script>
	<script type="text/javascript" src="./scripts/Menu.js"></script>
	<script type="text/javascript" src="./scripts/audio.js"></script>
	<script type="text/javascript" src="./scripts/moldalMsg.js"></script>
	<script type="text/javascript" src="./scripts/telaInicial.js"></script>
	<script type="text/javascript" src="./scripts/carregaListaInicio.js"></script>

	<link rel="stylesheet" type="text/css" href="./css/fontawesome-free-5.12.1-web/css/all.min.css">
	<link rel="stylesheet" type="text/css" href="./css/fontawesome-free-5.12.1-web/css/brands.min.css">
	<link rel="stylesheet" type="text/css" href="./css/fontawesome-free-5.12.1-web/css/solid.min.css">
	<link rel="stylesheet" type="text/css" href="./css/fontawesome-free-5.12.1-web/css/svg-with-js.min.css">
	<link rel="stylesheet" type="text/css" href="./css/fontawesome-free-5.12.1-web/css/regular.min.css">
	<link rel="stylesheet" type="text/css" href="./css/fontawesome-free-5.12.1-web/css/v4-shims.min.css">
	<link rel="shortcut icon" type="image/jpg" <?php echo "href='".Info::$logoSistema."'" ?> sizes="50x50">

	<link rel="stylesheet" type="text/css" href="./css/config.css">
	<link rel="stylesheet" type="text/css" href="./css/TelaInicial.css">

	<style type="text/css">
		#MoldalLivros .livrosM{
			padding-top: 150px;
		}
		.subMenuOp{
			width: 100%;
			overflow: hidden;
		}
		#menu{
			box-shadow: none;
			z-index: 99999999;
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

	<nav id="menuB">
		<ul>
			<li class="liB" style="border-bottom: 5px solid #4287f5" onclick="funSubMenu(0)">Inicio</li>
			<li class="liB" onclick="funSubMenu(1)">Gêneros</li>
			<li class="liB" onclick="funSubMenu(2)">Listas</li>
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
					echo "<a href='Inicio.php'><li id='MarcadoItem'><i class='fas fa-home'></i> Inicio</li></a>
						  <a href='dados.php'><li><i class='fas fa-user'></i> Dados Pessoais</li></a>
						  <a href='meuslivros.php'><li><i class='fas fa-book-open'></i> Meus Livros</li></a>
						  <a href='minhalista.php'><li><i class='fas fa-list'></i> Minha Lista</li></a>
						  <a href='livros.php'><li><i class='fas fa-book'></i> Livros</li></a>
						  <a href='alunos.php'><li><i class='fas fa-users'></i> Alunos</li></a>
						  <a href='professores.php'><li><i class='fas fa-user-tie'></i> Professores</li></a>
						  <a href='funcionarios.php'><li><i class='fas fa-user-circle'></i> Funcionários</li></a>
						  <a href='instituicoes.php'><li><i class='fas fa-school'></i> Cursos da Instituição</li></a>
						  <a href='alocacoes.php'><li><i class='fas fa-location-arrow'></i> Alocações</li></a>
						  <a href='sair.php'><li><i class='fas fa-sign-out-alt'></i> Sair</li></a>";
				}else{
					echo "<a href='Inicio.php'><li id='MarcadoItem'><i class='fas fa-home'></i> Inicio</li></a>
						  <a href='dados.php'><li><i class='fas fa-user'></i> Dados Pessoais</li></a>
						  <a href='meuslivros.php'><li><i class='fas fa-book-open'></i> Meus Livros</li></a>
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

	<a href="ajuda.php#Inicio"><div id="btnhelp" title="Ajuda"><i class="fas fa-question"></i></div></a>

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

	<section class="subMenuOp">
		<section id="Carrosseis">

			
				<?php
					try{
						$comando = $conexao->prepare("SELECT l.cod_livro, l.titulo, l.img_livro, l.idioma, (SELECT AVG(avaliacao_estrelas) FROM avaliacao WHERE livro_tombo_avaliacao = l.cod_livro) FROM livro AS l LEFT JOIN avaliacao AS a ON l.cod_livro = a.livro_tombo_avaliacao GROUP BY l.cod_livro ORDER BY (SELECT AVG(avaliacao_estrelas) FROM avaliacao WHERE livro_tombo_avaliacao = l.cod_livro) DESC LIMIT 10");

						$comando->execute();

						$dados = $comando->fetchAll();

						$i = 1;

						if(count($dados) > 0){
							echo "<div class='TituloC'>
									<h2>Top 10</h2>
								</div>

								<div class='container'>
									<div class='btnLivro back' onclick='back(0)'><i class='fas fa-angle-left'></i></div>

									<section class='carrosselLivros' id='carrossel0'>
										<ul id='carro0'>";

							foreach($dados as $value) {
								$codigo = htmlspecialchars($value[0]);
								$titulo = htmlspecialchars($value[1]);
								$img = base64_encode($value[2]);
								$idioma = htmlspecialchars($value[3]);
								$avaliacao = (strlen(htmlspecialchars($value[4])) > 0) ? htmlspecialchars($value[4]) : 0;

								$avaliacao = number_format($avaliacao, 1);

								$tituloCompleto = htmlspecialchars($value[1]);

								if(strlen($titulo) > 16){
									$titulo = substr($titulo, 0, 16) . "...";
								}

								echo "<a href='telaLivro.php?cod_livro=$codigo'><li>
										<div class='number'>$i</div>
										<img src='data:image/jpg;base64,$img'>

										<div class='infoLivroInicio'>
											<h5 title='$tituloCompleto'>$titulo</h5><br>
											$avaliacao <i class='fas fa-star'></i> | $idioma <i class='fas fa-language'></i>
										</div>
									</li></a>";

								$i++;
							}

							echo "</ul>
									</section>

									<div class='btnLivro frente' onclick='frente(0)'><i class='fas fa-angle-right'></i></div>
								</div>";
						}else{
							echo "<h4 style='text-align: center; color: white; padding: 40px;'>Não há livros cadastrados no sistema</h4>
								 <div style='
											padding: 10px; 
											width: 40px; 
											height: 40px; 
											border-radius: 50%; 
											background-color: white;
											display: flex; 
											align-items: center; 
											justify-content: center;
											margin: auto;
											margin-top: 40px;
											font-size: 50px;
											color: #4287f5;
								'><i class='fas fa-sad-tear'></i></div> ";
						}
					}catch(PDOException $ex){
						//Erros
					}
				?>
					
		</section>	
		<div class="loading" onclick="carregaLivrosCarro(this)" id="carregarMaisCarro"></div>
	</section>

	<section class="subMenuOp" style="display: none;">
		<section id="generos">
			<?php

				$comando = $conexao->prepare("SELECT * FROM genero ORDER BY nome_genero");

				$comando->execute();

				$dados = $comando->fetchAll();

				if(count($dados) > 0){
					foreach($dados as $value) {
						$codigo = htmlspecialchars($value[0]);
						$nome = htmlspecialchars($value[1]);

						echo "<a href='generosInicio.php?cod_genero=$codigo'>
								  <div>
									<div><p>$nome</p></div>
								  </div>
							  </a>";
					}
				}else{
					echo "<div style='grid-column: 3/1'>
							<h4 style='text-align: center; color: white; padding: 40px;'>Não há genêros cadastrados no sistema</h4>
							<main style='
								padding: 10px; 
								width: 40px; 
								height: 40px; 
								border-radius: 50%; 
								background-color: white;
								display: flex; 
								align-items: center; 
								justify-content: center;
								margin: auto;
								margin-top: 40px;
								font-size: 50px;
								color: #4287f5;
						'><i class='fas fa-sad-tear'></i></main></div>";
				}

			?>
		</section>
	</section>

	<section class="subMenuOp" style="display: none;">
		<section id="containerListas">
			<div class="divInputPesq">
				<input type="text" placeholder="Pesquisar lista..." onchange="pesquisaListaInicio()">
			</div>

			<main class="listasUsuarios">
				<div style='width: 200px; display: flex; align-items: center; justify-content: center;'>
					<div class="loading"></div>
				</div>	
			</main>
		</section>
	</section>

	<script type="text/javascript" src="./scripts/MenuItens.js"></script>
</body>
</html>