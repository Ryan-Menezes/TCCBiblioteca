let operacaoMensagemAviso = null

function abreMoldalMsg(indice){
	window.document.getElementsByClassName('MoldalMensagens')[indice].style.display = "flex"
}

function fechaMoldalMsg(indice){
	window.document.getElementsByClassName('MoldalMensagens')[indice].style.display = "none"
}

function carregaAvisos(obj){
	let tbody = window.document.getElementById('tbodyMsgAviso')
	let tr = window.document.getElementsByClassName('trMsg')

	if(operacaoMensagemAviso != null){ 
	    operacaoMensagemAviso.abort();
	    operacaoMensagemAviso = null;
	}

	operacaoMensagemAviso = $.ajax({
		method: "POST",
		url: "carregaAvisos.php",
		data: {min: tr.length},
		beforeSend: function(){
			if(obj != null){
				obj.innerHTML = ""
				obj.classList.remove('carregarMaisT')
				obj.classList.add("loading")
			}
		}
	})
	.done(function(res){
		if(window.document.getElementById('trMsgLoading') != undefined){
			window.document.getElementById('trMsgLoading').remove()
		}

		tbody.innerHTML += res
	})
	.fail(function(){
		if(operacaoMensagemAviso == null){
			alert("Ocorreu um erro ao tentar carregar os avisos")
		}

		if(obj != null){
			obj.innerHTML = "<i class='fas fa-plus' title='Carregar Mais'></i>"
			obj.classList.remove("loading")
			obj.classList.add('carregarMaisT')
		}
	})
}

function carregaAvisoUser(codigo, indice){
	let container = window.document.getElementById('itensMsg')
	let td = window.document.getElementById(`situcaoMsg${indice}`)

	$.ajax({
		method: "POST",
		url: "carregaAvisoUser.php",
		data: {cod: codigo},
		beforeSend: function(){
			window.document.getElementById("moldalLoading").style.display = "flex"
		}
	})
	.done(function(res){
		window.document.getElementById("moldalLoading").style.display = "none"

		container.innerHTML = res
		abreMoldalMsg(1)

		let sino = window.document.querySelector('#sinoNotificacao div')

		if(td.innerText == "Não Visualizado"){
			if(sino != undefined){
				let rest = Number(sino.innerText) - 1

				if(rest > 0){
					sino.innerText = rest
				}else{
					sino.remove()
				}
			}
		}

		td.innerText = "Visualizado";
	})
	.fail(function(){
		alert("Ocorreu um erro ao tentar visualizar esta mensagem!")

		window.document.getElementById("moldalLoading").style.display = "none"
	})
}

function deletaAviso(codigo){

	let tbody = window.document.getElementById('tbodyMsgAviso')

	if(confirm("Você realmente deseja excluir esta mensagem?")){
		$.ajax({
			method: "POST",
			url: "deletaAviso.php",
			data: {cod: codigo},
			beforeSend: function(){
				window.document.getElementById("moldalLoading").style.display = "flex"
			}
		})
		.done(function(msg){
			window.document.getElementById("MoldalAviso").innerHTML = msg
			window.document.getElementById("MoldalAviso").style.display = "flex"
			window.document.getElementById('moldalLoading').style.display = "none"

			let sino = window.document.querySelector('#sinoNotificacao div')

			if(sino != undefined){
				let rest = Number(sino.innerText) - 1

				if(rest > 0){
					sino.innerText = rest
				}else{
					sino.remove()
				}
			}

			tbody.innerHTML = `<tr id="trMsgLoading">
									<td colspan="4"><button class="loading"></button></td>
							   </tr>`

			carregaAvisos(null)
		})
		.fail(function(){
			alert("Mensagem não deletada, Ocorreu um erro no processo de exclusão!")

			window.document.getElementById("moldalLoading").style.display = "none"
		})
	}
}

function deletaMoldal(){
	window.document.getElementById("MoldalAviso").innerHTML = ""
	window.document.getElementById("MoldalAviso").style.display = "none"
}

function inicia(){
	window.document.getElementById('sinoNotificacao').addEventListener("click", function(){
		abreMoldalMsg(0)
	})

	carregaAvisos(null)
}

window.addEventListener("load", inicia)