function onAjaxComplete(request, status) {
    try {
        var starEl = null;
        //if user is not logged in -> redirect to login
        if (JSON.parse(request.responseText).success === false) {
            window.location.replace("/account/login");
        } else {
            //change star icon
            starEl = $("#star-link");
            if (starEl.hasClass("fa-star-o")) {
                starEl.removeClass("fa-star-o");
                starEl.addClass("fa-star");
            } else {
                starEl.removeClass("fa-star");
                starEl.addClass("fa-star-o");
            }
        }
    } catch (e) {
        //change star icon
        starEl = $("#star-link");
        if (starEl.hasClass("fa-star-o")) {
            starEl.removeClass("fa-star-o");
            starEl.addClass("fa-star");
        } else {
            starEl.removeClass("fa-star");
            starEl.addClass("fa-star-o");
        }
    }
}