		//Vetores que armazeraram os dados selecionados nas listas

		var imgInicial = null
		var pdfInicial = null
		var generos = []
		var autores = []

		function preview(){
			var imagem = window.document.getElementById('imagem').files[0]
			var preview = window.document.getElementById('imagemPreview')

			var reader = new FileReader()


			reader.onloadend = function(){
				preview.src = reader.result
			}

			if(imagem){
				reader.readAsDataURL(imagem)
			}else{
				preview.src = imgInicial
			}

			limpaCampos(0)
		}

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

		//Função que manda os dados para a tela cadastraLivro.php, e por lá o cadastro é finalizado

		function executaEdicao(){
			if(verifica()){
				window.document.getElementById("generos").value = generos.join()
				window.document.getElementById("autores").value = autores.join()

				$.ajax({
					method: "POST",
					url: "editaLivro.php",
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
					alert("Não foi possivel finalizar a edição, Ocorreu um erro na edição!")
					window.document.getElementById('moldalLoading').style.display = "none"
				})
			}
		}

		function abreMoldal(indice){
			window.document.getElementsByClassName('MoldalOpcoes')[indice].style.display = "flex"
		}

		function fechaMoldal(){
			let moldals = window.document.getElementsByClassName('MoldalOpcoes')

			for(i of moldals){
				i.style.display = "none"
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
		}

		function pegaURL(){
			let arquivo = window.document.getElementById('pdf_livro')
			let input = window.document.getElementById('pdf_url')

			if(arquivo.files[0]){
				input.value = arquivo.files[0].name
			}else{
				input.value = pdfInicial
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

			window.document.getElementById('pdf_livro').addEventListener("change", pegaURL)

			imgInicial = window.document.getElementById('imagemPreview').src
			pdfInicial = window.document.getElementById('pdf_url').value

			let a = window.document.getElementById("autoresSelecionados").childNodes
			let g = window.document.getElementById("generosSelecionados").childNodes

			for(i of a){
				autores.push(i.value)
			}

			for(i of g){
				generos.push(i.value)
			}
		}

		//Função para pegar dados das tabelas

		function selecionaGenero(codigo, texto){
			let ver = true

			for(i of generos){
				if(i == codigo){
					ver = false
				}
			}

			if(ver){
				generos.push(codigo)

				window.document.getElementById('generosSelecionados').innerHTML += `<option ondblclick='removeGeneroLista(${codigo}, this)'>${texto}</option>`

				window.document.getElementsByClassName('MoldalOpcoes')[0].style.display = "none"
			}else{
				alert("Este genêro já foi adicionado na lista")
			}
		}
		
		function removeGeneroLista(codigo, obj){
			for(let i = 0; i < generos.length; i++){
				if(generos[i] == codigo){
					generos.splice(i, 1)
					obj.remove()
				}
			}
		}

		//Autor

		function selecionaAutor(codigo, texto){
			let ver = true

			for(i of autores){
				if(i == codigo){
					ver = false
				}
			}

			if(ver){
				autores.push(codigo)

				window.document.getElementById('autoresSelecionados').innerHTML += `<option ondblclick='removeAutorLista(${codigo}, this)'>${texto}</option>`

				window.document.getElementsByClassName('MoldalOpcoes')[2].style.display = "none"
			}else{
				alert("Este autor já foi adicionado na lista")
			}
		}
		
		function removeAutorLista(codigo, obj){
			for(let i = 0; i < autores.length; i++){
				if(autores[i] == codigo){
					autores.splice(i, 1)
					obj.remove()
				}
			}
		}

		function deletaMoldal(){
			window.document.getElementById("MoldalAviso").innerHTML = ""
			window.document.getElementById("MoldalAviso").style.display = "none"
		}

		window.addEventListener("load", inicia)