var container = document.getElementsByTagName('main')[0];
var div = document.createElement('div');
div.style.borderStyle = 'solid';

var strongElement = document.createElement('strong');
strongElement.innerHTML = 'div';
strongElement.style.display = 'block';
strongElement.style.textAlign = 'center';

div.appendChild(strongElement);

var docFragment = document.createDocumentFragment();

for (i = 0; i < 10; i += 1) {
    var currDiv = div.cloneNode(true);
    currDiv.style.background = getRandomColor();
    currDiv.style.width = getRandomWidth() + 'px';
    currDiv.style.height = getRandomHeight() + 'px';
    currDiv.style.position = getRandomPosition();
    currDiv.firstChild.style.color = getRandomColor();
    currDiv.style.borderWidth = getRandomBorderWidth() + 'px';
    currDiv.style.borderColor = getRandomColor();
    currDiv.style.borderRadius = getRandomBorderRadius() + '%';

    currDiv.style.marginBottom = 20 + 'px';
    docFragment.appendChild(currDiv);
}

container.appendChild(docFragment);

function getRandomWidth() {
  var width,
      minWidth = 20,
      maxWidth = 100;

  width = (Math.random() * (maxWidth - minWidth + 1) | 0) + minWidth;

  return width;
}

function getRandomHeight() {
  var height,
      minHeight = 20,
      maxHeight = 100;

  height = (Math.random() * (maxHeight - minHeight + 1) | 0) + minHeight;

  return height;
}

function getRandomColor() {
  var letters = '0123456789ABCDEF'.split('');
  var color = '#';
  for (var i = 0; i < 6; i++) {
    color += letters[Math.floor(Math.random() * 16)];
  }
  return color;
}

function getRandomBorderWidth() {
  var borderWidth,
      borderMinWidth = 1,
      borderMaxWidth = 20;

  borderWidth = (Math.random() * (borderMaxWidth - borderMinWidth + 1) | 0) + borderMinWidth;

  return borderWidth;
}

function getRandomBorderRadius() {
  var borderRadius,
      borderMinRadius = 0,
      borderMaxRadius = 100;

  borderRadius = (Math.random() * (borderMaxRadius - borderMinRadius + 1) | 0) + borderMinRadius;

  return borderRadius;
}

function getRandomPosition() {
  var position, i,
      min = 0,
      max = 6,
      positionOptions = ['static', 'absolute', 'fixed', 'relative', 'initial', 'inherit'];  

  for (i = 0, len = positionOptions.length; i < len; i += 1) {
      position = positionOptions[(Math.random() * (max - min + 1) | 0) + min];
  }

  return position;
}
