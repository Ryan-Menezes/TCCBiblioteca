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
?>

<!DOCTYPE html>
<html lang="pt-br">
<head>
	<title><?php echo Info::$nomeSistema ?> - Ajuda</title>
	<meta charset="utf-8">
	<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">

	<script src="./scripts/jquery.min.js"></script>

	<link rel="stylesheet" type="text/css" href="./css/fontawesome-free-5.12.1-web/css/all.min.css">
	<link rel="stylesheet" type="text/css" href="./css/fontawesome-free-5.12.1-web/css/brands.min.css">
	<link rel="stylesheet" type="text/css" href="./css/fontawesome-free-5.12.1-web/css/solid.min.css">
	<link rel="stylesheet" type="text/css" href="./css/fontawesome-free-5.12.1-web/css/svg-with-js.min.css">
	<link rel="stylesheet" type="text/css" href="./css/fontawesome-free-5.12.1-web/css/regular.min.css">
	<link rel="stylesheet" type="text/css" href="./css/fontawesome-free-5.12.1-web/css/v4-shims.min.css">
	<link rel="shortcut icon" type="image/jpg" <?php echo "href='".Info::$logoSistema."'" ?> sizes="50x50">

	<link rel="stylesheet" type="text/css" href="./css/config.css">
	<link rel="stylesheet" type="text/css" href="./css/generosInicio.css">	

	<style type="text/css">
		html{
			scroll-behavior: smooth;
		}
		#containerPrincipal{
			width: 1200px;
			padding-top: 100px;
			display: grid;
			grid-template-columns: 250px 1fr;
			margin: auto;
		}
		#containerPrincipal nav{
			width: 250px;
			overflow: auto;
			position: fixed;
			height: 85%;
			left: 20px;
			top: 80px;
			scrollbar-color: #383838 #121111;
		}
		#containerPrincipal nav::-webkit-scrollbar{
			width: 8px;
			background-color: #121111;
			border-radius: 5px;
		}
		#containerPrincipal nav::-webkit-scrollbar-thumb{
			background-color: #383838;
			border-radius: 5px;
		}
		#containerPrincipal nav ul li{
			display: block;
		}
		#containerPrincipal nav ul li div{
			height: 30px;
			display: flex;
			align-items: center;
			padding-left: 10px;
			padding-right: 10px;
			border-right: 4px solid #242222;
			transition-duration: 0.3s;
		}
		#containerPrincipal nav ul li div:hover{
			border-right: 4px solid #4287f5;
			background-color: #1c1c1c;
		}
		#containerPrincipal nav ul li div i{
			margin-right: 10px;
		}
		#containerPrincipal .MarcadoItemAjuda{
			border-right: 4px solid #4287f5;
		}
		#containerPrincipal .containers h2{
			color: white;
		}
		#containerPrincipal .containers p{
			color: white;
			margin-top: 50px;
		}
		#containerPrincipal .containers img{
			width: 100%;
			margin-top: 50px;
			cursor: -webkit-grab;
			cursor: -moz-grab;
			cursor: -ms-grab;
			border-radius: 5px;
		}
		#containerPrincipal nav ul li ul{
			margin-left: 30px;
			font-size: 13px;
		}
		#moldalImg{
			position: fixed;
			width: 100%;
			height: 100%;
			background-color: rgba(0, 0, 0, 0.9);
			z-index: 99999999;
			display: flex;
			align-items: center;
			justify-content: center;
			display: none;
		}
		#moldalImg main{
			width: 1000px;
			position: relative;
		}
		#moldalImg main div{
			position: absolute;
			width: 40px;
			height: 40px;
			border-radius: 50%;
			color: white;
			background-color: #870707;
			display: flex;
			align-items: center;
			justify-content: center;
			font-size: 20px;
			cursor: pointer;
			top: -25px;
			right: -25px;
			transition-duration: 0.3s;
		}
		#moldalImg main div:hover{
			transform: scale(1.1);
		}
		#moldalImg main img{
			width: 100%;
			border-radius: 5px;
			box-shadow: 0px 0px 5px #121111;
		}
		#containerPrincipal hr{
			border: 1px solid #242222;
		}

		/*Responsividade*/

		@media(max-width: 1150px){
			#containerPrincipal{
				width: 1000px;
			}
			#moldalImg main{
				width: 700px;
			}
		}
		@media(max-width: 1100px){
			#containerPrincipal{
				width: 95%;
				grid-template-columns: 300px 1fr;
			}
		}
		@media(max-width: 850px){
			#containerPrincipal .containers h2{
				font-size: 14px;
			}
			#containerPrincipal .containers p{
				font-size: 12px;
			}
			#containerPrincipal nav{
				font-size: 12px;
			}
			#containerPrincipal{
				grid-template-columns: 270px 1fr;
			}
		}
		@media(max-width: 800px){
			#moldalImg main{
				width: 500px;
			}
		}
		@media(max-width: 650px){
			#containerPrincipal{
				padding-top: 0;
			}
			#containerPrincipal nav{
				position: relative;
				width: 95%;
				height: auto;
			}
			#containerPrincipal{
				grid-template-columns: 1fr;
			}
			#containerPrincipal #containerAjuda{
				margin-top: 150px;
			}
		}
		@media(max-width: 600px){
			#moldalImg main{
				width: 400px;
			}
		}
		@media(max-width: 480px){
			#moldalImg main{
				width: 300px;
			}
			#moldalImg main div{
				width: 30px;
				height: 30px;
				top: -15px;
				right: -15px;
			}
		}
	</style>
