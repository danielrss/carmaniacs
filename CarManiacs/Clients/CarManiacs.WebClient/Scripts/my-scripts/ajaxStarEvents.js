function onAjaxComplete(request, status) {
    try {
        if (JSON.parse(request.responseText).success == false) {
            window.location.replace("/account/login");
        }
    } catch (e) {

    }
}

function onAjaxSuccess(data) {
    var starEl = $("#star-link");
    if (starEl.hasClass("fa-star-o")) {
        starEl.removeClass("fa-star-o");
        starEl.addClass("fa-star");
    } else {
        starEl.removeClass("fa-star");
        starEl.addClass("fa-star-o");
    }
}