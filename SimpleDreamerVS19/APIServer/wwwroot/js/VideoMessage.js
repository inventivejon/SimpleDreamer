var VideoMessage = (function () {
    function VideoMessage() {
        this.Url = '';
        this.imageHeaders = '';
    }
    VideoMessage.prototype.AddData = function (url, imageHeaders) {
        this.Url = url;
        this.imageHeaders = imageHeaders;
    };
    return VideoMessage;
}());
//export { VideoMessage };
//# sourceMappingURL=VideoMessage.js.map