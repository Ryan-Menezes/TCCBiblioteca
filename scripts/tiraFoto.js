var cnv = null
var ctx = null
var video = null
var gravacao = null
var loop = null
var loading = null

var loopLoadingTime = null

let imgLoading = new Image()
imgLoading.src = "./Imagens/loading.gif"

imgLoading.onload = function(){
	loading = {
		x: -15,
		y: -15,
		width: 30,
		height: 30,
		img: imgLoading,
		rotation: 2
	}
}

//Funções de animação para o loading

function iniciaLoading(){
	ctx.clearRect(0, 0, cnv.width, cnv.height)
	ctx.save()
	ctx.translate((cnv.width / 2 - 15) + 15, (cnv.height / 2 - 15) + 15)
	ctx.rotate(loading.rotation)
	ctx.drawImage(loading.img, 0, 0, 630, 630, loading.x, loading.y, loading.width, loading.height)
	ctx.restore()
}

function loopLoading(){
	iniciaLoading()
	loading.rotation += 0.5

	loopLoadingTime = setTimeout(loopLoading, 100)
}

//Função para abrir moldal de gravação

function abreFechaMoldalFoto(tipo){ //1 - Abre | 2 - Fecha
	if(tipo == 1){
		loopLoading()
		
		//Iniciando gravação

		navigator.getMedia = navigator.getUserMedia ||
							 navigator.webkitGetUserMedia ||
							 navigator.mozGetUserMedia ||
							 navigator.msGetUserMedia

		if(navigator.getMedia){

			window.document.getElementById("moldalFoto").style.display = "flex"

			navigator.getMedia({
				video: true,
				audio: false
			},
			function(stream){
				if(loopLoadingTime != null){
					clearTimeout(loopLoadingTime)
				}
				
				video.srcObject = stream
				video.play()
			},
			function(error){
				if(loopLoadingTime != null){
					clearTimeout(loopLoadingTime)
				}

				alert("Ocorreu um erro ao tentar acessar sua webcam")
			})
		}else{
			if(loopLoadingTime != null){
				clearTimeout(loopLoadingTime)
			}

			alert("Seu navegador não tem suporte para gravações!")
		}
		
	}else{
		window.document.getElementById("moldalFoto").style.display = "none"
		window.document.getElementById("moldalExibeFoto").style.display = "none"
		stop(video.srcObject)
	}
}

//Função para parar a gravação

function stop(stream){
	try{
		stream.getTracks().forEach(function(track) {
		  track.stop();
		})
	}catch{}

	if(loop != null){
		clearTimeout(loop)
		loop = null
	}
}

//Função para visualizar a foto

function abreMoldalFotoVisualiza(img){
	window.document.getElementById("FotoTirada").src = img
	window.document.getElementById("moldalExibeFoto").style.display = "flex"
}

//Desenha a foto no canvas

function draw(video, context, width, height){
	context.drawImage(video, 0, 0, width, height)
	loop = setTimeout(draw, 0, video, context, width, height)
}

//Exibe a imagem

function tiraFoto(){
	abreFechaMoldalFoto(2)

	// obtém o source da imagem

	var imgData = cnv.toDataURL(); // por padrão, a imagem é PNG

	abreMoldalFotoVisualiza(imgData)
}

//Inicia os eventos e as variaveis

function inicia(){
	cnv = window.document.getElementById('telaFotoTira')
	ctx = cnv.getContext("2d")
	video = window.document.createElement("video")
	video.width = cnv.width
	video.height = cnv.height

	//Eventos

	window.document.getElementById("btnTiraFoto").addEventListener("click", tiraFoto, false)

	window.document.getElementById("btnAbreMoldalFoto").addEventListener("click", function(){
		abreFechaMoldalFoto(1)
	}, false)

	let fecha = window.document.getElementsByClassName("btnFechaFoto")

	for(i of fecha){
		i.addEventListener("click", function(){
			abreFechaMoldalFoto(2)
		}, false)
	}
	

	video.addEventListener("play", function(){
		draw(video, ctx, cnv.width, cnv.height)
	}, false)

	window.document.getElementById("salvarImagem").addEventListener("click", function(){
		var link = window.document.createElement("a")

		link.href = window.document.getElementById("FotoTirada").src; // source
		link.download = 'Foto.jpg'; // nome da imagem
		link.click()

		abreFechaMoldalFoto(2)
	}, false)
}

window.addEventListener("load", inicia)