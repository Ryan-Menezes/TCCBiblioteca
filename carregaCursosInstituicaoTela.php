<?php

	include_once "conexao.php";
	include_once "Usuario.php";
	if(!isset($_SESSION)) session_start();

	$conexao = conexao::getConexao();

	if(!isset($_SESSION["usuario"])){
		header("location: index.php");
	}

	$dados = $_SESSION["usuario"];

	$nivelAcesso = $dados->getNivelAcesso();

	if($nivelAcesso != "A"){
		header("location: index.php");
	}

	//Código acima - verificação de login

	if(isset($_POST["inst"]) && isset($_POST["min"]) && isset($_POST["txt"])){
		$conexao = conexao::getConexao();

		$cod = trim(addslashes($_POST["inst"]));
		$min = trim(addslashes($_POST["min"]));
		$txt = htmlspecialchars(trim(addslashes($_POST["txt"])));

		try{
			$cursos = null;

			//Pegando cursos

			$comando = $conexao->prepare("SELECT c.id_curso, c.nome_curso, c.modulo_serie, c.periodo, c.turma, c.tipo, i.nome_instituicao FROM curso AS c INNER JOIN instituicao AS i ON c.id_instituicao_curso = i.id_instituicao WHERE id_instituicao_curso = $cod AND c.nome_curso LIKE :txt ORDER BY nome_curso LIMIT $min, 10");

			$comando->bindValue(":txt", "%$txt%");

			$comando->execute();

			$dados = $comando->fetchAll();

			if(count($dados) > 0){
				foreach($dados as $valor){
					$codigo = htmlspecialchars($valor[0]);
					$nome = htmlspecialchars($valor[1]);
					$moduloSerie = htmlspecialchars($valor[2]);
					$periodo = null;

					if (htmlspecialchars($valor[3]) == "M") $periodo = "Manhã";
					else if (htmlspecialchars($valor[3]) == "T") $periodo = "Tarde";
					else if (htmlspecialchars($valor[3]) == "N") $periodo = "Noite";
					else $periodo = "Integral";
					
					$turma = htmlspecialchars($valor[4]);
					$tipo = htmlspecialchars($valor[5]);
					$nome_inst = htmlspecialchars($valor[6]);

					$cursos .= "<tr class='trCurso'>
									<td>$nome</td>
									<td>$moduloSerie</td>
									<td>$periodo</td>
									<td>$turma</td>
									<td>$tipo</td>
									<td>$nome_inst</td>
									<td>
									    <i class='fas fa-trash-alt' title='Excluir' onclick='abreMoldalSenha($codigo)'></i>
									    <a href='editCurso.php?codC=$codigo'><i class='fas fa-pencil-alt' title='Editar'></i></a>
									</td>
								</tr>";
				}

				if(count($dados) >= 10){
					$cursos .= "<tr id='carregarMaisTable'>
									<td colspan='7'><button class='btnCarr' onclick='carregaCursos(this)'><i class='fas fa-plus'></i></button></td>
								</tr>";
				}
			}else{
				if($min == 0 && strlen($txt) == 0){
					$cursos = "<tr>
								<td colspan='7'><h5>Não há cursos cadastrados nessa instituição</h5></td>
							  </tr>";
				}else if(strlen($txt) > 0){
					$cursos = "<tr>
								<td colspan='7'><h5>Não foi possivel localizar nenhum curso nessa instituição com o nome '$txt'</h5></td>
							  </tr>";
				}
			}
			

			echo $cursos;
		}catch(Exception $ex){
			echo "<tr id='carregarMaisTable'>
					<td colspan='7'><button class='btnCarr' onclick='carregaCursos(this)'><i class='fas fa-plus'></i></button></td>
				  </tr>";
		}
	}else{
		header("location: instituicoes.php");
	}

?>