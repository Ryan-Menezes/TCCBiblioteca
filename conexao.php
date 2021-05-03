<?php

	include_once "dadosSistema.php";

	error_reporting(E_ALL ^ E_ERROR | E_WARNING | E_PARSE);

	class conexao{
		public static $server = "localhost";
		public static $user = "root";
		public static $password = "";
		public static $banco = "bdbibliotecaetec";
		public static $conexao = null;

		public static function getConexao(){
			try{
				self::$conexao = new PDO("mysql:host=" . self::$server . "; dbname=" . self::$banco . "; charset=utf8", self::$user, self::$password);
				self::$conexao->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
				self::$conexao->exec("set names utf8");
			}catch(PDOException $erro){
				echo "<!DOCTYPE html>
					 <html>
					 <head>
					 	<title>".Info::$nomeSistema." - Erro de Conexão</title>
						<style type='text/css'>
							*{
								margin: 0;
								padding: 0;
								font-family: arial;
							}
							section{
								position: absolute;
								background-size: cover;
								background-image: url(./Imagens/telaFundo.png);
								width: 100%;
								height: 100%;
								display: flex;
								align-items: center;
								justify-content: center;
							}
							div{
								width: 300px; 
								text-align: center; 
								padding: 20px; color: white;
								background-color: #03a5fc; 
								border-radius: 3px; 
								box-shadow: 0px 0px 5px 3px #111212;
							}
							div hr{
								border: 1px solid #0293e6;
							}
							button{
								border: 2px solid white;
								padding: 5px;
								color: white;
								background-color: transparent;
								cursor: pointer;
								border-radius: 3px;
								transition-duration: 0.3s;
								outline: none;
							}
							button:hover{
								color: black;
								background-color: white;
							}
						</style>

						<link rel='stylesheet' type='text/css' href='./css/fontawesome-free-5.12.1-web/css/all.min.css'>
						<link rel='stylesheet' type='text/css' href='./css/fontawesome-free-5.12.1-web/css/brands.min.css'>
						<link rel='stylesheet' type='text/css' href='./css/fontawesome-free-5.12.1-web/css/solid.min.css'>
						<link rel='stylesheet' type='text/css' href='./css/fontawesome-free-5.12.1-web/css/svg-with-js.min.css'>
						<link rel='stylesheet' type='text/css' href='./css/fontawesome-free-5.12.1-web/css/regular.min.css'>
						<link rel='stylesheet' type='text/css' href='./css/fontawesome-free-5.12.1-web/css/v4-shims.min.css'>
						<link rel='shortcut icon' type='image/jpg' href='".Info::$logoSistema."' sizes='50x50'>
					 </head>
					 <body>
						<section>
							<div>
								<h5>Ocorreu um erro na conexão com o servidor <i class='fas fa-sad-tear'></i><h5>
								<br><hr><br>
								<button onclick='location.reload()'>Recarregar <i class='fas fa-redo-alt'></i></button>
							</div>
						</section>
					 </body>
					 </html>";

				exit;
			}

			return self::$conexao;
		}
	}

?>