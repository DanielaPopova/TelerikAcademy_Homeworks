(function(){
    let output = document.getElementById("my-location");    
    let btn = document.getElementById('get-location');
    btn.addEventListener('click', function () {
        let getLocation = new Promise(function (resolve, reject) {      

            if (!navigator.geolocation) {
                output.innerHTML = "<p>Geolocation is not supported by your browser</p>";
                return;
            }

            navigator.geolocation.getCurrentPosition(resolve, reject);
        });

        output.innerHTML = "<p>Locating…</p>";

        getLocation.then(function (position) {
            let latitude = position.coords.latitude;
            let longitude = position.coords.longitude;

            output.innerHTML = '<p>Latitude is ' + latitude.toFixed(5) + '° <br>Longitude is ' + longitude.toFixed(5) + '°</p>';

            let img = new Image();
            img.src = `https://maps.googleapis.com/maps/api/staticmap?center=${latitude},${longitude}
                        &zoom=18
                        &size=400x400
                        &markers=color:red%7Clabel:HHH%7C${latitude},${longitude}
                        &sensor=false`;

            output.appendChild(img);
        },
            function (error) {
                output.innerHTML = "Unable to retrieve your location";
            }
        );
    });
}())