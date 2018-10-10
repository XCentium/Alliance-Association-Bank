var ErrorHandler = function ($) {

    var init = function () {
        bindAlertHideEvent();
    };

    var handleAjaxError = function (ajaxContext) {
        //alert("An error occurred while processing your request");
        $alert = $("#top-alert");
        $alert.addClass("alert-danger");
        $alert.find(".js-alert-text").html("<strong>Oops!</strong> An error occurred while processing your request. Please try again later.");
        $alert.show("fade", 200);
    };

    var bindAlertHideEvent = function () {
        $(".js-btn-hide-alert").on("click", function () {
            var $alertTarget = $($(this).data("hide-target"));
            $alertTarget.hide("fade", 200);
        });
    };

    return {
        init: init,
        handleAjaxError: handleAjaxError
    };

}(jQuery);