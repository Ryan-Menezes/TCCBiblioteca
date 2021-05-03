<?php

	include_once "conexao.php";
	include_once "Usuario.php";
	include_once "recaptcha.php";
	include_once "codigosRecaptcha.php";
	if(!isset($_SESSION)) session_start();

	$conexao = conexao::getConexao();

	if(!isset($_SESSION["usuario"])){
		header("location: index.php");
	}

	$dados = $_SESSION["usuario"];

	$msgFinal = null;

	//Configurações sobre o recaptcha

	$chaveSecreta = $codChaveRe;
	$response = null;
    $reCaptcha = new reCaptcha($chaveSecreta);

	if(isset($_POST["txt"]) && isset($_POST["estrelas"]) && isset($_POST["livro"]) && isset($_POST['g-recaptcha-response'])){

		$response = $reCaptcha->verifyResponse($_SERVER['REMOTE_ADDR'], $_POST['g-recaptcha-response']);

		if($response != null && $response->success){
			try{
				$texto = (strlen(trim(addslashes($_POST["txt"]))) > 0) ? censuraPalavroes(trim(addslashes($_POST["txt"]))) : null;
				$estrelas = trim(addslashes($_POST["estrelas"]));
				$livro = trim(addslashes($_POST["livro"]));

				$comando = $conexao->prepare("INSERT INTO avaliacao (mensagem, avaliacao_estrelas, data_ava, id_usuario_avaliacao, livro_tombo_avaliacao) VALUES (:msg, :ava, CURDATE(), :user, :livro)");

				$comando->bindParam(":msg", $texto);
				$comando->bindParam(":ava", $estrelas);
				$comando->bindValue(":user", $dados->getCodUsuario());
				$comando->bindParam(":livro", $livro);

				$comando->execute();

				if($comando->rowCount() > 0){
					$msgFinal = "Avaliação enviada com sucesso!";
				}else{
					$msgFinal = "Não foi possivel enviar esta mensagem!, Ocorreu um erro no processo de envio!";
				}
			}catch(Exception $ex){
				$msgFinal = "Não foi possivel enviar esta mensagem!, Ocorreu um erro no processo de envio!";
			}
		}else{
			$msgFinal = "Recaptcha Inválido";
		}
	}else{
		header("location: telaLivro.php");
	}

	if($msgFinal == "Avaliação enviada com sucesso!"){
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

	function censuraPalavroes($txt){
		$palavroes = array("vai tomar no cu", "vai tomar no cú", "vai tomar no ku", "vai tomar no kú", "fuder", "foder", "fude", "fode", "fudeu", "foda-se", "fodase", "puta", "vai tomar no ku", "arrombado", "cuzão", "cusão", "cusao", "cozona", "cusona", "fdp", "pqp", "vsf", "vagabunda", "vagabundo", "caralho", "karalho", "porra", "pau duro", "pal duro", "pau no cu", "pal no cu", "pau no cú", "pal no cú", "pau no ku", "pal no ku", "pau no kú", "pal no kú", "buceta", "bct", "krl", "crl");

		foreach($palavroes as $palavrao){
			$asteristicos = null;

			for($i = 0; $i < strlen($palavrao); $i++){
				$asteristicos .= "*";
			}

			$txt = str_ireplace($palavrao, $asteristicos, $txt);
		}
		
		return $txt;
	}

?>