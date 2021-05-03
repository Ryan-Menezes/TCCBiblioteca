<?php

	include_once "conexao.php";
	include_once "Usuario.php";
	if(!isset($_SESSION)) session_start();

	$conexao = conexao::getConexao();

	if(!isset($_SESSION["usuario"])){
		header("location: index.php");
	}

	$minimo = 0;

	if(isset($_POST["min"])){
		try{
			$conexao = conexao::getConexao();

			$minimo = trim(addslashes($_POST["min"]));

			$comando = $conexao->prepare("SELECT g.id_genero, g.nome_genero FROM genero AS g INNER JOIN genero_livro AS l ON  g.id_genero = l.id_genero_tombo GROUP BY g.nome_genero LIMIT $minimo, 5");

			$comando->execute();

			$dados = $comando->fetchAll();

			$html = null;

			$i = $minimo + 1;

			foreach($dados as $value) {
				$codigoG = htmlspecialchars($value[0]);
				$nome = htmlspecialchars($value[1]);

				//Buscando livro

				$comando = $conexao->prepare("SELECT l.cod_livro, l.titulo, l.img_livro, l.idioma, (SELECT AVG(avaliacao_estrelas) FROM avaliacao WHERE livro_tombo_avaliacao = l.cod_livro) FROM livro AS l INNER JOIN genero_livro AS gl ON l.cod_livro = gl.id_livro_tombo WHERE gl.id_genero_tombo = :genero ORDER BY l.cod_livro DESC LIMIT 0, 9");

				$comando->bindParam(":genero", $codigoG);

				$comando->execute();

				$dadosLivro = $comando->fetchAll();

				if(count($dadosLivro) >= 5){
					$html .= "<div class='TituloC'>
								<h2>$nome</h2>
								<a href='generosInicio.php?cod_genero=$codigoG'><div><i class='fas fa-arrow-right'></i></div></a>
							</div>";

					$html .= "<div class='container'>
								<div class='btnLivro back' onclick='back($i)'><i class='fas fa-angle-left'></i></div>

								<section class='carrosselLivros' id='carrossel$i'>
									<ul id='carro$i'>";

					foreach($dadosLivro as $valueL){
						$codigo = htmlspecialchars($valueL[0]);
						$titulo = htmlspecialchars($valueL[1]);
						$img = base64_encode($valueL[2]);
						$idioma = htmlspecialchars($valueL[3]);
						$avaliacao = (strlen(htmlspecialchars($valueL[4])) > 0) ? htmlspecialchars($valueL[4]) : 0;

						$avaliacao = number_format($avaliacao, 1);

						$tituloCompleto = htmlspecialchars($valueL[1]);

						if(strlen($titulo) > 16){
							$titulo = substr($titulo, 0, 16) . "...";
						}

						$html .= "<a href='telaLivro.php?cod_livro=$codigo'><li>
									<img src='data:image/jpg;base64,$img'>

									<div class='infoLivroInicio'>
										<h5 title='$tituloCompleto'>$titulo</h5><br>
										$avaliacao <i class='fas fa-star'></i> | $idioma <i class='fas fa-language'></i>
									</div>
								</li></a>";
					}

					if(count($dadosLivro) >= 9){
						$html .= "<li class='liESqpecial' id='liEsp$i'>
									<div class='CarregarMais CPlus' title='Carregar Mais Livros' onclick='carregaMaisLivrosCarro($codigoG, $i, this)'>+</div>
								</li>";
					}

					$html .= "</ul></section><div class='btnLivro frente' onclick='frente($i)'><i class='fas fa-angle-right'></i></div></div>";
				}
				
				$i++;
			}

			echo $html;

		}catch(PDOException $ex){
			echo "";
		}
	}else{
		header("location: telaInicial.php");
	}

?>