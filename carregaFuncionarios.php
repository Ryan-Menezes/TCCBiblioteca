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

			$sexo = trim(addslashes($_POST["sexo"]));

			if($sexo == "O") $sexo = "AND f.sexo IS NULL";
			else if($sexo == "T") $sexo = "";
			else $sexo = "AND f.sexo = '$sexo'";

			$usuarios = explode(',', $_POST["users"]);

			$instituicao = trim(addslashes($_POST["instituicao"]));

			$comando = null;

			if($tipo == "C"){

				$cpfPesq = str_ireplace(".", "", str_ireplace("-", "", $txt));

				$comando = $conexao->prepare("SELECT f.nome, f.sobrenome, f.cpf, CASE f.sexo WHEN 'M' THEN 'Masculino' WHEN 'F' THEN 'Feminino' ELSE 'Personalizado' END AS 'sexo', f.data_cadastro, f.img_funcionario, CASE u.status_usuario WHEN 'D' THEN 'Desbloqueado' ELSE 'Bloqueado' END AS 'status', f.id_usuario_funcionario FROM funcionario AS f INNER JOIN usuario AS u ON f.id_usuario_funcionario = u.id_usuario INNER JOIN instituicao_usuario AS i ON i.id_usuario = u.id_usuario WHERE f.cpf LIKE :cpf AND u.status_usuario LIKE :status $sexo AND i.id_instituicao = :instituicao GROUP BY f.cpf ORDER BY CONCAT(f.nome, CONCAT(' ', f.sobrenome)) LIMIT $minimo, 10");

				$comando->bindValue(":cpf", "%$cpfPesq%");
				$comando->bindValue(":status", "%$status%");
				$comando->bindValue(":instituicao", "$instituicao");
			}else{
				$comando = $conexao->prepare("SELECT f.nome, f.sobrenome, f.cpf, CASE f.sexo WHEN 'M' THEN 'Masculino' WHEN 'F' THEN 'Feminino' ELSE 'Personalizado' END AS 'sexo', f.data_cadastro, f.img_funcionario, CASE u.status_usuario WHEN 'D' THEN 'Desbloqueado' ELSE 'Bloqueado' END AS 'status', f.id_usuario_funcionario FROM funcionario AS f INNER JOIN usuario AS u ON f.id_usuario_funcionario = u.id_usuario INNER JOIN instituicao_usuario AS i ON i.id_usuario = u.id_usuario WHERE CONCAT(f.nome, CONCAT(' ', f.sobrenome)) LIKE :nome AND u.status_usuario LIKE :status $sexo AND i.id_instituicao = :instituicao GROUP BY f.cpf ORDER BY CONCAT(f.nome, CONCAT(' ', f.sobrenome)) LIMIT $minimo, 10");

				$comando->bindValue(":nome", "%$txt%");
				$comando->bindValue(":status", "%$status%");
				$comando->bindValue(":instituicao", "$instituicao");
			}
			
			$comando->execute();

			$dados = $comando->fetchAll();

			$html = null;

			if(count($dados) > 0){
				foreach($dados as $valor){
					$nome = htmlspecialchars($valor[0]);
					$sobrenome = htmlspecialchars($valor[1]);
					$cpf = Mask("###.###.###-##", htmlspecialchars($valor[2]));
					$cpfS = htmlspecialchars($valor[2]);
					$sexo = htmlspecialchars($valor[3]);
					$data_cadastro = explode("-", htmlspecialchars($valor[4]));
					$data_cadastro = $data_cadastro[2] . "/" . $data_cadastro[1] . "/" . $data_cadastro[0];
					$img = base64_encode($valor[5]);
					$status = htmlspecialchars($valor[6]);
					$cod_usuario = htmlspecialchars($valor[7]);

					$opcoes = null;

					if($cpf != $dadosUsuario->getCPF()){
						if($status == "Desbloqueado"){
							$opcoes = "<i class='fas fa-comment' title='Emitir Mensagem' onclick='abreMoldalEnviaMsg(2, $cod_usuario, `F`)'></i>
									   <i class='fas fa-trash-alt' title='Excluir' onclick='abreMoldalSenha($cod_usuario)'></i>
									   <form action='editFunc.php' method='POST' style='display: inline-block'>
									   		<label for='$cpfS'><i class='fas fa-pencil-alt' title='Editar'></i></label>
									   		<input type='hidden' name='cpfF' value='$cpfS'>
									   		<input type='submit' id='$cpfS' style='display: none'>
									   </form>";
						}else{
							$opcoes = "<i class='fas fa-trash-alt' title='Excluir' onclick='abreMoldalSenha($cod_usuario)'></i>
									   <form action='editFunc.php' method='POST' style='display: inline-block'>
									   		<label for='$cpfS'><i class='fas fa-pencil-alt' title='Editar'></i></label>
									   		<input type='hidden' name='cpfF' value='$cpfS'>
									   		<input type='submit' id='$cpfS' style='display: none'>
									   </form>";
						}
					}else{
						$opcoes = "Opções Inacessíveis";
					}

					if(in_array($cpfS, $usuarios)){
						$html .= "<tr class='dadoInfo'>
									<td><input type='checkbox' checked onchange='selecionaUser($cpfS)'></td>
									<td><img src='data:image/jpg;base64,$img'></td>
									<td>$nome $sobrenome</td>
									<td>$cpf</td>
									<td>$data_cadastro</td>
									<td>$sexo</td>
									<td>$status</td>
									<td>$opcoes</td>
								<tr>";
					}else{
						$html .= "<tr class='dadoInfo'>
									<td><input type='checkbox' onchange='selecionaUser($cpfS)'></td>
									<td><img src='data:image/jpg;base64,$img'></td>
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
								<td colspan='12'><button class='btnCarr' onclick='carregaFuncionarios(this)'><i class='fas fa-plus'></i></button></td>
							</tr>";
				}
			}else{

				if($minimo == 0 && strlen($txt) == 0){
					$html .= "<tr>
								<td colspan='12'><h4>Não foi possivel localizar nenhum funcionário cadastrado com o filtros requisitados!</h4></td>
							 </tr>";
				}else if(strlen($txt) > 0){
					 if($tipo == "C"){
						$html .= "<tr>
									<td colspan='12'><h4>Não foi possivel localizar nenhum funcionário cadastrado com o CPF '$txt'</h4></td>
								 </tr>";
					}else{
						$html .= "<tr>
									<td colspan='12'><h4>Não foi possivel localizar nenhum funcionário cadastrado com o Nome '$txt'</h4></td>
								 </tr>";
					}
				}
			}

			echo $html;

		}catch(Exception $ex){
			echo "<tr id='carregarMaisTable'>
					<td colspan='12'><button class='btnCarr' onclick='carregaFuncionarios(this)'><i class='fas fa-plus'></i></button></td>
				  </tr>";
		}
	}else{
		header("location: alunos.php");
	}

?>