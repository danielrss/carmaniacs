function onImageUploadSuccess(e) {
    //reload to see changes
    location.reload();
}

function onImageUploadError(e) {
    //show error
    var response = e.XMLHttpRequest.response;
    $('#upload-hint').html('<strong>' + response + '</strong>');
}