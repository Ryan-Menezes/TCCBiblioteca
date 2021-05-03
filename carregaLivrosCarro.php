<?php

	include_once "conexao.php";
	include_once "Usuario.php";
	if(!isset($_SESSION)) session_start();

	$conexao = conexao::getConexao();

	if(!isset($_SESSION["usuario"])){
		header("location: index.php");
	}

	if(isset($_POST["min"]) && isset($_POST["cod"]) && isset($_POST["posi"])){
		try{
			$conexao = conexao::getConexao();

			$codigoG = addslashes($_POST["cod"]);
			$minimo = addslashes($_POST["min"]);
			$posi = addslashes($_POST["posi"]);

			//Buscando livro

			$comando = $conexao->prepare("SELECT l.cod_livro, l.titulo, l.img_livro, l.idioma, (SELECT AVG(avaliacao_estrelas) FROM avaliacao WHERE livro_tombo_avaliacao = l.cod_livro) FROM livro AS l INNER JOIN genero_livro AS gl ON l.cod_livro = gl.id_livro_tombo WHERE gl.id_genero_tombo = :genero ORDER BY l.cod_livro DESC LIMIT $minimo, 5");

			$comando->bindParam(":genero", $codigoG);

			$comando->execute();

			$dadosLivro = $comando->fetchAll();

			$html = null;

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

			if(count($dadosLivro) >= 5){
				$html .= "<li class='liESqpecial' id='liEsp$posi'>
							<div class='CarregarMais CPlus' title='Carregar Mais Livros' onclick='carregaMaisLivrosCarro($codigoG, $posi, this)'>+</div>
						</li>";
			}

			echo $html;
		}catch(PDOException $ex){
			echo "<li class='liESqpecial' id='liEsp$posi'>
					<div class='CarregarMais CPlus' title='Carregar Mais Livros' onclick='carregaMaisLivrosCarro($codigoG, $posi, this)'>+</div>
				  </li>";
		}
	}else{
		header("location: telaInicial.php");
	}

?>