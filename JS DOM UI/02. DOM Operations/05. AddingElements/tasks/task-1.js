module.exports = function solve() {
   return function (element, contents) {
   
    if (typeof element !== 'string' && !(element instanceof HTMLElement)) {  //element.nodeType != 1
      throw new Error('Provided element must be a valid string id or DOM element!');
    }

    let domElement;

    if (typeof element === 'string') {
      domElement = document.getElementById(element);

      if (domElement === null) {
        throw new Error('There is no such DOM element with that id!');
      }

    } else {
      domElement = element;
    }

    for (let i = 0, len = contents.length; i < len; i += 1) {
      let currContent = contents[i];

      if (typeof currContent !== 'string' && typeof currContent !== 'number') {
        throw new Error('Invalid contents type!');
      }
    }

    domElement.innerHTML = '';
    let div = document.createElement('div'),
        docFragment = document.createDocumentFragment();

    for (let i = 0, len = contents.length; i < len; i += 1) {
      let currentDiv = div.cloneNode(true);

      currentDiv.innerHTML = contents[i];
      docFragment.appendChild(currentDiv);
    }

    domElement.appendChild(docFragment);
  };
};
