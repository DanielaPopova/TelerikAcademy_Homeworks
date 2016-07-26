var textArea = document.getElementsByTagName('textarea')[0];
var firstColorBox = document.getElementsByTagName('input')[0];
var secondColorBox = document.getElementsByTagName('input')[1];

firstColorBox.addEventListener('change', setFontColor);
secondColorBox.addEventListener('change', setBackground);

function setFontColor() {
  var firstColorBoxColor = firstColorBox.value;
  textArea.style.color = firstColorBoxColor;
}

function setBackground() {
  var secondColorBoxColor = secondColorBox.value;
  textArea.style.background = secondColorBoxColor;
}
