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

	$instituicaoU = null;
	$dadosF = null;

	if(isset($_POST["cpfF"])){
		try{
			$codigo = trim(addslashes($_POST["cpfF"]));

			if($codigo == $dados->getCPF()){
				header("location: funcionarios.php");
			}

			//Pegando istituições

			$comando = $conexao->prepare("SELECT * FROM instituicao");

			$comando->execute();

			$dadosInt = $comando->fetchAll();

			//Pegando dados do usuario

			$comando = $conexao->prepare("SELECT * FROM funcionario AS f INNER JOIN contato_funcionario AS c ON c.cpf_funcionario = f.cpf INNER JOIN usuario AS u ON u.id_usuario = f.id_usuario_funcionario INNER JOIN endereco_funcionario AS e ON e.cpf_funcionario_endereco = f.cpf WHERE f.cpf = :cpf LIMIT 1");

			$comando->bindParam(":cpf", $codigo);

			$comando->execute();

			$dadosF = $comando->fetchAll();

			if(count($dadosF) > 0){
				$cod_usuario = htmlspecialchars($dadosF[0]['id_usuario_funcionario']);

				$comando = $conexao->prepare("SELECT i.id_instituicao, i.nome_instituicao FROM instituicao AS i INNER JOIN instituicao_usuario AS iu ON iu.id_instituicao = i.id_instituicao WHERE iu.id_usuario = :codigo");

				$comando->bindParam(":codigo", $cod_usuario);

				$comando->execute();

				$inst = $comando->fetchAll();

				foreach($inst as $valor){
					$codigo = htmlspecialchars($valor[0]);
					$nome = htmlspecialchars($valor[1]);

					$instituicaoU .= "<option value='$codigo' ondblclick='removeInstituicaoLista($codigo, this)'>$nome</option>";
				}
			}else{
				header("location: alunos.php");
			}

		}catch(PDOException $ex){
			header("location: funcionarios.php");
		}
	}else{
		header("location: funcionarios.php");
	}
	
?>

