		var txtL = ''
		let operacaoLivroAlocacao = null
	
		function carregaLivros(obj){
			let tbody = window.document.getElementById('livroT')
			let minimo = window.document.getElementsByClassName('livrosT').length
			let instituicao = window.document.getElementById('instituicoes')

			if(operacaoLivroAlocacao != null){ 
			    operacaoLivroAlocacao.abort();
			    operacaoLivroAlocacao = null;
			}

			operacaoLivroAlocacao = $.ajax({
				method: "POST",
				url: "carregaLivrosAlocacao.php",
				data: {min: minimo, txt: txtL.trim(), idInst: instituicao.value.trim()},
				beforeSend: function(){
					if(obj != null){
						obj.innerHTML = ""
						obj.classList.remove('btns')
						obj.classList.remove('carregarMaisT')
						obj.classList.add('loading')
					}
				}
			})
			.done(function(res){
				if(res.length == 0){
					if(obj != null){
						obj.style.display = "none"
						obj.innerHTML = "<i class='fas fa-plus' title='Carregar Mais'></i>"
						obj.classList.remove('loading')
						obj.classList.add('btns')
						obj.classList.add('carregarMaisT')
					}

					if(txtL.trim().length > 0){
						tbody.innerHTML =  `<tr><td colspan='3'><h5>Não foi possivel encontrar um livro com o titulo '${txtL.trim()}'</h5></td></tr>`
					}else if(minimo == 0){
						tbody.innerHTML =  `<tr><td colspan='3'><h5>Não há livros cadastrados no sistema</h5></td></tr>`
					}
				}else{
					tbody.innerHTML += res

					if(obj != null){
						obj.style.display = "block"
						obj.innerHTML = "<i class='fas fa-plus' title='Carregar Mais'></i>"
						obj.classList.remove('loading')
						obj.classList.add('btns')
						obj.classList.add('carregarMaisT')
					}
				}
			})
			.fail(function(){
				if(operacaoLivroAlocacao == null){
					alert("Ocorreu um erro ao tentar carregar os livros")
				}

				if(obj != null){
					obj.innerHTML = "<i class='fas fa-plus' title='Carregar Mais'></i>"
					obj.classList.remove('loading')
					obj.classList.add('btns')
					obj.classList.add('carregarMaisT')
				}
			})
		}

		function pesquisaLivro(obj){
			window.document.getElementById('livroT').innerHTML = ""
			txtL = obj.value.trim()

			if(window.document.getElementsByClassName('carregarMaisT')[0] != undefined){
				window.document.getElementsByClassName('carregarMaisT')[0].style.display = "block"
			}

			carregaLivros(window.document.getElementsByClassName('carregarMaisT')[0])
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

		function selecionaInstituicao(){
			window.document.getElementById('livroT').innerHTML = ""
			carregaLivros(window.document.getElementsByClassName('carregarMaisT')[0])
		}

		window.addEventListener("load", function(){
			carregaLivros(window.document.getElementsByClassName('carregarMaisT')[0])
		})