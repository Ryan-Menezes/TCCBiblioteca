let operacaoListaInicio = null

function carregaListaInicio(obj){
	let container = window.document.querySelector("#containerListas .listasUsuarios")
	let itens = window.document.getElementsByClassName('listU')
	let input = window.document.querySelector("#containerListas .divInputPesq input[type=text]")

	if(operacaoListaInicio != null){ 
	    operacaoListaInicio.abort();
	    operacaoListaInicio = null;
	}

	operacaoListaInicio = $.ajax({
		method: "POST",
		url: "carregaListaInicio.php",
		data: {min: itens.length, filtro: input.value.trim()},
		beforeSend: function(){
			if(obj != null){
				obj.innerHTML = ""
				obj.classList.remove("CarregarMais")
				obj.classList.add("loading")
			}
		}
	})
	.done(function(res){
		if(obj != null){
			obj.parentNode.remove()
		}

		container.innerHTML += res
	})
	.fail(function(){
		if(operacaoListaInicio == null){
			alert("Ocorreu um erro ao tentar carregar as listas!")
		}

		if(obj != null){
			obj.innerHTML = "<i class='fas fa-plus'></i>"
			obj.classList.remove("loading")
			obj.classList.add("CarregarMais")
		}
	})
}

function pesquisaListaInicio(){
	window.document.querySelector("#containerListas .listasUsuarios").innerHTML = `<div style='width: 200px; display: flex; align-items: center; justify-content: center;'><div class="loading"></div></div>`

	carregaListaInicio(window.document.querySelector("#containerListas .listasUsuarios .loading"))
}

window.addEventListener("load", function(){
	carregaListaInicio(window.document.querySelector("#containerListas .listasUsuarios .loading"))
})