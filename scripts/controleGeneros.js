let minimoG = 0
let ElementoG = null
let operacaoGenero = null

function carregaGenero(){

	if(operacaoGenero != null){ 
	    operacaoGenero.abort();
	    operacaoGenero = null;
	}

	operacaoGenero = $.ajax({
		method: "POST",
		url: "carregaGenero.php",
		data: {min:minimoG}
	})
	.done(function(res){
		window.document.getElementById('generosT').innerHTML += res

		if(ElementoG != null){
			ElementoG.innerHTML = `<i class='fas fa-plus' title="Carregar Mais"></i>`
			ElementoG.classList.remove('loading')
			ElementoG.classList.add('btns')
			ElementoG.classList.add('carregarMaisT')
		}

		if(res.length == 0 && ElementoG != null){
			ElementoG.remove()
		}
	})
	.fail(function(){
		if(operacaoGenero == null){
			alert("Ocorreu um erro ao carregar mais genêros")
		}
	})
}

function carregaMaisGeneros(obj){
	ElementoG = obj

	ElementoG.innerHTML = ""
	ElementoG.classList.remove('btns')
	ElementoG.classList.remove('carregarMaisT')
	ElementoG.classList.add('loading')

	minimoG += 10
	carregaGenero();
}

window.addEventListener("load", carregaGenero)