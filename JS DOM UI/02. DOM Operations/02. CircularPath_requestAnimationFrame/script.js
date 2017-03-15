(function () {
    let docFragment = document.createDocumentFragment(),
        main = document.getElementsByTagName('main')[0],
        div = document.createElement('div');
                
    div.style.width = '20px';
    div.style.height = '20px';
    div.style.background = 'red';
    div.style.borderRadius = '50px';
    div.style.margin = 70 + 'px';
    div.style.position = 'relative';

    for (let i = 0; i < 5; i += 1) {
        let currDiv = div.cloneNode(true);
        docFragment.appendChild(currDiv);
    }

    main.appendChild(docFragment);

    let allDivs = document.getElementsByTagName('div');
    for (let i = 0; i < allDivs.length; i += 1) {
        let currDiv = allDivs[i],
            angle = 0,
            xcenter = 0,
            ycenter = 0,
            width = 50,
            height = 50;

        function moveDiv(timestamp) {
            xcenter = width + width * Math.cos(angle * Math.PI / 180);
            ycenter = height + height * Math.sin(angle * Math.PI / 180);

            currDiv.style.left = xcenter + 'px';
            currDiv.style.top = ycenter + 'px';

            angle += 3;  //determines the speed
            if (angle > 360) {
                angle = 0;
            }

            requestAnimationFrame(moveDiv);
        }

        requestAnimationFrame(moveDiv);
    }
}())
