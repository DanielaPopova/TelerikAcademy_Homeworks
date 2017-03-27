function solve() {
  return function (selector, isCaseSensitive) {

      isCaseSensitive = isCaseSensitive || false;
      var root = document.querySelector(selector);
      root.className = 'items-control';
      root.style.width = '30%';
      root.style.margin = '10px';           
      root.style.border = '1px solid black';

      // Add controls
      var addControls = document.createElement('div');
      addControls.className = 'add-controls';
      addControls.style.borderBottom = '1px solid black';
      addControls.style.padding = '10px';
      addControls.style.textAlign = 'center';

      var label = document.createElement('label');
      label.setAttribute('for', 'field');
      label.innerHTML = 'Enter text';      

      var inputField = document.createElement('input');
      inputField.setAttribute('type', 'text');
      inputField.id = 'field';
      inputField.style.margin = '5px';      

      var addButton = document.createElement('button');
      addButton.className = 'button';
      addButton.innerHTML = 'Add';
      addButton.style.display = 'block';
      addButton.style.margin = 'auto';
      addButton.style.width = '80%';      

      addControls.appendChild(label);
      addControls.appendChild(inputField);
      addControls.appendChild(addButton);      
      
      // Search-controls 
      var searchControls = document.createElement('div');
      searchControls.className = 'search-controls';
      searchControls.style.borderBottom = '1px solid black';
      searchControls.style.padding = '10px';
      searchControls.style.margin = 0;
      searchControls.style.textAlign = 'center';

      var labelForSearch = document.createElement('label');
      labelForSearch.setAttribute('for', 'search-field');
      labelForSearch.innerHTML = 'Search:';

      var searchField = document.createElement('input');
      searchField.setAttribute('type', 'text');
      searchField.id = 'search-field';
     
      searchControls.appendChild(labelForSearch);
      searchControls.appendChild(searchField);

      // Result-controls
      var resultControls = document.createElement('div');
      resultControls.className = 'result-controls';
      resultControls.style.margin = 0;

      var itemsList = document.createElement('ul');
      itemsList.className = 'items-list';
      itemsList.style.listStyle = 'none';
      itemsList.style.padding = '10px';
      itemsList.style.margin = 0;

      var item = document.createElement('li');
      item.className = 'list-item';
      item.style.borderBottom = '1px solid black';

      var deleteButton = document.createElement('button');
      deleteButton.className = 'button';
      deleteButton.innerHTML = 'X';      
      deleteButton.style.margin = '5px';

      var text = document.createElement('p');
      text.style.display = 'inline';

      addButton.addEventListener('click', function(ev){
            var clonedLi = item.cloneNode(true);
            var clonedbtn = deleteButton.cloneNode(true);
            var clonedP = text.cloneNode(true);
            clonedP.innerHTML = inputField.value;

            clonedLi.appendChild(clonedbtn);
            clonedLi.appendChild(clonedP);
            itemsList.appendChild(clonedLi);

            inputField.value = '';
      });      

      itemsList.addEventListener('click', function(ev){
          var target = ev.target;
          if(target.tagName === 'BUTTON'){
              itemsList.removeChild(target.parentElement);
          }
      });

      resultControls.appendChild(itemsList);

      searchField.addEventListener('input', function(ev){
          var searchValue = ev.target.value;
          var allLis = itemsList.getElementsByClassName('list-item');

          for(var i = 0, len = allLis.length; i < len; i += 1){
              var currItem = allLis[i];
              var currItemText = currItem.lastElementChild.innerHTML;

              if(isCaseSensitive){
                  if(currItemText.indexOf(searchValue) >= 0){
                      currItem.style.display = '';
                  } else {
                      currItem.style.display = 'none';
                  }
              } else {
                  if(currItemText.toLowerCase().indexOf(searchValue.toLowerCase()) >= 0){
                      currItem.style.display = '';
                  } else {
                      currItem.style.display = 'none';
                  }
              }
          }
      });

      // Append everyting to root container
      root.appendChild(addControls);
      root.appendChild(searchControls);
      root.appendChild(resultControls);
  };
}

module.exports = solve;