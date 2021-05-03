<?php

	include_once "conexao.php";
	include_once "Usuario.php";
	if(!isset($_SESSION)) session_start();

	$conexao = conexao::getConexao();

	if(!isset($_SESSION["usuario"])){
		header("location: index.php");
	}

	$dados = $_SESSION["usuario"];
	$cod_usuario = $dados->getCodUsuario();

	$comando = $conexao->prepare("SELECT * FROM locacao AS al INNER JOIN exemplares AS e ON e.id_exemplares = al.id_exemplares INNER JOIN livro AS l ON l.cod_livro = e.livro_tombo_exemplares INNER JOIN instituicao AS i ON i.id_instituicao = e.id_instituicao WHERE al.data_devolucao < CURDATE() AND al.notificado = 0 AND al.id_usuario_locacao = :id");

	$comando->bindParam(":id", $cod_usuario);

	$comando->execute();

	$dadosLoc = $comando->fetchAll();

	foreach($dadosLoc as $valor){
		$idLocacao = htmlspecialchars($valor["id_locacao"]);
		$cod_admin = htmlspecialchars($valor["id_usuarioAdimin_locacao"]);
		$instituicao = htmlspecialchars($valor["nome_instituicao"]);
		$tituloLivro = '"' . htmlspecialchars($valor["titulo"]) . '"';

		$comando = $conexao->prepare("INSERT INTO avisos (titulo, mensagem, situacao, data_envio, id_usuario_avisos, id_usuarioRemetente_avisos) VALUES ('Atraso', 'Você está devendo o seguinte livro $tituloLivro para a biblioteca do(a) $instituicao, por favor procure a administração e renove o seu tempo de devolução ou devolva-o, assim outras pessoas podem ter o prazer de ler este mesmo livro.', 'N', CURDATE(), :usuario, :userRem)");

		$comando->bindParam(":usuario", $cod_usuario);
		$comando->bindParam(":userRem", $cod_admin);

		$comando->execute();

		//Alterando o atributo notificado

		$comando = $conexao->prepare("UPDATE locacao SET notificado = TRUE WHERE id_locacao = :id LIMIT 1");

		$comando->bindParam(":id", $idLocacao);

		$comando->execute();
	}
?>