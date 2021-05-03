<?php

	include_once "conexao.php";
	include_once "Usuario.php";
	if(!isset($_SESSION)) session_start();

	$conexao = conexao::getConexao();

	if(!isset($_SESSION["usuario"])){
		header("location: index.php");
	}

	$dadosUser = $_SESSION["usuario"];

	try{
		$conexao = conexao::getConexao();

		if(isset($_POST["min"])){
			$minimo = trim(addslashes($_POST["min"]));

			//Verificando se o código passado está associado há algum livro no sistema

			$comando = $conexao->prepare("SELECT li.id_lista, l.cod_livro, l.titulo, l.idioma, l.img_livro, (SELECT AVG(avaliacao_estrelas) FROM avaliacao WHERE livro_tombo_avaliacao = l.cod_livro) FROM livro AS l INNER JOIN lista AS li ON li.livro_tombo_lista = l.cod_livro WHERE li.id_usuario_lista = :cod ORDER BY li.id_lista DESC LIMIT $minimo, 10");

			$comando->bindValue(":cod", $dadosUser->getCodUsuario());

			$comando->execute();

			$dadosLivro = $comando->fetchAll();

			$html = null;

			if(count($dadosLivro) > 0){
				foreach($dadosLivro as $value){
					$codigoLista = htmlspecialchars($value[0]);
					$codigoL = htmlspecialchars($value[1]);
					$titulo = htmlspecialchars($value[2]);
					$idioma = htmlspecialchars($value[3]);
					$img = base64_encode($value[4]);
					$avaliacao = (strlen(htmlspecialchars($value[5])) > 0) ? htmlspecialchars($value[5]) : 0;

					$avaliacao = number_format($avaliacao, 1);

					$tituloCompleto = htmlspecialchars($value[2]);

					if(strlen($titulo) > 15){
						$titulo = substr($titulo, 0, 15) . "...";
					}

					$html .= "<main class='livrosLista'>
								<img src='data:image/jpg;base64,$img'>
								<div>
									<div>
										<h5 title='$tituloCompleto'>$titulo</h5><br>
										$avaliacao <i class='fas fa-star'></i> | $idioma <i class='fas fa-language'></i>
									</div>

									<div class='opLista'>
										<a href='telaLivro.php?cod_livro=$codigoL'><button>Visualizar</button></a>
										<i class='fas fa-trash-alt' onclick='removeLivroLista($codigoLista)'></i>
									</div>
								</div>
							</main>";
				}

				if(count($dadosLivro) >= 10){
					$html .= "<div id='loadingCont'>
								<div class='carregarMais' title='Carregar Mais Livros' onclick='carregaMaisLivrosLista(this)'><i class='fas fa-plus'></i></div>
							  </div>";
				}

			}else{
				if($minimo == 0){
					$html = "<div id='loadingCont'>
								<h4>Não há nenhum livro adicionado em sua lista</h4>
								<div style='
											padding: 10px; 
											width: 40px; 
											height: 40px; 
											border-radius: 50%; 
											background-color: white;
											display: flex; 
											align-items: center; 
											justify-content: center;
											margin: auto;
											margin-top: 50px;
											font-size: 50px;
											color: #4287f5;
								'><i class='fas fa-sad-tear'></i></div>
							</div>";
				}	
			}

			echo $html;
		}else{
			header("location: Inicio.php");
		}

	}catch(PDOException $ex){
		echo "Ocorreu um erro ao tentar carregar mais livros";
	}
?>