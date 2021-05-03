var valor = document.documentElement.scrollTop

window.onscroll = function(){
	var top2 = document.documentElement.scrollTop

	if(top2 > valor){
		window.document.getElementById('menu').style.top = `-${$('#menu').height()}px`
		window.document.getElementById('menuB').style.top = '0px'
	}else{
		window.document.getElementById('menu').style.top = 	'0px'
		window.document.getElementById('menuB').style.top = `${$('#menu').height()}px`
	}

	valor = top2
}