function onSuccess() {
    $('#comment-input').val('');

    var commentsHeadingEl = $('.comments-heading');
    if (commentsHeadingEl.text() === 'No comments') {
        commentsHeadingEl.text('Comments');
    }
    var errorsEl = $('.validation-summary-errors');
    if (errorsEl) {
        $($(errorsEl.children()[0]).children()[0]).remove();
    }
}