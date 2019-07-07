var ImageMessage = (function () {
    function ImageMessage() {
        this.imageBinary = '';
        this.imageHeaders = '';
    }
    ImageMessage.prototype.AddData = function (imageBinary, imageHeaders) {
        this.imageBinary = imageBinary;
        this.imageHeaders = imageHeaders;
    };
    return ImageMessage;
}());
//export { ImageMessage };
//# sourceMappingURL=imagemessage.js.map