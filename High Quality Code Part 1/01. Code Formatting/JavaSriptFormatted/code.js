/*
Remarks:
ShowMenu/HideMenu with parameter - menuId, prevent repeated code
eval() - not good practice
document.all/document.layers - obsolete, used respectively in IE/Netscape - use getElementById() instead
change visibility through style property
pixelLeft/Top/Right return integer number - left/top/right (recommended) return string, containing "px" - parseInt is needed
evn and event in mouseMove - I'm guessing it's the same
event.x/y - alias for clientX/Y
*/

(function () {
	let browserName = navigator.appName;
	let addScroll = false;
	let off = 0;
	let txt = '';
	let pX = 0;
	let pY = 0;

	if ((navigator.userAgent.indexOf('MSIE 5') > 0) || (navigator.userAgent.indexOf('MSIE 6')) > 0) {
		addScroll = true;
	}

	document.onmousemove = mouseMove;

	if (browserName === 'Netscape') {
		document.captureEvents(Event.MOUSEMOVE);
	}

	function mouseMove(evn) {
		if (browserName == 'Netscape') {
			pX = evn.pageX - 5;
			pY = evn.pageY;

			if (document.getElementById('ToolTip').style.visibility === 'show') {
				popTip();
			}
		} else {
			pX = event.x - 5;
			pY = event.y;

			if (document.getElementById('ToolTip').style.visibility === 'visible') {
				popTip();
			}
		}
	}

	function popTip() {
		let theLayer = document.getElementById('ToolTip');

		if (browserName === "Netscape") {			

			if ((pX + 120) > window.innerWidth) {
				pX = window.innerWidth - 150;
			}

			theLayer.left = pX + 10;
			theLayer.top = pY + 15;
			theLayer.style.visibility = 'show';
		} else {			

			if (theLayer) {
				pX = event.x - 5;
				pY = event.y;

				if (addScroll) {
					pX = pX + document.body.scrollLeft;
					pY = pY + document.body.scrollTop;
				}

				if ((pX + 120) > document.body.clientWidth) {
					pX = pX - 150;
				}

				theLayer.style.pixelLeft = pX + 10;
				theLayer.style.pixelTop = pY + 15;
				theLayer.style.visibility = 'visible';
			}
		}
	}

	function hideTip() {
		let args = HideTip.arguments; //never used, could be replaced by HideMenu with changed name - HideElement

		if (browserName === "Netscape") {
			document.getElementById('ToolTip').style.visibility = 'hide';
		} else {
			document.getElementById('ToolTip').style.visibility = 'hidden';
		}
	}

	function hideMenu(menuId) {
		let theLayer = document.getElementById(menuId);

		if (browserName === "Netscape") {
			theLayer.style.visibility = 'hide';
		} else {
			theLayer.style.visibility = 'hidden';
		}
	}

	function showMenu(menuId) {
		let theLayer = document.getElementById(menuId);

		if (browserName === "Netscape") {			
			theLayer.style.visibility = 'show';
		} else {			
			theLayer.style.visibility = 'visible';
		}
	}
	
}());
