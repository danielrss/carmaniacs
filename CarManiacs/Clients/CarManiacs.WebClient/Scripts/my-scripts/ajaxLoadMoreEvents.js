function onAjaxComplete(request, status) {
    try {
        //if no more elements to load
        if (JSON.parse(request.responseText).success === false) {
            $($('#load-more')[0]).hide();
        } else {
            var loadMoreHref = $($('#load-more')[0]).attr('href');
            var newPage = +loadMoreHref.substring(loadMoreHref.lastIndexOf('/') + 1, loadMoreHref.length) + 1;
            var newHref = loadMoreHref.substring(0, loadMoreHref.lastIndexOf('/') + 1) + newPage;
            $($('#load-more')[0]).attr('href', newHref);
        }
    } catch (e) {
        var loadMoreHref = $($('#load-more')[0]).attr('href');
        var newPage = +loadMoreHref.substring(loadMoreHref.lastIndexOf('/') + 1, loadMoreHref.length) + 1;
        var newHref = loadMoreHref.substring(0, loadMoreHref.lastIndexOf('/') + 1) + newPage;
        $($('#load-more')[0]).attr('href', newHref);
    }
}