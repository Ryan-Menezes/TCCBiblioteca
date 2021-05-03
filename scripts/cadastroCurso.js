		var turmas = []
		var periodos = []
		var moduloSeries = []

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

		function limpaCamposCad(){
			var elementos = window.document.forms['formCad'].elements

			for(let i = 0; i < elementos.length; i++){
				if(elementos[i].type == 'date' || elementos[i].type == 'number' || elementos[i].type == 'text' || elementos[i].type == 'file' || elementos[i].type == 'email'){
					elementos[i].value = ""
				}else if(elementos[i].type == "select-one" && elementos[i].size >= 5){
					elementos[i].innerHTML = ""
				}
			}

			turmas = []
			periodos = []
			moduloSeries = []
		}

		function executaCadastro(){
			if(verifica()){
				window.document.getElementById("moduloSeries").value = moduloSeries.join()
				window.document.getElementById("turmas").value = turmas.join()
				window.document.getElementById("periodos").value = periodos.join()

				$.ajax({
					method: "POST",
					url: "cadastraCurso.php",
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
					alert("Curso não cadastrado, Ocorreu um erro na operação de cadastro!")
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

			window.document.getElementsByClassName("btnAbreMoldal")[0].addEventListener("click", abreMoldalCad)
			window.document.getElementsByClassName("btnCadSub")[0].addEventListener("click", adicionaTurma)

			var inputsT = window.document.getElementsByClassName("inputsT")			

			for(let i = 0; i < inputsT.length; i++){
				inputsT[i].addEventListener("keyup", function(){
					limpaInputTurma(i)
				})
			}
		}

		function deletaMoldal(tipo){
			window.document.getElementById("MoldalAviso").innerHTML = ""
			window.document.getElementById("MoldalAviso").style.display = "none"

			if(tipo){
				limpaCamposCad()
			}
		}

		function fechaMoldalCad(){
			var inputsT = window.document.getElementsByClassName("inputsT")

			window.document.getElementsByClassName("MoldaCad")[0].style.display = "none"

			for(let i = 0; i < inputsT.length; i++){
				limpaInputTurma(i)
				inputsT[i].value = ""
			}
		}

		function abreMoldalCad(){
			window.document.getElementsByClassName("MoldaCad")[0].style.display = "flex"
		}

		function adicionaTurma(){
			var inputsT = window.document.getElementsByClassName("inputsT")
			var select = window.document.getElementById("periodo")
			var span = window.document.getElementsByClassName("spanCad")

			var verifica = true

			for(let i = 0; i < inputsT.length; i++){
				if(inputsT[i].value.trim().length == 0){
					inputsT[i].style.border = '1px solid #5c0101'
					span[i].style.display = 'inline'
					verifica = false
				}
			}

			if(verifica){
				for(let i = 0; i < turmas.length; i++){
					if(moduloSeries[i] == inputsT[0].value.trim() && turmas[i] == inputsT[1].value.trim()){
						verifica = false
					}
				}

				if(verifica){
					moduloSeries.push(inputsT[0].value.trim())
					turmas.push(inputsT[1].value.trim())
					periodos.push(select.value.trim())

					let periodoText = (select.value.trim() == "M") ? "Manhã" : (select.value.trim() == "T") ? "Tarde" : (select.value.trim() == "N") ? "Noite" : "Integral"

					window.document.getElementById("turmasSelecionados").innerHTML += `<option ondblclick="removeTurma(this, '${inputsT[0].value.trim()}', '${inputsT[1].value.trim()}')">${inputsT[0].value.trim()}º Módulo/Série - Turma: ${inputsT[1].value.trim()} - Periodo: ${periodoText}</option>`
					fechaMoldalCad()
				}else{
					alert("Já existe uma turma como essa na lista, não é possível adicioná-la novamente!")
				}
			}
		}

		function removeTurma(obj, moduloSerie, turma){
			for(let i = 0; i < turmas.length; i++){
				if(moduloSeries[i] == moduloSerie && turmas[i] == turma){
					moduloSeries.splice(i, 1)
					turmas.splice(i, 1)
					periodos.splice(i, 1)
					obj.remove()
				}
			}
		}

		function limpaInputTurma(indice){
			var inputsT = window.document.getElementsByClassName("inputsT")
			var span = window.document.getElementsByClassName("spanCad")

			span[indice].style.display = 'none'
			inputsT[indice].style.border = '1px solid #141313'
		}

		window.addEventListener("load", inicia)