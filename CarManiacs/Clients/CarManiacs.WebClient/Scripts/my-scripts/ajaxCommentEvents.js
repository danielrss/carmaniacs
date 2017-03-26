function onSuccess() {
    //clear comment input
    $('#comment-input').val('');

    var commentsHeadingEl = $('.comments-heading');
    if (commentsHeadingEl.text() === 'No comments') {
        commentsHeadingEl.text('Comments');
    }

    //clear validation errors
    var errorsEl = $('.validation-summary-errors');
    if (errorsEl) {
        $($(errorsEl.children()[0]).children()[0]).remove();
    }
}