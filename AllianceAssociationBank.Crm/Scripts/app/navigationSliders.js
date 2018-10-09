var NavigationSliders = function ($) {

    var init = function () {
        bindDataToggleEvents();
        bindScreenOverlayFadeOut();
    };

    var bindDataToggleEvents = function () {
        $('[data-toggle="slide-collapse-right"]').on("click", function () {
            var $toggleTarget = $($(this).data("target"));
            $toggleTarget.show("slide");
            screenOverlayFadeIn(500);
        });

        $('[data-toggle="slide-collapse-down"]').on("click", function () {
            var $toggleTarget = $($(this).data("target"));
            $toggleTarget.show("blind", 250);
            screenOverlayFadeIn(250);
        });
    };

    var bindScreenOverlayFadeOut = function () {
        $(".screen-overlay").on("click", function (event) {
            $("#nav-side-menu").hide("slide");
            $("#project-search").val("");
            $("#search-widget").hide("blind", 250);
            $(this).fadeOut(500);
        });
    };

    var screenOverlayFadeIn = function (duration) {
        $(".screen-overlay").fadeIn(duration);
    };

    return {
        init: init
    };

}(jQuery);