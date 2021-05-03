		let minimo = 0
		let minimoPesq = 0

		var imagens = 5
		var liTamanho
		var scrollTamanho

		let operacaoCarrosselLivro = null
		let operacaoCarrosseislLivro = null

		function frente(valor){
			$(`#Carrosseis #carrossel${valor}`).animate({scrollLeft: $(`#Carrosseis #carrossel${valor}`).scrollLeft() + scrollTamanho}, 300)
		}

		function back(valor){
			$(`#Carrosseis #carrossel${valor}`).animate({scrollLeft: $(`#Carrosseis #carrossel${valor}`).scrollLeft() - scrollTamanho - liTamanho}, 300)
		}

		function carregaLivros(Elemento){

			if(operacaoCarrosselLivro != null){ 
			    operacaoCarrosselLivro.abort();
			    operacaoCarrosselLivro = null;
			}

			operacaoCarrosselLivro = $.ajax({
				method: "POST",
				url: "carregaLivrosInicial.php",
				data: {min:minimo}
			})
			.done(function(res){
				if(res.length > 0){
					window.document.getElementById('Carrosseis').innerHTML += res

					Elemento.innerText = "Carregar Mais" 
					Elemento.classList.remove('loading')
					Elemento.classList.add('CarregarMais')
				}else{
					Elemento.style.display = "none"
				}
			})
			.fail(function(){
				if(operacaoCarrosselLivro == null){
					alert("Ocorreu um erro ao tentar carregar mais livros")
				}
				
				Elemento.innerText = "Carregar Mais" 
				Elemento.classList.remove('loading')
				Elemento.classList.add('CarregarMais')
			})
		}

		function carregaLivrosCarro(obj){
			obj.innerText = "" 
			obj.classList.add('loading')
			obj.classList.remove('CarregarMais')

			minimo += 5
			carregaLivros(obj)
		}

		//Função que carrega mais livros no carrossel

		function carregaMaisLivrosCarro(codigo, pos, obj){

			let ulCarrossel = window.document.getElementById(`carro${pos}`)
			let mini = ulCarrossel.childNodes.length - 1

			let dados = {
				cod: codigo,
				min: mini,
				posi: pos
			}

			if(operacaoCarrosseislLivro != null){ 
			    operacaoCarrosseislLivro.abort();
			    operacaoCarrosseislLivro = null;
			}

			operacaoCarrosseislLivro = $.ajax({
				method: "POST",
				url: "carregaLivrosCarro.php",
				data: dados,
				beforeSend: function(){
					obj.innerHTML = "" 
					obj.classList.add('CPlusLoading')
					obj.classList.remove('CPlus')
					obj.classList.remove('CarregarMais')
				}
			})
			.done(function(res){
				window.document.getElementById(`liEsp${pos}`).remove()

				if(res.length > 0){
					ulCarrossel.innerHTML += res
					ulCarrossel.style.gridTemplateColumns = `repeat(${ulCarrossel.childNodes.length}, 1fr)`
				}
			})
			.fail(function(){
				if(operacaoCarrosseislLivro == null){
					alert("Ocorreu um erro ao tentar carregar os dados do carrossel")
				}

				obj.innerHTML = "+"
				obj.classList.remove('CPlusLoading')
				obj.classList.add('CPlus')
				obj.classList.add('CarregarMais')
			})
		}

		window.addEventListener("load", function(){
			liTamanho = (parseInt($(`.carrosselLivros li`).outerWidth() + parseInt($(`.carrosselLivros li`).css('margin'))) + 50)
			scrollTamanho = liTamanho * 5

			defineTipoPesquisa()
			carregaLivros(window.document.getElementById('carregarMaisCarro'))
		})