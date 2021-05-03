		function verifica(){
			var rm = formLogin.rm.value
			var senha = formLogin.senha.value

			var span = window.document.getElementsByClassName('SpanAlerta')
			var input = window.document.getElementsByClassName('in')

			if((rm.length == 0 && window.document.getElementById("rm").type == "number") || (rm.length < 14 && window.document.getElementById("rm").type == "text")){
				span[0].style.display = 'inline'
				input[0].style.border = '1px solid #912900'
			}

			if(senha.length == 0){
				span[1].style.display = 'inline'
				input[1].style.border = '1px solid #912900'
			}

			for(var i = 0; i <= 1; i++){
				if(span[i].style.display == 'inline'){
					return false
				}
			}

			window.document.getElementById('moldalLoading').style.display = "flex"
		}

		function limpaCampo(valor, obj){
			var span = window.document.getElementsByClassName('SpanAlertaTroca')

			obj.style.borderColor = 'gray'
			span[valor].style.display = 'none'			
		}

		function limpa(valor){
			var span = window.document.getElementsByClassName('SpanAlerta')
			var input = window.document.getElementsByClassName('in')

			span[valor].style.display = 'none'
			input[valor].style.border = 'none'
		}

		function fechaMoldal(){
			window.document.getElementsByClassName('Moldal')[0].style.display = 'none'
		}
		function abrirMoldal(){
			window.document.getElementsByClassName('Moldal')[0].style.display = 'flex'
		}

		function deletaMoldal(){
			window.document.getElementById('MoldalAviso').remove()
		}

		function selecionaEntrada(obj){
			let inputSenha = window.document.getElementById('rm')
			let span = window.document.getElementsByClassName('SpanAlerta')

			if(obj.value == 0 || obj.value == 1){
				inputSenha.type = "number"
				inputSenha.placeholder = "RM"
				span[0].innerHTML = "Digite o RM<br>"

				$('#rm').mask("0000000000000000000000000000000000000")
			}else{
				inputSenha.type = "text"
				inputSenha.placeholder = "CPF"
				span[0].innerHTML = "Digite o CPF<br>"

				$('#rm').mask("000.000.000-00")
			}
		}

		function selecionaEntradaMoldal(obj){
			let inputSenha = window.document.getElementById('rmTroca')

			if(obj.value == 0 || obj.value == 1){
				inputSenha.type = "number"
				inputSenha.placeholder = "RM"

				$('#rmTroca').mask("0000000000000000000000000000000000000")
			}else{
				inputSenha.type = "text"
				inputSenha.placeholder = "CPF"

				$('#rmTroca').mask("000.000.000-00")
			}
		}

		//Funções para visualizar senha

		function verSenha(obj){
			let inputSenha = window.document.getElementById("senha")

			if(inputSenha.type == "text"){
				obj.classList.add("fa-eye")
				obj.classList.remove("fa-eye-slash")

				inputSenha.type = "password"
			}else{
				obj.classList.add("fa-eye-slash")
				obj.classList.remove("fa-eye")

				inputSenha.type = "text"
			}
		}

		window.addEventListener("load", function(){
			$("#cpfTroca").mask("000.000.000-00")
		})