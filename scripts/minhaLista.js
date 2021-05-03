let operacaoMaisLivros = null

function carregaMaisLivrosLista(obj){
	let container = window.document.getElementsByClassName('livrosG')[0]

	let livrosLista = window.document.getElementsByClassName('livrosLista')

	if(operacaoMaisLivros != null){ 
	    operacaoMaisLivros.abort();
	    operacaoMaisLivros = null;
	}

	operacaoMaisLivros = $.ajax({
		method: "POST",
		url: "carregaListaUsuario.php",
		data: {min: livrosLista.length},
		beforeSend: function(){
			if(obj != null){
				obj.innerHTML = ""
				obj.classList.remove('carregarMais')
				obj.classList.add('loading')
			}
		}
	})
	.done(function(res){
		if(window.document.getElementById('loadingCont') != undefined){
			window.document.getElementById('loadingCont').remove()
		}

		container.innerHTML += res
	})
	.fail(function(){
		if(operacaoMaisLivros == null){
			alert("Ocorreu um erro ao tentar carregar mais livros")
		}
		
		if(obj != null){
			obj.innerHTML = "<i class='fas fa-plus'></i>"
			obj.classList.add('carregarMais')
			obj.classList.remove('loading')
		}
	})
}

function removeLivroLista(codigo){
	if(confirm("Você realmente deseja remover este livro de sua lista?")){
		$.ajax({
			method: "POST",
			url: "removeLivroLista.php",
			data: {cod: codigo},
			beforeSend: function(){
				window.document.getElementById("moldalLoading").style.display = "flex"
			}
		})
		.done(function(msg){
			window.document.getElementById("MoldalAviso").innerHTML = msg
			window.document.getElementById("MoldalAviso").style.display = "flex"
			window.document.getElementById('moldalLoading').style.display = "none"

			window.document.getElementsByClassName('livrosG')[0].innerHTML = `<div id='loadingCont'>
																				<div class="loading"></div>
																			  </div>`
			carregaMaisLivrosLista(null)
		})
		.fail(function(){
			alert("Ocorreu um erro ao tentar remover este livro de sua lista")
		})
	}
}

function deletaMoldal(){
	window.document.getElementById("MoldalAviso").innerHTML = ""
	window.document.getElementById("MoldalAviso").style.display = "none"
}

window.addEventListener("load", function(){
	carregaMaisLivrosLista(null)
})