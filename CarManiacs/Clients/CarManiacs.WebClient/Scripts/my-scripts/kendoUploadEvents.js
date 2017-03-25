function onImageUploadSuccess(e) {
    location.reload();
}

function onImageUploadError(e) {
    var response = e.XMLHttpRequest.response;
    $('#upload-hint').html('<strong>' + response + '</strong>');
}