<!DOCTYPE html>
<html lang="pt-br">
<head>
	<title><?php echo Info::$nomeSistema ?> - Editar Funcionário</title>
	<meta charset="utf-8">
	<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">

	<script src="./scripts/jquery.min.js"></script>
	<script src="./scripts/MaskaraJquery/jquery.mask.js"></script>
	<script src="./scripts/edicaoFuncionario.js"></script>
	<script src="./scripts/controleInstituicao.js"></script>
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
					<h5><?php echo Info::$nomeSistema; ?> - Selecionar Instituição</h5>
				</div>

				<div>
					<?php

						echo "<img title='". Info::$nomeEtec ."' src='". Info::$logoEtec ."'>
						      <img title='". Info::$nomeCentro ."' src='". Info::$logoCentro ."'>";

					?>
				</div>
			</header>
			
			<section style="grid-template-rows: 60px 1fr 60px;">
				<main>
					<input type="text" name="textPesquisa" placeholder="Pesquisar instituição..." onkeyup="pesquisaInstituicao(this)">
					<button><i class='fas fa-search'></i></button>
				</main>
				
				<table>
					<thead>
						<tr>
							<th>Nome</th>
						</tr>
					</thead>
					<tbody id="instiT"></tbody>
				</table>

				<footer>
					<div><button class="carregarMaisT" onclick="carregaMaisInstituicao(this)"><i class='fas fa-plus' title="Carregar Mais"></i></button></div>
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
			<li id="mn"><a href="javascript: history.go(-1)"><span><i class="fas fa-arrow-left"></i></span></a> <h5>Funcionários</h5></li>
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

			<input type="hidden" name="id_usuario" <?php echo "value='".$dadosF[0]['id_usuario_funcionario']."'"; ?>>
			<input type="hidden" name="cpf_original" <?php echo "value='".$dadosF[0]['cpf']."'"; ?>>
			<input type="hidden" id="cidade_original" <?php echo "value='".$dadosF[0]['cidade']."'"; ?>>
		
			<div id="containerImg">
				<main>
					<label for="imagem"><img <?php echo "src='data:image/jpg;base64,".base64_encode($dadosF[0]['img_funcionario'])."'" ?> id="imagemPreview"></label>
					<button id="btnAbreMoldalFoto"><i class="fas fa-camera"></i></button>
				</main>
				
				<input type="file" name="imagem" id="imagem" accept="Image/jpeg">
			</div>

			<div class="inputs" id="input1">
				<div class="inputFlexContainer">
					<input type="text" name="nome" placeholder="Nome" class="inputV" maxlength="20" <?php echo "value='".$dadosF[0]['nome']."'" ?>>
				</div>
				
				<span class="spanAlerta"><br>Digite o nome</span><br><br>

				<div class="inputFlexContainer">
					<input type="text" name="sobrenome" placeholder="Sobrenome" class="inputV" maxlength="40" <?php echo "value='".$dadosF[0]['sobrenome']."'" ?>>
				</div>
				
				<span class="spanAlerta"><br>Digite o sobrenome</span><br><br>
			</div>

			<div class="inputs" id="input2">

				<div>
					<div class="inputComBTN">
						
						<?php echo "<select class='inputV' size='5' id='intituicoesSelecionados'>$instituicaoU</select>"; ?>
						
						<button class="btnAbreMoldal" style="width: 150px">Adicionar Instituição</button>

						<input type="hidden" name="instituicoes" id="intituicoesSelecionadosT">
					</div>
					<br><span class="spanAlerta">Selecione pelo menos uma instituição em que este funcionário trabalha</span><br><br>
				</div>

				<div class="divide">
					<div style="grid-column: 3/1">
						<div>
							<fieldset><legend>Status</legend>
								<?php

									if($dadosF[0]['status_usuario'] == "B"){
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
							<input type="text" name="cpf" id="cpf" placeholder="CPF" class="inputV" <?php echo "value='".$dadosF[0]['cpf']."'" ?>>
						</div>

						<br><span class="spanAlerta">Digite o cpf</span><br><br>
					</div>

					<div>
						<div class="inputFlexContainer">
							<input type="text" name="telefone" id="telefone" placeholder="Telefone" <?php echo "value='".$dadosF[0]['telefone']."'" ?>>
						</div>

						<br><br><br>
					</div>

				</div>

				<div class="divide">
					<div>
						<div class="inputFlexContainer">
							<input type="text" name="celular" id="celular" placeholder="Celular" class="inputV" <?php echo "value='".$dadosF[0]['celular']."'" ?>>
						</div>

						<br><span class="spanAlerta">Digite o celular</span><br><br>
					</div>
					<div>
						<div>
							<?php

								if($dadosF[0]['sexo'] == "M"){
									echo "<select name='sexo'>
											<option value='M' selected>Masculino</option>
											<option value='F'>Feminino</option>
											<option value='P'>Personalizado</option>
										</select>";
								}else if($dadosF[0]['sexo'] == "F"){
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

					<div style="grid-column: 3/1">
						<div class="inputFlexContainer">
							<input type="email" name="email" placeholder="E-Mail" class="inputV" maxlength="100" <?php echo "value='".$dadosF[0]['email']."'" ?>>
						</div>

						<br><span class="spanAlerta">Digite o email</span><br><br>
					</div>

				</div>

				<div style="grid-column: 3/1">
					<div  class="inputFlexContainer">
						<input type="text" name="logradouro" id="logradouro" placeholder="Logradouro" maxlength="100" class="inputV" <?php echo "value='".$dadosF[0]['logradouro']."'"; ?>>
					</div>
						
					<br><span class="spanAlerta">Digite o logradouro</span><br><br>
				</div>

				<div class="divide">
					
					<div>
						<div class="inputFlexContainer">
							<input type="text" name="cep" id="cep" placeholder="CEP" class="inputV" <?php echo "value='".$dadosF[0]['cep']."'"; ?>>
						</div>
						
						<br><span class="spanAlerta">Digite o CEP</span><br><br>		
					</div>

					<div>
						<div class="inputFlexContainer">
							<input type="number" name="numero" placeholder="Número" min="0" class="inputV" <?php echo "value='".$dadosF[0]['numero']."'"; ?>>
						</div>

						<br><span class="spanAlerta">Digite o número</span><br><br>
					</div>

				</div>

					
				<div>
					<div class="inputFlexContainer">
						<input type="text" name="bairro" id="bairro" placeholder="Bairro" maxlength="50" class="inputV" <?php echo "value='".$dadosF[0]['bairro']."'"; ?>>
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
						<textarea placeholder="Complemento" name="complemento" id="complemento" rows="5" <?php echo "value='".$dadosF[0]['complemento']."'"; ?>></textarea>
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

	<a href="ajuda.php#CadFuncionario"><div id="btnhelp" title="Ajuda" style="bottom: 40px"><i class="fas fa-question"></i></div></a>

	<footer><h5><?php echo Info::$copyright; ?></h5></footer>

</body>
</html>