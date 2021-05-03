function carregaMaisLivrosLis(codigo, obj){
	let container = window.document.getElementsByClassName('livrosG')[0]

	$.ajax({
		method: "POST",
		url: "carregaListaUsuarioInicio.php",
		data: {cod:codigo, min: container.childNodes.length - 1},
		beforeSend: function(){
			obj.innerHTML = ""
			obj.classList.remove('carregarMais')
			obj.classList.add('loading')
		}
	})
	.done(function(res){
		if(window.document.getElementById('loadingCont') != undefined){
			window.document.getElementById('loadingCont').remove()
		}

		container.innerHTML += res
	})
	.fail(function(){
		alert("Ocorreu um erro ao tentar carregar mais livros")

		obj.innerHTML = "<i class='fas fa-plus'></i>"
		obj.classList.add('carregarMais')
		obj.classList.remove('loading')
	})
}