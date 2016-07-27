var i,
    angle = 0,
    xcenter = 0,
    ycenter = 0,
    width = 50,
    height = 50,
    currDiv,
    div =  document.createElement('div'),
    docFragment = document.createDocumentFragment();

div.style.width = 15 + 'px';
div.style.height = 15 + 'px';
div.style.borderRadius = 50 + 'px';
div.style.background = 'blue';
div.style.margin = 70 + 'px';
div.style.position = 'relative'; //'absolute' would be appropriate for one element only

for (i = 0; i < 5; i += 1) {
    currDiv = div.cloneNode(true);    
    docFragment.appendChild(currDiv);
}

document.body.appendChild(docFragment);

var allDivsTag = document.getElementsByTagName('div');
for (i = 0, len = allDivsTag.length; i < len; i += 1) {
    currDiv = allDivsTag[i];
    move(currDiv);
}


function move(currDiv) {
  
  xcenter = width + width * Math.cos(angle * Math.PI / 180);
  ycenter = height + height * Math.sin(angle * Math.PI / 180);

  currDiv.style.left = xcenter + 'px';
  currDiv.style.top = ycenter + 'px';

  angle += 3;  //determines the speed
  if (angle > 360) {
    angle = 0;
  }  

  setTimeout(function () {
      move(currDiv);
  }, 100);
}


// First try - only last div moves
// function move() {
//   time += 0.1;

//   var radius = 50,
//       xcenter = 50,
//       ycenter = 50,
//       newLeft = Math.floor(xcenter + (radius * Math.cos(time)));
//       newTop = Math.floor(ycenter + (radius * Math.sin(time)));
//   
//   currDiv.style.left = newLeft;
//   currDiv.style.top = newTop;

//   setTimeout(function () {
//      move(currDiv);
//   }, 100);
// }

// static nodelist
// var allDivs = document.querySelectorAll('div');
// allDivs.forEach(function (currDiv) {
//   move(currDiv);
// });

