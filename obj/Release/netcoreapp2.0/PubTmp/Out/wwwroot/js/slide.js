//layout slideshow
! function ($) {
    "use strict";
    var slide = $("[data-slides]"),
        count = 0,
        slides = slide.data("slides"),
        len = slides.length,
        n = function () {
            if (count >= len) {
                count = 0
            }
            slide.fadeTo(100, 0.7, function () {
                slide.css("background-image", 'url("' + slides[count - 1] + '")')
                    .show(0, function () {
                        setTimeout(n, 3000)
                    });;
            }).fadeTo(500, 1);
            count++;
        };
    n();
}(jQuery);