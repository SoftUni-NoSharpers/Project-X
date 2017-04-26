$(document).ready(function () {
    $('body').append('<div id="toTop" class="btn btn-primary"><span class="glyphicon glyphicon-chevron-up"></span> </div>');
    $(window).scroll(function () {
        if ($(this).scrollTop() != 0) {
            $('#toTop').fadeIn();
        } else {
            $('#toTop').fadeOut();
        }
    });
    $('#toTop').click(function () {
        $("html, body").animate({ scrollTop: 0 }, 600);
        return false;
    });
});

