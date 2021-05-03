<?php

	include_once "conexao.php";
	include_once "Usuario.php";
	if(!isset($_SESSION)) session_start();

	$conexao = conexao::getConexao();

	if(!isset($_SESSION["usuario"])){
		header("location: index.php");
	}

	try{
		$conexao = conexao::getConexao();

		$codigo = null;

		if(isset($_POST["cod"]) && isset($_POST["min"])){
			$codigo = trim(addslashes($_POST["cod"]));
			$minimo = trim(addslashes($_POST["min"]));

			//Verificando se o código passado está associado há algum livro no sistema

			$comando = $conexao->prepare("SELECT l.cod_livro, l.titulo, l.idioma, l.img_livro, (SELECT AVG(avaliacao_estrelas) FROM avaliacao WHERE livro_tombo_avaliacao = l.cod_livro) FROM livro AS l INNER JOIN genero_livro AS g ON g.id_livro_tombo = l.cod_livro WHERE g.id_genero_tombo = :cod LIMIT $minimo, 10");

			$comando->bindParam(":cod", $codigo);

			$comando->execute();

			$dadosLivro = $comando->fetchAll();

			$html = null;

			if(count($dadosLivro) > 0){
				
				foreach($dadosLivro as $value){
					$codigoL = htmlspecialchars($value[0]);
					$titulo = htmlspecialchars($value[1]);
					$idioma = htmlspecialchars($value[2]);
					$img = base64_encode($value[3]);
					$avaliacao = (strlen(htmlspecialchars($value[4])) > 0) ? htmlspecialchars($value[4]) : 0;

					$avaliacao = number_format($avaliacao, 1);

					$tituloCompleto = htmlspecialchars($value[1]);

					if(strlen($titulo) > 20){
						$titulo = substr($titulo, 0, 40) . "...";
					}

					$html .= "<a href='telaLivro.php?cod_livro=$codigoL'>
								<main>
									<img src='data:image/jpg;base64,$img'>
									<div>
										<div>
											<h4 title='$tituloCompleto'>$titulo</h4><br>
											<p>$avaliacao <i class='fas fa-star'></i> | $idioma <i class='fas fa-language'></i></p>
										</div>
									</div>
								</main>
							</a>";
				}

				if(count($dadosLivro) >= 10){
					$html .= "<div id='loadingCont'>
								<div class='carregarMais' title='Carregar Mais Livros' onclick='carregaMaisLivrosGen($codigo, this)'><i class='fas fa-plus'></i></div>
							  </div>";
				}

			}else{
				$html = "";
			}

			echo $html;
		}else{
			header("location: Inicio.php");
		}

	}catch(PDOException $ex){
		header("location: Inicio.php");
	}
?>