let codigoUser = null
let linhas = []
let colunas = []
let operacaoFuncionario = null
let operacaoRelatorio = null

function carregaFuncionarios(btn){
	let tbody = window.document.getElementById('dadosCarregados')
	let dados = window.document.getElementsByClassName('dadoInfo')
	let obj = window.document.querySelector('#carregarMaisTable')

	minimoA = (dados != undefined) ? dados.length : 1

	let info = {
		min: minimoA - 1,
		txt: window.document.getElementById('pesquisaInput').value.trim(),
		tipo: window.document.getElementById('pesqOP').value.trim(),
		status: window.document.getElementById('statusOP').value.trim(),
		sexo: window.document.getElementById('sexoOP').value.trim(),
		instituicao: window.document.getElementById('instituicaoOP').value.trim(),
		users: linhas.join()
	}

	if(operacaoFuncionario != null){ 
	    operacaoFuncionario.abort();
	    operacaoFuncionario = null;
	}

	operacaoFuncionario = $.ajax({
		method: "POST",
		url: "carregaFuncionarios.php",
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
		if(operacaoFuncionario == null){
			alert("Ocorreu um erro ao tentar carregar mais funcionários")
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
	carregaFuncionarios(null)
	window.document.getElementsByClassName('MoldalOp')[0].style.display = "none"
}

//Pesquisa

function pesquisaFuncionario(){
	window.document.getElementById('dadosCarregados').innerHTML = "<tr id='carregarMaisTable'><td colspan='12'><button class='loading'></button></td></tr>"
	carregaFuncionarios(null)
}

//Função de exclusão

function excluirFuncionario(){
	let input = window.document.getElementById('inputSenha')

	if(input.value.trim().length > 0){
		if(codigoUser != null){
			$.ajax({
				method: "POST",
				url: "deletaUsuario.php",
				data: {codU: codigoUser, senha: input.value.trim(), instituicao: window.document.getElementById('instituicaoOP').value.trim()},
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

				carregaFuncionarios(null)

				//Recarregando mensagens

				window.document.getElementById('tbodyMsgAviso').innerHTML = `<tr id="trMsgLoading">
																				<td colspan="4"><button class="loading"></button></td>
																		     </tr>`

				carregaAvisos(null)
			})
			.fail(function(){
				alert("Funcionário não deletado, Ocorreu um erro na operação de exclusão")

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

function abreMoldalSenha(codigoU){
	codigoUser = codigoU

	window.document.getElementsByClassName('MoldalOp')[1].style.display = "flex"
}

function selecionaUser(codigo){
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
		alert("Selecione pelo menos um funcionário para emitir o relatório!")
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
		tipo: 3,
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
			window.document.getElementById("tbodyRelatorio").innerHTML = "<tr><td colspan='16'><button class='loading'></button></td></tr>"
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
				tipo: 3,
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
				tipo: 3,
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

function abreMoldalEnviaMsg(indice, codigo, tipo){
	$.ajax({
		method: "POST",
		url: "carregaUsuarioAviso.php",
		data: {type: tipo, cod: codigo},
		beforeSend: function(){
			window.document.getElementById("moldalLoading").style.display = "flex"
		}
	})
	.done(function(res){
		window.document.getElementById("dadosRemetenteAviso").innerHTML = res
		window.document.getElementById("moldalLoading").style.display = "none"

		window.document.getElementById("textBoxMensagem").value = ""
		window.document.getElementById("tituloAviso").value = ""
		window.document.getElementById("codUsuarioAviso").value = codigo
		window.document.getElementsByClassName('MoldalMensagens')[indice].style.display = "flex"
	})
	.fail(function(){
		alert("Ocorreu um erro ao tentar abrir o formulário de envio de mensagens!")
		window.document.getElementById("moldalLoading").style.display = "none"
	})
}

function enviaMensagem(){

	let msg = window.document.getElementById("textBoxMensagem")
	let codigo = window.document.getElementById("codUsuarioAviso").value.trim()
	let titulo = window.document.getElementById("tituloAviso")

	if(msg.value.trim().length > 0 && titulo.value.trim().length > 0){
		$.ajax({
		method: "POST",
			url: "enviaMensagemAviso.php",
			data: {mensagem: msg.value.trim(), cod: codigo, title: titulo.value.trim()},
			beforeSend: function(){
				window.document.getElementById("moldalLoading").style.display = "flex"
			}
		})
		.done(function(res){
			window.document.getElementById("MoldalAviso").innerHTML = res
			window.document.getElementById("MoldalAviso").style.display = "flex"
			window.document.getElementById('moldalLoading').style.display = "none"

			msg.value = ""
			titulo.value = ""
		})
		.fail(function(){
			alert("Mensagem não enviada!, Ocorreu um erro ao enviar esta mensagem")
			window.document.getElementById("moldalLoading").style.display = "none"
		})
	}else{
		if(titulo.value.trim().length == 0){
			alert("Digite o titulo da mensagem que deseja enviar!")
			titulo.focus()
		}else{
			alert("Digite a mensagem que deseja enviar!")
			msg.focus()
		}
	}
}

window.addEventListener("load", function(){
	let btn = window.document.getElementsByClassName('fechaMoldalOp')

	carregaFuncionarios(null)

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