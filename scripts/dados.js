function verifica(){
	let input = window.document.getElementsByClassName('inputSenha')
	let span = window.document.getElementsByClassName('spanSenha')

	let verificar = true

	if(input[0].value.trim().length == 0){
		span[0].innerText = "Digite sua senha atual"
		span[0].style.display = "inline-block"

		verificar = false
	}else if(input[1].value.trim().length < 8){
		span[0].innerText = "Digite sua nova senha com pelo menos 8 digítos!"
		span[0].style.display = "inline-block"

		verificar = false
	}else if(input[2].value.trim().length == 0){
		span[0].innerText = "Repita sua nova senha"
		span[0].style.display = "inline-block"

		verificar = false
	}else if(input[1].value.trim() != input[2].value.trim()){
		span[0].innerText = "As senhas digitadas não são iguais!"
		span[0].style.display = "inline-block"

		verificar = false
	}

	return verificar
}

function limpaCampoSenha(){
	window.document.getElementsByClassName('spanSenha')[0].style.display = "none"
}

function alterarSenha(){
	let input = window.document.getElementsByClassName('inputSenha')

	if(verifica()){
		$.ajax({
			method: "POST",
			url: "alteraSenha.php",
			data: {senha: input[0].value.trim(), novaSenha: input[1].value.trim()},
			beforeSend: function(){
				window.document.getElementById('moldalLoading').style.display = "flex"
			}
		})
		.done(function(msg){
			window.document.getElementById("MoldalAviso").innerHTML = msg
			window.document.getElementById("MoldalAviso").style.display = "flex"
			window.document.getElementById('moldalLoading').style.display = "none"

			window.document.getElementById('moldalLoading').style.display = "none"
		})
		.fail(function(){
			alert("Não foi possivel alterar a senha!, ocorreu um erro na operação")

			window.document.getElementById('moldalLoading').style.display = "none"
		})
	}
}

function abreMoldalSenha(){
	window.document.getElementsByClassName("MoldalOp")[0].style.display = "flex"
}

function fechaMoldalSenha(){
	let input = window.document.getElementsByClassName('inputSenha')

	window.document.getElementsByClassName("MoldalOp")[0].style.display = "none"

	limpaCampoSenha()

	for(i of input){
		i.value = ""
	}
}

function deletaMoldal(){
	window.document.getElementById("MoldalAviso").innerHTML = ""
	window.document.getElementById("MoldalAviso").style.display = "none"
}