/* globals $ */

/* 

Create a function that takes an id or DOM element and:

If an id is provided, select the element
Finds all elements with class button or content within the provided element
    Change the content of all .button elements with "hide"
When a .button is clicked:
    Find the topmost .content element, that is before another .button and:
        If the .content is visible:
            Hide the .content
            Change the content of the .button to "show"
        If the .content is hidden:
            Show the .content
            Change the content of the .button to "hide"
        If there isn't a .content element after the clicked .button and before other .button, do nothing
Throws if:
    The provided DOM element is non-existant
    The id is neither a string nor a DOM element

*/

function solve(){
  return function (selector) {
    var i, 
        domElement,
        allButtons,
        allButtonsLength,
        currButton;

    if (typeof selector !== 'string' && selector.nodeType != 1) {
      throw new Error();
    }

    if (typeof selector === 'string') {
      domElement = document.getElementById(selector);

        if (!domElement) {
          throw new Error();
        }

    } else {
      domElement = selector;
    }    

    allButtons = domElement.querySelectorAll('.button');
    allButtonsLength = allButtons.length;

    for (i = 0; i < allButtonsLength; i += 1) {
        currButton = allButtons.item(i);
        currButton.textContent = 'hide';
    }

    domElement.addEventListener('click', onElementClick, false);

    function onElementClick(event) {
      var nextElement,
          clickedButton;

      if (event.target.className == 'button') {
          clickedButton = event.target;
          nextElement = clickedButton.nextElementSibling;

          if (nextElement.className == 'content' && nextElement.nextElementSibling.className == 'button') {
              if (nextElement.style.display != 'none') {
                nextElement.style.display = 'none';
                clickedButton.innerHTML = 'show';
              } else {
                nextElement.style.display = '';
                clickedButton.innerHTML = 'hide';
              }
          }
      }
    }

  };
}

//module.exports = solve;