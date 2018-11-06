var NavigationWidgets = function ($) {

    var init = function () {
        bindDataToggleEvents();
        bindTabBottomNavigationEvents();
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

    var disableTabBottonNavigationButton = function () {
        $previousTab = $(".nav-tabs > .active").prev("a");
        $nextTab = $(".nav-tabs > .active").next("a");

        if ($previousTab.length === 0) {
            $("#btn-change-tab-left").attr("disabled", true);
        } else {
            $("#btn-change-tab-left").removeAttr("disabled");
        }

        if ($nextTab.length === 0) {
            $("#btn-change-tab-right").attr("disabled", true);
        } else {
            $("#btn-change-tab-right").removeAttr("disabled");
        }
    }

    var bindTabBottomNavigationEvents = function () {
        $(".nav-tabs").on("shown.bs.tab", disableTabBottonNavigationButton);

        $("#btn-change-tab-left").on("click", function () {
            // disable the button a for short period so click event can be fully handled
            //this.disabled = true;
            $(".nav-tabs > .active").prev("a").trigger("click");
            //enableElementAfterTimeout(this, 200);
        });

        $("#btn-change-tab-right").on("click", function () {
            //this.disabled = true;
            $(".nav-tabs > .active").next("a").trigger("click");
            //enableElementAfterTimeout(this, 200);
        });
    };

    //var enableElementAfterTimeout = function (e, timeout) {
    //    var enableElement = function (e) {
    //        e.removeAttribute("disabled");
    //    };
    //    setTimeout(enableElement, timeout, e);
    //}

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