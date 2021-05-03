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

	//Função que coloca maskara nas strings

	function Mask($mask, $str){
	    $str = str_ireplace(" ", "", $str);

	    for($i = 0; $i < strlen($str); $i++){
	        $mask[strpos($mask,"#")] = $str[$i];
	    }

	    return $mask;
	}

	//Pegando instituições

	if(isset($_GET["codA"])){
		try{
			$codigoA = trim(addslashes($_GET["codA"]));

			$comando = $conexao->prepare("SELECT al.data_devolucao, al.id_usuario_locacao, al.id_usuarioAdimin_locacao, l.titulo, l.img_livro, i.nome_instituicao FROM locacao AS al INNER JOIN exemplares AS e ON e.id_exemplares = al.id_exemplares INNER JOIN livro As l ON l.cod_livro = e.livro_tombo_exemplares INNER JOIN instituicao AS i ON i.id_instituicao = e.id_instituicao WHERE id_locacao = :id LIMIT 1");

			$comando->bindParam(":id", $codigoA);

			$comando->execute();

			$dadosAlocacao = $comando->fetchAll();

			$dataDevolucao = htmlspecialchars($dadosAlocacao[0][0]);
			$usuario = htmlspecialchars($dadosAlocacao[0][1]);
			$admin = htmlspecialchars($dadosAlocacao[0][2]);
			$titulo = htmlspecialchars($dadosAlocacao[0][3]);
			$imgLivro = base64_encode($dadosAlocacao[0][4]);
			$nome_instituicao = htmlspecialchars($dadosAlocacao[0][5]);

			$nomeUser = null;
			$cpfUser = null;
			$imgUser = null;
			$tipoUser = null;

			$nomeAdmin = null;
			$cpfAdmin = null;
			$imgAdmin = null;
			$tipoUserAdmin = null;

			//Buscando dados do usuário da alocação

			$comando = $conexao->prepare("SELECT CONCAT(nome, CONCAT(' ', sobrenome)), cpf, img_aluno FROM aluno WHERE id_usuario_aluno = :id LIMIT 1");

			$comando->bindParam(":id", $usuario);

			$comando->execute();

			$dadosUsuario = $comando->fetchAll();

			if(count($dadosUsuario) > 0){
				$nomeUser = htmlspecialchars($dadosUsuario[0][0]);
				$cpfUser = Mask("###.###.###-##", htmlspecialchars($dadosUsuario[0][1]));
				$imgUser = base64_encode($dadosUsuario[0][2]);
				$tipoUser = "Aluno";
			}else{
				$comando = $conexao->prepare("SELECT CONCAT(nome, CONCAT(' ', sobrenome)), cpf, img_professor FROM professor WHERE id_usuario_professor = :id LIMIT 1");

				$comando->bindParam(":id", $usuario);

				$comando->execute();

				$dadosUsuario = $comando->fetchAll();

				if(count($dadosUsuario) > 0){
					$nomeUser = htmlspecialchars($dadosUsuario[0][0]);
					$cpfUser = Mask("###.###.###-##", htmlspecialchars($dadosUsuario[0][1]));
					$imgUser = base64_encode($dadosUsuario[0][2]);
					$tipoUser = "Professor";
				}else{
					$comando = $conexao->prepare("SELECT CONCAT(nome, CONCAT(' ', sobrenome)), cpf, img_funcionario FROM funcionario WHERE id_usuario_funcionario = :id LIMIT 1");

					$comando->bindParam(":id", $usuario);

					$comando->execute();

					$dadosUsuario = $comando->fetchAll();

					if(count($dadosUsuario) > 0){
						$nomeUser = htmlspecialchars($dadosUsuario[0][0]);
						$cpfUser = Mask("###.###.###-##", htmlspecialchars($dadosUsuario[0][1]));
						$imgUser = base64_encode($dadosUsuario[0][2]);
						$tipoUser = "Funcionário";
					}
				}
			}

			//Buscando dados do administrador da alocação

			$comando = $conexao->prepare("SELECT CONCAT(nome, CONCAT(' ', sobrenome)), cpf, img_aluno FROM aluno WHERE id_usuario_aluno = :id LIMIT 1");

			$comando->bindParam(":id", $admin);

			$comando->execute();

			$dadosUsuario = $comando->fetchAll();

			if(count($dadosUsuario) > 0){
				$nomeAdmin = htmlspecialchars($dadosUsuario[0][0]);
				$cpfAdmin = Mask("###.###.###-##", htmlspecialchars($dadosUsuario[0][1]));
				$imgAdmin = base64_encode($dadosUsuario[0][2]);
				$tipoUserAdmin = "Aluno";
			}else{
				$comando = $conexao->prepare("SELECT CONCAT(nome, CONCAT(' ', sobrenome)), cpf, img_professor FROM professor WHERE id_usuario_professor = :id LIMIT 1");

				$comando->bindParam(":id", $admin);

				$comando->execute();

				$dadosUsuario = $comando->fetchAll();

				if(count($dadosUsuario) > 0){
					$nomeAdmin = htmlspecialchars($dadosUsuario[0][0]);
					$cpfAdmin = Mask("###.###.###-##", htmlspecialchars($dadosUsuario[0][1]));
					$imgAdmin = base64_encode($dadosUsuario[0][2]);
					$tipoUserAdmin = "Professor";
				}else{
					$comando = $conexao->prepare("SELECT CONCAT(nome, CONCAT(' ', sobrenome)), cpf, img_funcionario FROM funcionario WHERE id_usuario_funcionario = :id LIMIT 1");

					$comando->bindParam(":id", $admin);

					$comando->execute();

					$dadosUsuario = $comando->fetchAll();

					if(count($dadosUsuario) > 0){
						$nomeAdmin = htmlspecialchars($dadosUsuario[0][0]);
						$cpfAdmin = Mask("###.###.###-##", htmlspecialchars($dadosUsuario[0][1]));
						$imgAdmin = base64_encode($dadosUsuario[0][2]);
						$tipoUserAdmin = "Funcionário";
					}
				}
			}
		}catch(Exception $ex){
			header("location: alocacoes.php");
		}
	}else{
		header("location: alocacoes.php");
	}
	
