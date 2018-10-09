var ErrorHandler = function () {

    var handleAjaxError = function (ajaxContext) {
        alert("An error occurred while processing your request");
    };

    return {
        handleAjaxError: handleAjaxError
    };

}();