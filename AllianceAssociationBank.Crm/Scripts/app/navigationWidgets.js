var NavigationWidgets = function ($) {

    var init = function () {
        bindDataToggleEvents();
        bindTabBottonNavigationEvents();
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

    var bindTabBottonNavigationEvents = function () {
        $("#btn-change-tab-left").on("click", function () {
            $('.nav-tabs > .active').prev('a').trigger('click');
        });

        $("#btn-change-tab-right").on("click", function () {
            $('.nav-tabs > .active').next('a').trigger('click');
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