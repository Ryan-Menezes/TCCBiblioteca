<?php

	include_once "conexao.php";
	include_once "Usuario.php";
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

	//Função que coloca maskara nos inputs

	function Mask($mask, $str){
	    $str = str_ireplace(" ", "", $str);

	    for($i = 0; $i < strlen($str); $i++){
	        $mask[strpos($mask,"#")] = $str[$i];
	    }

	    return $mask;
	}

	try{
		if(isset($_POST["tipo"]) && isset($_POST["rows"])){
			$tipo = trim(addslashes($_POST["tipo"]));
			$rows = trim(addslashes($_POST["rows"]));

			if($tipo == 1){ //1 - Alunos | 2 - Professores | 3 - Funcionários | 4 - Livros

				$html = null;

				//Prepararando Script SQL

				$sql = "SELECT a.img_aluno, a.rm_aluno, CONCAT(a.nome, CONCAT(' ', a.sobrenome)) AS nome, a.cpf, CASE a.sexo WHEN 'M' THEN 'Masculino' WHEN 'F' THEN 'Feminino' ELSE 'Personalizado' END, a.data_cadastro, CASE u.status_usuario WHEN 'B' THEN 'Bloqueado' ELSE 'Desbloqueado' END, c.telefone, c.celular, c.email, e.cep, e.logradouro, e.numero, e.bairro, e.cidade, e.complemento, u.id_usuario FROM aluno AS a INNER JOIN usuario AS u ON u.id_usuario = a.id_usuario_aluno INNER JOIN contato_aluno AS c ON c.rm_aluno_contato = a.rm_aluno INNER JOIN endereco_aluno AS e ON e.rm_aluno_endereco = a.rm_aluno WHERE a.rm_aluno IN($rows) ORDER BY concat(a.nome, concat(' ', a.sobrenome))";

				//Executando query

				$comando = $conexao->prepare($sql);

				$comando->execute();

				$dados = $comando->fetchAll();

				//Gerando Relatório

				foreach($dados as $valor){
					$img = base64_encode($valor[0]);
					$rm = htmlspecialchars($valor[1]);
					$nome = htmlspecialchars($valor[2]);
					$cpf = Mask("###.###.###-##", $valor[3]);
					$sexo = htmlspecialchars($valor[4]);
					$data = explode("-", $valor[5]);
					$data = $data[1] . "/" . $data[2] . "/" . $data[0];
					$status = htmlspecialchars($valor[6]);
					$telefone = (strlen(htmlspecialchars($valor[7])) > 0) ? Mask("(##)####-####", htmlspecialchars($valor[7])) : "";
					$celular = Mask("(##)#####-####", $valor[8]);			
					$email = htmlspecialchars($valor[9]);
					$cep = Mask("###-#####", $valor[10]);
					$logradouro = htmlspecialchars($valor[11]);
					$numero = htmlspecialchars($valor[12]);
					$bairro = htmlspecialchars($valor[13]);
					$cidade = htmlspecialchars($valor[14]);
					$complemento = htmlspecialchars($valor[15]);
					$id_usuario = htmlspecialchars($valor[16]);

					//Buscando as instituições do usuário

					$cursos = null;

					$comando = $conexao->prepare("SELECT c.nome_curso FROM curso AS c INNER JOIN curso_usuario AS ca ON ca.curso_id_curso = c.id_curso WHERE ca.usuario_id_usuario = :id");

					$comando->bindParam(":id", $id_usuario);

					$comando->execute();

					foreach($comando->fetchAll() as $valorI){
						$cursos .= $valorI[0] . ", ";
					}

					$cursos = substr($cursos, 0, (strlen($cursos) - 2));

					$html .= "<tr>
								<td><img src='data:image/jpg;base64,$img'></td>
								<td>$rm</td>
								<td>$nome</td>
								<td>$cpf</td>
								<td>$sexo</td>
								<td>$data</td>
								<td>$status</td>
								<td>$telefone</td>
								<td>$celular</td>
								<td>$email</td>
								<td>$cep</td>
								<td>$logradouro</td>
								<td>$numero</td>
								<td>$bairro</td>
								<td>$cidade</td>
								<td>$complemento</td>
								<td>$cursos</td>
							  </tr>";
				}

				echo $html;
			}else if($tipo == 2){
				$html = null;

				//Prepararando Script SQL

				$sql = "SELECT p.img_professor, p.rm_professor, CONCAT(p.nome, CONCAT(' ', p.sobrenome)) AS nome, p.cpf, CASE p.sexo WHEN 'M' THEN 'Masculino' WHEN 'F' THEN 'Feminino' ELSE 'Personalizado' END, p.data_cadastro, CASE u.status_usuario WHEN 'B' THEN 'Bloqueado' ELSE 'Desbloqueado' END, c.telefone, c.celular, c.email, e.cep, e.logradouro, e.numero, e.bairro, e.cidade, e.complemento, u.id_usuario FROM professor AS p INNER JOIN usuario AS u ON u.id_usuario = p.id_usuario_professor INNER JOIN contato_professor AS c ON c.rm_professor_contato = p.rm_professor INNER JOIN endereco_professor AS e ON e.rm_professor_endereco = p.rm_professor WHERE p.rm_professor IN($rows) ORDER BY concat(p.nome, concat(' ', p.sobrenome))";

				//Executando query

				$comando = $conexao->prepare($sql);

				$comando->execute();

				$dados = $comando->fetchAll();

				//Gerando Relatório

				foreach($dados as $valor){
					$img = base64_encode($valor[0]);
					$rm = htmlspecialchars($valor[1]);
					$nome = htmlspecialchars($valor[2]);
					$cpf = Mask("###.###.###-##", $valor[3]);
					$sexo = htmlspecialchars($valor[4]);
					$data = explode("-", $valor[5]);
					$data = $data[1] . "/" . $data[2] . "/" . $data[0];
					$status = htmlspecialchars($valor[6]);
					$telefone = (strlen(htmlspecialchars($valor[7])) > 0) ? Mask("(##)####-####", htmlspecialchars($valor[7])) : "";
					$celular = Mask("(##)#####-####", $valor[8]);			
					$email = htmlspecialchars($valor[9]);
					$cep = Mask("###-#####", $valor[10]);
					$logradouro = htmlspecialchars($valor[11]);
					$numero = htmlspecialchars($valor[12]);
					$bairro = htmlspecialchars($valor[13]);
					$cidade = htmlspecialchars($valor[14]);
					$complemento = htmlspecialchars($valor[15]);
					$id_usuario = htmlspecialchars($valor[16]);

					//Buscando as instituições do usuário

					$instituicoes = null;

					$comando = $conexao->prepare("SELECT i.nome_instituicao FROM instituicao AS i INNER JOIN instituicao_usuario AS iu ON iu.id_instituicao = i.id_instituicao WHERE iu.id_usuario = :id");

					$comando->bindParam(":id", $id_usuario);

					$comando->execute();

					foreach($comando->fetchAll() as $valorI){
						$instituicoes .= $valorI[0] . ", ";
					}

					$instituicoes = substr($instituicoes, 0, (strlen($instituicoes) - 2));

					$html .= "<tr>
								<td><img src='data:image/jpg;base64,$img'></td>
								<td>$rm</td>
								<td>$nome</td>
								<td>$cpf</td>
								<td>$sexo</td>
								<td>$data</td>
								<td>$status</td>
								<td>$telefone</td>
								<td>$celular</td>
								<td>$email</td>
								<td>$cep</td>
								<td>$logradouro</td>
								<td>$numero</td>
								<td>$bairro</td>
								<td>$cidade</td>
								<td>$complemento</td>
								<td>$instituicoes</td>
							  </tr>";
				}

				echo $html;
			}else if($tipo == 3){
				$html = null;

				//Prepararando Script SQL

				$sql = "SELECT f.img_funcionario, CONCAT(f.nome, CONCAT(' ', f.sobrenome)) AS nome, f.cpf, CASE f.sexo WHEN 'M' THEN 'Masculino' WHEN 'F' THEN 'Feminino' ELSE 'Personalizado' END, f.data_cadastro, CASE u.status_usuario WHEN 'B' THEN 'Bloqueado' ELSE 'Desbloqueado' END, c.telefone, c.celular, c.email, e.cep, e.logradouro, e.numero, e.bairro, e.cidade, e.complemento, u.id_usuario FROM funcionario AS f INNER JOIN usuario AS u ON u.id_usuario = f.id_usuario_funcionario INNER JOIN contato_funcionario AS c ON c.cpf_funcionario = f.cpf INNER JOIN endereco_funcionario AS e ON e.cpf_funcionario_endereco = f.cpf WHERE f.cpf IN($rows) ORDER BY concat(f.nome, concat(' ', f.sobrenome))";

				//Executando query

				$comando = $conexao->prepare($sql);

				$comando->execute();

				$dados = $comando->fetchAll();

				//Gerando Relatório

				foreach($dados as $valor){
					$img = base64_encode($valor[0]);
					$nome = htmlspecialchars($valor[1]);
					$cpf = Mask("###.###.###-##", $valor[2]);
					$sexo = htmlspecialchars($valor[3]);
					$data = explode("-", $valor[4]);
					$data = $data[1] . "/" . $data[2] . "/" . $data[0];
					$status = htmlspecialchars($valor[5]);
					$telefone = (strlen(htmlspecialchars($valor[6])) > 0) ? Mask("(##)####-####", htmlspecialchars($valor[6])) : "";
					$celular = Mask("(##)#####-####", $valor[7]);			
					$email = htmlspecialchars($valor[8]);
					$cep = Mask("###-#####", $valor[9]);
					$logradouro = htmlspecialchars($valor[10]);
					$numero = htmlspecialchars($valor[11]);
					$bairro = htmlspecialchars($valor[12]);
					$cidade = htmlspecialchars($valor[13]);
					$complemento = htmlspecialchars($valor[14]);
					$id_usuario = htmlspecialchars($valor[15]);

					//Buscando as instituições do usuário

					$instituicoes = null;

					$comando = $conexao->prepare("SELECT i.nome_instituicao FROM instituicao AS i INNER JOIN instituicao_usuario AS iu ON iu.id_instituicao = i.id_instituicao WHERE iu.id_usuario = :id");

					$comando->bindParam(":id", $id_usuario);

					$comando->execute();

					foreach($comando->fetchAll() as $valorI){
						$instituicoes .= $valorI[0] . ", ";
					}

					$instituicoes = substr($instituicoes, 0, (strlen($instituicoes) - 2));

					$html .= "<tr>
								<td><img src='data:image/jpg;base64,$img'></td>
								<td>$nome</td>
								<td>$cpf</td>
								<td>$sexo</td>
								<td>$data</td>
								<td>$status</td>
								<td>$telefone</td>
								<td>$celular</td>
								<td>$email</td>
								<td>$cep</td>
								<td>$logradouro</td>
								<td>$numero</td>
								<td>$bairro</td>
								<td>$cidade</td>
								<td>$complemento</td>
								<td>$instituicoes</td>
							  </tr>";
				}

				echo $html;
			}else if($tipo == 4){
				$html = null;

				//Prepararando Script SQL

				$comando = $conexao->prepare("SELECT l.img_livro, l.cod_livro, l.tombo, l.titulo, l.volume, l.edicao, e.quantidade, (e.quantidade - (SELECT COUNT(*) FROM locacao AS al WHERE al.id_exemplares = e.id_exemplares)) AS qtderes, l.insercao, l.ano_publicacao, l.isbn, l.idioma, i.nome_instituicao FROM livro AS l INNER JOIN exemplares AS e ON e.livro_tombo_exemplares = l.cod_livro INNER JOIN instituicao AS i ON i.id_instituicao = e.id_instituicao INNER JOIN genero_livro AS gl ON gl.id_livro_tombo = l.cod_livro WHERE e.id_exemplares IN($rows) GROUP BY e.id_exemplares ORDER BY l.titulo");

				//Executando query

				$comando->execute();

				$dados = $comando->fetchAll();

				//Gerando Relatório

				foreach($dados as $valor){
					$generos = null;
					$autores = null;
					$editoras = null;

					$codigo = htmlspecialchars($valor[1]);

					//Pegando os generos do livro

					$comando = $conexao->prepare("SELECT g.nome_genero FROM genero AS g INNER JOIN genero_livro AS gl ON gl.id_genero_tombo = g.id_genero WHERE gl.id_livro_tombo = :id");

					$comando->bindParam(":id", $codigo);

					$comando->execute();

					$dadosG = $comando->fetchAll();

					foreach($dadosG as $valorG){
						$generos .= htmlspecialchars($valorG[0]) . ", ";
					}

					//Pegando os autores do livro

					$comando = $conexao->prepare("SELECT a.nome_autor FROM autor AS a INNER JOIN autor_livro AS al ON al.id_autor_tombo = a.id_autor WHERE al.id_livro_tombo = :id");

					$comando->bindParam(":id", $codigo);

					$comando->execute();

					$dadosA = $comando->fetchAll();

					foreach($dadosA as $valorA){
						$autores .= htmlspecialchars($valorA[0]) . ", ";
					}

					//Pegando editoras do livro

					$comando = $conexao->prepare("SELECT e.nome_editora FROM editora AS e INNER JOIN editora_livro AS el ON el.id_editora = e.id_editora WHERE el.cod_livro = :id");

					$comando->bindParam(":id", $codigo);

					$comando->execute();

					$dadosE = $comando->fetchAll();

					foreach($dadosE as $valorE){
						$editoras .= htmlspecialchars($valorE[0]) . ", ";
					}

					//Carregando os dados

					$img = base64_encode($valor[0]);
					$tombo = htmlspecialchars($valor[2]);
					$titulo = htmlspecialchars($valor[3]);
					$volume = htmlspecialchars($valor[4]);
					$edicao = htmlspecialchars($valor[5]);
					$quantidade = htmlspecialchars($valor[6]);
					$qtderes = htmlspecialchars($valor[7]);
					$data = explode("-", htmlspecialchars($valor[8]));
					$insercao = $data[2] . "/" . $data[1] . "/" . $data[0];
					$data = explode("-", htmlspecialchars($valor[9]));
					$data = $data[2] . "/" . $data[1] . "/" . $data[0];
					$isbn = htmlspecialchars($valor[10]);
					$idioma = htmlspecialchars($valor[11]);
					$instituicao = htmlspecialchars($valor[12]);

					$generos = substr($generos, 0, strlen($generos) - 2);
					$autores = substr($autores, 0, strlen($autores) - 2);
					$editoras = substr($editoras, 0, strlen($editoras) - 2);
					
					$html .= "<tr>
								<td><img src='data:image/jpg;base64,$img'></td>
								<td>$tombo</td>
								<td>$titulo</td>
								<td>$volume</td>
								<td>$edicao</td>
								<td>$autores</td>
								<td>$generos</td>
								<td>$editoras</td>
								<td>$quantidade</td>
								<td>$qtderes</td>
								<td>$insercao</td>
								<td>$data</td>
								<td>$isbn</td>
								<td>$idioma</td>
								<td>$instituicao</td>
							<tr>";
				}

				echo $html;
			}else if($tipo == 5){
				$html = null;

				//Prepararando Script SQL

				$comando = $conexao->prepare("SELECT l.tombo, l.titulo, l.img_livro, u.id_usuario, al.data_locacao, al.data_devolucao FROM locacao AS al INNER JOIN exemplares AS e ON e.id_exemplares = al.id_exemplares INNER JOIN livro AS l ON l.cod_livro = e.livro_tombo_exemplares INNER JOIN usuario AS u ON u.id_usuario = al.id_usuario_locacao WHERE al.id_locacao IN($rows) ORDER BY al.id_locacao DESC");

				//Executando query

				$comando->execute();

				$dados = $comando->fetchAll();

				//Gerando Relatório

				foreach($dados as $valor){
					$tombo = htmlspecialchars($valor[0]);
					$titulo = htmlspecialchars($valor[1]);
					$img = base64_encode($valor[2]);
					$id_usuario = htmlspecialchars($valor[3]);
					$data_alocacao = htmlspecialchars($valor[4]);
					$data_devolucao = htmlspecialchars($valor[5]);
					$tipoUsuario = null;
					$cpf = null;
					$nome = null;
					$situacaoL = (strtotime(date("Y-m-d")) > strtotime($data_devolucao)) ? "Atrasado" : "Normal";

					$data = explode("-", $data_devolucao);
					$data_devolucao = $data[2]."/".$data[1]."/".$data[0];

					$data = explode("-", $data_alocacao);
					$data_alocacao = $data[2]."/".$data[1]."/".$data[0];

					//Pegando os dados do usuário
					
					$comando = $conexao->prepare("SELECT cpf, CONCAT(nome, CONCAT(' ', sobrenome)) FROM aluno WHERE id_usuario_aluno = :id LIMIT 1");

					$comando->bindParam(":id", $id_usuario);

					$comando->execute();

					$dadosUsuario = $comando->fetchAll();

					if(count($dadosUsuario) > 0){
						$cpf = Mask("###.###.###-##", htmlspecialchars($dadosUsuario[0][0]));
						$nome = htmlspecialchars($dadosUsuario[0][1]);
						$tipoUsuario = "Aluno";
					}else{
						$comando = $conexao->prepare("SELECT cpf, CONCAT(nome, CONCAT(' ', sobrenome)) FROM professor WHERE id_usuario_professor = :id LIMIT 1");

						$comando->bindParam(":id", $id_usuario);

						$comando->execute();

						$dadosUsuario = $comando->fetchAll();

						if(count($dadosUsuario) > 0){
							$cpf = Mask("###.###.###-##", htmlspecialchars($dadosUsuario[0][0]));
							$nome = htmlspecialchars($dadosUsuario[0][1]);
							$tipoUsuario = "Professor";
						}else{
							$comando = $conexao->prepare("SELECT cpf, CONCAT(nome, CONCAT(' ', sobrenome)) FROM funcionario WHERE id_usuario_funcionario = :id LIMIT 1");

							$comando->bindParam(":id", $id_usuario);

							$comando->execute();

							$dadosUsuario = $comando->fetchAll();

							if(count($dadosUsuario) > 0){
								$cpf = Mask("###.###.###-##", htmlspecialchars($dadosUsuario[0][0]));
								$nome = htmlspecialchars($dadosUsuario[0][1]);
								$tipoUsuario = "Funcionário";
							}
						}
					}
					
					$html .= "<tr>
								<td>$tombo</td>
								<td><img src='data:image/jpg;base64,$img'></td>
								<td>$titulo</td>
								<td>$cpf</td>
								<td>$nome</td>
								<td>$tipoUsuario</td>
								<td>$data_alocacao</td>
								<td>$data_devolucao</td>
								<td>$situacaoL</td>
							<tr>";
				}

				echo $html;
			}
		}else{
			header("location: Inicio.php");
		}
	}catch(Exception $ex){
		echo null;
	}
	
?>