function solve() {

	return function(selector, defaultLeft, defaultRight) {

		var root = document.querySelector(selector);		

		// Column container
		var columnContainer = document.createElement('div');
		columnContainer.className = 'column-container';

		// Left Column
		var leftColumn = document.createElement('div');
		leftColumn.className = 'column';
		
		var leftSelect = document.createElement('div');
		leftSelect.className = 'select';

		var leftRadio = document.createElement('input');
		leftRadio.setAttribute('type', 'radio');
		leftRadio.setAttribute('checked', 'checked');
		leftRadio.setAttribute('name', 'column-select');
		leftRadio.id = 'select-left-column';
		
		var leftRadioLabel = document.createElement('label');
		leftRadioLabel.setAttribute('for', 'select-left-column');
		leftRadioLabel.innerHTML = 'Add here';

		leftSelect.appendChild(leftRadio);
		leftSelect.appendChild(leftRadioLabel);

		// Creating LI for clone
		var li = document.createElement('li');
		li.className = 'entry';

		var img = document.createElement('img');
		img.className = 'delete';
		img.src = 'imgs/Remove-icon.png';		

		li.appendChild(img);

		// Ol left
		var leftOl = document.createElement('ol');

		leftColumn.appendChild(leftSelect);
		leftColumn.appendChild(leftOl);

		// Right Column
		var rightColumn = document.createElement('div');
		rightColumn.className = 'column';

		var rightSelect = document.createElement('div');
		rightSelect.className = 'select';

		var rightRadio = document.createElement('input');
		rightRadio.setAttribute('type', 'radio');
		rightRadio.setAttribute('name', 'column-select');
		rightRadio.id = 'select-right-column';
		
		var rightRadioLabel = document.createElement('label');
		rightRadioLabel.setAttribute('for', 'select-right-column');
		rightRadioLabel.innerHTML = 'Add here';

		rightSelect.appendChild(rightRadio);
		rightSelect.appendChild(rightRadioLabel);

		// Ol right
		var rightOl = document.createElement('ol');

		rightColumn.appendChild(rightSelect);
		rightColumn.appendChild(rightOl);

		columnContainer.appendChild(leftColumn);
		columnContainer.appendChild(rightColumn);
		
		// Input
		var inputField = document.createElement('input');
		inputField.setAttribute('type', 'text');
		inputField.setAttribute('autofocus', 'autofocus');
		inputField.size = 40;
		
		// Button
		var addButton = document.createElement('button');
		addButton.innerHTML = 'Add';

		if(defaultLeft){
			for(var i = 0, len = defaultLeft.length; i < len; i += 1){
				var currItem = defaultLeft[i].trim();
				currItem = escapeHtml(currItem);
				if(currItem){
					addItem(currItem, leftOl);					
				}				
			}			
		}

		if(defaultRight){
			for(var i = 0, len = defaultRight.length; i < len; i += 1){
				var currItem = defaultRight[i].trim();
				currItem = escapeHtml(currItem);
				if(currItem){
					addItem(currItem, rightOl);					
				}
			}	
		}

		root.appendChild(columnContainer);
		root.appendChild(inputField);
		root.appendChild(addButton);	

		columnContainer.addEventListener('click', function(ev){
			var target = ev.target;

			if(target.className === 'delete'){				
				var liText = target.parentElement.innerText;
				var parent = target.parentElement;
				var ol = parent.parentElement;
				
				inputField.value = liText;

				ol.removeChild(parent);
			}
		});

		addButton.addEventListener('click', function(ev){

			var text = inputField.value;
			text = text.trim();
			text = escapeHtml(text);

			if(leftRadio.checked){				
				if(text !== ''){
					addItem(text, leftOl);										
				}
			}

			if(rightRadio.checked){				
				if(text !== ''){
					addItem(text, rightOl);
				}
			}

			inputField.value = '';
		});

		function addItem(newItem, toColumn){
			newItem = newItem.trim();
			var newLi = li.cloneNode(true);
			newLi.innerHTML = newLi.innerHTML + newItem;

			toColumn.appendChild(newLi);			
		}

		function escapeHtml(text) {
    		return text
				.replace(/&/g, "&amp;")
				.replace(/</g, "&lt;")
				.replace(/>/g, "&gt;")
				.replace(/"/g, "&quot;")
				.replace(/'/g, "&#039;");
 		}
	};
}

// SUBMIT THE CODE ABOVE THIS LINE

if(typeof module !== 'undefined') {
	module.exports = solve;
}
