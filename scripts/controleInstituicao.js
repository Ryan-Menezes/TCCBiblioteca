let minimoC = 0
let textoC = ''
let ElementoC = null

let operacaoInstituicao = null

function carregaInstituicao(tipo){

	if(operacaoInstituicao != null){ 
	    operacaoInstituicao.abort();
	    operacaoInstituicao = null;
	}
	
	operacaoInstituicao = $.ajax({
		method: "POST",
		url: "carregaInstituicao.php",
		data: {min:minimoC, txt:textoC}
	})
	.done(function(res){
		if(tipo == 1){
			if(res.length > 0){
				window.document.getElementById('instiT').innerHTML += res

				if(ElementoC != null){
					ElementoC.innerHTML = `<i class='fas fa-plus' title="Carregar Mais"></i>`
					ElementoC.classList.remove('loading')
					ElementoC.classList.add('btns')
					ElementoC.classList.add('carregarMaisT')
				}
			}else{
				if(minimoC == 0){
					window.document.getElementById('instiT').innerHTML = "<tr><td colspan='4'><h5>Não há instituições cadastradas nessa instituição</h5></td></tr>"
				}

				if(ElementoC != null){
					ElementoC.style.display = "none"
				}
			}
		}else{
			if(res.length > 0){
				window.document.getElementById('instiT').innerHTML = res
			}else{
				window.document.getElementById('instiT').innerHTML = `<tr><td colspan='4'><h5>Não foi possivel encontrar uma instituição com o nome '${textoC}'</h5></td></tr>`
			}
		}
	})
	.fail(function(){
		if(operacaoInstituicao == null){
			alert("Ocorreu um erro ao carregar mais instituições")
		}

		if(ElementoC != null){
			ElementoC.innerHTML = `<i class='fas fa-plus' title="Carregar Mais"></i>`
			ElementoC.classList.remove('loading')
			ElementoC.classList.add('btns')
			ElementoC.classList.add('carregarMaisT')
		}
	})
}

function carregaMaisInstituicao(obj){
	ElementoC = obj

	ElementoC.innerHTML = ""
	ElementoC.classList.remove('btns')
	ElementoC.classList.remove('carregarMaisT')
	ElementoC.classList.add('loading')

	minimoC += 10
	carregaInstituicao(1);
}

function pesquisaInstituicao(obj){

	minimoC = 0
	textoC = obj.value

	if(ElementoC != null){
		ElementoC.innerHTML = `<i class='fas fa-plus' title="Carregar Mais"></i>`
		ElementoC.classList.remove('loading')
		ElementoC.classList.add('btns')
		ElementoC.classList.add('carregarMaisT')
		ElementoC.style.display = "block"
	}
	
	carregaInstituicao(2)
}

window.addEventListener("load", function(){
	carregaInstituicao(2)
})