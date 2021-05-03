let codigoLivro = null
let codigoExemplares = null
let linhas = []
let colunas = []

let operacaoLivroTela = null
let operacaoRelatorio = null

function carregaLivro(btn){
	let tbody = window.document.getElementById('dadosCarregados')
	let dados = window.document.getElementsByClassName('dadoInfo')
	let obj = window.document.querySelector('#carregarMaisTable')

	minimoA = (dados != undefined) ? dados.length : 0

	let info = {
		min: minimoA,
		txt: window.document.getElementById('pesquisaInput').value.trim(),
		tipo: window.document.getElementById('pesqOP').value.trim(),
		genero: window.document.getElementById('generosOP').value.trim(),
		instituicao: window.document.getElementById('instituicaoOP').value.trim(),
		livros: linhas.join()
	}

	if(operacaoLivroTela != null){ 
	    operacaoLivroTela.abort();
	    operacaoLivroTela = null;
	}

	operacaoLivroTela = $.ajax({
		method: "POST",
		url: "carregaLivros.php",
		data: info,
		beforeSend: function(){
			if(btn != null){
				btn.innerHTML = ""
				btn.classList.remove("btnCarr")
				btn.classList.add("loading")
			}
		}
	})
	.done(function(res){
		if(obj != undefined){
			obj.innerHTML = ""
			obj.remove()
		}

		tbody.innerHTML += res
	})
	.fail(function(){
		if(operacaoLivroTela == null){
			alert("Ocorreu um erro ao tentar carregar mais livros")
		}

		if(btn != null){
			btn.innerHTML = "<i class='fas fa-plus'></i>"
			btn.classList.remove("loading")
			btn.classList.add("btnCarr")
		}
		
	})
}

//Filtro

function abreMoldalFiltro(){
	window.document.getElementsByClassName('MoldalOp')[0].style.display = "flex"
}

function defineFiltro(){
	window.document.getElementById('pesquisaInput').value = ""
	window.document.getElementById('dadosCarregados').innerHTML = "<tr id='carregarMaisTable'><td colspan='12'><button class='loading'></button></td></tr>"
	carregaLivro(null)
	window.document.getElementsByClassName('MoldalOp')[0].style.display = "none"
}

//Pesquisa

function pesquisaLivro(){
	window.document.getElementById('dadosCarregados').innerHTML = "<tr id='carregarMaisTable'><td colspan='12'><button class='loading'></button></td></tr>"
	carregaLivro(null)
}

//Função de exclusão

function excluirLivro(){
	let input = window.document.getElementById('inputSenha')

	if(input.value.trim().length > 0){
		if(codigoLivro != null && codigoExemplares != null){
			$.ajax({
				method: "POST",
				url: "deletaLivro.php",
				data: {codL: codigoLivro, codE: codigoExemplares, senha: input.value.trim()},
				beforeSend: function(){
					window.document.getElementById('moldalLoading').style.display = "flex"	
				}
			})
			.done(function(res){
				window.document.getElementById("MoldalAviso").innerHTML = res
				window.document.getElementById("MoldalAviso").style.display = "flex"
				window.document.getElementById('moldalLoading').style.display = "none"

				window.document.getElementById('moldalLoading').style.display = "none"

				window.document.getElementsByClassName('MoldalOp')[1].style.display = "none"
				limpaCampoSenha()
				codigoUser = null
				window.document.getElementById('inputSenha').value = ""

				window.document.getElementById('dadosCarregados').innerHTML = "<tr id='carregarMaisTable'><td colspan='12'><button class='loading'></button></td></tr>"

				carregaLivro(null)
			})
			.fail(function(){
				alert("Livro não deletado, Ocorreu um erro na operação de exclusão")

				window.document.getElementById('moldalLoading').style.display = "none"
			})
		}
	}else{
		input.style.borderColor = "#5c0101"
		window.document.getElementById('spanSenha').style.display = "inline"
	}
}

function limpaCampoSenha(){
	window.document.getElementById('inputSenha').style.borderColor = "#161717"
	window.document.getElementById('spanSenha').style.display = "none"
}

function abreMoldalSenha(codigoE, codigoL){
	codigoExemplares = codigoE
	codigoLivro = codigoL

	window.document.getElementsByClassName('MoldalOp')[1].style.display = "flex"
}

function selecionaLivro(codigo){
	let indice = linhas.indexOf(codigo)

	if(indice == -1){
		linhas.push(codigo)
	}else{
		linhas.splice(indice, 1)
	}
}

//Funções para gerar o relatório

function abreMoldalRelatorio(){
	if(linhas.length > 0){
		carregaRelatorio()

		window.document.getElementsByClassName('MoldalOp')[2].style.display = "flex"
	}else{
		alert("Selecione pelo menos um livro para emitir o relatório!")
	}
}

