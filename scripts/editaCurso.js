		function verifica(){
			var span = window.document.getElementsByClassName('spanAlerta')

			var verificar = true

			let elementos = window.document.getElementsByClassName('inputV')

			for(let i = 0; i < elementos.length; i++){
				if(elementos[i].type == 'date'){
					if(elementos[i].value.trim().length < 8){
						verificar = false
						span[i].style.display = 'inline'
						elementos[i].style.border = '1px solid #5c0101'
					}
				}else if(elementos[i].type == 'number'){
					if(elementos[i].value.trim().length == 0 || elementos[i].value.trim() < elementos[i].min){
						verificar = false
						span[i].style.display = 'inline'
						elementos[i].style.border = '1px solid #5c0101'
					}
				}else if(elementos[i].type == "select-one"){
					if(elementos[i].innerHTML.length == 0){
						verificar = false
						span[i].style.display = 'inline'
						elementos[i].style.border = '1px solid #5c0101'
					}
				}else{
					if(elementos[i].value.trim().length == 0){
						verificar = false
						span[i].style.display = 'inline'
						elementos[i].style.border = '1px solid #5c0101'
					}
				}
			}

			return verificar
		}

		function limpaCampos(indice){
			var span = window.document.getElementsByClassName('spanAlerta')
			var input = window.document.getElementsByClassName('inputV')

			span[indice].style.display = 'none'
			input[indice].style.border = '1px solid #141313'
		}

		function executaCadastro(){
			if(verifica()){
				$.ajax({
					method: "POST",
					url: "editaCurso.php",
					data: new FormData(window.document.getElementById('formCad')),
					processData: false, 
					contentType: false,
					beforeSend: function(){
						window.document.getElementById('moldalLoading').style.display = "flex"
					}
				})
				.done(function(msg){
					window.document.getElementById("MoldalAviso").innerHTML = msg
					window.document.getElementById("MoldalAviso").style.display = "flex"
					window.document.getElementById('moldalLoading').style.display = "none"
				})
				.fail(function(){
					alert("Turma não editada, Ocorreu um erro na operação de edição!")
					window.document.getElementById('moldalLoading').style.display = "none"
				})
			}
		}

		function transformaMaisucula(input){
			input.value = input.value.toUpperCase()
		}

		function inicia(){
			let elementos = window.document.getElementsByClassName('inputV')

			for(let i = 0; i < elementos.length; i++){
				if(elementos[i].type == 'file' || elementos[i].type == 'date' || elementos[i].type == 'number' || elementos[i].type == 'select-one'){
					elementos[i].addEventListener("change", function(){
						limpaCampos(i)
					})
				}

				elementos[i].addEventListener("keyup", function(){
					limpaCampos(i)
				})
			}
		}

		function deletaMoldal(){
			window.document.getElementById("MoldalAviso").innerHTML = ""
			window.document.getElementById("MoldalAviso").style.display = "none"
		}

		window.addEventListener("load", inicia)