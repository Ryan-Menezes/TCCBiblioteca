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
		if(isset($_POST["tipo"]) && isset($_POST["columns"]) && isset($_POST["rows"]) && isset($_POST["title"])){
			$tipo = trim(addslashes($_POST["tipo"]));
			$columns = explode(",", trim(addslashes($_POST["columns"])));
			$rows = trim(addslashes($_POST["rows"]));
			$titulo = htmlspecialchars(trim(addslashes($_POST["title"])));

			if($tipo == 1){ //1 - Alunos | 2 - Professores | 3 - Funcionários | 4 - Livros

				$html = null;

				$colunas = ["a.img_aluno", "a.rm_aluno", "concat(a.nome, concat(' ', a.sobrenome)) AS nome", "a.cpf", "CASE a.sexo WHEN 'M' THEN 'Masculino' WHEN 'F' THEN 'Feminino' ELSE 'Personalizado' END", "a.data_cadastro", "CASE u.status_usuario WHEN 'B' THEN 'Bloqueado' ELSE 'Desbloqueado' END", "c.telefone", "c.celular", "c.email", "e.cep", "e.logradouro", "e.numero", "e.bairro", "e.cidade", "e.complemento", "u.id_usuario"];

				$colunasVisiveis = ["Foto", "RM", "Nome", "CPF", "Sexo", "Data de Cadastro", "Status", "Telefone", "Celular", "E-Mail", "CEP", "Logradouro", "Número", "Bairro", "Cidade", "Complemento", "Curso(s)"];

				//Prepararando Script SQL

				$sql = "SELECT ";

				for($i = 0; $i < count($columns); $i++){
					$sql .= $colunas[$columns[$i]] . ", ";
				}

				$sql = substr($sql, 0, (strlen($sql) - 2));

				$sql .= " FROM aluno AS a INNER JOIN usuario AS u ON u.id_usuario = a.id_usuario_aluno INNER JOIN contato_aluno AS c ON c.rm_aluno_contato = a.rm_aluno INNER JOIN endereco_aluno AS e ON e.rm_aluno_endereco = a.rm_aluno WHERE a.rm_aluno IN($rows) ORDER BY concat(a.nome, concat(' ', a.sobrenome))";

				//Executando query

				$comando = $conexao->prepare($sql);

				$comando->execute();

				$dados = $comando->fetchAll();

				//Gerando Relatório

				$html = "<!DOCTYPE html>
						 <html lang='pt-br'>
						 <head>
							<title>Alunos</title>
							<meta charset='utf-8'>
						 </head>
						 <body>
						 <table style='text-align: center'>
							<thead>
								<tr>
									<th colspan='".(($columns[0] == "0") ? count($columns) - 1 : count($columns))."'>$titulo</th>
								</tr>
								<tr>";

				for($i = 0; $i < count($columns); $i++){
					if($columns[$i] != "0"){
						$html .= "<th>" . $colunasVisiveis[$columns[$i]] . "</th>";
					}	
				}
									
				$html .=  "</tr></thead><tbody>";

				foreach($dados as $valor){
					$html .= "<tr>";

					for($i = 0; $i < (count($valor)/2); $i++){
						if($columns[$i] != "0"){
							if($columns[$i] == "3"){ //CPF

								$cpf = Mask("###.###.###-##", htmlspecialchars($valor[$i]));

								$html .= "<td>" . $cpf . "</td>";
							}else if($columns[$i] == "5"){ //Data

								$data = explode("-", htmlspecialchars($valor[$i]));

								$html .= "<td>" . $data[1] . "/" . $data[2] . "/" . $data[0] . "</td>";
							}else if($columns[$i] == "7"){ //Telefone

								$telefone = (strlen(htmlspecialchars($valor[$i])) > 0) ? Mask("(##)####-####", htmlspecialchars($valor[$i])) : "";

								$html .= "<td>" . $telefone . "</td>";
							}else if($columns[$i] == "8"){ //Celular

								$celular = Mask("(##)#####-####", htmlspecialchars($valor[$i]));

								$html .= "<td>" . $celular . "</td>";
							}else if($columns[$i] == "10"){ //CEP

								$cep = Mask("###-#####", htmlspecialchars($valor[$i]));

								$html .= "<td>" . $cep . "</td>";
							}else if($columns[$i] == "16"){//Cursos

								$id_usuario = htmlspecialchars($valor[$i]);
								$cursos = null;

								$comando = $conexao->prepare("SELECT c.nome_curso FROM curso AS c INNER JOIN curso_usuario AS ca ON ca.curso_id_curso = c.id_curso WHERE ca.usuario_id_usuario = :id");

								$comando->bindParam(":id", $id_usuario);

								$comando->execute();

								foreach($comando->fetchAll() as $valorI){
									$cursos .= $valorI[0] . ", ";
								}

								$cursos = substr($cursos, 0, (strlen($cursos) - 2));

								$html .= "<td>$cursos</td>";
							}else{
								$html .= "<td>" . htmlspecialchars($valor[$i]) . "</td>";
							}	
						}
					}

					$html .= "</tr>";
				}

				$html .= "</tbody></table></body></html>";

				echo $html;
			}else if($tipo == 2){
				$html = null;

				$colunas = ["p.img_professor", "p.rm_professor", "concat(p.nome, concat(' ', p.sobrenome)) AS nome", "p.cpf", "CASE p.sexo WHEN 'M' THEN 'Masculino' WHEN 'F' THEN 'Feminino' ELSE 'Personalizado' END", "p.data_cadastro", "CASE u.status_usuario WHEN 'B' THEN 'Bloqueado' ELSE 'Desbloqueado' END", "c.telefone", "c.celular", "c.email", "e.cep", "e.logradouro", "e.numero", "e.bairro", "e.cidade", "e.complemento", "u.id_usuario"];

				$colunasVisiveis = ["Foto", "RM", "Nome", "CPF", "Sexo", "Data de Cadastro", "Status", "Telefone", "Celular", "E-Mail", "CEP", "Logradouro", "Número", "Bairro", "Cidade", "Complemento", "Instituição(ões)"];

				//Prepararando Script SQL

				$sql = "SELECT ";

				for($i = 0; $i < count($columns); $i++){
					$sql .= $colunas[$columns[$i]] . ", ";
				}

				$sql = substr($sql, 0, (strlen($sql) - 2));

				$sql .= " FROM professor AS p INNER JOIN usuario AS u ON u.id_usuario = p.id_usuario_professor INNER JOIN contato_professor AS c ON c.rm_professor_contato = p.rm_professor INNER JOIN endereco_professor AS e ON e.rm_professor_endereco = p.rm_professor WHERE p.rm_professor IN($rows) ORDER BY concat(p.nome, concat(' ', p.sobrenome))";

				//Executando query

				$comando = $conexao->prepare($sql);

				$comando->execute();

				$dados = $comando->fetchAll();

				//Gerando Relatório

				$html = "<!DOCTYPE html>
						 <html lang='pt-br'>
						 <head>
							<title>Professores</title>
							<meta charset='utf-8'>
						 </head>
						 <body>
						 <table style='text-align: center'>
							<thead>
								<tr>
									<th colspan='".(($columns[0] == "0") ? count($columns) - 1 : count($columns))."'>$titulo</th>
								</tr>
								<tr>";

				for($i = 0; $i < count($columns); $i++){
					if($columns[$i] != "0"){
						$html .= "<th>" . $colunasVisiveis[$columns[$i]] . "</th>";
					}	
				}
									
				$html .=  "</tr></thead><tbody>";

				foreach($dados as $valor){
					$html .= "<tr>";

					for($i = 0; $i < (count($valor)/2); $i++){
						if($columns[$i] != "0"){
							if($columns[$i] == "3"){ //CPF

								$cpf = Mask("###.###.###-##", htmlspecialchars($valor[$i]));

								$html .= "<td>" . $cpf . "</td>";
							}else if($columns[$i] == "5"){ //Data

								$data = explode("-", htmlspecialchars($valor[$i]));

								$html .= "<td>" . $data[1] . "/" . $data[2] . "/" . $data[0] . "</td>";
							}else if($columns[$i] == "7"){ //Telefone

								$telefone = (strlen(htmlspecialchars($valor[$i])) > 0) ? Mask("(##)####-####", htmlspecialchars($valor[$i])) : "";

								$html .= "<td>" . $telefone . "</td>";
							}else if($columns[$i] == "8"){ //Celular

								$celular = Mask("(##)#####-####", htmlspecialchars($valor[$i]));

								$html .= "<td>" . $celular . "</td>";
							}else if($columns[$i] == "10"){ //CEP

								$cep = Mask("###-#####", htmlspecialchars($valor[$i]));

								$html .= "<td>" . $cep . "</td>";
							}else if($columns[$i] == "16"){//Instituições

								$id_usuario = htmlspecialchars($valor[$i]);
								$instituicoes = null;

								$comando = $conexao->prepare("SELECT i.nome_instituicao FROM instituicao AS i INNER JOIN instituicao_usuario AS iu ON iu.id_instituicao = i.id_instituicao WHERE iu.id_usuario = :id");

								$comando->bindParam(":id", $id_usuario);

								$comando->execute();

								foreach($comando->fetchAll() as $valorI){
									$instituicoes .= $valorI[0] . ", ";
								}

								$instituicoes = substr($instituicoes, 0, (strlen($instituicoes) - 2));

								$html .= "<td>$instituicoes</td>";
							}else{
								$html .= "<td>" . htmlspecialchars($valor[$i]) . "</td>";
							}	
						}
					}

					$html .= "</tr>";
				}

				$html .= "</tbody></table></body></html>";

				echo $html;
			}else if($tipo == 3){
				$html = null;

				$colunas = ["f.img_funcionario", "concat(f.nome, concat(' ', f.sobrenome)) AS nome", "f.cpf", "CASE f.sexo WHEN 'M' THEN 'Masculino' WHEN 'F' THEN 'Feminino' ELSE 'Personalizado' END", "f.data_cadastro", "CASE u.status_usuario WHEN 'B' THEN 'Bloqueado' ELSE 'Desbloqueado' END", "c.telefone", "c.celular", "c.email", "e.cep", "e.logradouro", "e.numero", "e.bairro", "e.cidade", "e.complemento", "u.id_usuario"];

				$colunasVisiveis = ["Foto", "Nome", "CPF", "Sexo", "Data de Cadastro", "Status", "Telefone", "Celular", "E-Mail", "CEP", "Logradouro", "Número", "Bairro", "Cidade", "Complemento", "Instituição(ões)"];

				//Prepararando Script SQL

				$sql = "SELECT ";

				for($i = 0; $i < count($columns); $i++){
					$sql .= $colunas[$columns[$i]] . ", ";
				}

				$sql = substr($sql, 0, (strlen($sql) - 2));

				$sql .= " FROM funcionario AS f INNER JOIN usuario AS u ON u.id_usuario = f.id_usuario_funcionario INNER JOIN contato_funcionario AS c ON c.cpf_funcionario = f.cpf INNER JOIN endereco_funcionario AS e ON e.cpf_funcionario_endereco = f.cpf WHERE f.cpf IN($rows) ORDER BY concat(f.nome, concat(' ', f.sobrenome))";

				//Executando query

				$comando = $conexao->prepare($sql);

				$comando->execute();

				$dados = $comando->fetchAll();

				//Gerando Relatório

				$html = "<!DOCTYPE html>
						 <html lang='pt-br'>
						 <head>
							<title>Funcionários</title>
							<meta charset='utf-8'>
						 </head>
						 <body>
						 <table style='text-align: center'>
							<thead>
								<tr class='thHeader'>
									<th colspan='".(($columns[0] == "0") ? count($columns) - 1 : count($columns))."'>$titulo</th>
								</tr>
								<tr>";

				for($i = 0; $i < count($columns); $i++){
					if($columns[$i] != "0"){
						$html .= "<th>" . $colunasVisiveis[$columns[$i]] . "</th>";
					}
				}
									
				$html .=  "</tr></thead><tbody>";

				foreach($dados as $valor){
					$html .= "<tr>";

					for($i = 0; $i < (count($valor)/2); $i++){
						if($columns[$i] != "0"){
							if($columns[$i] == "2"){ //CPF

								$cpf = Mask("###.###.###-##", htmlspecialchars($valor[$i]));

								$html .= "<td>" . $cpf . "</td>";
							}else if($columns[$i] == "4"){ //Data

								$data = explode("-", htmlspecialchars($valor[$i]));

								$html .= "<td>" . $data[1] . "/" . $data[2] . "/" . $data[0] . "</td>";
							}else if($columns[$i] == "6"){ //Telefone

								$telefone = (strlen(htmlspecialchars($valor[$i])) > 0) ? Mask("(##)####-####", htmlspecialchars($valor[$i])) : "";

								$html .= "<td>" . $telefone . "</td>";
							}else if($columns[$i] == "7"){ //Celular

								$celular = Mask("(##)#####-####", htmlspecialchars($valor[$i]));

								$html .= "<td>" . $celular . "</td>";
							}else if($columns[$i] == "9"){ //CEP

								$celular = Mask("###-#####", htmlspecialchars($valor[$i]));

								$html .= "<td>" . $celular . "</td>";
							}else if($columns[$i] == "15"){//Instituições

								$id_usuario = htmlspecialchars($valor[$i]);
								$instituicoes = null;

								$comando = $conexao->prepare("SELECT i.nome_instituicao FROM instituicao AS i INNER JOIN instituicao_usuario AS iu ON iu.id_instituicao = i.id_instituicao WHERE iu.id_usuario = :id");

								$comando->bindParam(":id", $id_usuario);

								$comando->execute();

								foreach($comando->fetchAll() as $valorI){
									$instituicoes .= $valorI[0] . ", ";
								}

								$instituicoes = substr($instituicoes, 0, (strlen($instituicoes) - 2));

								$html .= "<td>$instituicoes</td>";
							}else{
								$html .= "<td>" . htmlspecialchars($valor[$i]) . "</td>";
							}
						}	
					}

					$html .= "</tr>";
				}

				$html .= "</tbody></table></body></html>";

				echo $html;
			}else if($tipo == 4){
				$html = null;

				$colunas = ["l.img_livro", "l.tombo", "l.titulo", "l.volume", "l.edicao", "e.id_exemplares", "e.id_exemplares", "e.id_exemplares", "e.quantidade", "(e.quantidade - (SELECT COUNT(*) FROM locacao AS al WHERE al.id_exemplares = e.id_exemplares)) AS qtderes", "l.insercao", "l.ano_publicacao", "l.isbn", "l.idioma", "i.nome_instituicao"];

				$colunasVisiveis = ["Capa", "Tombo", "Titulo", "Volume", "Edição", "Autor(es)", "Genêro(s)", "Editora(s)", "Total de exemplares", "Exemplares disponíveis", "Data de inserção", "Data de publicação", "ISBN", "Idioma", "Instituição"];

				//Prepararando Script SQL

				$sql = "SELECT ";

				for($i = 0; $i < count($columns); $i++){
					$sql .= $colunas[$columns[$i]] . ", ";
				}

				$sql = substr($sql, 0, strlen($sql) - 2);

				$sql .= " FROM livro AS l INNER JOIN exemplares AS e ON e.livro_tombo_exemplares = l.cod_livro INNER JOIN instituicao AS i ON i.id_instituicao = e.id_instituicao INNER JOIN genero_livro AS gl ON gl.id_livro_tombo = l.cod_livro WHERE e.id_exemplares IN($rows) GROUP BY e.id_exemplares ORDER BY l.titulo";

				//Executando query

				$comando = $conexao->prepare($sql);

				$comando->execute();

				$dados = $comando->fetchAll();

				//Gerando Relatório

				$html = "<!DOCTYPE html>
						 <html lang='pt-br'>
						 <head>
							<title>Livros</title>
							<meta charset='utf-8'>
						 </head>
						 <body>
						 <table style='text-align: center'>
							<thead>
								<tr class='thHeader'>
									<th colspan='".(($columns[0] == "0") ? count($columns) - 1 : count($columns))."'>$titulo</th>
								</tr>
								<tr>";

				for($i = 0; $i < count($columns); $i++){
					if($columns[$i] != "0"){
						$html .= "<th>" . $colunasVisiveis[$columns[$i]] . "</th>";
					}
				}
									
				$html .=  "</tr></thead><tbody>";

				$rows = explode(",", $rows);
				$li = 0;

				foreach($dados as $valor){

					//pegando código do livro

					$cmd = $conexao->prepare("SELECT l.cod_livro FROM livro AS l INNER JOIN exemplares AS e ON e.livro_tombo_exemplares = l.cod_livro INNER JOIN genero_livro AS gl ON gl.id_livro_tombo = l.cod_livro WHERE e.id_exemplares = :linha GROUP BY e.id_exemplares LIMIT 1");

					$cmd->bindParam(":linha", $rows[$li]);

					$cmd->execute();

					$dadosCodigo = $cmd->fetchAll();

					$cod_livro = htmlspecialchars($dadosCodigo[0][0]);

					$html .= "<tr>";

					for($i = 0; $i < count($columns); $i++){
						if($columns[$i] != "0"){
							if($columns[$i] == "5"){ //Autores
								$comando = $conexao->prepare("SELECT a.nome_autor FROM autor AS a INNER JOIN autor_livro AS al ON al.id_autor_tombo = a.id_autor WHERE al.id_livro_tombo = :id");

								$comando->bindParam(":id", $cod_livro);

								$comando->execute();

								$dadosA = $comando->fetchAll();

								$html .= "<td>";

								foreach($dadosA as $valorA){
									$html .= htmlspecialchars($valorA[0]) . ", ";
								}

								$html = substr($html, 0, strlen($html) - 2);

								$html .= "</td>";
							}else if($columns[$i] == "6"){ //Genêros
								$comando = $conexao->prepare("SELECT g.nome_genero FROM genero AS g INNER JOIN genero_livro AS gl ON gl.id_genero_tombo = g.id_genero WHERE gl.id_livro_tombo = :id");

								$comando->bindParam(":id", $cod_livro);

								$comando->execute();

								$dadosG = $comando->fetchAll();

								$html .= "<td>";

								foreach($dadosG as $valorG){
									$html .= htmlspecialchars($valorG[0]) . ", ";
								}

								$html = substr($html, 0, strlen($html) - 2);

								$html .= "</td>";
							}else if($columns[$i] == "7"){ //Editoras
								$comando = $conexao->prepare("SELECT e.nome_editora FROM editora AS e INNER JOIN editora_livro AS el ON el.id_editora = e.id_editora WHERE el.cod_livro = :id");

								$comando->bindParam(":id", $cod_livro);

								$comando->execute();

								$dadosE = $comando->fetchAll();

								$html .= "<td>";

								foreach($dadosE as $valorE){
									$html .= htmlspecialchars($valorE[0]) . ", ";
								}

								$html = substr($html, 0, strlen($html) - 2);

								$html .= "</td>";
							}else if($columns[$i] == "10"){
								$html .= "<td>" . explode("-", htmlspecialchars($valor[$i]))[2] . "/" . explode("-", htmlspecialchars($valor[$i]))[1] . "/" . explode("-", htmlspecialchars($valor[$i]))[0] ."</td>";
							}else if($columns[$i] == "11"){
								$html .= "<td>" . explode("-", htmlspecialchars($valor[$i]))[2] . "/" . explode("-",htmlspecialchars($valor[$i]))[1] . "/" . explode("-", htmlspecialchars($valor[$i]))[0] ."</td>";
							}else{	
								$html .= "<td>" . htmlspecialchars($valor[$i]) . "</td>";
							}
						}	
					}

					$html .= "</tr>";

					$li++;
				}

				$html .= "</tbody></table></body></html>";

				echo $html;
			}else if($tipo == 5){
				$html = null;

				$colunas = ["l.tombo", "l.img_livro", "l.titulo", "u.id_usuario", "u.id_usuario", "u.id_usuario", "al.data_locacao", "al.data_devolucao", "al.id_locacao"];

				$colunasVisiveis = ["Tombo", "Capa", "Titulo", "CPF", "Usuário", "Tipo de Usuário", "Data da Alocação", "Data de Devolução", "Situação"];

				//Prepararando Script SQL

				$sql = "SELECT ";

				for($i = 0; $i < count($columns); $i++){
					$sql .= $colunas[$columns[$i]] . ", ";
				}

				$sql = substr($sql, 0, strlen($sql) - 2);

				$sql .= " FROM locacao AS al INNER JOIN exemplares AS e ON e.id_exemplares = al.id_exemplares INNER JOIN livro AS l ON l.cod_livro = e.livro_tombo_exemplares INNER JOIN usuario AS u ON u.id_usuario = al.id_usuario_locacao WHERE al.id_locacao IN($rows) ORDER BY al.id_locacao DESC";

				//Executando query

				$comando = $conexao->prepare($sql);

				$comando->execute();

				$dados = $comando->fetchAll();

				//Gerando Relatório

				$html = "<!DOCTYPE html>
						 <html lang='pt-br'>
						 <head>
							<title>Alocações</title>
							<meta charset='utf-8'>
						 </head>
						 <body>
						 <table style='text-align: center'>
							<thead>
								<tr class='thHeader'>
									<th colspan='".(($columns[1] == "1") ? count($columns) - 1 : count($columns))."'>$titulo</th>
								</tr>
								<tr>";

				for($i = 0; $i < count($columns); $i++){
					if($columns[$i] != "1"){
						$html .= "<th>" . $colunasVisiveis[$columns[$i]] . "</th>";
					}
				}
									
				$html .=  "</tr></thead><tbody>";

				$cpf = null;
				$nome = null;
				$tipoUsuario = null;
				$cod_usuario = null;

				foreach($dados as $valor){

					$html .= "<tr>";

					for($i = 0; $i < count($columns); $i++){
						if($columns[$i] != "1"){
							if($columns[$i] == "3" || $columns[$i] == "4" || $columns[$i] == "5"){ //Usuário
								//Pegando os dados do usuário
						
								$comando = $conexao->prepare("SELECT cpf, CONCAT(nome, CONCAT(' ', sobrenome)) FROM aluno WHERE id_usuario_aluno = :id LIMIT 1");

								$comando->bindValue(":id", htmlspecialchars($valor[$i]));

								$comando->execute();

								$dadosUsuario = $comando->fetchAll();

								if(count($dadosUsuario) > 0){
									$cpf = Mask("###.###.###-##", htmlspecialchars($dadosUsuario[0][0]));
									$nome = htmlspecialchars($dadosUsuario[0][1]);
									$tipoUsuario = "Aluno";
								}else{
									$comando = $conexao->prepare("SELECT cpf, CONCAT(nome, CONCAT(' ', sobrenome)) FROM professor WHERE id_usuario_professor = :id LIMIT 1");

									$comando->bindValue(":id", htmlspecialchars($valor[$i]));

									$comando->execute();

									$dadosUsuario = $comando->fetchAll();

									if(count($dadosUsuario) > 0){
										$cpf = Mask("###.###.###-##", htmlspecialchars($dadosUsuario[0][0]));
										$nome = htmlspecialchars($dadosUsuario[0][1]);
										$tipoUsuario = "Professor";
									}else{
										$comando = $conexao->prepare("SELECT cpf, CONCAT(nome, CONCAT(' ', sobrenome)) FROM funcionario WHERE id_usuario_funcionario = :id LIMIT 1");

										$comando->bindValue(":id", htmlspecialchars($valor[$i]));

										$comando->execute();

										$dadosUsuario = $comando->fetchAll();

										if(count($dadosUsuario) > 0){
											$cpf = Mask("###.###.###-##", htmlspecialchars($dadosUsuario[0][0]));
											$nome = htmlspecialchars($dadosUsuario[0][1]);
											$tipoUsuario = "Funcionário";
										}
									}
								}

								if($columns[$i] == "3") $html .= "<td>$cpf</td>";
								else if($columns[$i] == "4") $html .= "<td>$nome</td>";
								else $html .= "<td>$tipoUsuario</td>";

							}else if($columns[$i] == "6"){
								$html .= "<td>" . explode("-", htmlspecialchars($valor[$i]))[2] . "/" . explode("-", htmlspecialchars($valor[$i]))[1] . "/" . explode("-", htmlspecialchars($valor[$i]))[0] ."</td>";
							}else if($columns[$i] == "7"){
								$html .= "<td>" . explode("-", htmlspecialchars($valor[$i]))[2] . "/" . explode("-", htmlspecialchars($valor[$i]))[1] . "/" . explode("-", htmlspecialchars($valor[$i]))[0] ."</td>";
							}else if($columns[$i] == "8"){
								$comando = $conexao->prepare("SELECT data_devolucao FROM locacao WHERE id_locacao = :id LIMIT 1");

								$comando->bindValue(":id", htmlspecialchars($valor[$i]));

								$comando->execute();

								$data_devolucao = $comando->fetchAll()[0][0];

								$situacaoL = (strtotime(date("Y-m-d")) > strtotime($data_devolucao)) ? "Atrasado" : "Normal";

								$html .= "<td>$situacaoL</td>";
							}else{	
								$html .= "<td>" . htmlspecialchars($valor[$i]) . "</td>";
							}
						} 	
					}

					$html .= "</tr>";
				}

				$html .= "</tbody></table></body></html>";

				echo $html;
			}
		}else{
			header("location: Inicio.php");
		}
	}catch(Exception $ex){
		echo null;
	}
	
?>