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

	//Função que coloca maskara nos inputs

	function Mask($mask, $str){
	    $str = str_ireplace(" ", "", $str);

	    for($i = 0; $i < strlen($str); $i++){
	        $mask[strpos($mask,"#")] = $str[$i];
	    }

	    return $mask;
	}

	//Pesquisando os dados do usuário

	$dadosPessoais = null;
	$dadosExibicao = null;
	$pegarCurso = true;

	//Pesquisando alunos

	$comando = $conexao->prepare("SELECT * FROM aluno AS a INNER JOIN contato_aluno AS c ON c.rm_aluno_contato = a.rm_aluno INNER JOIN endereco_aluno AS e ON e.rm_aluno_endereco = a.rm_aluno WHERE a.id_usuario_aluno = :id LIMIT 1");

	$comando->bindValue(":id", $dados->getCodUsuario());

	$comando->execute();

	$dadosPessoais = $comando->fetchAll();

	if(count($dadosPessoais) == 0){
		//Pesquisando professores

		$comando = $conexao->prepare("SELECT * FROM professor AS p INNER JOIN contato_professor AS c ON c.rm_professor_contato = p.rm_professor INNER JOIN endereco_professor AS e ON e.rm_professor_endereco = p.rm_professor INNER JOIN instituicao AS i ON i.id_instituicao = p.sede WHERE p.id_usuario_professor = :id LIMIT 1");

		$comando->bindValue(":id", $dados->getCodUsuario());

		$comando->execute();

		$dadosPessoais = $comando->fetchAll();

		if(count($dadosPessoais) == 0){

			//Pesquisando funcionários

			$comando = $conexao->prepare("SELECT * FROM funcionario AS f INNER JOIN contato_funcionario AS c ON f.cpf = c.cpf_funcionario INNER JOIN endereco_funcionario AS e ON e.cpf_funcionario_endereco = f.cpf WHERE id_usuario_funcionario = :id LIMIT 1");

			$comando->bindValue(":id", $dados->getCodUsuario());

			$comando->execute();

			$dadosPessoais = $comando->fetchAll();

			if(count($dadosPessoais) == 0){
				header("location: Inicio.php");
			}else{
				$pegarCurso = false;

				foreach($dadosPessoais as $valor){
					$nome = htmlspecialchars($valor['nome']) . " " . htmlspecialchars($valor['sobrenome']);
					$cpf = Mask("###.###.###-##", htmlspecialchars($valor['cpf']));
					
					if(htmlspecialchars($valor['sexo']) == 'M'){
						$sexo = "Masculino";
					}else if(htmlspecialchars($valor['sexo']) == 'F'){
						$sexo = "Feminino";
					}else{
						$sexo = "Personalizado";
					}

					$data = explode("-", htmlspecialchars($valor['data_cadastro']));
					$data = $data[2] . "/" . $data[1] . "/" . $data[0];
					$telefone = (strlen(htmlspecialchars($valor['telefone'])) > 0) ? Mask("(##)####-####", htmlspecialchars($valor['telefone'])) : "";
					$celular = Mask("(##)#####-####", htmlspecialchars($valor['celular']));
					$email = htmlspecialchars($valor['email']);
					$cep = Mask("#####-###", htmlspecialchars($valor['cep']));
					$logradouro = htmlspecialchars($valor['logradouro']);
					$numero = htmlspecialchars($valor['numero']);
					$bairro = htmlspecialchars($valor['bairro']);
					$cidade = htmlspecialchars($valor['cidade']);
					$complemento = htmlspecialchars($valor['complemento']);

					$dadosExibicao = "<div class='dados'>
										<div>
											<h3>Dados Pessoais</h3>
										</div>
										<div>
										    <button onclick='abreMoldalSenha()'>Alterar Senha <i class='fas fa-lock'></i></button>
										</div>
									  </div>

									  <div>
										<h4>$nome</h4><br>
										<p><strong>CPF:</strong> $cpf</p>
										<p><strong>Sexo:</strong> $sexo</p>
										<p><strong>Data de Cadastro:</strong> $data</p>				
									  </div>

									  <br><hr><br>

									  <h3>Contato</h3>

									  <div>
										<p><strong>Telefone:</strong> $telefone</p>
										<p><strong>Celular:</strong> $celular</p>
										<p><strong>E-Mail:</strong> $email</p>		
									  </div>

									  <br><hr><br>

									  <h3>Endereço</h3>

									  <div>
										<p><strong>CEP:</strong> $cep</p>
										<p><strong>Logradouro:</strong> $logradouro</p>
										<p><strong>Número:</strong> $numero</p>
										<p><strong>Bairro:</strong> $bairro</p>	
										<p><strong>Cidade:</strong> $cidade</p>
										<p><strong>Complemento:</strong> $complemento</p>	
									  </div>

									  <br><hr><br>";

				}
			}
		}else{
			$pegarCurso = false;

			foreach($dadosPessoais as $valor){
				$rm = htmlspecialchars($valor['rm_professor']);
				$nome = htmlspecialchars($valor['nome']) . " " . htmlspecialchars($valor['sobrenome']);
				$cpf = Mask("###.###.###-##", htmlspecialchars($valor['cpf']));
				
				if(htmlspecialchars($valor['sexo']) == 'M'){
					$sexo = "Masculino";
				}else if(htmlspecialchars($valor['sexo']) == 'F'){
					$sexo = "Feminino";
				}else{
					$sexo = "Personalizado";
				}

				$data = explode("-", htmlspecialchars($valor['data_cadastro']));
				$data = $data[2] . "/" . $data[1] . "/" . $data[0];
				$sede = htmlspecialchars($valor['nome_instituicao']);
				$telefone = (strlen(htmlspecialchars($valor['telefone'])) > 0) ? Mask("(##)####-####", htmlspecialchars($valor['telefone'])) : "";
				$celular = Mask("(##)#####-####", htmlspecialchars($valor['celular']));
				$email = htmlspecialchars($valor['email']);
				$cep = Mask("#####-###", htmlspecialchars($valor['cep']));
				$logradouro = htmlspecialchars($valor['logradouro']);
				$numero = htmlspecialchars($valor['numero']);
				$bairro = htmlspecialchars($valor['bairro']);
				$cidade = htmlspecialchars($valor['cidade']);
				$complemento = htmlspecialchars($valor['complemento']);

				$dadosExibicao = "<div class='dados'>
									<div>
										<h3>Dados Pessoais</h3>
									</div>
									<div>
									    <button onclick='abreMoldalSenha()'>Alterar Senha <i class='fas fa-lock'></i></button>
									</div>
								  </div>

								  <div>
									  <h4>$nome</h4><br>
									  <p><strong>RM:</strong> $rm</p>
									  <p><strong>CPF:</strong> $cpf</p>
									  <p><strong>Sexo:</strong> $sexo</p>
									  <p><strong>Data de Cadastro:</strong> $data</p>
									  <p><strong>Sede:</strong> $sede</p>			
								  </div>

								  <br><hr><br>

								  <h3>Contato</h3>

									<div>
										<p><strong>Telefone:</strong> $telefone</p>
										<p><strong>Celular:</strong> $celular</p>
										<p><strong>E-Mail:</strong> $email</p>			
									</div>

									<br><hr><br>

									<h3>Endereço</h3>

									<div>
										<p><strong>CEP:</strong> $cep</p>
										<p><strong>Logradouro:</strong> $logradouro</p>
										<p><strong>Número:</strong> $numero</p>
										<p><strong>Bairro:</strong> $bairro</p>	
										<p><strong>Cidade:</strong> $cidade</p>
										<p><strong>Complemento:</strong> $complemento</p>	
									</div>

									<br><hr><br>";

			}
		}
	}else{
		foreach($dadosPessoais as $valor){
			$rm = htmlspecialchars($valor['rm_aluno']);
			$nome = htmlspecialchars($valor['nome']) . " " . htmlspecialchars($valor['sobrenome']);
			$cpf = Mask("###.###.###-##", htmlspecialchars($valor['cpf']));

			if(htmlspecialchars($valor['sexo']) == 'M'){
				$sexo = "Masculino";
			}else if(htmlspecialchars($valor['sexo']) == 'F'){
				$sexo = "Feminino";
			}else{
				$sexo = "Personalizado";
			}

			$data = explode("-", htmlspecialchars($valor['data_cadastro']));
			$data = $data[2] . "/" . $data[1] . "/" . $data[0];
			$telefone = (strlen(htmlspecialchars($valor['telefone'])) > 0) ? Mask("(##)####-####", htmlspecialchars($valor['telefone'])) : "";
			$celular = Mask("(##)#####-####", htmlspecialchars($valor['celular']));
			$email = htmlspecialchars($valor['email']);
			$cep = Mask("#####-###", htmlspecialchars($valor['cep']));
			$logradouro = htmlspecialchars($valor['logradouro']);
			$numero = htmlspecialchars($valor['numero']);
			$bairro = htmlspecialchars($valor['bairro']);
			$cidade = htmlspecialchars($valor['cidade']);
			$complemento = htmlspecialchars($valor['complemento']);

			$dadosExibicao = "<div class='dados'>
								<div>
									<h3>Dados Pessoais</h3>
								</div>
								<div>
								    <button onclick='abreMoldalSenha()'>Alterar Senha <i class='fas fa-lock'></i></button>
								</div>
							  </div>

							  <div>
								  <h4>$nome</h4><br>
								  <p><strong>RM:</strong> $rm</p>
								  <p><strong>CPF:</strong> $cpf</p>
								  <p><strong>Sexo:</strong> $sexo</p>
								  <p><strong>Data de Cadastro:</strong> $data</p>				
							  </div>

							  <br><hr><br>

							  <h3>Contato</h3>

								<div>
									<p><strong>Telefone:</strong> $telefone</p>
									<p><strong>Celular:</strong> $celular</p>
									<p><strong>E-Mail:</strong> $email</p>			
								</div>

								<br><hr><br>

								<h3>Endereço</h3>

								<div>
									<p><strong>CEP:</strong> $cep</p>
									<p><strong>Logradouro:</strong> $logradouro</p>
									<p><strong>Número:</strong> $numero</p>
									<p><strong>Bairro:</strong> $bairro</p>	
									<p><strong>Cidade:</strong> $cidade</p>
									<p><strong>Complemento:</strong> $complemento</p>	
								</div>

								<br><hr><br>";

		}
	}

	//Pesquisando cursos

	if($pegarCurso){
		$comando = $conexao->prepare("SELECT c.nome_curso, c.modulo_serie, c.periodo, c.turma, i.nome_instituicao FROM curso AS c INNER JOIN curso_usuario as ca ON ca.curso_id_curso = c.id_curso INNER JOIN instituicao AS i ON i.id_instituicao = c.id_instituicao_curso WHERE ca.usuario_id_usuario = :id");

		$comando->bindValue(":id", $dados->getCodUsuario());

		$comando->execute();

		$dadosPessoais = $comando->fetchAll();

		$dadosExibicao .= "<h3>Curso(s)</h3>

						   <div>
								<ul>";

		foreach($dadosPessoais as $valor){
			$nomeCurso = htmlspecialchars($valor[0]);
			$modulo_serie = htmlspecialchars($valor[1]);
			$periodo = null;

			if (htmlspecialchars($valor[2]) == "M") $periodo = "Manhã";
			else if (htmlspecialchars($valor[2]) == "T") $periodo = "Tarde";
			else if (htmlspecialchars($valor[2]) == "N") $periodo = "Noite";
			else $periodo = "Integral";

			$turma = htmlspecialchars($valor[3]);
			$nome_instituicao = htmlspecialchars($valor[4]);

			$dadosExibicao .= "<li>$nomeCurso - $modulo_serie º Módulo/Série - Turma: $turma - $periodo - $nome_instituicao</li><br>";		
		}

		$dadosExibicao .= "</ul></div>";
	}else{
		$comando = $conexao->prepare("SELECT i.nome_instituicao FROM instituicao AS i INNER JOIN instituicao_usuario AS iu ON iu.id_instituicao = i.id_instituicao WHERE iu.id_usuario = :id");

		$comando->bindValue(":id", $dados->getCodUsuario());

		$comando->execute();

		$dadosPessoais = $comando->fetchAll();

		$dadosExibicao .= "<h3>Instituição(ões)</h3>

						   <div>
								<ul>";

		foreach($dadosPessoais as $valor){
			$nomeI = htmlspecialchars($valor[0]);

			$dadosExibicao .= "<li>$nomeI</li><br>";		
		}

		$dadosExibicao .= "</ul></div>";
	}
