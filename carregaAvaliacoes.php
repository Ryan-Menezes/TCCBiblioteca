<?php

	include_once "conexao.php";
	include_once "Usuario.php";
	if(!isset($_SESSION)) session_start();

	$conexao = conexao::getConexao();

	if(!isset($_SESSION["usuario"])){
		header("location: index.php");
	}

	$dados = $_SESSION["usuario"];

	$codUsuarioLog = $dados->getCodUsuario();

	if(isset($_POST["min"]) && isset($_POST["cod"])){
		try{
			$min = trim(addslashes($_POST["min"]));
			$cod = trim(addslashes($_POST["cod"]));
			$filtro = (trim(addslashes($_POST["filtro"])) == "T") ? "" : "AND avaliacao_estrelas = " . trim(addslashes($_POST["filtro"]));

			$comando = $conexao->prepare("SELECT * FROM avaliacao WHERE livro_tombo_avaliacao = :cod AND mensagem IS NOT NULL $filtro ORDER BY id_avaliacao DESC LIMIT $min, 10");

			$comando->bindParam(":cod", $cod);

			$comando->execute();

			$dados = $comando->fetchAll();

			$html = null;
			$indice = $min;

			if(count($dados) > 0){
				foreach($dados as $valor){
					$id_avaliacao = htmlspecialchars($valor[0]);
					$mensagem = htmlspecialchars($valor[1]);
					$estrelas = htmlspecialchars($valor[2]);
					$data = htmlspecialchars($valor[3]);
					$data = explode("-", $data)[2] ."/" . explode("-", $data)[1] . "/" . explode("-", $data)[0];
					$usuario = htmlspecialchars($valor[4]);
					$nome = null;
					$img = null;

					//Pesquisando usuario

					$comando = $conexao->prepare("SELECT CONCAT(CONCAT(nome, ' '), sobrenome) AS nome, img_aluno FROM aluno WHERE id_usuario_aluno = :cod LIMIT 1");

					$comando->bindParam(":cod", $usuario);

					$comando->execute();

					$dadosUser = $comando->fetchAll();

					if(count($dadosUser) > 0){ //Aluno

						foreach($dadosUser as $valorU){
							$nome = htmlspecialchars($valorU[0]);
							$img = base64_encode($valorU[1]);
						}

					}else{
						$comando = $conexao->prepare("SELECT CONCAT(CONCAT(nome, ' '), sobrenome) AS nome, img_professor FROM professor WHERE id_usuario_professor = :cod LIMIT 1");

						$comando->bindParam(":cod", $usuario);

						$comando->execute();

						$dadosUser = $comando->fetchAll();

						if(count($dadosUser) > 0){ //Professor
							foreach($dadosUser as $valorU){
								$nome = htmlspecialchars($valorU[0]);
								$img = base64_encode($valorU[1]);
							}
						}else{
							$comando = $conexao->prepare("SELECT CONCAT(CONCAT(nome, ' '), sobrenome) AS nome, img_funcionario FROM funcionario WHERE id_usuario_funcionario = :cod LIMIT 1");

							$comando->bindParam(":cod", $usuario);

							$comando->execute();

							$dadosUser = $comando->fetchAll();

							//Funcionário

							foreach($dadosUser as $valorU){
								$nome = htmlspecialchars($valorU[0]);
								$img = base64_encode($valorU[1]);
							}
						}
					}

					//Avaliação

					$estrelasI = null;

					for($i = 0; $i < $estrelas; $i++){ 
						$estrelasI .= "<i class='fas fa-star' style='color: #adb505'></i>";
					}

					for($i = $estrelas; $i < 5; $i++){ 
						$estrelasI .= "<i class='fas fa-star' style='color: gray'></i>";
					}

					if($usuario == $codUsuarioLog){
						$html .= "<div class='ava'>
									<div>
										<img src='data:image/jpg;base64,$img'>

										<div class='infoAva'>
											<div class='infoUser'>
												<div>
													<p>$nome - $data</p>
												</div>
												<div>
													<i class='fas fa-trash-alt' title='Excluir' onclick='deletaAvavliacao($id_avaliacao)'></i>
												</div>
											</div><br>

											<div class='estrelas'>
												$estrelasI
											</div>
										</div>
									</div>

									<textarea rows='3' readonly class='msgTextArea' onclick='verMais($indice)'>$mensagem</textarea>

									<span><a href='javascript: void(0)' onclick='verMais($indice)' class='vermaisA'>Ver Mais</a></span>
								</div>";
					}else{
						$html .= "<div class='ava'>
									<div>
										<img src='data:image/jpg;base64,$img'>

										<div class='infoAva'>
											<div class='infoUser'>
												<div>
													<p>$nome - $data</p>
												</div>
												<div></div>
											</div><br>

											<div class='estrelas'>
												$estrelasI
											</div>
										</div>
									</div>

									<textarea rows='3' readonly class='msgTextArea' onclick='verMais($indice)'>$mensagem</textarea>

									<span><a href='javascript: void(0)' onclick='verMais($indice)' class='vermaisA'>Ver Mais</a></span>
								</div>";
					}

					$indice++;
				}

				if(count($dados) >= 10){
					$html .= "<button class='carregarMais' onclick='carregaAvaliacoes(this)'><i class='fas fa-plus'></i></button>";
				}

				echo $html;
			}else{
				if($min == 0 && strlen($filtro) == 0){
					echo "<h4>Não há avaliações deste livro</h3>";
				}else{
					echo "<h4>Não há avaliações com " . htmlspecialchars(trim(addslashes($_POST["filtro"]))) . " estrelas deste livro</h4>";
				}
			}
		}catch(Exception $ex){
			echo "<button class='carregarMais' onclick='carregaAvaliacoes(this)'><i class='fas fa-plus'></i></button>";
		}
	}else{
		header("location: telaLivro.php");
	}

?>