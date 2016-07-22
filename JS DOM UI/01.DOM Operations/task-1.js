/* globals $ */

/* 

Create a function that takes an id or DOM element and an array of contents

* if an id is provided, select the element
* Add divs to the element
  * Each div's content must be one of the items from the contents array
* The function must remove all previous content from the DOM element provided
* Throws if:
  * The provided first parameter is neither string or existing DOM element
  * The provided id does not select anything (there is no element that has such an id)
  * Any of the function params is missing
  * Any of the function params is not as described
  * Any of the contents is neight `string` or `number`
    * In that case, the content of the element **must not be** changed   
*/

function solve() {
  return function(element, contents) {
      var i,
          domElement,
          content,
          div,
          currentDiv,
          len = contents.length;
          docFragment = document.createDocumentFragment();

      if (typeof element  !== 'string' && !(element instanceof HTMLElement)) {  //element.nodeType != 1
        throw new Error();
      }

      if (typeof element === 'string') {
        domElement = document.getElementById(element);
        if (!domElement) {
          throw new Error();
        }
      } else {
        domElement = element;
      }

      for (i = 0; i < len; i += 1) {
        content = contents[i];

        if (typeof content  !== 'string' && typeof content !== 'number') {
          throw new Error();
        }
      }

      domElement.innerHTML = '';
      div = document.createElement('div');

      for (i = 0; i < len; i += 1) {
          currentDiv = div.cloneNode(true);
          currentDiv.innerHTML = contents[i];
          docFragment.appendChild(currentDiv);
      }

      domElement.appendChild(docFragment);

    };
 }

module.exports = solve();