
$(function () {
    $('#slideshow').cycle({
        fx: 'turnRight',
        speed: 'slow',
        timeout: 2000,
        pager: '#nav',
        slideExpr: 'img'
    });
});