?>

<!DOCTYPE html>
<html lang="pt-br">
<head>
	<title><?php echo Info::$nomeSistema ?> - Dados Pessoias</title>
	<meta charset="utf-8">
	<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">

	<script src="./scripts/jquery.min.js"></script>
	<script type="text/javascript" src="./scripts/Menu.js"></script>
	<script type="text/javascript" src="./scripts/audio.js"></script>
	<script type="text/javascript" src="./scripts/moldalMsg.js"></script>
	<script type="text/javascript" src="./scripts/dados.js"></script>

	<link rel="stylesheet" type="text/css" href="./css/fontawesome-free-5.12.1-web/css/all.min.css">
	<link rel="stylesheet" type="text/css" href="./css/fontawesome-free-5.12.1-web/css/brands.min.css">
	<link rel="stylesheet" type="text/css" href="./css/fontawesome-free-5.12.1-web/css/solid.min.css">
	<link rel="stylesheet" type="text/css" href="./css/fontawesome-free-5.12.1-web/css/svg-with-js.min.css">
	<link rel="stylesheet" type="text/css" href="./css/fontawesome-free-5.12.1-web/css/regular.min.css">
	<link rel="stylesheet" type="text/css" href="./css/fontawesome-free-5.12.1-web/css/v4-shims.min.css">
	<link rel="shortcut icon" type="image/jpg" <?php echo "href='".Info::$logoSistema."'" ?> sizes="50x50">

	<link rel="stylesheet" type="text/css" href="./css/config.css">
	<link rel="stylesheet" type="text/css" href="./css/telas.css">
	<link rel="stylesheet" type="text/css" href="./css/dados.css">

	<style type="text/css">
		
		#principal .ferramentas{
			display: grid;
			grid-template-columns: 1fr;
		}
		.MoldalOp .telas{
			height: 400px;
		}
		hr{
			border: 1px solid #2e2b2b;
		}
		@media(max-width: 380px){
			.MoldalOp .telas{
				height: 380px;
			}
			.MoldalOp .telas .selectI form{
				margin: 10px;
			}
			.MoldalOp .telas .selectI form input[type=password]{
				width: 90%;
			}
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

	<!--Moldal de senha-->

	<section class="MoldalOp">
		<section class="telas">

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

			<section class="selectI" style="padding: 15px;">
				<form action="javascript: void(0)">

					<input type="password" name="senha" placeholder="Senha" class="inputSenha" onkeyup="limpaCampoSenha()">

					<br><br><br>

					<input type="password" name="novaSenha" placeholder="Nova senha" class="inputSenha" onkeyup="limpaCampoSenha()">

					<br><br><br>

					<input type="password" name="repetirSenha" placeholder="Repetir nova senha" class="inputSenha" onkeyup="limpaCampoSenha()">

					<br><br><span class="spanSenha">Repita sua nova senha</span><br><br>

					<div>
						<input type="submit" value="Alterar Senha" onclick="alterarSenha()">
					<div>

				</form>
			</section>
			
		</section>
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
						  <a href='dados.php'><li id='MarcadoItem'><i class='fas fa-user'></i> Dados Pessoais</li></a>
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
					echo "<a href='Inicio.php'><li><i class='fas fa-home'></i> Inicio</li></a>
						  <a href='dados.php'><li id='MarcadoItem'><i class='fas fa-user'></i> Dados Pessoais</li></a>
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

	<a href="ajuda.php#Dados"><div id="btnhelp" title="Ajuda"><i class="fas fa-question"></i></div></a>

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
		<section class="containerDados">
			<?php echo $dadosExibicao; ?>
		</section>
	</section>
</body>
</html>