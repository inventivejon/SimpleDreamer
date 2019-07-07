"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("http://localhost:48445/zub").build();

//Disable send button until connection is established
var CanvasElement = document.getElementById("signalRImgs");
var ctx = CanvasElement.getContext('2d');
CanvasElement.disabled = true;

connection.on('ImageMessage', (data) => {
    console.log(data);
    ctx.drawImage(data, 0, 0, canvas.width, canvas.height);
    //this.images.push(data);
});

connection.start().then(function () {
    CanvasElement.disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});