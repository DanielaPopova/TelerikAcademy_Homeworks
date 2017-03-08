module.exports = function solve() {
  return function (element, contents) {
    let domElement,
      content,
      div,
      docFragment = document.createDocumentFragment();

    if (typeof element !== 'string' && !(element instanceof HTMLElement)) {  //element.nodeType != 1
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

    for (let i = 0; i < contents.length; i += 1) {
      content = contents[i];

      if (typeof content !== 'string' && typeof content !== 'number') {
        throw new Error();
      }
    }

    domElement.innerHTML = '';
    div = document.createElement('div');

    for (let i = 0; i < contents.length; i += 1) {
      let currentDiv = div.cloneNode(true);

      currentDiv.innerHTML = contents[i];
      docFragment.appendChild(currentDiv);
    }

    domElement.appendChild(docFragment);
  };
};
