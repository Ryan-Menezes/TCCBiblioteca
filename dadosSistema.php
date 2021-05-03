<?php

	class Info{

		//Informaçõres do sistema

		public static $nomeSistema = "Biblioteca";
		public static $logoSistema = "./Imagens/Logo.jpg";
		public static $copyright = null;

		//Informações da etec

		public static $nomeEtec = "ETEC Juscelino Kubitschek de Oliveira";
		public static $logoEtec = "./Imagens/LogoJK.jpg";
		public static $siteEtec = "http://www.etecjk.com/";


		//Informações centro paula souza

		public static $nomeCentro = "Centro Paula Souza";
		public static $logoCentro = "./Imagens/LogoCPS.jpg";
		public static $siteCentro = "https://www.cps.sp.gov.br/";

		//Método

		public static function inicia(){
			self::$copyright = self::$nomeSistema . " - &copy; 2020 - " . date("Y") . " - Todos os direitos reservados";
		}
	}

	Info::inicia();

?>