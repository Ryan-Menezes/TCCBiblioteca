<?php

	final class Usuario{
		private $rm;
		private $cpf;
		private $nome;
		private $sobrenome;
		private $img;
		private $senha;
		private $nivelAcesso;
		private $instituicoes;
		private $codUsuario;

		//Metodo construtor

		public function __construct($r, $c, $n, $so, $i, $se, $ni, $in, $co){
			$this->setRM($r);
			$this->setCPF($c);
			$this->setNome($n);
			$this->setSobrenome($so);
			$this->setImg($i);
			$this->setSenha($se);
			$this->setNivelAcesso($ni);
			$this->setInstituicoes($in);
			$this->setCodUsuario($co);
		}

		//Metodos get e set

		public final function getRM(){
			return $this->rm;
		}

		public final function getCPF(){
			return $this->cpf;
		}

		public final function getNome(){
			return $this->nome;
		}

		public final function getSobrenome(){
			return $this->sobrenome;
		}

		public final function getImg(){
			return $this->img;
		}

		public final function getSenha(){
			return $this->senha;
		}

		public final function getNivelAcesso(){
			return $this->nivelAcesso;
		}

		public final function getInstituicoes(){
			return $this->instituicoes;
		}

		public final function getCodUsuario(){
			return $this->codUsuario;
		}

		//setters

		public final function setRM($valor){
			$this->rm = $valor;
		}

		public final function setCPF($valor){
			$this->cpf = $valor;
		}

		public final function setNome($valor){
			$this->nome = $valor;
		}

		public final function setSobrenome($valor){
			$this->sobrenome = $valor;
		}

		public final function setImg($valor){
			$this->img = $valor;
		}

		public final function setSenha($valor){
			$this->senha = $valor;
		}

		public final function setNivelAcesso($valor){
			$this->nivelAcesso = $valor;
		}

		public final function setInstituicoes($valor){
			$this->instituicoes = $valor;
		}

		public final function setCodUsuario($valor){
			$this->codUsuario = $valor;
		}
	}

?>