function veriricaColunas(){
	colunas = []
	let coluna = window.document.getElementsByClassName('checkboxTable')

	for(i of coluna){
		if(i.checked){
			colunas.push(i.value)
		}
	}
}

function carregaRelatorio(){
	let dados = {
		tipo: 4,
		rows: linhas.join()
	}

	if(operacaoRelatorio != null){
	    operacaoRelatorio.abort();
	    operacaoRelatorio = null;
	}

	operacaoRelatorio = $.ajax({
		method: "POST",
		url: "carregaRelatorio.php",
		data: dados,
		beforeSend: function(){
			window.document.getElementById("tbodyRelatorio").innerHTML = "<tr><td colspan='15'><button class='loading'></button></td></tr>"
		}
	})
	.done(function(res){
		window.document.getElementById('tbodyRelatorio').innerHTML = res
	})
	.fail(function(){
		if(operacaoRelatorio == null){
			alert("Ocorreu um erro ao tentar carregar o relatório")
		}
	})
}

function geraPDF(){
	let titulo = window.document.getElementById('tituloRelatorio')

	let iColunas = window.document.getElementById('columnsPDF')
	let iLinhas = window.document.getElementById('rowsPDF')
	let iTitulo = window.document.getElementById('titlePDF')

	let orientacao = window.document.getElementById('OP')
	let tamanho = window.document.getElementById('TP')

	veriricaColunas()

	if(titulo.value.trim().length > 0){
		if(colunas.length > 0){

			iColunas.value = colunas.join()
			iLinhas.value = linhas.join()
			iTitulo.value = titulo.value.trim()

			orientacao.value = window.document.getElementById('orientacaoPaper').value.trim()
			tamanho.value = window.document.getElementById('tamanhoPaper').value.trim()

			return true
		}else{
			alert("Selecione pelo menos uma coluna!")
			return false
		}
	}else{
		alert("Dê um titulo ao seu relatório!")
		titulo.focus()
		return false
	}
}

function geraExcel(){
	let titulo = window.document.getElementById('tituloRelatorio')

	veriricaColunas()

	if(titulo.value.trim().length > 0){	
		if(colunas.length > 0){
			let dados = {
				tipo: 4,
				columns: colunas.join(),
				rows: linhas.join(),
				title: titulo.value.trim()
			}

			$.ajax({
				method: "POST",
				url: "geraExcel.php",
				data: dados
			})
			.done(function(res){
				let a = document.createElement("a")
				a.setAttribute("href", "data:text/plain;charset=utf-8," + encodeURIComponent(res))
				a.setAttribute("download", `${titulo.value.trim()}.xls`)
				a.click()
			})
			.fail(function(){
				alert("Ocorreu um erro ao tentar emitir o relatório")
			})
		}else{
			alert("Selecione pelo menos uma coluna!")
		}
	}else{
		alert("Dê um titulo ao seu relatório!")
		titulo.focus()
	}	
}

function Imprimir(){
	let titulo = window.document.getElementById('tituloRelatorio')

	veriricaColunas()

	if(titulo.value.trim().length > 0){
		if(colunas.length > 0){
			let dados = {
				tipo: 4,
				columns: colunas.join(),
				rows: linhas.join(),
				title: titulo.value.trim()
			}

			$.ajax({
				method: "POST",
				url: "Imprimir.php",
				data: dados
			})
			.done(function(res){
				const WIDTH = 800
				const HEIGHT = 450
				const X = (window.outerWidth - WIDTH) / 2
				const Y = (window.outerHeight - HEIGHT) / 2

				let pagina = window.open("", "_blank", `height=${HEIGHT}, width=${WIDTH}, top=${Y}, left=${X}`)

				pagina.document.write(res)

				pagina.document.close()

				pagina.print()
			})
			.fail(function(){
				alert("Ocorreu um erro ao tentar emitir o relatório")
			})
		}else{
			alert("Selecione pelo menos uma coluna!")
		}
	}else{
		alert("Dê um titulo ao seu relatório!")
		titulo.focus()
	}
}

function deletaMoldal(){
	window.document.getElementById("MoldalAviso").innerHTML = ""
	window.document.getElementById("MoldalAviso").style.display = "none"
}

window.addEventListener("load", function(){
	let btn = window.document.getElementsByClassName('fechaMoldalOp')

	carregaLivro(null)

	for(i of btn){
		i.addEventListener("click", function(){
			let moldal = window.document.getElementsByClassName('MoldalOp')

			for(i of moldal){
				i.style.display = "none"
			}

			limpaCampoSenha()
			codigoUser = null
			window.document.getElementById('inputSenha').value = ""
		})
	}
	veriricaColunas()
})