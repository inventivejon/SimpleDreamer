"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/zub").build();

//Disable send button until connection is established
var CanvasElement = document.getElementById("signalRImgs");
CanvasElement.disabled = true;

function displayNextImage() {

    if (x >= (images.length - 1)) {
        console.log('No new picture');
    }
    else {
        x++;
        CanvasElement.src = images[x];
        console.log('Set received picture as source');
    }
}

function startTimer() {
    setInterval(displayNextImage, 3000);
}

var images = [], x = -1;

connection.on('ImageMessage', (data) => {
    console.log(data);
    this.images.push(data.imageHeaders + data.imageBinary);
    console.log('images length is now:' + this.images.length);
    console.log(this.images);
});

connection.start().then(function () {
    CanvasElement.disabled = false;
    startTimer();
}).catch(function (err) {
    return console.error(err.toString());
});