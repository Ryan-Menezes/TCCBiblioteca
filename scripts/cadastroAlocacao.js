		//Vetores que armazeraram os dados selecionados nas listas

		var livros = []

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

			livros = []
		}

		//Função que manda os dados para a tela cadastraLivro.php, e por lá o cadastro é finalizado

		function cadastraAlocacao(){
			if(verifica()){

				window.document.getElementById("livrosCodigos").value = livros.join()

				$.ajax({
					method: "POST",
					url: "cadastraAlocacao.php",
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
					alert("Não foi possivel alocar este(s) livro(s), Ocorreu um erro na operação de alocar!")
					window.document.getElementById('moldalLoading').style.display = "none"
				})
			}
		}

		function inicia(){
			let elementos = window.document.getElementsByClassName('inputV')
	
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

			$('#rmCpf').mask("000000000000000000000000000000")
		}

		function deletaMoldal(tipo){
			window.document.getElementById("MoldalAviso").innerHTML = ""
			window.document.getElementById("MoldalAviso").style.display = "none"

			if(tipo){
				limpaCamposCad()
			}
		}

		//Livro

		function selecionaLivro(codigo, titulo){
			if(livros.indexOf(codigo) == -1){
				livros.push(codigo)
				window.document.getElementById('livrosSelecionados').innerHTML += `<option ondblclick='removeLivro(${codigo}, this)'>${titulo}</option>`
				fechaMoldal()
				carregaLivros(window.document.getElementsByClassName('carregarMaisT')[0])
			}else{
				alert("Este livro já foi adicionado na lista, Não é possivel adicioná-lo novamente!")
			}
		}

		function removeLivro(codigo, obj){
			let index = livros.indexOf(codigo)

			if(index != -1){
				obj.remove()
				livros.splice(index, 1)
			}
		}

		function selecionaTipo(obj){
			let input = window.document.getElementById("rmCpf")

			if(obj.value == "F"){
				input.placeholder = "CPF"
				$('#rmCpf').mask("000.000.000-00")
			}else{
				input.placeholder = "RM"
				$('#rmCpf').mask("000000000000000000000000000000")
			}
		}

		window.addEventListener("load", inicia)