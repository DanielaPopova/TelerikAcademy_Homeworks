(function () {  
  let main = document.getElementsByTagName('main')[0];
  main.style.width = '20%';

  let input = document.getElementsByTagName('input')[0];
  input.style.display = 'block';
  input.style.width = '100%';
  input.style.height = '20px';
  input.style.marginTop = '8px';
  input.style.marginBottom = '8px';
  input.setAttribute('autofocus', 'autofocus');

  let showHideButton = document.getElementById('show-hide-btn');
  showHideButton.style.float = 'right';

  let list = document.getElementById('todo-list');
  list.style.listStyle = 'none';
  list.style.padding = 0;
  list.style.margin = 0;

  let checkBox = document.createElement('input');
  checkBox.setAttribute('type', 'radio');  
  checkBox.setAttribute('name', 'choice');
  checkBox.style.float = 'right';

  let span = document.createElement('span');  

  let li = document.createElement('li');
  li.style.border = '1px solid black';
  li.style.padding = '5px';
  li.appendChild(span);
  li.appendChild(checkBox);

  let hTag = document.getElementsByTagName('h4')[0];
  hTag.style.marginTop = '10px';
  hTag.style.marginBottom = '5px';

  let addBtn = document.getElementById('add-btn');
  addBtn.addEventListener('click', function () {
    if (input.value !== '') {
      let currLi = li.cloneNode(true);
      currLi.firstElementChild.innerHTML = input.value;  //that's the span element innerHTML
      list.appendChild(currLi);
      input.value = '';      
    } else {
      alert('Add item first!');
    }

  });

  showHideButton.addEventListener('click', function () {
    let content = showHideButton.innerHTML;
    if (content === 'Hide') {
      list.style.display = 'none';
      showHideButton.innerHTML = 'Show';
    } else if(content === 'Show'){
      list.style.display = '';
      showHideButton.innerHTML = 'Hide';      
    }
  });

  let deleteBtn = document.getElementById('delete-btn');
  deleteBtn.addEventListener('click', function(){
      if(list.children.length === 0){
        alert('There are no items to delete!');
      }

      let allLis = list.children;
      for(let i = 0, len = allLis.length; i < len; i += 1){
        let currLi = allLis[i];
        
        if(currLi.lastElementChild.checked){
          list.removeChild(currLi);
          break;
        }
      }     
  });

}())