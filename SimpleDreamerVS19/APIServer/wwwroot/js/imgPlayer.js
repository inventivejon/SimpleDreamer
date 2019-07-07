"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/zub").build();

//Disable send button until connection is established
var CanvasElement = document.getElementById("signalRImgs");
CanvasElement.disabled = true;

connection.on('ImageMessage', (data) => {
    console.log(data);
    CanvasElement.src = data.imageHeaders + data.imageBinary;
});

connection.start().then(function () {
    CanvasElement.disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});