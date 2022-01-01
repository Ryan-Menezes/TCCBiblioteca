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

	$cursosU = null;
	$dadosA = null;

	if(isset($_GET["codA"])){
		try{
			$codigo = trim(addslashes($_GET["codA"]));

			if($codigo == $dados->getRM()){
				header("location: alunos.php");
			}

			//Pegando istituições

			$comando = $conexao->prepare("SELECT * FROM instituicao");

			$comando->execute();

			$dadosInt = $comando->fetchAll();

			//Pegando dados do usuario

			$comando = $conexao->prepare("SELECT * FROM aluno AS a INNER JOIN contato_aluno AS c ON c.rm_aluno_contato = a.rm_aluno INNER JOIN endereco_aluno AS e ON e.rm_aluno_endereco = a.rm_aluno INNER JOIN usuario AS u ON u.id_usuario = a.id_usuario_aluno WHERE rm_aluno = :rm LIMIT 1");

			$comando->bindParam(":rm", $codigo);

			$comando->execute();

			$dadosA = $comando->fetchAll();

			if(count($dadosA) > 0){
				$cod_usuario = htmlspecialchars($dadosA[0]['id_usuario_aluno']);

				$comando = $conexao->prepare("SELECT id_curso, nome_curso, modulo_serie, periodo, turma FROM curso AS c INNER JOIN curso_usuario AS ca ON ca.curso_id_curso = c.id_curso WHERE ca.usuario_id_usuario = :codigo");

				$comando->bindParam(":codigo", $cod_usuario);

				$comando->execute();

				$cursos = $comando->fetchAll();

				foreach($cursos as $valor){
					$codigo = htmlspecialchars($valor[0]);
					$nome = htmlspecialchars($valor[1]);
					$moduloSerie = htmlspecialchars($valor[2]);

					$periodo = null;

					if (htmlspecialchars($valor[3]) == "M") $periodo = "Manhã";
					else if (htmlspecialchars($valor[3]) == "T") $periodo = "Tarde";
					else if (htmlspecialchars($valor[3]) == "N") $periodo = "Noite";
					else $periodo = "Integral";
					
					$turma = htmlspecialchars($valor[4]);

					$cursosU .= "<option value='$codigo' ondblclick='removeCursoLista($codigo, this)'>$nome - Módulo/Série: $moduloSerie - Periodo: $periodo - Turma: $turma</option>";
				}
			}else{
				header("location: alunos.php");
			}

		}catch(PDOException $ex){
			header("location: alunos.php");
		}
	}else{
		header("location: alunos.php");
	}
	
?>

