		//Vetores que armazeraram os dados selecionados nas listas

		var editora = null
		var livro = null
		var txtL = ''

		var estadoRed = 1; //1 - OK | 2 - Redireciona a página

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
					if(elementos[i].value.trim().length == 0 || (Number(elementos[i].value.trim()) < elementos[i].min || Number(elementos[i].value.trim()) > elementos[i].max)){
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

		function exportaExemplares(){
			let exp = window.document.getElementById('exemplaresEx')

			if(verifica()){
				if(exp.max == exp.value){
					if(confirm("Você realmente deseja exportar todos os exemplares deste livro?")){
						estadoRed = 2

						$.ajax({
							method: "POST",
							url: "exportaExemplaresLivro.php",
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
							alert("Não foi possivel exportar os exemplares, Ocorreu um erro no processo")
							window.document.getElementById('moldalLoading').style.display = "none"
						})
					}
				}else{
					estadoRed = 1

					$.ajax({
						method: "POST",
						url: "exportaExemplaresLivro.php",
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
						alert("Não foi possivel exportar os exemplares, Ocorreu um erro no processo")
						window.document.getElementById('moldalLoading').style.display = "none"
					})
				}
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
		}

		function atualizaExemplares(){
			let total = window.document.getElementById('exemplaresTotal')
			let exp = window.document.getElementById('exemplaresEx')

			total.innerText = Number(exp.max) - Number(exp.value)
		}

		function deletaMoldal(res){
			if(estadoRed == 1){
				window.document.getElementById("MoldalAviso").innerHTML = ""
				window.document.getElementById("MoldalAviso").style.display = "none"

				if(res == 1){
					let exp = window.document.getElementById('exemplaresEx')

					exp.max = Number(exp.max) - Number(exp.value)
					exp.value = ""
					window.document.getElementById('exemplaresTot').value = exp.max
				}else{
					location.replace("livros.php")
				}
			}else{
				location.replace("livros.php")
			}
		}

		window.addEventListener("load", inicia)