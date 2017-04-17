(function () {
    window.onload = function () {
        let div = document.getElementById('pop-up');
        setTimeout(function () {
            div.style.display = 'block';
        }, 500);
    }

    let promise = new Promise(function(resolve, reject){
        setTimeout(function(){
            resolve();            
        }, 2000);
    });

    promise.then(function(){
        window.location = 'http://www.boredpanda.com/';
    });
}())