<!DOCTYPE html>
<html lang="pt-br">
<head>
	<title><?php echo Info::$nomeSistema ?> - Editar Aluno</title>
	<meta charset="utf-8">
	<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">

	<script src="./scripts/jquery.min.js"></script>
	<script src="./scripts/MaskaraJquery/jquery.mask.js"></script>
	<script src="./scripts/edicaoAluno.js"></script>
	<script src="./scripts/controleCurso.js"></script>
	<script src="https://www.google.com/recaptcha/api.js" async defer></script>
	<script type="text/javascript" src="./scripts/tiraFoto.js"></script>

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

	<!--Moldal dos cursos-->

	<section class="MoldalOpcoes">
		
		<section class="telas">

			<div class="fechaMoldalOpcoes">&times;</div>

			<header>
				<div>
					<img <?php echo "src='". Info::$logoSistema ."'" ?>>
					<h5><?php echo Info::$nomeSistema; ?> - Selecionar Curso</h5>
				</div>

				<div>
					<?php

						echo "<img title='". Info::$nomeEtec ."' src='". Info::$logoEtec ."'>
						      <img title='". Info::$nomeCentro ."' src='". Info::$logoCentro ."'>";

					?>
				</div>
			</header>
			
			<section>
				<main>
					<input type="text" name="textPesquisa" placeholder="Pesquisar curso..." onkeyup="pesquisaCurso(this)">
					<button><i class='fas fa-search'></i></button>
				</main>

				<section>
					<select onchange="selecionaInstituicao(this)" id="instituicoesCurso">
						<?php

							foreach($dadosInt as $valor){
								$codigo = htmlspecialchars($valor[0]);
								$nome = htmlspecialchars($valor[1]);

								echo "<option value='$codigo'>$nome</option>";
							}

						?>
					</select>
				</section>
				
				<table>
					<thead>
						<tr>
							<th>Nome</th>
							<th>Módulo/Série</th>
							<th>Periodo</th>
							<th>Turma</th>
						</tr>
					</thead>
					<tbody id="cursoT"></tbody>
				</table>

				<footer>
					<div><button class="carregarMaisT" onclick="carregaMaisCurso(this)"><i class='fas fa-plus' title="Carregar Mais"></i></button></div>
				</footer>
			</section>
		</section>
	</section>

	<!--Modal foto-->

	<section id="moldalFoto">
		<main>
			<canvas id="telaFotoTira" width="500" height="500"></canvas>

			<div>
				<button id="btnTiraFoto"><i class="fas fa-camera"></i></button>
				<button class="btnFechaFoto">&times;</button>
			</div>
		</main>
	</section>

	<!--Modal exibe foto-->

	<section id="moldalExibeFoto">
		<main>
			<img src="" id="FotoTirada">

			<div>
				<button id="salvarImagem"><i class="fas fa-download"></i></button>
				<button class="btnFechaFoto">&times;</button>
			</div>
		</main>
	</section>

	<nav id="menu">
		<ul>
			<li id="mn"><a href="javascript: history.go(-1)"><span><i class="fas fa-arrow-left"></i></span></a> <h5>Alunos</h5></li>
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

			<input type="hidden" name="id_usuario" <?php echo "value='".$dadosA[0]['id_usuario_aluno']."'"; ?>>
			<input type="hidden" name="rm_original" <?php echo "value='".$dadosA[0]['rm_aluno']."'"; ?>>
			<input type="hidden" id="cidade_original" <?php echo "value='".$dadosA[0]['cidade']."'"; ?>>
		
			<div id="containerImg">
				<main>
					<label for="imagem"><img id="imagemPreview" <?php echo "src='data:image/jpg;base64,".base64_encode($dadosA[0]['img_aluno'])."'"; ?>></label>
					<button id="btnAbreMoldalFoto"><i class="fas fa-camera"></i></button>
				</main>
				
				<input type="file" name="imagem" id="imagem" accept="Image/jpeg">
			</div>

			<div class="inputs" id="input1">
				<div class="inputFlexContainer">
					<input type="text" name="nome" placeholder="Nome" class="inputV" maxlength='20' <?php echo "value='".$dadosA[0]['nome']."'"; ?>>
				</div>
				
				<span class="spanAlerta"><br>Digite o nome</span><br><br>

				<div class="inputFlexContainer">
					<input type="text" name="sobrenome" placeholder="Sobrenome" maxlength="40" class="inputV" <?php echo "value='".$dadosA[0]['sobrenome']."'"; ?>>
				</div>
				
				<span class="spanAlerta"><br>Digite o sobrenome</span><br><br>
			</div>

			<div class="inputs" id="input2">

				<div>
					<div class="inputComBTN">
						<?php echo "<select class='inputV' size='5' id='cursosSelecionados'>$cursosU</select>"; ?>

						<button class="btnAbreMoldal">Adicionar Curso</button>

						<input type="hidden" name="cursos" id="cursosSelecionadosT">
					</div>
					<br><span class="spanAlerta">Selecione pelo menos um curso</span><br><br>
				</div>

				<div class="divide">
					<div style="grid-column: 3/1">
						<div>
							<fieldset><legend>Status</legend>
								<?php

									if($dadosA[0]['status_usuario'] == "B"){
										echo "<select name='status'>
												<option value='B' selected>Bloqueado</option>
												<option value='D'>Desbloqueado</option>
											</select>";
									}else{
										echo "<select name='status'>
												<option value='B'>Bloqueado</option>
												<option value='D' selected>Desbloqueado</option>
											</select>";
									}

								?>
							</fieldset>
						</div>

						<br><br><br>
					</div>
				</div>

				<div class="divide">
					
					<div>
						<div class="inputFlexContainer">
							<input type="text" name="cpf" id="cpf" placeholder="CPF" class="inputV" <?php echo "value='".$dadosA[0]['cpf']."'"; ?>>
						</div>

						<br><span class="spanAlerta">Digite o cpf</span><br><br>
					</div>

					<div>
						<div class="inputFlexContainer">
							<input type="text" name="telefone" id="telefone" placeholder="Telefone" <?php echo "value='".$dadosA[0]['telefone']."'"; ?>>
						</div>
						<br><br><br>
					</div>

				</div>

				<div class="divide">
					<div>
						<div class="inputFlexContainer">
							<input type="text" name="celular" id="celular" placeholder="Celular" class="inputV" <?php echo "value='".$dadosA[0]['celular']."'"; ?>>
						</div>

						<br><span class="spanAlerta">Digite o celular</span><br><br>
					</div>
					<div>
						<div>
							<?php

								if($dadosA[0]['sexo'] == "M"){
									echo "<select name='sexo'>
											<option value='M' selected>Masculino</option>
											<option value='F'>Feminino</option>
											<option value='P'>Personalizado</option>
										</select>";
								}else if($dadosA[0]['sexo'] == "F"){
									echo "<select name='sexo'>
											<option value='M'>Masculino</option>
											<option value='F' selected>Feminino</option>
											<option value='P'>Personalizado</option>
										</select>";
								}else{
									echo "<select name='sexo'>
											<option value='M'>Masculino</option>
											<option value='F'>Feminino</option>
											<option value='P' selected>Personalizado</option>
										</select>";
								}

							?>
						</div>

						<br><br><br>
					</div>
				</div>

				<div class="divide">
					
					<div>
						<div class="inputFlexContainer">
							<input type="number" name="rm" placeholder="RM" class="inputV" max="999999999" <?php echo "value='".$dadosA[0]['rm_aluno']."'"; ?>>
						</div>
						
						<br><span class="spanAlerta">Digite o RM</span><br><br>		
					</div>

					<div>
						<div class="inputFlexContainer">
							<input type="email" name="email" placeholder="E-Mail" maxlength="100" class="inputV" <?php echo "value='".$dadosA[0]['email']."'"; ?>>
						</div>

						<br><span class="spanAlerta">Digite o email</span><br><br>
					</div>

				</div>

				<div style="grid-column: 3/1">
					<div  class="inputFlexContainer">
						<input type="text" name="logradouro" id="logradouro" placeholder="Logradouro" maxlength="100" class="inputV" <?php echo "value='".$dadosA[0]['logradouro']."'"; ?>>
					</div>
						
					<br><span class="spanAlerta">Digite o logradouro</span><br><br>
				</div>

				<div class="divide">
					
					<div>
						<div class="inputFlexContainer">
							<input type="text" name="cep" id="cep" placeholder="CEP" class="inputV" <?php echo "value='".$dadosA[0]['cep']."'"; ?>>
						</div>
						
						<br><span class="spanAlerta">Digite o CEP</span><br><br>		
					</div>

					<div>
						<div class="inputFlexContainer">
							<input type="number" name="numero" placeholder="Número" min="0" class="inputV" <?php echo "value='".$dadosA[0]['numero']."'"; ?>>
						</div>

						<br><span class="spanAlerta">Digite o número</span><br><br>
					</div>

				</div>

					
				<div>
					<div class="inputFlexContainer">
						<input type="text" name="bairro" id="bairro" placeholder="Bairro" maxlength="50" class="inputV" <?php echo "value='".$dadosA[0]['bairro']."'"; ?>>
					</div>
						
					<br><span class="spanAlerta">Digite o bairro</span><br><br>		
				</div>

				<div>
					<fieldset><legend>Cidade</legend>
						<select name="cidade" id="cidade"></select>
					</fieldset>
					<br><br><br>
				</div>

				<div>
					<div style="grid-column: 3/1;" class="inputFlexContainer">
						<textarea placeholder="Complemento" name="complemento" id="complemento" rows="5" <?php echo "value='".$dadosA[0]['complemento']."'"; ?>></textarea>
					</div>
					<br><br><br>
				</div>

				<div style="overflow: hidden;">
					<div class="g-recaptcha" <?php echo "data-sitekey='$codChaveDiv'"; ?>></div>
				</div>
			</div>

			<div id="btnCad">
				<input type="submit" value="Salvar Edições" onclick="executaEdicao()">
			</div>

		</form>
	</section>

	<!--Botão para ajuda-->

	<a href="ajuda.php#CadAluno"><div id="btnhelp" title="Ajuda" style="bottom: 40px"><i class="fas fa-question"></i></div></a>

	<footer><h5><?php echo Info::$copyright; ?></h5></footer>

</body>
</html>