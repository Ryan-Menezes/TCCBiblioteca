let operacaoMeusLivros = null

function carregaAlocacoes(obj){
	let tbody = window.document.getElementById('tbodyAlocacoes')
	let tbodyLinhas = window.document.getElementsByClassName('tbodyA')
	let linhaL = window.document.getElementById('carregarMaisTable')
	let input = window.document.getElementById('pesqLivroMeu')


	if(operacaoMeusLivros != null){ 
	    operacaoMeusLivros.abort();
	    operacaoMeusLivros = null;
	}

	operacaoMeusLivros = $.ajax({
		method: "POST",
		url: "carregaMeusLivros.php",
		data: {min:tbodyLinhas.length, txt: input.value.trim()},
		beforeSend: function(){
			if(obj != null){
				obj.innerHTML = ""
				obj.classList.remove("btnCarr")
				obj.classList.add("loading")
			}	
		}
	})
	.done(function(res){
		if(linhaL != undefined){
			linhaL.innerHTML = ""
			linhaL.remove()
		}

		tbody.innerHTML += res
	})
	.fail(function(){
		if(operacaoMeusLivros == null){
			alert("Ocorreu um erro ao tentar carregar seus livros")
		}

		if(obj != null){
			obj.innerHTML = "<i class='fas fa-plus'></i>"
			obj.classList.add("btnCarr")
			obj.classList.remove("loading")
		}
	})
}

function pesquisaLivro(){
	window.document.getElementById('tbodyAlocacoes').innerHTML = `<tr id='carregarMaisTable'>
																	<td colspan='6'><button class='loading'></button></td>
																  </tr>`
	carregaAlocacoes(null)
}

window.addEventListener("load", function(){
	carregaAlocacoes(null)
})