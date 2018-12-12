var AjaxHelper = function ($) {

    var LOADING_ELEMENT_CONTAINER = ".loading-element-container";

    var showLoadingAnimation = function () {
        $loading = $(LOADING_ELEMENT_CONTAINER);
        $loading.show();
    };

    var hideLoadingAnimation = function () {
        $loading = $(LOADING_ELEMENT_CONTAINER);
        $loading.hide("fade", 1000);
    };

    return {
        showLoadingAnimation: showLoadingAnimation,
        hideLoadingAnimation: hideLoadingAnimation
    };

}(jQuery);