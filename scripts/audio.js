//Funções para captura de voz

let audio = null
let operacaoBuscaLivro = null
let audioEncerra = true

function iniciaGravamento(){
	if(window.SpeechRecognition || window.webkitSpeechRecognition || window.msSpeechRecognition || window.mozSpeechRecognition){

		window.document.getElementById('MoldalVoz').style.display = "flex"

		var tipoAudio = window.SpeechRecognition || window.webkitSpeechRecognition || window.msSpeechRecognition || window.mozSpeechRecognition

		audio = new tipoAudio()

		audio.continuous = true;
		audio.lang = "pt-br"

		try{
			audioEncerra = true
			audio.start()			
		}catch{
			alert("Ocorreu um erro ao iniciar a gravação")
		}
				

		audio.addEventListener("result", function(e){
			window.document.getElementById('MoldalVoz').style.display = "none"

			window.document.querySelectorAll("#barraPesquisa .barra")[0].value = e.results[0][0].transcript
			window.document.querySelectorAll("#MoldalLivros .livrosM input[type=text]")[0].value = e.results[0][0].transcript

			pesquisarLivroI()

			audio.abort()
		})

		audio.addEventListener("error", function(){
			window.document.getElementById('MoldalVoz').style.display = "none"
					
			if(audioEncerra){
				alert("Se você disse algo, eu não ouvi muito bem!")
			}
		})
	}else{
		alert("Seu navegador não suporta pesquisa por voz")
	}
}

function fechaGravamento(){
	window.document.getElementById('MoldalVoz').style.display = "none"

	if(audio != null){
		audioEncerra = false
		audio.abort()
	}
}

//Funções de pesquisa no bando de dados

var tipoPesquisa //T - Todos, F - Fisico, P - PDF

//Funções que carregam livros na moldal de pesquisa

function pesquisarLivroInicial(obj, ele){
	let dados = {
		texto: obj.value,
		tipo: tipoPesquisa,
		min: minimoPesq
	}

	if(operacaoBuscaLivro != null){ 
	    operacaoBuscaLivro.abort();
	    operacaoBuscaLivro = null;
	}

	operacaoBuscaLivro = $.ajax({
		method: "POST",
		url: "buscaLivroInicial.php",
		data: dados,
		beforeSend: function(){
			if(ele == null){
				window.document.getElementById('dadosPesquisados').innerHTML = "<div class='loading'></div>"
			}else{
				ele.innerHTML = ""
				ele.classList.add('loading')
				ele.classList.remove('CPlus')
				ele.classList.remove('CarregarMais')
			}
		}
	})
	.done(function(res){
		if(ele == null){
			window.document.getElementById('dadosPesquisados').innerHTML = res
		}else{
			ele.remove()
			window.document.getElementById('dadosPesquisados').innerHTML += res
		}
	})
	.fail(function(){
		if(operacaoBuscaLivro == null){
			window.document.getElementById('dadosPesquisados').innerHTML = "<h3>Ocorreu um erro na pesquisa</h3>"
		}
	})
}

function pesquisarLivroI(){
	window.document.getElementById('MoldalLivros').style.display = 'block'

	minimoPesq = 0

	if(window.document.getElementById('barra').value.trim().length > 0){
		pesquisarLivroInicial(window.document.getElementById('barra'), null)
	}else{
		pesquisarLivroInicial(window.document.querySelectorAll("#MoldalLivros .livrosM input[type=text]")[0], null)
	}
}

function fechaMoldalLivroPesquisa(){
	window.document.getElementById('MoldalLivros').style.display = 'none'
}

function carregaMaisLivrosI(obj){
	minimoPesq += 10

	if(window.document.getElementById('barra').value.trim().length > 0){
		pesquisarLivroInicial(window.document.getElementById('barra'), obj)
	}else{
		pesquisarLivroInicial(window.document.querySelectorAll("#MoldalLivros .livrosM input[type=text]")[0], obj)
	}
}

function defineTipoPesquisa(){
	tipoPesquisa = window.document.getElementById('tipoPesquisaLivro').value
	minimoPesq = 0

	if(window.document.getElementById('barra').value.trim().length > 0){
		pesquisarLivroInicial(window.document.getElementById('barra'), null)
	}else{
		pesquisarLivroInicial(window.document.querySelectorAll("#MoldalLivros .livrosM input[type=text]")[0], null)
	}
}

function copiaTexto(obj){
	let pesqMenu = window.document.querySelectorAll("#barraPesquisa .barra")[0]
	let pesqMoldal = window.document.querySelectorAll("#MoldalLivros .livrosM input[type=text]")[0]

	if(obj == pesqMenu){
		pesqMoldal.value = pesqMenu.value.trim()
	}else{
		pesqMenu.value = pesqMoldal.value.trim()
	}
}

//Função de inicialização

function inicia(){
	tipoPesquisa = window.document.getElementById('tipoPesquisaLivro').value
	window.document.querySelectorAll('#MoldalVoz .containerMicro div')[0].addEventListener("click", fechaGravamento)
	window.document.getElementById('microfonePesq').addEventListener("click", iniciaGravamento)

	window.document.querySelectorAll("#barraPesquisa .barra")[0].addEventListener("change", pesquisarLivroI)
	window.document.querySelectorAll("#MoldalLivros .livrosM input[type=text]")[0].addEventListener("change", pesquisarLivroI)
}

window.addEventListener("load", inicia)