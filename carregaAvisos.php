<?php

	include_once "conexao.php";
	include_once "Usuario.php";
	if(!isset($_SESSION)) session_start();

	$conexao = conexao::getConexao();

	if(!isset($_SESSION["usuario"])){
		header("location: index.php");
	}

	$dados = $_SESSION["usuario"];

	if(isset($_POST["min"])){
		try{
			$min = trim(addslashes($_POST["min"]));
			$cod = $dados->getCodUsuario();

			$comando = $conexao->prepare("SELECT id_aviso, titulo, situacao, data_envio FROM avisos WHERE id_usuario_avisos = :id ORDER BY id_aviso DESC LIMIT $min, 10");

			$comando->bindParam(":id", $cod);

			$comando->execute();

			$dadoMsg = $comando->fetchAll();

			$html = null;

			if(count($dadoMsg) > 0){
				$i = $min;

				foreach($dadoMsg as $valor){
					$id = htmlspecialchars($valor[0]);
					$titulo = htmlspecialchars($valor[1]);
					$situacao = (htmlspecialchars($valor[2]) == "V") ? "Visualizado" : "Não Visualizado";
					$data = explode("-", htmlspecialchars($valor[3]));
					$data = $data[2] . "/" . $data[1] . "/" . $data[0];

					$html .= "<tr class='trMsg'>
								<td onclick='carregaAvisoUser($id, $i)'>$data</td>
								<td onclick='carregaAvisoUser($id, $i)'>$titulo</td>
								<td id='situcaoMsg$i' onclick='carregaAvisoUser($id, $i)'>$situacao</td>
								<td class='linhaOp'>
									<i class='fas fa-eye' title='Visualizar' onclick='carregaAvisoUser($id, $i)'></i>
									<i class='fas fa-trash-alt' title='Deletar' onclick='deletaAviso($id)'></i>
								</td>
							 </tr>";

					$i++;
				}

				if(count($dadoMsg) >= 10){
					$html .= "<tr id='trMsgLoading'>
								<td colspan='4'><button class='carregarMaisT' onclick='carregaAvisos(this)'><i class='fas fa-plus' title='Carregar Mais'></i></button></td>
							  </tr>";
				}
			}else{
				$html = "<tr><td colspan='4'><h4>Você não tem nenhuma mensagem</h4></td></tr>";
			}
			
			echo $html;
		}catch(Exeption $ex){
			echo "<tr id='trMsgLoading'>
					<td colspan='4'><button class='carregarMaisT' onclick='carregaAvisos(this)'><i class='fas fa-plus' title='Carregar Mais'></i></button></td>
				  </tr>";
		}
	}else{
		header("location: Inicio.php");
	}

?>