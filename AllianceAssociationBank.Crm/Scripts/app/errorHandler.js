var ErrorHandler = function ($) {

    var init = function () {
        bindAlertHideEvent();
    };

    var handleAjaxError = function (error) {

        var errorTitle = "Error";
        var errorMessage = "An error occurred while processing your request. Please try again later.";

        if (error && error.responseJSON) {
            var errorObj = error.responseJSON;

            if (errorObj.error && errorObj.message) {
                errorTitle = errorObj.error;
                errorMessage = errorObj.message;
            }
        }

        $alert = $("#top-alert");
        $alert.addClass("alert-danger");
        $alert.find(".js-alert-text").html("<strong>" + errorTitle + "!</strong> " + errorMessage);
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