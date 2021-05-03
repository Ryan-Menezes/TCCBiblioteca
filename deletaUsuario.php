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

	$msgFinal = null;

	if(isset($_POST["codU"]) && isset($_POST["senha"]) && isset($_POST["instituicao"])){
		try{
			$codigoU = trim(addslashes($_POST["codU"]));
			$senha = md5(trim(addslashes($_POST["senha"])));
			$instituicao = trim(addslashes($_POST["instituicao"]));

			if($senha == $dadosUsuario->getSenha()){
				$comando = $conexao->prepare("SELECT * FROM locacao AS l INNER JOIN exemplares AS e ON e.id_exemplares = l.id_exemplares WHERE id_usuario_locacao = :codU OR id_usuarioAdimin_locacao = :codA AND e.id_instituicao = :inst LIMIT 1");

				$comando->bindParam(":codU", $codigoU);
				$comando->bindParam(":codA", $codigoU);
				$comando->bindParam(":inst", $instituicao);

				$comando->execute();

				if(count($comando->fetchAll()) == 0){

					//Buscando instituições do usuário

					$comando = $conexao->prepare("DELETE FROM instituicao_usuario WHERE id_instituicao = :inst AND id_usuario = :user");

					$comando->bindParam(":inst", $instituicao);
					$comando->bindParam(":user", $codigoU);

					$comando->execute();

					//Buscando cursos do usuário

					$comando = $conexao->prepare("SELECT ca.id_curso_usuario FROM curso_usuario AS ca INNER JOIN curso AS c ON ca.curso_id_curso = c.id_curso INNER JOIN instituicao AS i ON i.id_instituicao = c.id_instituicao_curso WHERE i.id_instituicao = :inst AND ca.usuario_id_usuario = :user");

					$comando->bindParam(":inst", $instituicao);
					$comando->bindParam(":user", $codigoU);

					$comando->execute();

					$cursosUsuario = $comando->fetchAll();

					if(count($cursosUsuario) > 0){
						//Deletando cursos

						foreach($cursosUsuario as $valor){
							$comando = $conexao->prepare("DELETE FROM curso_usuario WHERE id_curso_usuario = :id LIMIT 1");

							$comando->bindValue(":id", $valor['id_curso_usuario']);

							$comando->execute();
						}
					}

					//Verificando todos os cursos e instituições do usuário

					//Cursos

					$comando = $conexao->prepare("SELECT ca.id_curso_usuario FROM curso_usuario AS ca INNER JOIN curso AS c ON ca.curso_id_curso = c.id_curso INNER JOIN instituicao AS i ON i.id_instituicao = c.id_instituicao_curso WHERE ca.usuario_id_usuario = :user LIMIT 1");

					$comando->bindParam(":user", $codigoU);

					$comando->execute();

					$cursosUsuario = $comando->fetchAll();

					//Instituição

					$comando = $conexao->prepare("SELECT id_instituicao_usuario FROM instituicao_usuario WHERE id_usuario = :user LIMIT 1");

					$comando->bindParam(":user", $codigoU);

					$comando->execute();

					$instituicaoUsuario = $comando->fetchAll();

					if(count($cursosUsuario) == 0 && count($instituicaoUsuario) == 0){
						
						//Deletando usuario por completo

						$comando = $conexao->prepare("DELETE FROM usuario WHERE id_usuario = :cod LIMIT 1");

						$comando->bindParam(":cod", $codigoU);

						$comando->execute();
					}
					
					$msgFinal = "Usuário deletado com sucesso";
				}else{
					$msgFinal = "Este usuário está devendo alguns livros a biblioteca ou está associado a alguma alocação feita, portanto não é possivel deletá-lo!";
				}
				
			}else{
				$msgFinal = "Senha inválida, não foi possivel deletar o usuário";
			}
		}catch(Execption $ex){
			$msgFinal = "Usuário não deletado, Ocorreu um erro na operação de exclusão";
		}
	}else{
		header("location: Inicio.php");
	}

	if($msgFinal == "Usuário deletado com sucesso"){
		echo "<main>
				<div class='containeAv'>
					<div>
						<h4>$msgFinal</h4>
					</div>
					<div>
						<i class='fas fa-check-circle'></i>
					</div>
				</div>
				<hr>
				<button onclick='deletaMoldal()'>OK</button>
			</main>";
	}else{
		echo "<main>
				<div class='containeAv'>
					<div>
						<h4>$msgFinal</h4>
					</div>
					<div>
						<i class='fas fa-times-circle'></i>
					</div>
				</div>
				<hr>
				<button onclick='deletaMoldal()'>OK</button>
			</main>";
	}
?>