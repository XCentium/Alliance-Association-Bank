var ErrorHandler = function ($) {

    var handleAjaxError = function (ajaxContext) {
        //alert("An error occurred while processing your request");
        $("#ajax-error-alert").removeClass("invisible");
    };

    return {
        handleAjaxError: handleAjaxError
    };

}(jQuery);