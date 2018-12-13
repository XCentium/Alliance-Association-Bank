var AjaxHelper = function ($) {

    var LOADING_ELEMENT_CONTAINER = ".loading-element-container";

    var showLoadingAnimation = function () {
        $loading = $(LOADING_ELEMENT_CONTAINER);
        $loading.show();
    };

    var hideLoadingAnimation = function () {
        var hideLoading = function () {
            $loading = $(LOADING_ELEMENT_CONTAINER);
            $loading.hide("fade", 100);
        };

        setTimeout(hideLoading, 1000);
    };

    return {
        showLoadingAnimation: showLoadingAnimation,
        hideLoadingAnimation: hideLoadingAnimation
    };

}(jQuery);