let minimoA = 0
let textoA = ''
let ElementoA = null
let operacaoAutor = null

function carregaAutor(tipo){

	if(operacaoAutor != null){ 
	    operacaoAutor.abort();
	    operacaoAutor = null;
	}

	operacaoAutor = $.ajax({
		method: "POST",
		url: "carregaAutor.php",
		data: {min:minimoA, txt:textoA}
	})
	.done(function(res){
		if(tipo == 1){
			if(res.length > 0){
				window.document.getElementById('autorT').innerHTML += res

				if(ElementoA != null){
					ElementoA.innerHTML = `<i class='fas fa-plus' title="Carregar Mais"></i>`
					ElementoA.classList.remove('loading')
					ElementoA.classList.add('btns')
					ElementoA.classList.add('carregarMaisT')
				}
			}else{
				if(minimoA == 0){
					window.document.getElementById('autorT').innerHTML = "<tr><td colspan='4'><h5>Não há autores cadastradas no sistema</h5></td></tr>"
				}

				if(ElementoA != null){
					ElementoA.style.display = "none"
				}
			}
		}else{
			if(res.length > 0){
				window.document.getElementById('autorT').innerHTML = res
			}else{
				window.document.getElementById('autorT').innerHTML = `<tr><td colspan='4'><h5>Não foi possivel encontrar um autor com o nome '${textoA}'</h5></td></tr>`
			}
		}
	})
	.fail(function(){
		if(operacaoAutor == null){
			alert("Ocorreu um erro ao carregar mais autores")
		}

		if(ElementoA != null){
			ElementoA.innerHTML = `<i class='fas fa-plus' title="Carregar Mais"></i>`
			ElementoA.classList.remove('loading')
			ElementoA.classList.add('btns')
			ElementoA.classList.add('carregarMaisT')
		}
	})
}

function carregaMaisAutor(obj){
	ElementoA = obj

	ElementoA.innerHTML = ""
	ElementoA.classList.remove('btns')
	ElementoA.classList.remove('carregarMaisT')
	ElementoA.classList.add('loading')

	minimoA += 10
	carregaAutor(1);
}

function deletaAutor(codigo, codigoA){
	if(confirm("Você realmente deseja deletar este autor?")){
		$.ajax({
			method: "POST",
			url: "deletaAutor.php",
			data: {cod:codigo},
			beforeSend: function(){
				window.document.getElementById('moldalLoading').style.display = 'flex'
			}
		})
		.done(function(msg){
			window.document.getElementById("MoldalAviso").innerHTML = msg
			window.document.getElementById("MoldalAviso").style.display = "flex"
			window.document.getElementById('moldalLoading').style.display = "none"

			window.document.getElementById('editoraT').innerHTML = ""
			minimoA = 0
			carregaAutor(2)

			//Removendo elemento da lista

			let obj = window.document.getElementById('autoresSelecionados').childNodes

			for(let i = 0; i < autores.length; i++){
				if(autores[i] == codigoA){
					autores.splice(i, 1)
					obj[i].remove()
				}
			}
		})
		.fail(function(){
			alert("Ocorreu um erro ao deletar a editora")
			window.document.getElementById('moldalLoading').style = 'none'
		})
	}
}

function pesquisaAutor(obj){

	minimoA = 0
	textoA = obj.value

	if(ElementoA != null){
		ElementoA.innerHTML = `<i class='fas fa-plus' title="Carregar Mais"></i>`
		ElementoA.classList.remove('loading')
		ElementoA.classList.add('btns')
		ElementoA.classList.add('carregarMaisT')
		ElementoA.style.display = "block"
	}
	
	carregaAutor(2)
}

window.addEventListener("load", function(){
	carregaAutor(1)
})

/*Script de cadastro*/

let inforA = null

