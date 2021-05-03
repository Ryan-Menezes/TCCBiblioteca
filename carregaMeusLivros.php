<?php
	include_once "conexao.php";
	include_once "Usuario.php";
	if(!isset($_SESSION)) session_start();

	$conexao = conexao::getConexao();

	$dadosUser = $_SESSION["usuario"];

	if(!isset($_SESSION["usuario"])){
		header("location: index.php");
	}

	if(isset($_POST["min"]) && isset($_POST["txt"])){
		try{
			$minimo = trim(addslashes($_POST["min"]));
			$texto = htmlspecialchars(trim(addslashes($_POST["txt"])));

			$comando = $conexao->prepare("SELECT l.titulo, l.img_livro, i.nome_instituicao, a.data_locacao, a.data_devolucao FROM livro AS l INNER JOIN exemplares AS e ON l.cod_livro = e.livro_tombo_exemplares INNER JOIN instituicao As i ON i.id_instituicao = e.id_instituicao INNER JOIN locacao AS a ON e.id_exemplares = a.id_exemplares WHERE a.id_usuario_locacao = :cod AND l.titulo LIKE :titulo ORDER BY a.id_locacao DESC LIMIT $minimo, 10");

			$comando->bindValue(":cod", $dadosUser->getCodUsuario());
			$comando->bindValue(":titulo", "%$texto%");

			$comando->execute();

			$dados = $comando->fetchAll();

			if(count($dados) > 0){
				$dadosAlocacao = null;

				foreach($dados as $valor){
					$titulo = htmlspecialchars($valor[0]);
					$img_livro = base64_encode($valor[1]);
					$nome_instituicao = htmlspecialchars($valor[2]);
					$data_locacao = htmlspecialchars($valor[3]);
					$data_devolucao = htmlspecialchars($valor[4]);

					$situacao = (strtotime(date("Y-m-d")) > strtotime($data_devolucao)) ? "<div class='dred'></div>" : "<div class='dgreen'></div>";

					$data = explode("-", htmlspecialchars($valor[3]));
					$data_locacao = $data[2]."/".$data[1]."/".$data[0];

					$data = explode("-", htmlspecialchars($valor[4]));
					$data_devolucao = $data[2]."/".$data[1]."/".$data[0];

					$dadosAlocacao .= "<tr class='tbodyA'>
										<td><img src='data:image/jpg;base64,$img_livro'></td>
										<td>$titulo</td>
										<td>$nome_instituicao</td>
										<td>$data_locacao</td>
										<td>$data_devolucao</td>
										<td>$situacao</td>
									  <tr>";
				}

				if(count($dados) >= 10){
					$dadosAlocacao .= "<tr id='carregarMaisTable'>
											<td colspan='6'><button class='btnCarr' onclick='carregaAlocacoes(this)'><i class='fas fa-plus'></i></button></td>
									   </tr>";
				}

				echo $dadosAlocacao;
			}else{
				if($minimo == 0 && strlen($texto) == 0){
					echo "<tr><td colspan='6'><h4>Você não possiu nenhum livro alocado!</h4></td></tr>";
				}else{
					echo "<tr><td colspan='6'><h4>Não foi possivel localizar uma alocação do livro com titulo '$texto'</h4></td></tr>";
				}
			}
		}catch(Exeception $ex){
			echo "<tr id='carregarMaisTable'>
					<td colspan='6'><button class='btnCarr' onclick='carregaAlocacoes(this)'><i class='fas fa-plus'></i></button></td>
				  </tr>";
		}
	}else{
		header("location: meuslivros.php");
	}
?>