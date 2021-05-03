let estrelaValor = 0

function resizeTextarea(obj){
	obj.style.height = '5px'
	obj.style.height = (obj.scrollHeight - 30) + "px"
	window.scrollBy(0, window.document.body.scrollHeight)
}

function enviaAvaliacao(){
	var texto = window.document.getElementById("caixaTextoAva")

	if(estrelaValor > 0){
		window.document.getElementById('estrelas').value = estrelaValor

		$.ajax({
			method: "POST",
			url: "enviaAvaliacao.php",
			data: new FormData(window.document.getElementById('formAvaliacao')),
			processData: false, 
			contentType: false,
			beforeSend: function(){
				window.document.getElementById("moldalLoading").style.display = "flex"
			}
		})
		.done(function(msg){
			window.document.getElementById("MoldalAviso").innerHTML = msg
			window.document.getElementById("MoldalAviso").style.display = "flex"
			window.document.getElementById('moldalLoading').style.display = "none"

			texto.value = ""
			limpaEstrelasSel()
			resizeTextarea(texto)

			selecionaFiltroAva()
		})
		.fail(function(){
			alert("Não foi possivel enviar esta mensagem!, Ocorreu um erro no processo de envio!")
			window.document.getElementById('moldalLoading').style.display = "none"
		})
	}else{
		window.document.getElementById("avisoEstrela").style.display = "block"
	}
}

function limpaEstrelasSel(){
	estrelaValor = 0

	let estrelas = window.document.querySelectorAll("#avaliar .estrelas .fas")

	for(let i = 0; i < 5; i++){
		estrelas[i].style.color = "gray"
	}
}

function carregaAvaliacoes(obj){
	let campo = window.document.getElementById('avaliacoesDiv')
	let divs = window.document.getElementsByClassName('ava')
	let codigo = window.document.getElementById('codigoLivro').value.trim()
	let select = window.document.getElementById('selectFiltro')
	let minimo = divs.length

	$.ajax({
		method: "POST",
		url: "carregaAvaliacoes.php",
		data: {min: minimo, cod: codigo, filtro: select.value.trim()},
		beforeSend: function(){
			if(obj != null){
				obj.innerHTML = ""
				obj.classList.remove("carregarMais");
				obj.classList.add("loading");
			}
		}
	})
	.done(function(res){
		if(obj != null){
			obj.remove()
		}

		campo.innerHTML += res

		let textArea = window.document.getElementsByClassName('msgTextArea')
		let vermaisA = window.document.getElementsByClassName('vermaisA')

		for(let i = minimo; i < divs.length; i++){
			if(textArea[i].scrollHeight > 54){
				vermaisA[i].style.display = "inline"
			}
		}
	})
	.fail(function(){
		if(obj != null){
			obj.innerHTML = "<i class='fas fa-plus'></i>"
			obj.classList.add("carregarMais");
			obj.classList.remove("loading");
		}
	})
}

function deletaAvavliacao(id){
	if(confirm("Você realmanete deseja deletar esta avaliação?")){
		$.ajax({
			method: "POST",
			url: "deletaAvaliacao.php",
			data: {cod: id},
			beforeSend: function(){
				window.document.getElementById("moldalLoading").style.display = "flex"
			}
		})
		.done(function(msg){
			window.document.getElementById("MoldalAviso").innerHTML = msg
			window.document.getElementById("MoldalAviso").style.display = "flex"
			window.document.getElementById('moldalLoading').style.display = "none"

			selecionaFiltroAva()
		})
		.fail(function(){
			alert("Avaliação não deletada, Ocorreu um erro no processo de exclusão!")
			window.document.getElementById('moldalLoading').style.display = "none"
		})
	}
}

function adicionaLista(codigo){
	$.ajax({
		method: "POST",
		url: "adicionaLista.php",
		data: {cod: codigo},
		beforeSend: function(){
			window.document.getElementById("moldalLoading").style.display = "flex"
		}
	})
	.done(function(msg){
		window.document.getElementById("MoldalAviso").innerHTML = msg
		window.document.getElementById("MoldalAviso").style.display = "flex"
		window.document.getElementById('moldalLoading').style.display = "none"
	})
	.fail(function(){
		alert("Livro não adicionado!, Ocorreu um erro ao tentar adicionar este livro na sua lista!")
		window.document.getElementById('moldalLoading').style.display = "none"
	})
}

function selecionaFiltroAva(){
	window.document.getElementById('avaliacoesDiv').innerHTML = `<button id="loadingInicial"></button>`

	carregaAvaliacoes(window.document.getElementById('loadingInicial'))
}

function selecionaEstrela(valor){
	estrelaValor = valor

	let estrelas = window.document.querySelectorAll("#avaliar .estrelas .fas")

	for(let i = 0; i < valor; i++){
		estrelas[i].style.color = "#adb505"
	}

	for(let i = valor; i < 5; i++){
		estrelas[i].style.color = "gray"
	}

	window.document.getElementById("avisoEstrela").style.display = "none"
}

//Efeito hover na estrelas

function passaEstrela(valor){
	let estrelas = window.document.querySelectorAll("#avaliar .estrelas .fas")

	for(let i = 0; i < valor; i++){
		estrelas[i].style.color = "#adb505"
	}

	for(let i = valor; i < 5; i++){
		estrelas[i].style.color = "gray"
	}
}

function sairEstrela(){
	let estrelas = window.document.querySelectorAll("#avaliar .estrelas .fas")

	for(let i = 0; i < estrelaValor; i++){
		estrelas[i].style.color = "#adb505"
	}

	for(let i = estrelaValor; i < 5; i++){
		estrelas[i].style.color = "gray"
	}
}

//Ver mais nas avaliações

function verMais(indice){
	let textArea = window.document.getElementsByClassName('msgTextArea')[indice]
	let vermaisA = window.document.getElementsByClassName('vermaisA')[indice]

	if(vermaisA.innerText == "Ver Mais"){
		textArea.style.height = (textArea.scrollHeight) + "px"
		vermaisA.innerText = "Ver Menos"
	}else{
		textArea.style.height = "54px"
		vermaisA.innerText = "Ver Mais"
	}
}

function selecionaInstituicao(obj, codigo){
	$.ajax({
		method: "POST",
		url: "pegaExemplaresInstituicao.php",
		data: {codI: obj.value.trim(), codL: codigo}
	})
	.done(function(res){
		window.document.getElementById('exemplaresDis').innerHTML = `<span><i class='fas fa-book'></i></span> Exemplares Disnoníveis: ${res}`
	})
}

function fecharMoldal(){
	window.document.getElementsByClassName("moldal")[0].style.display = "none"
}

function deletaMoldal(){
	window.document.getElementById("MoldalAviso").innerHTML = ""
	window.document.getElementById("MoldalAviso").style.display = "none"
}

function inicia(){
	let estrelas = window.document.querySelectorAll("#avaliar .estrelas .fas")

	for(let i = 0; i < estrelas.length; i++){
		let estrela = estrelas[i]

		estrela.addEventListener("mouseenter", function(){
			passaEstrela(i + 1)
		})

		estrela.addEventListener("click", function(){
			selecionaEstrela(i + 1)
		})

		estrela.addEventListener("mouseleave", sairEstrela)
	}

	window.document.getElementById('verAvaliacao').addEventListener('click', function(){
		window.document.getElementsByClassName("moldal")[0].style.display = "flex"
	})

	carregaAvaliacoes(window.document.getElementById('loadingInicial'))
}

window.addEventListener("load", inicia)