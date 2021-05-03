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

	if(isset($_POST["codL"]) && isset($_POST["senha"]) && isset($_POST["codE"])){
		try{
			$codigoL = trim(addslashes($_POST["codL"]));
			$codigoE = trim(addslashes($_POST["codE"]));
			$senha = md5(trim(addslashes($_POST["senha"])));

			if($senha == $dadosUsuario->getSenha()){
				$comando = $conexao->prepare("SELECT * FROM locacao WHERE id_exemplares = :cod LIMIT 1");

				$comando->bindParam(":cod", $codigoE);

				$comando->execute();

				if(count($comando->fetchAll()) == 0){
					
					//Deletando exemplares

					$comandoE = $conexao->prepare("DELETE FROM exemplares WHERE id_exemplares = :cod LIMIT 1");

					$comandoE->bindParam(":cod", $codigoE);

					$comandoE->execute();

					//Pesquisando livro e deletando se for necessário

					$comando = $conexao->prepare("SELECT * FROM exemplares WHERE livro_tombo_exemplares = :cod LIMIT 1");

					$comando->bindParam(":cod", $codigoL);

					$comando->execute();

					//Deletando livro por completo

					if(count($comando->fetchAll()) == 0){
						//Pegando pdf do livro

						$comando = $conexao->prepare("SELECT pdf_livro FROM livro WHERE cod_livro = :cod LIMIT 1");

						$comando->bindParam(":cod", $codigoL);

						$comando->execute();

						$pdf = $comando->fetchAll()[0][0];

						//Deletando livro

						$comandoL = $conexao->prepare("DELETE FROM livro WHERE cod_livro = :cod LIMIT 1");

						$comandoL->bindParam(":cod", $codigoL);

						$comandoL->execute();

						//Removendo pdf

						if($comandoL->rowCount() > 0 && strlen($pdf) > 0){
							if(file_exists("./PDFS/$pdf")){
								unlink("./PDFS/$pdf");
							}
						}
					}

					if($comandoE->rowCount() > 0 || $comandoL->rowCount() > 0){
						$msgFinal = "Livro deletado com sucesso";
					}else{
						$msgFinal = "Livro não deletado, Ocorreu um erro na operação de exclusão";
					}
				}else{
					$msgFinal = "Este livro tem algumas cópias alocadas, no momento não é possivel deletá-lo!, caso seja preciso, você deve encerrar todas essas alocações envolvendo este livro!";
				}
				
			}else{
				$msgFinal = "Senha inválida, não foi possivel deletar o livro";
			}
		}catch(Execption $ex){
			$msgFinal = "Livro não deletado, Ocorreu um erro na operação de exclusão";
		}
	}else{
		header("location: Inicio.php");
	}

	if($msgFinal == "Livro deletado com sucesso"){
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