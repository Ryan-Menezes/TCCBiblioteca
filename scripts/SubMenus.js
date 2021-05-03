function funSubMenu(val){

	window.document.getElementsByClassName('liB')[0].style.borderBottom = 'none'
	window.document.getElementsByClassName('liB')[1].style.borderBottom = 'none'
	window.document.getElementsByClassName('liB')[2].style.borderBottom = 'none'

	window.document.getElementsByClassName('liB')[val].style.borderBottom = '5px solid #4287f5'

	if(val == 0){
		window.document.getElementsByClassName('subMenuOp')[0].style.display = "block"
		window.document.getElementsByClassName('subMenuOp')[1].style.display = "none"
		window.document.getElementsByClassName('subMenuOp')[2].style.display = "none"			
	}else if(val == 1){
		window.document.getElementsByClassName('subMenuOp')[0].style.display = "none"
		window.document.getElementsByClassName('subMenuOp')[1].style.display = "block"
		window.document.getElementsByClassName('subMenuOp')[2].style.display = "none"
	}else if(val == 2){
		window.document.getElementsByClassName('subMenuOp')[0].style.display = "none"
		window.document.getElementsByClassName('subMenuOp')[1].style.display = "none"
		window.document.getElementsByClassName('subMenuOp')[2].style.display = "block"
	}
}