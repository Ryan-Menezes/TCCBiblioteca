<?php

	include_once "conexao.php";
	if(!isset($_SESSION)) session_start();

	$conexao = conexao::getConexao();

	if(!isset($_SESSION["usuario"])){
		header("location: index.php");
	}

	if(isset($_POST["min"]) && isset($_POST["tipo"]) && isset($_POST["texto"])){
		try{
			$conexao = conexao::getConexao();

			$minimo = trim(addslashes($_POST["min"]));
			$tipo = trim(addslashes($_POST["tipo"]));
			$texto = htmlspecialchars(trim(addslashes($_POST["texto"])));

			$comando = $conexao->prepare("SELECT * FROM livro");

			$comando->execute();

			$dados = $comando->fetchAll();

			$html = null;

			if(count($dados) > 0){

				if($tipo == "T"){
					$comando = $conexao->prepare("SELECT cod_livro, titulo, idioma, img_livro, (SELECT AVG(avaliacao_estrelas) FROM avaliacao WHERE livro_tombo_avaliacao = l.cod_livro) FROM livro AS l WHERE titulo LIKE :txt ORDER BY titulo LIMIT $minimo, 10");
				}else if($tipo == "F"){
					$comando = $conexao->prepare("SELECT cod_livro, titulo, idioma, img_livro, (SELECT AVG(avaliacao_estrelas) FROM avaliacao WHERE livro_tombo_avaliacao = l.cod_livro) FROM livro AS l WHERE titulo LIKE :txt AND NOT tombo IS NULL ORDER BY titulo LIMIT $minimo, 10");
				}else{
					$comando = $conexao->prepare("SELECT cod_livro, titulo, idioma, img_livro, (SELECT AVG(avaliacao_estrelas) FROM avaliacao WHERE livro_tombo_avaliacao = l.cod_livro) FROM livro AS l WHERE titulo LIKE :txt AND NOT pdf_livro IS NULL ORDER BY titulo LIMIT $minimo, 10");
				}

				$comando->bindValue(":txt", "%$texto%");

				$comando->execute();

				$dadosLivro = $comando->fetchAll();

				if(count($dadosLivro) > 0){
					foreach($dadosLivro as $valueL){
						$codigo = htmlspecialchars($valueL[0]);
						$titulo = htmlspecialchars($valueL[1]);
						$idioma = htmlspecialchars($valueL[2]);
						$img = base64_encode($valueL[3]);
						$avaliacao = (strlen(htmlspecialchars($valueL[4])) > 0) ? htmlspecialchars($valueL[4]) : 0;

						$avaliacao = number_format($avaliacao, 1);

						$tituloCompleto = htmlspecialchars($valueL[1]);

						if(strlen($titulo) > 30){
							$titulo = substr($titulo, 0, 30) . "...";
						}

						$html .= "<a href='telaLivro.php?cod_livro=$codigo'>
									<main>
										<img src='data:image/jpg;base64,$img'>
										<div>
											<div>
												<h4 title='$tituloCompleto'>$titulo</h4><br>
												<p>$avaliacao <i class='fas fa-star'></i> | $idioma <i class='fas fa-language'></i></p>
											</div>
										</div>
								</main></a>";
					}

					if(count($dadosLivro) >= 10){
						$html .= "<div class='CarregarMais CPlus' title='Carregar Mais Livros' onclick='carregaMaisLivrosI(this)'><i class='fas fa-plus'></i></div>";
					}

					echo $html;
				}else{
					if($minimo == 0){
						echo "<h4>Não foi encontrado nenhum livro com o titulo '$texto'</h4>
							  <div style='
									padding: 10px; 
									width: 30px; 
									height: 30px; 
									border-radius: 50%; 
									background-color: white;
									display: flex; 
									align-items: center; 
									justify-content: center;
									margin: auto;
									margin-top: 30px;
									font-size: 40px;
									color: #4287f5;
								'><i class='fas fa-sad-tear'></i></div>";
					}
				}
			}else{
				echo "<h4>Não há livros cadastrados no sistema</h4>
					  <div style='
							padding: 10px; 
							width: 30px; 
							height: 30px; 
							border-radius: 50%; 
							background-color: white;
							display: flex; 
							align-items: center; 
							justify-content: center;
							margin: auto;
							margin-top: 30px;
							font-size: 40px;
							color: #4287f5;
						'><i class='fas fa-sad-tear'></i></div>";
			}
		}catch(PDOException $ex){
			echo "<h4>Ocorreu um erro na pesquisa</h4>
				  <div style='
						padding: 10px; 
						width: 30px; 
						height: 30px; 
						border-radius: 50%; 
						background-color: white;
						display: flex; 
						align-items: center; 
						justify-content: center;
						margin: auto;
						margin-top: 30px;
						font-size: 40px;
						color: #4287f5;
					'><i class='fas fa-sad-tear'></i></div>";
		}
	}else{
		header("location: telaInicial.php");
	}

?>