<?php

	include_once "conexao.php";
	include_once "Usuario.php";
	if(!isset($_SESSION)) session_start();

	$conexao = conexao::getConexao();

	if(!isset($_SESSION["usuario"])){
		header("location: index.php");
	}

	$dadosUsuario = $_SESSION["usuario"];

	$nivelAcesso = $dadosUsuario->getNivelAcesso();

	if($nivelAcesso != "A"){
		header("location: index.php");
	}

	//Código acima - verificação de login

	if(isset($_POST["min"]) && isset($_POST["txt"])){
		$conexao = conexao::getConexao();

		try{
			$min = trim(addslashes($_POST["min"]));
			$txt = htmlspecialchars(trim(addslashes($_POST["txt"])));
			$tipo = trim(addslashes($_POST["tipo"]));
			$genero = (trim(addslashes($_POST["genero"])) != "T") ? "AND gl.id_genero_tombo = " . trim(addslashes($_POST["genero"])) : "";

			$livros = explode(',', $_POST["livros"]);

			$instituicao = trim(addslashes($_POST["instituicao"]));

			$comando = null;

			if($tipo == "T"){
				$comando = $conexao->prepare("SELECT l.cod_livro, l.tombo, l.titulo, l.insercao, l.isbn, l.img_livro, (e.quantidade - (SELECT COUNT(*) FROM locacao AS al WHERE al.id_exemplares = e.id_exemplares)), e.id_exemplares FROM livro AS l LEFT JOIN exemplares AS e ON e.livro_tombo_exemplares = l.cod_livro INNER JOIN genero_livro AS gl ON gl.id_livro_tombo = l.cod_livro WHERE (e.id_instituicao = :id OR l.tombo IS NULL) AND l.titulo LIKE :txt $genero GROUP BY e.id_exemplares ORDER BY l.titulo LIMIT $min, 10");

				$comando->bindValue(":id", $instituicao);
				$comando->bindValue(":txt", "%$txt%");
			}else if($tipo == "TO"){
				$comando = $conexao->prepare("SELECT l.cod_livro, l.tombo, l.titulo, l.insercao, l.isbn, l.img_livro, (e.quantidade - (SELECT COUNT(*) FROM locacao AS al WHERE al.id_exemplares = e.id_exemplares)), e.id_exemplares FROM livro AS l LEFT JOIN exemplares AS e ON e.livro_tombo_exemplares = l.cod_livro INNER JOIN genero_livro AS gl ON gl.id_livro_tombo = l.cod_livro WHERE e.id_instituicao = :id AND l.tombo LIKE :txt $genero GROUP BY e.id_exemplares ORDER BY l.titulo LIMIT $min, 10");

				$comando->bindValue(":id", $instituicao);
				$comando->bindValue(":txt", "%$txt%");
			}else{
				$comando = $conexao->prepare("SELECT l.cod_livro, l.tombo, l.titulo, l.insercao, l.isbn, l.img_livro, (e.quantidade - (SELECT COUNT(*) FROM locacao AS al WHERE al.id_exemplares = e.id_exemplares)), e.id_exemplares FROM livro AS l LEFT JOIN exemplares AS e ON e.livro_tombo_exemplares = l.cod_livro INNER JOIN genero_livro AS gl ON gl.id_livro_tombo = l.cod_livro WHERE e.id_instituicao = :id AND l.isbn LIKE :txt $genero GROUP BY e.id_exemplares ORDER BY l.titulo LIMIT $min, 10");

				$comando->bindValue(":id", $instituicao);
				$comando->bindValue(":txt", "%$txt%");
			}
			
			$comando->execute();

			$dados = $comando->fetchAll();

			$html = null;

			if(count($dados) > 0){
				foreach($dados as $valor){
					$generos = null;
					$autores = null;

					$codigo = htmlspecialchars($valor[0]);

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

					//Carregando os dados

					$tombo = htmlspecialchars($valor[1]);
					$titulo = htmlspecialchars($valor[2]);
					$insercao = explode("-", htmlspecialchars($valor[3]));
					$insercao = $insercao[2] . "/" . $insercao[1] . "/" . $insercao[0];
					$isbn = htmlspecialchars($valor[4]);
					$img = base64_encode($valor[5]);
					$qtde = htmlspecialchars($valor[6]);
					$codigoExemplar = htmlspecialchars($valor[7]);

					$generos = substr($generos, 0, strlen($generos) - 2);
					$autores = substr($autores, 0, strlen($autores) - 2);

					//Verificando instituições no sistema

					$opcoes = null;

					$comando = $conexao->prepare("SELECT * FROM instituicao LIMIT 2");

					$comando->execute();

					if(count($comando->fetchAll()) > 1){
						$opcoes = "<a href='exportarExemplares.php?codL=$codigo&codE=$codigoExemplar'><i class='fas fa-file-export' title='Exportar exemplares'></i></a>
								   <i class='fas fa-trash-alt' title='Excluir' onclick='abreMoldalSenha($codigoExemplar, $codigo)'></i>
								   <a href='editLivro.php?codL=$codigo&codE=$codigoExemplar'><i class='fas fa-pencil-alt' title='Editar'></i></a>";
					}else{
						$opcoes = "<i class='fas fa-trash-alt' title='Excluir' onclick='abreMoldalSenha($codigoExemplar, $codigo)'></i>
								   <a href='editLivro.php?codL=$codigo&codE=$codigoExemplar'><i class='fas fa-pencil-alt' title='Editar'></i></a>";
					}

					if(strlen($tombo) > 0){
						if(in_array($codigoExemplar, $livros)){
							$html .= "<tr class='dadoInfo'>
										<td><input type='checkbox' checked onchange='selecionaLivro($codigoExemplar)'></td>
										<td><img src='data:image/jpg;base64,$img'></td>
										<td>$tombo</td>
										<td>$titulo</td>
										<td>$autores</td>
										<td>$generos</td>
										<td>$qtde</td>
										<td>$insercao</td>
										<td>$isbn</td>
										<td>
											$opcoes
										</td>
									<tr>";
						}else{
							$html .= "<tr class='dadoInfo'>
										<td><input type='checkbox' onchange='selecionaLivro($codigoExemplar)'></td>
										<td><img src='data:image/jpg;base64,$img'></td>
										<td>$tombo</td>
										<td>$titulo</td>
										<td>$autores</td>
										<td>$generos</td>
										<td>$qtde</td>
										<td>$insercao</td>
										<td>$isbn</td>
										<td>
											$opcoes
										</td>
									<tr>";
						}
					}else{
						$html .= "<tr class='dadoInfo'>
									<td>Opção inacessível</td>
									<td><img src='data:image/jpg;base64,$img'></td>
									<td>$tombo</td>
									<td>$titulo</td>
									<td>$autores</td>
									<td>$generos</td>
									<td>$qtde</td>
									<td>$insercao</td>
									<td>$isbn</td>
									<td>
										<i class='fas fa-trash-alt' title='Excluir' onclick='abreMoldalSenha(0, $codigo)'></i>
										<a href='editLivroPDF.php?codL=$codigo'><i class='fas fa-pencil-alt' title='Editar'></i></a>
									</td>
								<tr>";
					}	
				}

				if(count($dados) >= 10){
					$html .= "<tr id='carregarMaisTable'>
								<td colspan='12'><button class='btnCarr' onclick='carregaLivro(this)'><i class='fas fa-plus'></i></button></td>
							</tr>";
				}
			}else{

				if($min == 0 && strlen($txt) == 0){
					$html .= "<tr>
								<td colspan='12'><h4>Não foi possivel localizar nenhum livro cadastrado com o filtros requisitados!</h4></td>
							 </tr>";
				}else if(strlen($txt) > 0){
					if($tipo == "T"){
						$html .= "<tr>
									<td colspan='12'><h4>Não foi possivel localizar nenhum livro cadastrado com o titulo '$txt'</h4></td>
								 </tr>";
					}else if($tipo == "TO"){
						$html .= "<tr>
									<td colspan='12'><h4>Não foi possivel localizar nenhum livro cadastrado com o tombo '$txt'</h4></td>
								 </tr>";
					}else{
						$html .= "<tr>
									<td colspan='12'><h4>Não foi possivel localizar nenhum livro cadastrado com o ISBN '$txt'</h4></td>
								 </tr>";
					}
				}
			}

			echo $html;

		}catch(Exception $ex){
			echo "<tr id='carregarMaisTable'>
					<td colspan='12'><button class='btnCarr' onclick='carregaLivro(this)'><i class='fas fa-plus'></i></button></td>
				  </tr>";
		}
	}else{
		header("location: alunos.php");
	}

?>