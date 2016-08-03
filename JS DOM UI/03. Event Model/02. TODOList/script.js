
  var i, 
      len,
      addBtn,
      deleteBtn,
      showHideBtn,
      index = 1,
      form = document.createElement('form'),
      inputField = document.createElement('input'),
      label = document.createElement('label'),
      button = document.createElement('button'),
      h3 = document.createElement('h3'),
      ulList = document.createElement('ul'),
      li,
      allLis,
      main = document.getElementsByTagName('main')[0];
     
form.setAttribute('action', '#');
form.setAttribute('method', 'get');

inputField.style.display = 'block';
inputField.style.width = 500 + 'px';
inputField.style.height = 30 + 'px';
inputField.style.borderWidth = 1 + 'px';
inputField.style.fontSize = 20 + 'px';
inputField.style.background = '#D8CAF3';
inputField.style.marginTop = 10 + 'px';
inputField.style.paddingLeft = 5 + 'px';
inputField.setAttribute('placeholder', 'Item');

label.innerHTML = 'Add new item: ';
label.style.fontSize = 20 + 'px';
label.appendChild(inputField);

button.style.width = 70 + 'px';
button.style.height = 30 + 'px';
button.style.marginTop = 10 + 'px';
button.style.marginRight = 10 + 'px';
button.style.borderColor = '#4D21A5';
button.style.borderRadius = 5 + 'px';
button.style.background = '#7F00FF';
button.style.fontSize = 16 + 'px';
button.style.color = 'white';

ulList.style.listStyle = 'none';
ulList.id = 'todo';
ulList.style.padding = 0;
ulList.style.width = 500 + 'px';

addBtn = button.cloneNode(true);
addBtn.innerHTML = 'Add';
addBtn.addEventListener('click', function () {
    li = document.createElement('li'); 
    li.style.fontSize = 20 + 'px';    

    if (inputField.value !== '') {
        li.innerHTML = index + '. ' + inputField.value;
        ulList.appendChild(li);
        index++;
    } else {
        alert('Add some item first');
    }

    inputField.value = '';
}, false);

ulList.addEventListener('click', function (event) {
  console.log(event.target);
  if (event.target) {
    event.target.className = 'selected';
    event.target.style.background = '#D8CAF3';     
  } else {
    event.target.style.background = 'white';
    event.target.className = '';

  }
}, false);

h3.innerHTML = 'TODO:';

deleteBtn = button.cloneNode(true);
deleteBtn.innerHTML = 'Delete';
deleteBtn.addEventListener('click', function () {
  
  ulList.removeChild(li);
  
  index--;
}, false);

showHideBtn = button.cloneNode(true);
showHideBtn.innerHTML = 'Hide';
showHideBtn.style.marginLeft = 270 + 'px';
showHideBtn.addEventListener('click', function (ev) {
  if (ev.target.innerHTML == 'Hide') {
    ulList.style.display = 'none';
    ev.target.innerHTML = 'Show';
  } else {
    ulList.style.display = '';
    ev.target.innerHTML = 'Hide';
  }
}, false);

form.appendChild(label);
form.appendChild(addBtn);
form.appendChild(deleteBtn);
form.appendChild(showHideBtn);
form.appendChild(h3);
form.appendChild(ulList);

main.appendChild(form);

// HOVER OVER LI
// li.addEventListener('mouseover', function (ev) {
//       ev.target.style.textDecoration = 'underline';
// }, false);
// li.addEventListener('mouseout', function (ev) {
//       ev.target.style.textDecoration = 'none';
// }, false);

// li.addEventListener('click', function (ev) {
    //   ev.target.className = 'selected';
    //   ev.target.style.background = '#D8CAF3';

    //   // allLis = document.querySelectorAll('#todo li');
    //   // console.log(allLis);
    //   // for (i = 0, len = allLis.length; i < len; i += 1) {
    //   //     //var currLi = allLis.item(i);
    //   //     console.log(allLis.item(i));
    //   //     if (currLi.className !== 'selected') {
    //   //       currLi.style.background = '';
    //   //     }
    //   // }
    //   // 

    // }, false);