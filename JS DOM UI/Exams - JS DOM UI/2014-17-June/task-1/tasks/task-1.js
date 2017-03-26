/* globals module */
function solve() {  

  return function createImagesPreviewer(selector, items) {

		var container = document.querySelector(selector);
		
		//Left Panel
		var leftPanel = document.createElement('section');
		leftPanel.className = 'image-preview';    
		leftPanel.style.display = 'inline-block';
		leftPanel.style.float = 'left';

		var leftPanelTitle = document.createElement('h1');
		leftPanelTitle.innerHTML = items[0].title;
		leftPanelTitle.style.textAlign = 'center';

		var leftPanelImage = document.createElement('img');
		leftPanelImage.setAttribute('src', items[0].url);
		leftPanelImage.setAttribute('alt', items[0].title);
		leftPanelImage.style.width = '400px';
		leftPanelImage.style.height = '400px';
		leftPanelImage.style.borderRadius = '10px';

		leftPanel.appendChild(leftPanelTitle);
		leftPanel.appendChild(leftPanelImage);
		
		//Right Panel
		var rightPanel = document.createElement('aside');
		rightPanel.style.display = 'inline-block';
		rightPanel.style.height = '500px';
		rightPanel.style.margin = '10px';
		rightPanel.style.padding = '10px';
		rightPanel.style.overflowY = 'scroll';

		var filterBox = document.createElement('input');
		filterBox.type = 'text';
		var filterBoxTitle = document.createElement('h4');
		filterBoxTitle.innerHTML = 'Filter';
		filterBoxTitle.style.textAlign = 'center';
		filterBoxTitle.style.margin = 0;

		var imageContainer = document.createElement('div');
		imageContainer.className = 'image-container';
		imageContainer.style.padding = '5px';

		var imageContainerTitle = document.createElement('h3');
		imageContainerTitle.style.textAlign = 'center';
		imageContainerTitle.style.margin = 0;

		var imageContainerImage = document.createElement('img');
		imageContainerImage.style.display = 'block';
		imageContainerImage.style.margin = 'auto';    
		imageContainerImage.style.width = '130px';
		imageContainerImage.style.height = '130px';
		imageContainerImage.style.borderRadius = '10px';

		var fragment = document.createDocumentFragment();
		for(var i = 0, len = items.length; i < len; i += 1){
			var currtitle = imageContainerTitle.cloneNode(true);
			currtitle.innerHTML = items[i].title;

			var currImg = imageContainerImage.cloneNode(true);
			currImg.setAttribute('src', items[i].url);
			currImg.setAttribute('alt', items[i].title);

			var currContainer = imageContainer.cloneNode(true);
			currContainer.appendChild(currtitle);
			currContainer.appendChild(currImg);

			fragment.appendChild(currContainer);
		}

		rightPanel.appendChild(filterBoxTitle);
		rightPanel.appendChild(filterBox);
		rightPanel.appendChild(fragment);

		container.appendChild(leftPanel);
		container.appendChild(rightPanel);
		
		// Events
		rightPanel.addEventListener('mouseover', function(ev){
			var target = ev.target;
			if(target.tagName === 'IMG'){  // || target.tagName === 'H3'
				target.parentElement.style.background = 'lightgrey';
				target.style.cursor = 'pointer';          
			}
		});

		rightPanel.addEventListener('mouseout', function(ev){
			var target = ev.target;
			if(target.tagName === 'IMG'){ // || target.tagName === 'H3'
				target.parentElement.style.background = '';          
			}
		});

		rightPanel.addEventListener('click', function(ev){
			var target = ev.target;
			if(target.tagName === 'IMG'){
				var currImgSrc = target.src;
				var currImgTitle = target.alt; // previousElementSibling.innerText;            
				leftPanelTitle.innerText = currImgTitle;
				leftPanelImage.src = currImgSrc;
			}
		});   

		filterBox.addEventListener('input', function(ev){        
			var inputValue = ev.target.value;
			var imageContainers = rightPanel.getElementsByClassName('image-container');
			for(var i = 0, len = imageContainers.length; i < len; i += 1){
				var currContainer = imageContainers[i];
				var containerTitle = currContainer.firstElementChild.innerText;
				if(containerTitle.toLowerCase().includes(inputValue.toLowerCase())){ // or with indexOf(inputValue.toLowerCase()) >= 0
					currContainer.style.display = '';
				} else {
					currContainer.style.display = 'none';
				}      
			}
		});    
	}
}

module.exports = solve;