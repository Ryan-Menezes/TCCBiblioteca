		//Vetores que armazeraram os dados selecionados nas listas

		var instituicoes = []
		var situacoes = []

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
				preview.src = "./Imagens/anonimo.png"
			}
		}

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

			window.document.getElementById('imagemPreview').src = "./Imagens/anonimo.png"

			instituicoes = []
			situacoes = []
		}

		function executaCadastro(){
			if(verifica()){
				window.document.getElementById('intituicoesSelecionadosT').value = instituicoes.join()
				window.document.getElementById('situacoesInsti').value = situacoes.join()

				$.ajax({
					method: "POST",
					url: "cadastraProfessor.php",
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
					alert("Não foi possivel finalizar o cadastro, Ocorreu um erro no cadastro!")
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

			window.document.getElementById('imagem').addEventListener('change', preview)

			for(let i = 0; i < moldals.length; i++){
				moldals[i].addEventListener("click", function(){
					abreMoldal(i)
				})
			}

			//Colocando maskara nos inputs

			$('#cpf').mask('000.000.000-00')
			$('#telefone').mask('(00)0000-0000')
			$('#celular').mask('(00)00000-0000')
			$('#cep').mask('000-00000')

			//CEP evento

			window.document.getElementById("cep").addEventListener("change", buscaEndereco)

			//Buscando cidades

			buscaCidades(null)
		}

		function selecionaInstituicao(codigo, texto){
			if(instituicoes.indexOf(codigo) == -1){
				let sit = window.document.getElementById('situacaoSelect').value

				instituicoes.push(codigo)
				situacoes.push(sit)

				window.document.getElementById('intituicoesSelecionados').innerHTML += `<option ondblclick='removeInstituicaoLista(${codigo}, this)'>${texto} - ${(sit == 'D') ? 'Determinado' : 'Inderteminado'}</option>`

				window.document.getElementsByClassName('MoldalOpcoes')[0].style.display = "none"
			}else{
				alert("Esta instituição já foi adicionada na lista, Não é possível adicioná-la novamente!")
			}
		}
		
		function removeInstituicaoLista(codigo, obj){
			for(let i = 0; i < instituicoes.length; i++){
				if(instituicoes[i] == codigo){
					instituicoes.splice(i, 1)
					situacoes.splice(i, 1)
					obj.remove()
				}
			}
		}

		function deletaMoldal(tipo){
			window.document.getElementById("MoldalAviso").innerHTML = ""
			window.document.getElementById("MoldalAviso").style.display = "none"

			if(tipo){
				limpaCamposCad()
			}
		}

		//Funções para busca de cidade e estado, e também o endereço completo

		function buscaEndereco(){
			var cep = window.document.getElementById("cep").value.trim().replace("-", "")
			var url = `https://viacep.com.br/ws/${cep}/json/`

			$.ajax({
				url: url,
				type: "GET",
				dataType: "json"
			})
			.done(function(res){
				if(res.logradouro != undefined){
					if(res.uf == "SP"){
						window.document.getElementById("logradouro").value = res.logradouro
						window.document.getElementById("bairro").value = res.bairro
						window.document.getElementById("complemento").value = res.complemento

						buscaCidades(res.localidade)
					}
				}
			})
		}

		function buscaCidades(c){
			var cidade = (c == null) ? "Diadema" : c
			var html = null

			$.getJSON("./scripts/estados-cidades.json", function(data){
				for(var i = 0; i < data.estados.length; i++){
					if(data.estados[i].sigla == "SP"){
						for(var j = 0; j < data.estados[i].cidades.length; j++){
							if(data.estados[i].cidades[j] == cidade)
								html += '<option selected>' + data.estados[i].cidades[j] + '</option>';
							else
								html += '<option>' + data.estados[i].cidades[j] + '</option>';
						}
					}
				}

				window.document.getElementById("cidade").innerHTML = html
			})
		}

		window.addEventListener("load", inicia)