let minimoC = 0
let textoC = ''
let ElementoC = null
var instituicao = null
let operacaoCurso = null

function carregaCurso(tipo){

	if(operacaoCurso != null){ 
	    operacaoCurso.abort();
	    operacaoCurso = null;
	}

	operacaoCurso = $.ajax({
		method: "POST",
		url: "carregaCursos.php",
		data: {min:minimoC, txt:textoC, inst: instituicao}
	})
	.done(function(res){
		if(tipo == 1){
			if(res.length > 0){
				window.document.getElementById('cursoT').innerHTML += res

				if(ElementoC != null){
					ElementoC.innerHTML = `<i class='fas fa-plus' title="Carregar Mais"></i>`
					ElementoC.classList.remove('loading')
					ElementoC.classList.add('carregarMaisT')
				}
			}else{
				if(minimoC == 0){
					window.document.getElementById('cursoT').innerHTML = "<tr><td colspan='4'><h5>Não há cursos cadastradas nessa instituição</h5></td></tr>"
				}

				if(ElementoC != null){
					ElementoC.style.display = "none"
				}
			}
		}else{
			if(res.length > 0){
				window.document.getElementById('cursoT').innerHTML = res
			}else{
				window.document.getElementById('cursoT').innerHTML = `<tr><td colspan='4'><h5>Não foi possivel encontrar um curso com o nome '${textoC}'</h5></td></tr>`
			}
		}
	})
	.fail(function(){
		if(operacaoCurso == null){
			alert("Ocorreu um erro ao carregar mais cursos")
		}

		if(ElementoC != null){
			ElementoC.innerHTML = `<i class='fas fa-plus' title="Carregar Mais"></i>`
			ElementoC.classList.remove('loading')
			ElementoC.classList.add('carregarMaisT')
		}
	})
}

function carregaMaisCurso(obj){
	ElementoC = obj

	ElementoC.innerHTML = ""
	ElementoC.classList.remove('carregarMaisT')
	ElementoC.classList.add('loading')

	minimoC += 10
	carregaCurso(1);
}

function pesquisaCurso(obj){

	minimoC = 0
	textoC = obj.value

	if(ElementoC != null){
		ElementoC.innerHTML = `<i class='fas fa-plus' title="Carregar Mais"></i>`
		ElementoC.classList.remove('loading')
		ElementoC.classList.add('carregarMaisT')
		ElementoC.style.display = "block"
	}
	
	carregaCurso(2)
}

function selecionaInstituicao(obj){
	window.document.getElementById('cursoT').innerHTML = ""
	instituicao = obj.value
	minimoC = 0

	if(ElementoC != null){
		ElementoC.innerHTML = `<i class='fas fa-plus' title="Carregar Mais"></i>`
		ElementoC.classList.remove('loading')
		ElementoC.classList.add('carregarMaisT')
		ElementoC.style.display = "block"
	}

	carregaCurso(1)
}

window.addEventListener("load", function(){
	selecionaInstituicao(window.document.getElementById('instituicoesCurso'))
})