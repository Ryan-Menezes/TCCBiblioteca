let minimoE = 0
let textoE = ''
let ElementoE = null
let operacaoEditora = null

function carregaEditora(tipo){

	if(operacaoEditora != null){ 
	    operacaoEditora.abort();
	    operacaoEditora = null;
	}

	operacaoEditora = $.ajax({
		method: "POST",
		url: "carregaEditora.php",
		data: {min:minimoE, txt:textoE}
	})
	.done(function(res){
		if(tipo == 1){
			if(res.length > 0){
				window.document.getElementById('editoraT').innerHTML += res

				if(ElementoE != null){
					ElementoE.innerHTML = `<i class='fas fa-plus' title="Carregar Mais"></i>`
					ElementoE.classList.remove('loading')
					ElementoE.classList.add('btns')
					ElementoE.classList.add('carregarMaisT')
				}
			}else{
				if(minimoE == 0){
					window.document.getElementById('editoraT').innerHTML = "<tr><td colspan='3'><h5>Não há editoras cadastradas no sistema</h5></td></tr>"
				}

				if(ElementoE != null){
					ElementoE.style.display = "none"
				}
			}
		}else{
			if(res.length > 0){
				window.document.getElementById('editoraT').innerHTML = res
			}else{
				window.document.getElementById('editoraT').innerHTML = `<tr><td colspan='3'><h5>Não foi possivel encontrar uma editora com o nome '${textoE}'</h5></td></tr>`
			}
		}
	})
	.fail(function(){
		if(operacaoEditora == null){
			alert("Ocorreu um erro ao carregar mais editoras")
		}

		if(ElementoE != null){
			ElementoE.innerHTML = `<i class='fas fa-plus' title="Carregar Mais"></i>`
			ElementoE.classList.remove('loading')
			ElementoE.classList.add('btns')
			ElementoE.classList.add('carregarMaisT')
		}
	})
}

function carregaMaisEditoras(obj){
	ElementoE = obj

	ElementoE.innerHTML = ""
	ElementoE.classList.remove('btns')
	ElementoE.classList.remove('carregarMaisT')
	ElementoE.classList.add('loading')

	minimoE += 10
	carregaEditora(1);
}

