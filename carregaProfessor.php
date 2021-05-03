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

	if(isset($_POST["min"]) && isset($_POST["txt"])){
		$conexao = conexao::getConexao();

		try{
			$minimo = trim(addslashes($_POST["min"]));
			$txt = htmlspecialchars(trim(addslashes($_POST["txt"])));
			$tipo = trim(addslashes($_POST["tipo"]));
			$status = (trim(addslashes($_POST["status"])) != "T") ? trim(addslashes($_POST["status"])) : "";
			$situacao = (trim(addslashes($_POST["situacao"])) != "T") ? "AND i.situacao = '" . trim(addslashes($_POST["situacao"])) . "'" : "";

			$sexo = trim(addslashes($_POST["sexo"]));

			if($sexo == "O") $sexo = "AND p.sexo IS NULL";
			else if($sexo == "T") $sexo = "";
			else $sexo = "AND p.sexo = '$sexo'";

			$usuarios = explode(',', $_POST["users"]);

			$instituicao = trim(addslashes($_POST["instituicao"]));

			$comando = null;

			if($tipo == "R"){
				$comando = $conexao->prepare("SELECT p.rm_professor, p.nome, p.sobrenome, p.cpf, CASE p.sexo WHEN 'M' THEN 'Masculino' WHEN 'F' THEN 'Feminino' ELSE 'Personalizado' END AS 'sexo', p.data_cadastro, p.img_professor, CASE u.status_usuario WHEN 'D' THEN 'Desbloqueado' ELSE 'Bloqueado' END AS 'status', p.id_usuario_professor FROM professor AS p INNER JOIN usuario AS u ON p.id_usuario_professor = u.id_usuario INNER JOIN instituicao_usuario AS i ON i.id_usuario = p.id_usuario_professor WHERE p.rm_professor LIKE :rm AND u.status_usuario LIKE :status $sexo AND i.id_instituicao = :inst $situacao GROUP BY p.rm_professor ORDER BY CONCAT(p.nome, CONCAT(' ', p.sobrenome)) LIMIT $minimo, 10");

				$comando->bindValue(":rm", "%$txt%");
				$comando->bindValue(":status", "%$status%");
				$comando->bindParam(":inst", $instituicao);
			}else if($tipo == "C"){

				$cpfPesq = str_ireplace(".", "", str_ireplace("-", "", $txt));

				$comando = $conexao->prepare("SELECT p.rm_professor, p.nome, p.sobrenome, p.cpf, CASE p.sexo WHEN 'M' THEN 'Masculino' WHEN 'F' THEN 'Feminino' ELSE 'Personalizado' END AS 'sexo', p.data_cadastro, p.img_professor, CASE u.status_usuario WHEN 'D' THEN 'Desbloqueado' ELSE 'Bloqueado' END AS 'status', p.id_usuario_professor FROM professor AS p INNER JOIN usuario AS u ON p.id_usuario_professor = u.id_usuario INNER JOIN instituicao_usuario AS i ON i.id_usuario = p.id_usuario_professor WHERE p.cpf LIKE :cpf AND u.status_usuario LIKE :status $sexo AND i.id_instituicao = :inst $situacao GROUP BY p.rm_professor ORDER BY CONCAT(p.nome, CONCAT(' ', p.sobrenome)) LIMIT $minimo, 10");

				$comando->bindValue(":cpf", "%$cpfPesq%");
				$comando->bindValue(":status", "%$status%");
				$comando->bindParam(":inst", $instituicao);
			}else{
				$comando = $conexao->prepare("SELECT p.rm_professor, p.nome, p.sobrenome, p.cpf, CASE p.sexo WHEN 'M' THEN 'Masculino' WHEN 'F' THEN 'Feminino' ELSE 'Personalizado' END AS 'sexo', p.data_cadastro, p.img_professor, CASE u.status_usuario WHEN 'D' THEN 'Desbloqueado' ELSE 'Bloqueado' END AS 'status', p.id_usuario_professor FROM professor AS p INNER JOIN usuario AS u ON p.id_usuario_professor = u.id_usuario INNER JOIN instituicao_usuario AS i ON i.id_usuario = p.id_usuario_professor WHERE CONCAT(p.nome, CONCAT(' ', p.sobrenome)) LIKE :nome AND u.status_usuario LIKE :status $sexo AND i.id_instituicao = :inst $situacao GROUP BY p.rm_professor ORDER BY CONCAT(p.nome, CONCAT(' ', p.sobrenome)) LIMIT $minimo, 10");

				$comando->bindValue(":nome", "%$txt%");
				$comando->bindValue(":status", "%$status%");
				$comando->bindParam(":inst", $instituicao);
			}
			
			$comando->execute();

			$dados = $comando->fetchAll();

			$html = null;

			if(count($dados) > 0){
				foreach($dados as $valor){
					$rm = htmlspecialchars($valor[0]);
					$nome = htmlspecialchars($valor[1]);
					$sobrenome = htmlspecialchars($valor[2]);
					$cpf = Mask("###.###.###-##", htmlspecialchars($valor[3]));
					$sexo = htmlspecialchars($valor[4]);
					$data_cadastro = explode("-", htmlspecialchars($valor[5]));
					$data_cadastro = $data_cadastro[2] . "/" . $data_cadastro[1] . "/" . $data_cadastro[0];
					$img = base64_encode($valor[6]);
					$status = htmlspecialchars($valor[7]);
					$cod_usuario = htmlspecialchars($valor[8]);

					$opcoes = null;

					if($rm != $dadosUsuario->getRM()){
						if($status == "Desbloqueado"){
							$opcoes = "<i class='fas fa-comment' title='Emitir Mensagem' onclick='abreMoldalEnviaMsg(2, $cod_usuario, `P`)'></i>
									   <i class='fas fa-trash-alt' title='Excluir' onclick='abreMoldalSenha($cod_usuario)'></i>
									   <a href='editProfessor.php?codA=$rm'><i class='fas fa-pencil-alt' title='Editar'></i></a>";
						}else{
							$opcoes = "<i class='fas fa-trash-alt' title='Excluir' onclick='abreMoldalSenha($cod_usuario)'></i>
									   <a href='editProfessor.php?codA=$rm'><i class='fas fa-pencil-alt' title='Editar'></i></a>";
						}
					}else{
						$opcoes = "Opções Inacessíveis";
					}

					if(in_array($rm, $usuarios)){
						$html .= "<tr class='dadoInfo'>
									<td><input type='checkbox' checked onchange='selecionaUser($rm)'></td>
									<td><img src='data:image/jpg;base64,$img'></td>
									<td>$rm</td>
									<td>$nome $sobrenome</td>
									<td>$cpf</td>
									<td>$data_cadastro</td>
									<td>$sexo</td>
									<td>$status</td>
									<td>$opcoes</td>
								<tr>";
					}else{
						$html .= "<tr class='dadoInfo'>
									<td><input type='checkbox' onchange='selecionaUser($rm)'></td>
									<td><img src='data:image/jpg;base64,$img'></td>
									<td>$rm</td>
									<td>$nome $sobrenome</td>
									<td>$cpf</td>
									<td>$data_cadastro</td>
									<td>$sexo</td>
									<td>$status</td>
									<td>$opcoes</td>
								<tr>";
					}
					
				}

				if(count($dados) >= 10){
					$html .= "<tr id='carregarMaisTable'>
								<td colspan='12'><button class='btnCarr' onclick='carregaProfessores(this)'><i class='fas fa-plus'></i></button></td>
							</tr>";
				}
			}else{

				if($minimo == 0 && strlen($txt) == 0){
					$html .= "<tr>
								<td colspan='12'><h4>Não foi possivel localizar nenhum professsor cadastrado com o filtros requisitados!</h4></td>
							 </tr>";
				}else if(strlen($txt) > 0){
					if($tipo == "R"){
						$html .= "<tr>
									<td colspan='12'><h4>Não foi possivel localizar nenhum professor cadastrado com o RM '$txt'</h4></td>
								 </tr>";
					}else if($tipo == "C"){
						$html .= "<tr>
									<td colspan='12'><h4>Não foi possivel localizar nenhum professor cadastrado com o CPF '$txt'</h4></td>
								 </tr>";
					}else{
						$html .= "<tr>
									<td colspan='12'><h4>Não foi possivel localizar nenhum professor cadastrado com o nome '$txt'</h4></td>
								 </tr>";
					}
				}
			}

			echo $html;

		}catch(Exception $ex){
			echo "<tr id='carregarMaisTable'>
					<td colspan='12'><button class='btnCarr' onclick='carregaProfessores(this)'><i class='fas fa-plus'></i></button></td>
				  </tr>";
		}
	}else{
		header("location: alunos.php");
	}

?>