?>

<!DOCTYPE html>
<html lang="pt-br">
<head>
	<title><?php echo Info::$nomeSistema ?> - Editar Alocação</title>
	<meta charset="utf-8">
	<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">

	<script src="./scripts/jquery.min.js"></script>
	<script src="./scripts/MaskaraJquery/jquery.mask.js"></script>
	<script src="./scripts/editaAlocacao.js"></script>
	<script type="text/javascript" src="./scripts/recaptcha.js"></script>

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
		#campoLivro, #campoUser{
			background-color: #141313;
			padding: 10px;
			border-radius: 3px;
			color: white;
			display: grid;
			grid-template-columns: 50px 1fr;
		}
		#campoLivro img{
			height: 50px;
			border-radius: 3px;
		}
		#campoUser img{
			height: 40px;
			width: 40px;
			border-radius: 50%;
			margin-top: 5px;
		}
		h5{
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

			<input type="hidden" name="codA" <?php echo "value='$codigoA'" ?>>

			<div class="inputs" id="input2" style="padding: 20px;">
				<div id='campoLivro'>
					<img <?php echo "src='data:image/jpg;base64,$imgLivro'" ?>>
					<div>
						<h5><?php echo $titulo; ?></h5><br>
						<h5><?php echo $nome_instituicao; ?></h5>
					</div>
				</div>

				<br><br>

				<div id='campoUser'>
					<img <?php echo "src='data:image/jpg;base64,$imgUser'" ?>>
					<div>
						<h5><?php echo "$nomeUser - $tipoUser"; ?></h5><br>
						<h5>CPF: <?php echo $cpfUser; ?></h5>
					</div>
				</div>

				<br><br>

				<h5>Administrador responsável pela alocação:</h5>

				<br>

				<div id='campoUser'>
					<img <?php echo "src='data:image/jpg;base64,$imgAdmin'" ?>>
					<div>
						<h5><?php echo "$nomeAdmin - $tipoUserAdmin"; ?></h5><br>
						<h5>CPF: <?php echo $cpfAdmin; ?></h5>
					</div>
				</div>

				<br><br>

				<div>
					<div>
						<fieldset class="inputFlexContainer"><legend>Data da Devolução</legend>
							<input type="date" name="dataDevolucao" class="inputV" <?php echo "value='$dataDevolucao'" ?>>
						</fieldset>
					</div>

					<br><span class="spanAlerta">Digite a data de devolução</span><br><br>
				</div>

				<div style="overflow: hidden;">
					<div class="g-recaptcha" <?php echo "data-sitekey='$codChaveDiv'"; ?>></div>
				</div>	
			</div>

			<div id="btnCad">
				<input type="submit" name="btnCadLivro" value="Salvar Edições" onclick="editaAlocacao()">
			</div>
		</form>
	</section>

	<!--Botão para ajuda-->

	<a href="ajuda.php#EditAlocacao"><div id="btnhelp" title="Ajuda" style="bottom: 40px"><i class="fas fa-question"></i></div></a>

	<footer><h5><?php echo Info::$copyright; ?></h5></footer>

</body>
</html>