</head>
<body>

	<section id="moldalImg">
		<main>
			<div onclick="abreFechaMoldalImagem(null)">&times;</div>
			<img src="">
		</main>
	</section>

	<nav id="menu">
		<ul>
			<li id="mn"><a href="javascript: history.go(-1)"><span><i class="fas fa-arrow-left"></i></span></a> <h5>Voltar</h5></li>
			<li id="imgInicial">
				<?php

					echo "<a href='". Info::$siteEtec ."' target='_blank'><img title='". Info::$nomeEtec ."' src='". Info::$logoEtec ."'></a>
						  <a href='Inicio.php'><img title='". Info::$nomeSistema ."' src='". Info::$logoSistema ."'></a>
						  <a href='". Info::$siteCentro ."' target='_blank'><img title='". Info::$nomeCentro ."' src='". Info::$logoCentro ."'></a>";

				?>
			</li>
		</ul>
	</nav>

	<section id="containerPrincipal">

		<nav>
			<ul>
				<li>
					<a href='#Inicio'><div class="divsMenu"><i class='fas fa-home'></i> In??cio</div></a>
					<ul>
						<li><a href='#TelaLivro'><div class="divsMenu"><i class='fas fa-book'></i> Tela sobre informa????es do livro</div></a></li>
					</ul>
				</li>
				<li><a href='#Dados'><div class="divsMenu"><i class='fas fa-user'></i> Dados Pessoais</div></a></li>
				<li><a href='#MeusLivros'><div class="divsMenu"><i class='fas fa-book-open'></i> Meus Livros</div></a></li>
				<li><a href='#MinhaLista'><div class="divsMenu"><i class='fas fa-list'></i> Minha Lista</div></a></li>

				<?php

					if($nivelAcesso == "A"){

				?>

				<li>
					<a href='#Livro'><div class="divsMenu"><i class='fas fa-book'></i> Livros</div></a>
					<ul>
						<li><a href='#CadLivro'><div class="divsMenu"><i class='fas fa-book'></i> Cadastro/Edi????o livros</div></a></li>
						<li><a href='#AdicionarExemplares'><div class="divsMenu"><i class='fas fa-plus-circle'></i> Adicionar exemplares</div></a></li>
						<li><a href='#CadLivroPDF'><div class="divsMenu"><i class='fas fa-file-pdf'></i> Cadastro/Edi????o de livros PDF</div></a></li>
						<li><a href='#ExportarExemplares'><div class="divsMenu"><i class='fas fa-file-export'></i> Exportar Exemplares</div></a></li>
					</ul>
				</li>
				<li>
					<a href='#Alunos'><div class="divsMenu"><i class='fas fa-users'></i> Alunos</div></a>
					<ul>
						<li><a href='#CadAluno'><div class="divsMenu"><i class='fas fa-user'></i> Cadastro/Edi????o</div></a></li>
					</ul>
				</li>
				<li>
					<a href='#Professores'><div class="divsMenu"><i class='fas fa-user-tie'></i> Professores</div></a>
					<ul>
						<li><a href='#CadProfessor'><div class="divsMenu"><i class='fas fa-user'></i> Cadastro/Edi????o</div></a></li>
					</ul>
				</li>
				<li>
					<a href='#Funcionario'><div class="divsMenu"><i class='fas fa-user-circle'></i> Funcion??rios</div></a>
					<ul>
						<li><a href='#CadFuncionario'><div class="divsMenu"><i class='fas fa-user'></i> Cadastro/Edi????o</div></a></li>
					</ul>
				</li>
				<li>
					<a href='#CursosInstituicao'><div class="divsMenu"><i class='fas fa-school'></i> Cursos da Institui????o</div></a>
					<ul>
						<li><a href='#CadCurso'><div class="divsMenu"><i class='fas fa-chalkboard-teacher'></i> Cadastro</div></a></li>
						<li><a href='#EditaTurma'><div class="divsMenu"><i class='fas fa-pencil-alt'></i> Edi????o</div></a></li>
					</ul>
				</li>
				<li>
					<a href='#Alocacoes'><div class="divsMenu"><i class='fas fa-location-arrow'></i> Aloca????es</div></a>
					<ul>
						<li><a href='#CadAlocacao'><div class="divsMenu"><i class='fas fa-book'></i> Alocar</div></a></li>
						<li><a href='#EditAlocacao'><div class="divsMenu"><i class='fas fa-pencil-alt'></i> Edi????o</div></a></li>
					</ul>
				</li>
				<li>
					<a href='#Relatorios'><div class="divsMenu"><i class='fas fa-file'></i> Relat??rios</div></a>
				</li>

				<?php

					}

				?>
			</ul>
		</nav>

		<div></div>

		<section id="containerAjuda">
			
			<section id="Inicio" class="containers">
				
				<h2>1 - In??cio</h2>

				<p>Esta ?? a primeira tela apresentada logo ap??s o usu??rio ter feito o login.</p>

				<img src="./Imagens/help/Inicio.jpg" onclick="abreFechaMoldalImagem(this)">

			</section>

			<br><br><hr><br><br>

			<section id="TelaLivro" class="containers">
				
				<h2>1.2 - Tela sobre informa????es do livro</h2>

				<p>NPara conseguir mais informa????es sobre algum livro encontrado o usu??rio dependendo da tela onde o encontrou pode se redirecionar para uma tela com mais informa????es do mesmo, e por ali ele pode ver avalia????es de outros usu??rios e fazer a sua pr??pria avalia????o.</p>

				<img src="./Imagens/help/TelaLivro.jpg" onclick="abreFechaMoldalImagem(this)">
				<img src="./Imagens/help/TelaLivro2.jpg" onclick="abreFechaMoldalImagem(this)">

			</section>

			<br><br><hr><br><br>

			<section id="Dados" class="containers">
				
				<h2>2 - Dados Pessoais</h2>

				<p>Esta tela serve para exibir os dados de cadastro do usu??rio logado.</p>

				<img src="./Imagens/help/Dados.jpg" onclick="abreFechaMoldalImagem(this)">

			</section>

			<br><br><hr><br><br>

			<section id="MeusLivros" class="containers">
				
				<h2>3 - Meus Livros</h2>

				<p>O usu??rio pode verificar quais livros ele alocou para leitura e quais destes mesmos livros ele est?? devendo a biblioteca.</p>

				<img src="./Imagens/help/MeusLivros.jpg" onclick="abreFechaMoldalImagem(this)">

			</section>

			<br><br><hr><br><br>

			<section id="MinhaLista" class="containers">
				
				<h2>4 - Minha Lista</h2>

				<p>Qualquer usu??rio pode ter uma lista de seus livros favoritos, onde outros usu??rios podem dar uma olhada em busca de algo novo para ler, al??m disso cada usu??rio ger??ncia sua pr??pria lista.</p>

				<img src="./Imagens/help/MinhaLista.jpg" onclick="abreFechaMoldalImagem(this)">

			</section>

			<br><br>

			<?php

				if($nivelAcesso == "A"){

			?>

			<hr><br><br>

			<section id="Livro" class="containers">
				
				<h2>5 - Livros</h2>

				<p>Na tela abaixo o usu??rio administrador pode gerenciar todos os livros de sua institui????o, onde por ali ele pode cadastrar, editar, excluir, emitir relat??rios e etc.</p>

				<img src="./Imagens/help/Livro.jpg" onclick="abreFechaMoldalImagem(this)">

			</section>

			<br><br><hr><br><br>

			<section id="CadLivro" class="containers">
				
				<h2>5.1 - Cadastro/Edi????o livros</h2>

				<p>Abaixo est?? o formul??rio de cadastro dos livros com c??pias fis??cas e digitais(PDF), vale lembrar que a tela de edi????o do livro ?? id??ntica a de cadastro.</p>

				<img src="./Imagens/help/CadLivro.jpg" onclick="abreFechaMoldalImagem(this)">
				<img src="./Imagens/help/CadLivro2.jpg" onclick="abreFechaMoldalImagem(this)">
				<img src="./Imagens/help/CadLivro3.jpg" onclick="abreFechaMoldalImagem(this)">

			</section>

			<br><br><hr><br><br>

			<section id="AdicionarExemplares" class="containers">
				
				<h2>5.2 - Adicionar exemplares</h2>

				<p>Existem casos em que j?? existe o cadastro de um certo livro, por??m somente algumas institui????es tem o poder de editar os exemplares desse livro, pelo fato desses exemplares estarem associados a essas mesmas institui????es, portanto caso alguma outra institui????o queira cadastrar mais exemplares deste mesmo livro e associar esses novos exemplares a si, ela pode adiciona-los, assim reaproveitando o cadastro deste livro e somente adicionando novos exemplares a si mesma.</p>

				<img src="./Imagens/help/AdicionarExemplares.jpg" onclick="abreFechaMoldalImagem(this)">

			</section>

			<br><br><hr><br><br>

			<section id="CadLivroPDF" class="containers">
				
				<h2>5.3 - Cadastro/Edi????o de livros PDF</h2>

				<p>A tela de cadastro do livro PDF ?? a mesma para edi????o, portanto todo o processo mostrado abaixo se repete em ambas as partes, ?? importante afirmar que um livro cadastrado somente com um PDF dispon??vel, ele n??o tem tombo pelo fato de n??o possuir exemplares e tamb??m n??o tem ISBN.</p>

				<img src="./Imagens/help/CadLivroPDF.jpg" onclick="abreFechaMoldalImagem(this)">
				<img src="./Imagens/help/CadLivroPDF2.jpg" onclick="abreFechaMoldalImagem(this)">

			</section>

			<br><br><hr><br><br>

			<section id="ExportarExemplares" class="containers">
				
				<h2>5.4 - Exportar Exemplares</h2>

				<p>Esta tela somente ficar?? dispon??vel quando houver mais de uma institui????o cadastrada no sistema, Nessa tela voc?? poder?? exportar exemplares de algum livro em sua institui????o para outra.</p>

				<img src="./Imagens/help/ExportarExemplares.jpg" onclick="abreFechaMoldalImagem(this)">

			</section>

			<br><br><hr><br><br>

			<section id="Alunos" class="containers">
				
				<h2>6 - Alunos</h2>

				<p>Na tela abaixo o usu??rio administrador pode gerenciar todos os alunos de sua institui????o, onde por ali ele pode cadastrar, editar, excluir, emitir relat??rios e etc.</p>

				<img src="./Imagens/help/Alunos.jpg" onclick="abreFechaMoldalImagem(this)">

			</section>

			<br><br><hr><br><br>

			<section id="CadAluno" class="containers">
				
				<h2>6.1 - Cadastro/Edi????o</h2>

				<p>Abaixo est?? o formul??rio de cadastro dos alunos, vale lembrar que a tela de edi????o do aluno ?? id??ntica a de cadastro.</p>

				<img src="./Imagens/help/CadAluno.jpg" onclick="abreFechaMoldalImagem(this)">
				<img src="./Imagens/help/CadAluno2.jpg" onclick="abreFechaMoldalImagem(this)">

			</section>

			<br><br><hr><br><br>

			<section id="Professores" class="containers">
				
				<h2>7 - Professores</h2>

				<p>Na tela abaixo o usu??rio administrador pode gerenciar todos os professores de sua institui????o, onde por ali ele pode cadastrar, editar, excluir, emitir relat??rios e etc.</p>

				<img src="./Imagens/help/Professores.jpg" onclick="abreFechaMoldalImagem(this)">

			</section>

			<br><br><hr><br><br>

			<section id="CadProfessor" class="containers">
				
				<h2>7.1 - Cadastro/Edi????o</h2>

				<p>Abaixo est?? o formul??rio de cadastro dos professores, vale lembrar que a tela de edi????o do professor ?? id??ntica a de cadastro.</p>

				<img src="./Imagens/help/CadProfessor.jpg" onclick="abreFechaMoldalImagem(this)">
				<img src="./Imagens/help/CadProfessor2.jpg" onclick="abreFechaMoldalImagem(this)">

			</section>

			<br><br><hr><br><br>

			<section id="Funcionario" class="containers">
				
				<h2>8 - Funcion??rios</h2>

				<p>Na tela abaixo o usu??rio administrador pode gerenciar todos os funcion??rios de sua institui????o, onde por ali ele pode cadastrar, editar, excluir, emitir relat??rios e etc, vale lembrar que um funcion??rio n??o possui um RM, portanto quem ?? cadastrado como funcion??rio no sistema b??sicamente s??o aqueles que n??o possuem cadastro no NSA.</p>

				<img src="./Imagens/help/Funcionario.jpg" onclick="abreFechaMoldalImagem(this)">

			</section>

			<br><br><hr><br><br>

			<section id="CadFuncionario" class="containers">
				
				<h2>8.1 - Cadastro/Edi????o</h2>

				<p>Abaixo est?? o formul??rio de cadastro dos funcion??rios, vale lembrar que a tela de edi????o do funcion??rio ?? id??ntica a de cadastro.</p>

				<img src="./Imagens/help/CadFuncionario.jpg" onclick="abreFechaMoldalImagem(this)">
				<img src="./Imagens/help/CadFuncionario2.jpg" onclick="abreFechaMoldalImagem(this)">

			</section>

			<br><br><hr><br><br>

			<section id="CursosInstituicao" class="containers">
				
				<h2>9 - Cursos da Institui????o</h2>

				<p>Na tela abaixo o usu??rio administrador pode gerenciar todos as turmas de v??rios cursos de sua institui????o, onde por ali ele pode cadastrar, editar, excluir, emitir relat??rios e etc.</p>

				<img src="./Imagens/help/CursosInstituicao.jpg" onclick="abreFechaMoldalImagem(this)">

			</section>

			<br><br><hr><br><br>

			<section id="CadCurso" class="containers">
				
				<h2>9.1 - Cadastro</h2>

				<p>Abaixo est?? o formul??rio de cadastro dos cursos, onde nessa mesma tela o administrador tamb??m j?? cadastra todas as turmas relacionadas a este curso.</p>

				<img src="./Imagens/help/CadCurso.jpg" onclick="abreFechaMoldalImagem(this)">
				<img src="./Imagens/help/CadCurso2.jpg" onclick="abreFechaMoldalImagem(this)">

			</section>

			<br><br><hr><br><br>

			<section id="EditaTurma" class="containers">
				
				<h2>9.2 - Edi????o</h2>

				<p>Direrente do cadastro do curso, na hora de editar o usu??rio administrador s?? pode editar as turmas daquele curso, caso ele delete todas as turmas de um certo curso, automaticamente este curso tamb??m ser?? deletado.</p>

				<img src="./Imagens/help/EditaTurma.jpg" onclick="abreFechaMoldalImagem(this)">

			</section>

			<br><br><hr><br><br>

			<section id="Alocacoes" class="containers">
				
				<h2>10 - Aloca????es</h2>

				<p>Na tela abaixo o usu??rio administrador pode gerenciar todas as aloca????es de sua institui????o, onde por ali ele pode alocar, editar, excluir, emitir relat??rios e etc.</p>

				<img src="./Imagens/help/Alocacoes.jpg" onclick="abreFechaMoldalImagem(this)">

			</section>

			<br><br><hr><br><br>

			<section id="CadAlocacao" class="containers">
				
				<h2>10.1 - Cadastro</h2>

				<p>Diferente da tela de cadastro de aloca????es, na hora de editar alguma aloca????o o usu??rio administrador s?? pode editar a data de devolu????o.</p>

				<img src="./Imagens/help/CadAlocacao.jpg" onclick="abreFechaMoldalImagem(this)">
				<img src="./Imagens/help/CadAlocacao2.jpg" onclick="abreFechaMoldalImagem(this)">

			</section>

			<br><br><hr><br><br>

			<section id="EditAlocacao" class="containers">
				
				<h2>10.2 - Edi????o</h2>

				<p>Diferente da tela de cadastro de aloca????es, na hora de editar alguma aloca????o o usu??rio administrador s?? pode editar a data de devolu????o.</p>

				<img src="./Imagens/help/EditAlocacao.jpg" onclick="abreFechaMoldalImagem(this)">
				<img src="./Imagens/help/EditAlocacao2.jpg" onclick="abreFechaMoldalImagem(this)">

			</section>

			<br><br><hr><br><br>

			<section id="Relatorios" class="containers">
				
				<h2>11 - Relat??rios</h2>

				<p>Para gerar um relat??rio segue o mesmo procedimento abaixo:</p>

				<img src="./Imagens/help/Relatorio.jpg" onclick="abreFechaMoldalImagem(this)">

			</section>

			<br><br>

			<?php

				}

			?>

		</section>
		
	</section>

	<script type="text/javascript">
		
		function abreFechaMoldalImagem(img){
			if(img != null){
				window.document.querySelector("#moldalImg img").src = img.src
				window.document.getElementById('moldalImg').style.display = "flex"
			}else{
				window.document.querySelector("#moldalImg img").src = ""
				window.document.getElementById('moldalImg').style.display = "none"
			}
		}

		function verificaScroll(){
			var divsMenu = window.document.getElementsByClassName('divsMenu')
			var containers = window.document.getElementsByClassName('containers')

			for(let i in divsMenu){
				let container = containers[i]
				let div = divsMenu[i]
				let scroll = document.documentElement.scrollTop

				if(container && div){
					if(scroll >= container.offsetTop){
						limpaDivis()
						div.classList.add("MarcadoItemAjuda")
					}
				}
			}
		}

		function limpaDivis(){
			var divsMenu = window.document.getElementsByClassName('divsMenu')

			for(let div of divsMenu){
				div.classList.remove("MarcadoItemAjuda")
			}
		}

		window.onscroll = function(){
			verificaScroll()
		}

	</script>

</body>
</html>