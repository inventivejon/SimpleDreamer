"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/streamingHub").build();

var myplayer = document.getElementById("my-player");
var mySrcplayer = document.getElementById("src-player");
myplayer.disabled = true;

connection.start().then(function () {
    myplayer.disabled = false;
    console.log('Connected to streaming hook');
}).catch(function (err) {
    return console.error(err.toString());
});

connection.on('VideoMessage', (data) => {
    console.log(data.url);
    mySrcplayer.setAttribute("src", data.url);
    myplayer.load();
    myplayer.play();
});