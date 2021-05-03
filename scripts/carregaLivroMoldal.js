		var txtL = ''
		let controleLivroMoldal = null
	
		function carregaLivros(obj){
			let tbody = window.document.getElementById('livroT')
			let minimo = window.document.getElementsByClassName('livrosT').length

			if(controleLivroMoldal != null){ 
			    controleLivroMoldal.abort();
			    controleLivroMoldal = null;
			}

			controleLivroMoldal = $.ajax({
				method: "POST",
				url: "carregaLivrosMoldal.php",
				data: {min: minimo, txt: txtL.trim()},
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
						obj.innerHTML = "<i class='fas fa-plus' title='Carregar Mais'></i>"
						obj.classList.remove('loading')
						obj.classList.add('btns')
						obj.classList.add('carregarMaisT')
					}
				}
			})
			.fail(function(){
				if(controleLivroMoldal == null){
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

			if(window.document.getElementsByClassName('carregarMaisT')[1] != undefined){
				window.document.getElementsByClassName('carregarMaisT')[1].style.display = "block"
			}

			carregaLivros(window.document.getElementsByClassName('carregarMaisT')[1])
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

		window.addEventListener("load", function(){
			window.document.getElementsByClassName("btnAbreMoldalLivro")[0].addEventListener("click", function(){
				abreMoldal(1)
			})
			window.document.getElementsByClassName("btnAbreMoldal")[0].addEventListener("click", function(){
				abreMoldal(0)
			})

			carregaLivros(window.document.getElementsByClassName('carregarMaisT')[1])
		})