function deletaEditora(codigo){
	if(confirm("Você realmente deseja deletar esta editora?")){
		$.ajax({
			method: "POST",
			url: "deletaEditora.php",
			data: {cod:codigo},
			beforeSend: function(){
				window.document.getElementById("moldalLoading").style.display = "flex"
			}
		})
		.done(function(msg){
			window.document.getElementById("MoldalAviso").innerHTML = msg
			window.document.getElementById("MoldalAviso").style.display = "flex"
			window.document.getElementById('moldalLoading').style.display = "none"

			window.document.getElementById('editoraT').innerHTML = ""
			minimoE = 0
			carregaEditora(1)

			//Removendo elemento da lista

			let obj = window.document.getElementById('editorasSelecionados').childNodes

			for(let i = 0; i < editoras.length; i++){
				if(editoras[i] == codigo){
					editoras.splice(i, 1)
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

function pesquisaEditora(obj){

	minimoE = 0
	textoE = obj.value

	if(ElementoE != null){
		ElementoE.innerHTML = `<i class='fas fa-plus' title="Carregar Mais"></i>`
		ElementoE.classList.remove('loading')
		ElementoE.classList.add('btns')
		ElementoE.classList.add('carregarMaisT')
		ElementoE.style.display = "block"
	}
	
	carregaEditora(2)
}

window.addEventListener("load", function(){
	carregaEditora(1)
})

/*Script de cadastro*/

let inforE = null

function abreMoldalEditora(operacao, info){//Operacao 1 - cadastro | 2 - edicao
	inforE = JSON.parse(JSON.stringify(info))

	window.document.getElementsByClassName('MoldaCad')[0].style.display = 'flex'

	if(operacao == 1){
		window.document.getElementsByClassName('btnCadSub')[0].value = "Cadastrar Editora"
		window.document.getElementsByClassName('tituloCad')[0].innerText = "Cadastro da Editora"

		window.document.getElementsByClassName('btnCadSub')[0].removeEventListener("click", chamaEventoEdicao)
		window.document.getElementsByClassName('btnCadSub')[0].addEventListener("click", cadastrarEditora)
	}else{
		window.document.getElementsByClassName('btnCadSub')[0].value = "Salvar Edições"
		window.document.getElementsByClassName('tituloCad')[0].innerText = "Edição da Editora"

		let inputsE = window.document.getElementsByClassName('inputsE')

		for(let i = 0; i < inputsE.length; i++){
			inputsE[i].value = inforE[i]
		}

		window.document.getElementsByClassName('btnCadSub')[0].removeEventListener("click", cadastrarEditora)
		window.document.getElementsByClassName('btnCadSub')[0].addEventListener("click", chamaEventoEdicao)
	}
}

function cadastrarEditora(){
	let inputsE = window.document.getElementsByClassName('inputsE')
	let span = window.document.getElementsByClassName('spanCadE')

	let verifica = true

	for(let i = 0; i < inputsE.length - 1; i++){
		if(inputsE[i].value.trim().length == 0){
			verifica = false;
			span[i].style.display = 'inline'
			inputsE[i].style.border = '1px solid #5c0101'
		}
	}

	if(verifica){
		let dados = {
			nome: inputsE[0].value.trim().replace(/[',",),(,-,.]/ig, ''),
			cnpj: inputsE[1].value.trim().replace(/[',",),(,-,.]/ig, '')
		}

		$.ajax({
			method: "POST",
			url: "cadastraEditora.php",
			data: dados,
			beforeSend: function(){
				window.document.getElementById("moldalLoading").style.display = "flex"
			}
		})
		.done(function(msg){
			window.document.getElementById("MoldalAviso").innerHTML = msg
			window.document.getElementById("MoldalAviso").style.display = "flex"
			window.document.getElementById('moldalLoading').style.display = "none"

			for(let i = 0; i < inputsE.length; i++){
				inputsE.value = ""
			}

			minimoE = 0
			carregaEditora(2)

			//Limpando campos

			for(let i = 0; i < inputsE.length; i++){
				inputsE[i].value = ""
			}
		})
		.fail(function(){
			alert("Não foi possivel cadastrar esta editora, Ocorreu um erro na operação de cadastro!")
			window.document.getElementById("moldalLoading").style.display = "none"
		})
	}
}

function chamaEventoEdicao(){
	if(inforE != null){
		editarEditora(inforE[2])
	}
}

function editarEditora(codigo){
	let inputsE = window.document.getElementsByClassName('inputsE')
	let span = window.document.getElementsByClassName('spanCadE')

	let verifica = true

	for(let i = 0; i < inputsE.length - 1; i++){
		if(inputsE[i].value.trim().length == 0){
			verifica = false;
			span[i].style.display = 'inline'
			inputsE[i].style.border = '1px solid #5c0101'
		}
	}

	if(verifica){
		let dados = {
			cod: codigo,
			nome: inputsE[0].value.trim(),
			cnpj: inputsE[1].value.trim()
		}

		$.ajax({
			method: "POST",
			url: "editarEditora.php",
			data: dados,
			beforeSend: function(){
				window.document.getElementById("moldalLoading").style.display = "flex"
			}
		})
		.done(function(msg){
			window.document.getElementById("MoldalAviso").innerHTML = msg
			window.document.getElementById("MoldalAviso").style.display = "flex"
			window.document.getElementById('moldalLoading').style.display = "none"

			minimoE = 0
			carregaEditora(2)

			//Removendo elemento da lista

			let obj = window.document.getElementById('editorasSelecionados').childNodes

			for(let i = 0; i < editoras.length; i++){
				if(editoras[i] == codigo){
					obj[i].innerText = inputsE[0].value
				}
			}
		})
		.fail(function(){
			alert("Não foi possivel editar esta editora, Ocorreu um erro na operação de edição!")
			window.document.getElementById("moldalLoading").style.display = "none"
		})
	}
}

function limpaCamposE(indice){
	let inputsE = window.document.getElementsByClassName('inputsE')[indice].style.border = "none"
	let spanE = window.document.getElementsByClassName('spanCadE')[indice].style.display = "none"
}

window.addEventListener("load", function(){
	$('#cnpjEditora').mask("00.000.000/0000-00")
})