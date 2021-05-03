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

	//Função que coloca maskara nos inputs

	function Mask($mask, $str){
	    $str = str_ireplace(" ", "", $str);

	    for($i = 0; $i < strlen($str); $i++){
	        $mask[strpos($mask,"#")] = $str[$i];
	    }

	    return $mask;
	}

	if(isset($_POST["min"]) && isset($_POST["txt"]) && isset($_POST["tipo"]) && isset($_POST["situacao"]) && isset($_POST["instituicao"])){
		$conexao = conexao::getConexao();

		try{
			$minimo = trim(addslashes($_POST["min"]));
			$txt = htmlspecialchars(trim(addslashes($_POST["txt"])));
			$tipo = trim(addslashes($_POST["tipo"]));
			$situacao = trim(addslashes($_POST["situacao"]));

			if($situacao == "T") $situacao = "";
			else if($situacao == "N") $situacao = "AND al.data_devolucao >= CURDATE()";
			else $situacao = "AND al.data_devolucao < CURDATE()";

			$tipoU = trim(addslashes($_POST["tipoU"]));

			$instituicao = "AND e.id_instituicao = " . trim(addslashes($_POST["instituicao"]));

			$alocacoes = explode(',', $_POST["alocacoes"]);

			$comando = null;

			if($tipo == "TI"){
				if($tipoU == "T"){
					$comando = $conexao->prepare("SELECT al.id_locacao, l.tombo, l.titulo, l.img_livro, u.id_usuario, al.data_locacao, al.data_devolucao FROM locacao AS al INNER JOIN exemplares AS e ON e.id_exemplares = al.id_exemplares INNER JOIN livro AS l ON l.cod_livro = e.livro_tombo_exemplares INNER JOIN usuario AS u ON u.id_usuario = al.id_usuario_locacao WHERE l.titulo LIKE :titulo $situacao $instituicao ORDER BY al.id_locacao DESC LIMIT $minimo, 10");
				}else if($tipoU == "A"){
					$comando = $conexao->prepare("SELECT al.id_locacao, l.tombo, l.titulo, l.img_livro, u.id_usuario, al.data_locacao, al.data_devolucao FROM locacao AS al INNER JOIN exemplares AS e ON e.id_exemplares = al.id_exemplares INNER JOIN livro AS l ON l.cod_livro = e.livro_tombo_exemplares INNER JOIN usuario AS u ON u.id_usuario = al.id_usuario_locacao INNER JOIN aluno AS a ON a.id_usuario_aluno = u.id_usuario WHERE l.titulo LIKE :titulo $situacao $instituicao ORDER BY al.id_locacao DESC LIMIT $minimo, 10");
				}else if($tipoU == "P"){
					$comando = $conexao->prepare("SELECT al.id_locacao, l.tombo, l.titulo, l.img_livro, u.id_usuario, al.data_locacao, al.data_devolucao FROM locacao AS al INNER JOIN exemplares AS e ON e.id_exemplares = al.id_exemplares INNER JOIN livro AS l ON l.cod_livro = e.livro_tombo_exemplares INNER JOIN usuario AS u ON u.id_usuario = al.id_usuario_locacao INNER JOIN professor AS p ON p.id_usuario_professor = u.id_usuario WHERE l.titulo LIKE :titulo $situacao $instituicao ORDER BY al.id_locacao DESC LIMIT $minimo, 10");
				}else{
					$comando = $conexao->prepare("SELECT al.id_locacao, l.tombo, l.titulo, l.img_livro, u.id_usuario, al.data_locacao, al.data_devolucao FROM locacao AS al INNER JOIN exemplares AS e ON e.id_exemplares = al.id_exemplares INNER JOIN livro AS l ON l.cod_livro = e.livro_tombo_exemplares INNER JOIN usuario AS u ON u.id_usuario = al.id_usuario_locacao INNER JOIN funcionario AS f ON f.id_usuario_funcionario = u.id_usuario WHERE l.titulo LIKE :titulo $situacao $instituicao ORDER BY al.id_locacao DESC LIMIT $minimo, 10");
				}
				

				$comando->bindValue(":titulo", "%$txt%");
			}else{
				if($tipoU == "T"){
					$comando = $conexao->prepare("SELECT al.id_locacao, l.tombo, l.titulo, l.img_livro, u.id_usuario, al.data_locacao, al.data_devolucao FROM locacao AS al INNER JOIN exemplares AS e ON e.id_exemplares = al.id_exemplares INNER JOIN livro AS l ON l.cod_livro = e.livro_tombo_exemplares INNER JOIN usuario AS u ON u.id_usuario = al.id_usuario_locacao  WHERE l.tombo LIKE :tombo $situacao $instituicao ORDER BY al.id_locacao DESC LIMIT $minimo, 10");
				}else if($tipoU == "A"){
					$comando = $conexao->prepare("SELECT al.id_locacao, l.tombo, l.titulo, l.img_livro, u.id_usuario, al.data_locacao, al.data_devolucao FROM locacao AS al INNER JOIN exemplares AS e ON e.id_exemplares = al.id_exemplares INNER JOIN livro AS l ON l.cod_livro = e.livro_tombo_exemplares INNER JOIN usuario AS u ON u.id_usuario = al.id_usuario_locacao INNER JOIN aluno AS a ON a.id_usuario_aluno = u.id_usuario WHERE l.tombo LIKE :tombo $situacao $instituicao ORDER BY al.id_locacao DESC LIMIT $minimo, 10");
				}else if($tipoU == "P"){
					$comando = $conexao->prepare("SELECT al.id_locacao, l.tombo, l.titulo, l.img_livro, u.id_usuario, al.data_locacao, al.data_devolucao FROM locacao AS al INNER JOIN exemplares AS e ON e.id_exemplares = al.id_exemplares INNER JOIN livro AS l ON l.cod_livro = e.livro_tombo_exemplares INNER JOIN usuario AS u ON u.id_usuario = al.id_usuario_locacao INNER JOIN professor AS p ON p.id_usuario_professor = u.id_usuario WHERE l.tombo LIKE :tombo $situacao $instituicao ORDER BY al.id_locacao DESC LIMIT $minimo, 10");
				}else{
					$comando = $conexao->prepare("SELECT al.id_locacao, l.tombo, l.titulo, l.img_livro, u.id_usuario, al.data_locacao, al.data_devolucao FROM locacao AS al INNER JOIN exemplares AS e ON e.id_exemplares = al.id_exemplares INNER JOIN livro AS l ON l.cod_livro = e.livro_tombo_exemplares INNER JOIN usuario AS u ON u.id_usuario = al.id_usuario_locacao INNER JOIN funcionario AS f ON f.id_usuario_funcionario = u.id_usuario WHERE l.tombo LIKE :tombo $situacao $instituicao ORDER BY al.id_locacao DESC LIMIT $minimo, 10");
				}

				$comando->bindValue(":tombo", "%$txt%");
			}
			
			$comando->execute();

			$dados = $comando->fetchAll();

			$html = null;

			if(count($dados) > 0){
				foreach($dados as $valor){
					$id_alocacao = htmlspecialchars($valor[0]);
					$tombo = htmlspecialchars($valor[1]);
					$titulo = htmlspecialchars($valor[2]);
					$img = base64_encode($valor[3]);
					$id_usuario = htmlspecialchars($valor[4]);
					$data_alocacao = htmlspecialchars($valor[5]);
					$data_devolucao = htmlspecialchars($valor[6]);
					$tipoUsuario = null;
					$cpf = null;
					$nome = null;
					$situacaoL = (strtotime(date("Y-m-d")) > strtotime($data_devolucao)) ? "<div class='dred'></div>" : "<div class='dgreen'></div>";

					$data = explode("-", $data_devolucao);
					$data_devolucao = $data[2]."/".$data[1]."/".$data[0];

					$data = explode("-", $data_alocacao);
					$data_alocacao = $data[2]."/".$data[1]."/".$data[0];

					//Pegando os dados do usuário
					
					$comando = $conexao->prepare("SELECT cpf, CONCAT(nome, CONCAT(' ', sobrenome)) FROM aluno WHERE id_usuario_aluno = :id LIMIT 1");

					$comando->bindParam(":id", $id_usuario);

					$comando->execute();

					$dadosUsuario = $comando->fetchAll();

					if(count($dadosUsuario) > 0){
						$cpf = Mask("###.###.###-##", htmlspecialchars($dadosUsuario[0][0]));
						$nome = htmlspecialchars($dadosUsuario[0][1]);
						$tipoUsuario = "Aluno";
					}else{
						$comando = $conexao->prepare("SELECT cpf, CONCAT(nome, CONCAT(' ', sobrenome)) FROM professor WHERE id_usuario_professor = :id LIMIT 1");

						$comando->bindParam(":id", $id_usuario);

						$comando->execute();

						$dadosUsuario = $comando->fetchAll();

						if(count($dadosUsuario) > 0){
							$cpf = Mask("###.###.###-##", htmlspecialchars($dadosUsuario[0][0]));
							$nome = htmlspecialchars($dadosUsuario[0][1]);
							$tipoUsuario = "Professor";
						}else{
							$comando = $conexao->prepare("SELECT cpf, CONCAT(nome, CONCAT(' ', sobrenome)) FROM funcionario WHERE id_usuario_funcionario = :id LIMIT 1");

							$comando->bindParam(":id", $id_usuario);

							$comando->execute();

							$dadosUsuario = $comando->fetchAll();

							if(count($dadosUsuario) > 0){
								$cpf = Mask("###.###.###-##", htmlspecialchars($dadosUsuario[0][0]));
								$nome = htmlspecialchars($dadosUsuario[0][1]);
								$tipoUsuario = "Funcionário";
							}
						}
					}

					if(in_array($id_alocacao, $alocacoes)){
						$html .= "<tr class='dadoInfo'>
									<td><input type='checkbox' checked onchange='selecionaAloc($id_alocacao)'></td>
									<td>$tombo</td>
									<td><img src='data:image/jpg;base64,$img'></td>
									<td>$titulo</td>
									<td>$cpf</td>
									<td>$nome</td>
									<td>$tipoUsuario</td>
									<td>$data_alocacao</td>
									<td>$data_devolucao</td>
									<td>$situacaoL</td>
									<td>
										<i class='fas fa-trash-alt' title='Desalocar' onclick='abreMoldalSenha($id_alocacao)'></i>
										<a href='editAlocacao.php?codA=$id_alocacao'><i class='fas fa-pencil-alt' title='Editar'></i></a>
									</td>
								<tr>";
					}else{
						$html .= "<tr class='dadoInfo'>
									<td><input type='checkbox' onchange='selecionaAloc($id_alocacao)'></td>
									<td>$tombo</td>
									<td><img src='data:image/jpg;base64,$img'></td>
									<td>$titulo</td>
									<td>$cpf</td>
									<td>$nome</td>
									<td>$tipoUsuario</td>
									<td>$data_alocacao</td>
									<td>$data_devolucao</td>
									<td>$situacaoL</td>
									<td>
										<i class='fas fa-trash-alt' title='Desalocar' onclick='abreMoldalSenha($id_alocacao)'></i>
										<a href='editAlocacao.php?codA=$id_alocacao'><i class='fas fa-pencil-alt' title='Editar'></i></a>
									</td>
								<tr>";
					}
				}

				if(count($dados) >= 10){
					$html .= "<tr id='carregarMaisTable'>
								<td colspan='12'><button class='btnCarr' onclick='carregaAlocacoes(this)'><i class='fas fa-plus'></i></button></td>
							</tr>";
				}
			}else{

				if($minimo == 0 && strlen($txt) == 0){
					$html .= "<tr>
								<td colspan='12'><h4>Não foi possivel localizar nenhuma alocação cadastrada com os filtros requisitados!</h4></td>
							 </tr>";
				}else if(strlen($txt) > 0){
					if($tipo == "TI"){
						$html .= "<tr>
									<td colspan='12'><h4>Não foi possivel localizar nenhuma alocação com o livro do titulo '$txt'</h4></td>
								 </tr>";
					}else{
						$html .= "<tr>
									<td colspan='12'><h4>Não foi possivel localizar nenhuma alocação com o livro do tombo '$txt'</h4></td>
								 </tr>";
					}
				}
			}

			echo $html;

		}catch(Exception $ex){
			echo "<tr id='carregarMaisTable'>
					<td colspan='12'><button class='btnCarr' onclick='carregaAlocacoes(this)'><i class='fas fa-plus'></i></button></td>
				  </tr>";
		}
	}else{
		header("location: alocacoes.php");
	}

?>