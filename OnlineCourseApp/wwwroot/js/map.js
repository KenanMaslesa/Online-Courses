

//firebase
var firebaseConfig = {
    apiKey: "AIzaSyCh7SRumUntvWT3UB21KuZ0l5q9wf_vzfE",
    authDomain: "rs1-seminarski.firebaseapp.com",
    databaseURL: "https://rs1-seminarski-default-rtdb.firebaseio.com/",
    projectId: "rs1-seminarski",
    storageBucket: "rs1-seminarski.appspot.com",
    messagingSenderId: "1087808271486",
    appId: "1:1087808271486:web:3506c295050907a1e7542f"
};

// Initialize Firebase
firebase.initializeApp(firebaseConfig);

//create firebase database reference
var mapRef = firebase.database().ref('map');


var today = new Date();
var date = today.getDate() + '.' + (today.getMonth() + 1)+ '.' + today.getFullYear() + '.';
var time = today.getHours() + ":" + today.getMinutes() + ":" + today.getSeconds();
var dateTime = date + ' ' + time;

if (sessionStorage.getItem('firstLoad')) {

}
else {
    //first load
    navigator.geolocation.getCurrentPosition(successLocation, locationByIPAddress, { enableHighAccuracy: true });
    sessionStorage.setItem('firstLoad', true);
}

function successLocation(position) {
    currentPosition = position;
    latitude = position.coords.latitude,
        longitude = position.coords.longitude,
        mapRef.push({
            latitude: latitude,
            longitude: longitude,
            username: $('#username').html(),
            dateTime: dateTime
        });
}

function locationByIPAddress() {
    $.getJSON('https://api.ipdata.co/?api-key=aa05d607607426d1d15ebefd1d5344fd64dfd02e8362659fdf6681bd', function (data) {
        mapRef.push({
            latitude: data.latitude,
            longitude: data.longitude,
            username: $('#username').html(),
            dateTime: dateTime
        });
    });
}


L.mapbox.accessToken = 'pk.eyJ1Ijoia2VuYW5tYXNsZXNhIiwiYSI6ImNranVrZmJ3YzIwdWgyeWwxdnc0N3c1eWEifQ.NU5jwn8auapNwbJVrjKTfg';
var map = L.mapbox.map('map')
    .addLayer(L.mapbox.styleLayer('mapbox://styles/mapbox/streets-v11'));

var myLayer = L.mapbox.featureLayer().addTo(map);


// Add custom popup html to each marker.
myLayer.on('layeradd', function (e) {
    var marker = e.layer;
    var feature = marker.feature;


    // Create custom popup content
    var popupContent = '<div id="' + feature.properties.id + '" class="popup">' +
        '<h2><strong>' + feature.properties.username + '</strong></h2>' +
        '<h2>' + feature.properties.dateTime + '</h2>' +
        '</div>'
    '</div>';

    marker.bindPopup(popupContent, {
        closeButton: false,
        minWidth: 150
    });
});


map.setView([40.6521, 17.96], 5);

var geoJson = {
    "type": "FeatureCollection",
    "features": []
};
//add markers to map
mapRef.on("child_added", function (snap) {
    var obj = snap.val();

    geoJson.features.push({
        "type": "Feature", "geometry": { "type": "Point", "coordinates": [obj.longitude, obj.latitude] }, "properties": {
            'marker-color': '#3c4e5a',
            'username': [obj.username],
            'dateTime': [obj.dateTime]
        }
    });

    // Add features to the map
    myLayer.setGeoJSON(geoJson);

});

