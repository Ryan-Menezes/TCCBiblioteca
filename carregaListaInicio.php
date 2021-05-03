<?php

	include_once "conexao.php";
	include_once "Usuario.php";
	if(!isset($_SESSION)) session_start();

	$conexao = conexao::getConexao();

	if(!isset($_SESSION["usuario"])){
		header("location: index.php");
	}

	$dados = $_SESSION["usuario"];

	if(isset($_POST["min"]) && isset($_POST["filtro"])){
		try{
			$min = trim(addslashes($_POST["min"]));
			$filtro = trim(addslashes($_POST["filtro"]));

			$comando = $conexao->prepare("SELECT (SELECT COUNT(*) FROM lista WHERE id_usuario_lista = l.id_usuario_lista), l.id_usuario_lista FROM lista AS l LEFT JOIN aluno AS a ON a.id_usuario_aluno = l.id_usuario_lista  LEFT JOIN professor AS p ON p.id_usuario_professor = l.id_usuario_lista LEFT JOIN funcionario AS f ON f.id_usuario_funcionario = l.id_usuario_lista WHERE (CONCAT(CONCAT(a.nome, ' '), a.sobrenome) LIKE :nomeA OR CONCAT(CONCAT(p.nome, ' '), p.sobrenome) LIKE :nomeP OR CONCAT(CONCAT(f.nome, ' '), f.sobrenome) LIKE :nomeF) AND (SELECT COUNT(*) FROM lista WHERE id_usuario_lista = l.id_usuario_lista) > 0 GROUP BY l.id_usuario_lista ORDER BY l.id_lista DESC LIMIT $min, 10");

			$comando->bindValue(":nomeA", "%$filtro%");
			$comando->bindValue(":nomeP", "%$filtro%");
			$comando->bindValue(":nomeF", "%$filtro%");

			$comando->execute();

			$dados = $comando->fetchAll();

			$html = null;
			$contador = 0;

			if(count($dados) > 0){
				foreach($dados as $valor){
					$num = htmlspecialchars($valor[0]);
					$usuario = htmlspecialchars($valor[1]);
					$nome = null;
					$img = null;

					//Pesquisando usuario

					$comando = $conexao->prepare("SELECT CONCAT(CONCAT(nome, ' '), sobrenome), img_aluno FROM aluno WHERE id_usuario_aluno = :cod AND CONCAT(CONCAT(nome, ' '), sobrenome) LIKE :txt LIMIT 1");

					$comando->bindParam(":cod", $usuario);
					$comando->bindValue(":txt", "%$filtro%");

					$comando->execute();

					$dadosUser = $comando->fetchAll();

					if(count($dadosUser) > 0){ //Aluno

						foreach($dadosUser as $valorU){
							$nome = htmlspecialchars($valorU[0]);
							$img = base64_encode($valorU[1]);
						}

					}else{
						$comando = $conexao->prepare("SELECT CONCAT(CONCAT(nome, ' '), sobrenome), img_professor FROM professor WHERE id_usuario_professor = :cod AND CONCAT(CONCAT(nome, ' '), sobrenome) LIKE :txt LIMIT 1");

						$comando->bindParam(":cod", $usuario);
						$comando->bindValue(":txt", "%$filtro%");

						$comando->execute();

						$dadosUser = $comando->fetchAll();

						if(count($dadosUser) > 0){ //Professor
							foreach($dadosUser as $valorU){
								$nome = htmlspecialchars($valorU[0]);
								$img = base64_encode($valorU[1]);
							}
						}else{
							$comando = $conexao->prepare("SELECT CONCAT(CONCAT(nome, ' '), sobrenome), img_funcionario FROM funcionario WHERE id_usuario_funcionario = :cod AND CONCAT(CONCAT(nome, ' '), sobrenome) LIKE :txt LIMIT 1");

							$comando->bindParam(":cod", $usuario);
							$comando->bindValue(":txt", "%$filtro%");

							$comando->execute();

							$dadosUser = $comando->fetchAll();

							//Funcionário

							foreach($dadosUser as $valorU){
								$nome = htmlspecialchars($valorU[0]);
								$img = base64_encode($valorU[1]);
							}
						}
					}

					//Lista

					if(count($dadosUser) > 0){
						$html .= "<a href='listaUsuario.php?codU=$usuario'>
									<div class='listU'>
										<div class='ImageUserList'>
											<img src='data:image/jpg;base64,$img'>
										</div>
										<div class='infoList'>
											<h5>$nome</h5>
											<p>$num livro(s) em sua lista</p>
										</div>
									</div>
								</a>";

						$contador++;
					}
				}

				if($contador >= 10){
					$html .= "<div style='width: 200px; display: flex; align-items: center; justify-content: center;'>
								<div class='CarregarMais' title='Carregar mais listas' onclick='carregaListaInicio(this)'><i class='fas fa-plus'></i></div>
							  </div>";
				}
				
				echo $html;
			}else{
				if($min == 0 && strlen($filtro) == 0){
					echo "<div>
					         <h4>Não há nenhuma lista disponível!</h4>
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
							'><i class='fas fa-sad-tear'></i></div>
						 </div>";
				}else{
					$html .= "<div>
						          <h4>Não foi encontrado nenhuma lista de um usuário com o nome '" . htmlspecialchars(trim(addslashes($_POST["filtro"]))) . "'</h4>
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
									'><i class='fas fa-sad-tear'></i></div>
							  </div>";
				}
			}
		}catch(Exception $ex){
			echo "<div style='width: 200px; display: flex; align-items: center; justify-content: center;'>
					<div class='CarregarMais' title='Carregar mais listas' onclick='carregaListaInicio(this)'><i class='fas fa-plus'></i></div>
			      </div>";
		}
	}else{
		header("location: Inicio.php");
	}

?>