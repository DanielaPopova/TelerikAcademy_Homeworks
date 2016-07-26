
var div,
    span,
    currSpan,
    key,
    value,    
    container = document.getElementById('container'),
    inputField = document.getElementById('tags'),
    textField = document.getElementsByTagName('textarea')[0],
    enterButton = document.getElementsByTagName('button')[0],
    gnrtButton = document.getElementsByTagName('button')[1],
    fragment = document.createDocumentFragment(),
    minFontSize = 16,
    allTags = [],
    occurences = {}; 

enterButton.addEventListener('click', function () { 
  textField.value += inputField.value + ' ';
  allTags.push(inputField.value);
  inputField.value = '';
});

div = document.createElement('div');

span = document.createElement('span');
span.style.fontSize = minFontSize;
span.style.marginRight = 5 + 'px';

gnrtButton.addEventListener('click', function () { 
  occurences = countOccerences(allTags);

  for (key in occurences) {
    if (occurences.hasOwnProperty(key)) {
        value = occurences[key];
        currSpan = span.cloneNode(true);
        currSpan.innerHTML = key;
        currSpan.style.fontSize = minFontSize * value + 'px';

        fragment.appendChild(currSpan);
    }
  }

  div.appendChild(fragment);
  container.appendChild(div);
});

function countOccerences(array) {
  var i,
      currTag,
      counts = {};

  for (i = 0, len = array.length; i < len; i += 1) {
      currTag = array[i];
      counts[currTag] = counts[currTag] ? counts[currTag] + 1 : 1;
  }

  return counts;
}