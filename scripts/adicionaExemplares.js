		//Vetores que armazeraram os dados selecionados nas listas

		var editoras = []
		var livro = null
		var title = null
		var cod = null

		function verifica(){
			var span = window.document.getElementsByClassName('spanAlerta')

			var verificar = true

			let elementos = window.document.getElementsByClassName('inputV')

			for(let i = 0; i < elementos.length; i++){
				if(elementos[i].type == 'file'){
					let source = elementos[i].value.split('/')

					if(source[source.length - 1] == elementos[i].alt){
						verificar = false
						span[i].style.display = 'inline'
					}
				}else if(elementos[i].type == 'date'){
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


		//Função que irá limpar os campos após o cadastro

		function limpaCamposCad(){
			var elementos = window.document.forms['formCad'].elements

			for(let i = 0; i < elementos.length; i++){
				if(elementos[i].type == 'date' || elementos[i].type == 'number' || elementos[i].type == 'text' || elementos[i].type == 'file' || elementos[i].type == 'email'){
					elementos[i].value = ""
				}else if(elementos[i].type == "select-one" && elementos[i].size >= 5){
					elementos[i].innerHTML = ""
				}
			}

			editora = null
			livro = null
			title = null
			cod = null
		}

		//Função que manda os dados para a tela cadastraLivro.php, e por lá o cadastro é finalizado

		function adicionaExemplares(){
			if(verifica()){

				window.document.getElementById("livroCodigo").value = livro
				window.document.getElementById("editoras").value = editoras.join()

				$.ajax({
					method: "POST",
					url: "adicionaExemplaresLivro.php",
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
					alert("Não foi possivel adicionar os exemplares, Ocorreu um erro no processo")
					window.document.getElementById('moldalLoading').style.display = "none"
				})
			}
		}

		function fechaMoldalCad(){
			let moldals = window.document.getElementsByClassName('MoldaCad')
			let inputsE = window.document.getElementsByClassName('inputsE')
			let inputsA = window.document.getElementsByClassName('inputsA')

			let spanA = window.document.getElementsByClassName('spanCadA')
			let spanE = window.document.getElementsByClassName('spanCadE')

			for(i of moldals){
				i.style.display = 'none'
			}

			//Cadastro editora inputs

			for(i of inputsE){
				i.value = ""
				i.style.border = "none"
			}

			for(i of spanE){
				i.style.display = "none"
			}

			//Cadastro autor inputs

			for(i of inputsA){
				i.value = ""
				i.style.border = "none"
			}

			for(i of spanA){
				i.style.display = "none"
			}

			//Limpando input tombo

			limpaInputTombo(0)
			limpaInputTombo(1)
			title = null

			let inputs = window.document.getElementsByClassName("inputTomboCad")

			for(let i = 0; i < inputs.length; i++){
				inputs[i].value = ""
			}
		}

		function inicia(){
			let btn = window.document.getElementsByClassName('fechaMoldalOpcoes')
			let elementos = window.document.getElementsByClassName('inputV')
			let moldals = window.document.getElementsByClassName('btnAbreMoldal')
			
			for(i of btn){
				i.addEventListener("click", fechaMoldal)
			}

			for(let i = 0; i < elementos.length; i++){
				if(elementos[i].type == 'file' || elementos[i].type == 'date' || elementos[i].type == 'number' || elementos[i].type == 'select-one'){
					elementos[i].addEventListener("change", function(){
						limpaCampos(i)
					})

					if(elementos[i].type == 'file'){
						elementos[i].addEventListener("change", preview)
					}
				}

				elementos[i].addEventListener("keyup", function(){
					limpaCampos(i)
				})
			}

			for(let i = 0; i < moldals.length; i++){
				moldals[i].addEventListener("click", function(){
					abreMoldal(i)
				})
			}

			let inputs = window.document.getElementsByClassName("inputTomboCad")

			for(let i = 0; i < inputs.length; i++){
				inputs[i].addEventListener("keyup", function(){
					limpaInputTombo(i)
				})
			}
		}

		//editora

		function selecionaEditora(codigo, texto){
			
			editora = codigo

			window.document.getElementById('editora').value = texto

			window.document.getElementsByClassName('MoldalOpcoes')[0].style.display = "none"
		}

		function deletaMoldal(tipo){
			window.document.getElementById("MoldalAviso").innerHTML = ""
			window.document.getElementById("MoldalAviso").style.display = "none"

			if(tipo){
				limpaCamposCad()
			}
		}

		//Livro

		function selecionaLivro(codigo, titulo, tombo){

			if(tombo.trim().length > 0){
				livro = codigo
				window.document.getElementById("livro").value = `${titulo} - Tombo: ${tombo}`
				window.document.getElementById("inputTombo").value = ""
				window.document.getElementById("inputISBN").value = ""
			}else{
				cod = codigo
				title = titulo
				abreMoldalTombo()
			}

			fechaMoldal()
		}

		function informaTombo(){
			let inputs = window.document.getElementsByClassName("inputTomboCad")
			let spans = window.document.getElementsByClassName("spanTombo")
			let verifica = true

			for(let i = 0; i < inputs.length; i++){
				if(inputs[i].value.trim().length == 0){
					spans[i].style.display = 'inline'
					inputs[i].style.border = '1px solid #5c0101'
					verifica = false
				}
			}

			if(verifica){
				window.document.getElementById("inputTombo").value = inputs[0].value.trim()
				window.document.getElementById("inputISBN").value = inputs[1].value.trim()

				window.document.getElementById("livro").value = `${title} - Tombo: ${inputs[0].value.trim()}`
				livro = cod

				title = null

				for(let i = 0; i < inputs.length; i++){
					spans[i].style.display = 'none'
					inputs[i].value = ""
				}

				fechaMoldalCad()
			}
		}

		function limpaInputTombo(i){
			let inputs = window.document.getElementsByClassName("inputTomboCad")
			let spans = window.document.getElementsByClassName("spanTombo")

			spans[i].style.display = 'none'
			inputs[i].style.border = 'none'
		}

		//Função para abrir moldal de adicionar

		function abreMoldalTombo(){
			window.document.getElementsByClassName("MoldaCad")[1].style.display = "flex"
		}

		//editora

		function selecionaEditora(codigo, texto){
			let ver = true

			for(i of editoras){
				if(i == codigo){
					ver = false
				}
			}

			if(ver){
				editoras.push(codigo)

				window.document.getElementById('editorasSelecionados').innerHTML += `<option ondblclick='removeEditoraLista(${codigo}, this)'>${texto}</option>`

				window.document.getElementsByClassName('MoldalOpcoes')[0].style.display = "none"
			}else{
				alert("Esta editora já foi adicionada na lista")
			}
		}
		
		function removeEditoraLista(codigo, obj){
			for(let i = 0; i < editoras.length; i++){
				if(editoras[i] == codigo){
					editoras.splice(i, 1)
					obj.remove()
				}
			}
		}

		window.addEventListener("load", inicia)