function abreMoldalAutor(operacao, info){//Operacao 1 - cadastro | 2 - edicao
	inforA = JSON.parse(JSON.stringify(info))

	window.document.getElementsByClassName('MoldaCad')[1].style.display = 'flex'

	if(operacao == 1){
		window.document.getElementsByClassName('btnCadSub')[1].value = "Cadastrar Autor"
		window.document.getElementsByClassName('tituloCad')[1].innerText = "Cadastro do Autor"

		window.document.getElementsByClassName('btnCadSub')[1].removeEventListener("click", chamaEventoEdicaoAutor)
		window.document.getElementsByClassName('btnCadSub')[1].addEventListener("click", cadastrarAutor)
	}else{
		window.document.getElementsByClassName('btnCadSub')[1].value = "Salvar Edições"
		window.document.getElementsByClassName('tituloCad')[1].innerText = "Edição do Autor"

		let inputsA = window.document.getElementsByClassName('inputsA')

		for(let i = 0; i < inputsA.length; i++){
			inputsA[i].value = inforA[i]
		}

		window.document.getElementsByClassName('btnCadSub')[1].removeEventListener("click", cadastrarAutor)
		window.document.getElementsByClassName('btnCadSub')[1].addEventListener("click", chamaEventoEdicaoAutor)
	}
}

function cadastrarAutor(){
	let inputsA = window.document.getElementsByClassName('inputsA')
	let span = window.document.getElementsByClassName('spanCadA')

	let verifica = true

	for(let i = 0; i < inputsA.length - 1; i++){
		if(inputsA[i].value.trim().length == 0){
			verifica = false;
			span[i].style.display = 'inline'
			inputsA[i].style.border = '1px solid #5c0101'
		}
	}

	if(verifica){
		let dados = {
			nome: inputsA[0].value.trim().replace(/[',"]/ig, ''),
			nacio: inputsA[1].value.trim().replace(/[',"]/ig, ''),
			cola: inputsA[2].value.trim().replace(/[',"]/ig, '')
		}

		$.ajax({
			method: "POST",
			url: "cadastraAutor.php",
			data: dados,
			beforeSend: function(){
				window.document.getElementById("moldalLoading").style.display = "flex"
			}
		})
		.done(function(msg){
			window.document.getElementById("MoldalAviso").innerHTML = msg
			window.document.getElementById("MoldalAviso").style.display = "flex"
			window.document.getElementById('moldalLoading').style.display = "none"

			for(let i = 0; i < inputsA.length; i++){
				inputsA[i].value = ""
			}

			minimoA = 0
			carregaAutor(2)
		})
		.fail(function(){
			alert("Não foi possivel cadastrar este autor, Ocorreu um erro na operação de cadastro!")
			window.document.getElementById("moldalLoading").style.display = "none"
		})
	}
}

function chamaEventoEdicaoAutor(){
	if(inforA != null){
		editarAutor(inforA[3], inforA[4])
	}
}

function editarAutor(codigoA, codigoC){
	let inputsA = window.document.getElementsByClassName('inputsA')
	let span = window.document.getElementsByClassName('spanCadA')

	let verifica = true

	for(let i = 0; i < inputsA.length - 1; i++){
		if(inputsA[i].value.trim().length == 0){
			verifica = false;
			span[i].style.display = 'inline'
			inputsA[i].style.border = '1px solid #5c0101'
		}
	}

	if(verifica){
		let dados = {
			cod: codigoA,
			codC: codigoC,
			nome: inputsA[0].value.trim(),
			nacio: inputsA[1].value.trim(),
			cola: inputsA[2].value.trim()
		}

		$.ajax({
			method: "POST",
			url: "editarAutor.php",
			data: dados,
			beforeSend: function(){
				window.document.getElementById("moldalLoading").style.display = "flex"
			}
		})
		.done(function(msg){
			window.document.getElementById("MoldalAviso").innerHTML = msg
			window.document.getElementById("MoldalAviso").style.display = "flex"
			window.document.getElementById('moldalLoading').style.display = "none"

			minimoA = 0
			carregaAutor(2)

			//Atualizando elemento da lista

			let obj = window.document.getElementById('autoresSelecionados').childNodes

			for(let i = 0; i < autores.length; i++){
				if(autores[i] == codigoA){
					obj[i].innerText = inputsA[0].value
				}
			}
		})
		.fail(function(){
			alert("Não foi possivel editar este autor, Ocorreu um erro na operação de edição!")
			window.document.getElementById("moldalLoading").style.display = "none"
		})
	}
}

function limpaCamposA(indice){
	let inputsA = window.document.getElementsByClassName('inputsA')[indice].style.border = "none"
	let spanA = window.document.getElementsByClassName('spanCadA')[indice].style.display = "none"
}