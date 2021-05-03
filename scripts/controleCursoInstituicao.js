var codCurso = null
let operacaoCursoTela = null

function carregaCursos(obj){
	let instituicao = window.document.getElementById('instituicaoSelecionada').value.trim()
	let tbody = window.document.getElementById('dadosCarregados')
	let trCurso = window.document.getElementsByClassName('trCurso')
	let trLoading = window.document.getElementById('carregarMaisTable')
	let texto = window.document.getElementById('pesquisaInput')

	if(operacaoCursoTela != null){ 
	    operacaoCursoTela.abort();
	    operacaoCursoTela = null;
	}

	operacaoCursoTela = $.ajax({
		method: "POST",
		url: "carregaCursosInstituicaoTela.php",
		data: {min: trCurso.length, inst: instituicao, txt: texto.value.trim()},
		beforeSend: function(){
			if(obj != null){
				obj.innerHTML = ""
				obj.classList.remove("btnCarr")
				obj.classList.add("loading")
			}
		}
	})
	.done(function(res){
		trLoading.remove()

		tbody.innerHTML += res
	})
	.fail(function(){
		if(operacaoCursoTela == null){
			alert("Cursos não carregados, ocorreu um erro ao tentar carregar mais cursos!")
		}
	})
}

function selecionaInstituicao(){
	window.document.getElementById('dadosCarregados').innerHTML = `<tr id="carregarMaisTable">
																		<td colspan="7"><button class="loading"></button></td>
																   </tr>`

    carregaCursos(null)
}

function pesquisaCurso(){
	window.document.getElementById('dadosCarregados').innerHTML = `<tr id="carregarMaisTable">
																		<td colspan="7"><button class="loading"></button></td>
																   </tr>`
	
	carregaCursos(null)
}

function excluirCurso(){
	let input = window.document.getElementById('inputSenha')

	if(input.value.trim().length > 0){
		if(codCurso != null){
			$.ajax({
				method: "POST",
				url: "deletaCurso.php",
				data: {codC: codCurso, senha: input.value.trim()},
				beforeSend: function(){
					window.document.getElementById('moldalLoading').style.display = "flex"	
				}
			})
			.done(function(res){
				window.document.getElementById("MoldalAviso").innerHTML = res
				window.document.getElementById("MoldalAviso").style.display = "flex"
				window.document.getElementById('moldalLoading').style.display = "none"

				window.document.getElementById('moldalLoading').style.display = "none"

				window.document.getElementsByClassName('MoldalOp')[0].style.display = "none"
				limpaCampoSenha()
				codigoUser = null
				window.document.getElementById('inputSenha').value = ""

				window.document.getElementById('dadosCarregados').innerHTML = "<tr id='carregarMaisTable'><td colspan='7'><button class='loading'></button></td></tr>"

				carregaCursos(null)
			})
			.fail(function(){
				alert("Turma não deletada, Ocorreu um erro na operação de exclusão")

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

function abreMoldalSenha(cod){
	codCurso = cod

	window.document.getElementsByClassName('MoldalOp')[0].style.display = "flex"
}

function fechaMoldalSenha(){
	codCurso = null

	window.document.getElementsByClassName('MoldalOp')[0].style.display = "none"

	limpaCampoSenha()
}

function deletaMoldal(){
	window.document.getElementById("MoldalAviso").innerHTML = ""
	window.document.getElementById("MoldalAviso").style.display = "none"
}

window.addEventListener("load", function(){
	carregaCursos(null)
})