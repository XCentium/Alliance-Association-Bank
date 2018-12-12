var AjaxHelper = function ($) {

    var LOADING_ELEMENT_CONTAINER = ".loading-element-container";

    var showLoadingAnimation = function () {
        $loading = $(LOADING_ELEMENT_CONTAINER);
        $loading.show();
    };

    var hideLoadingAnimation = function () {
        $loading = $(LOADING_ELEMENT_CONTAINER);
        $loading.hide("fade", 1000);
        //var hideElement = function (element) {
        //    $loadingElement = $($(element).data("loading-element-id"));
        //    $loadingElement.hide("fade", 1000);
        //};
        //setTimeout(hideElement, 200, this);
    };

    return {
        showLoadingAnimation: showLoadingAnimation,
        hideLoadingAnimation: hideLoadingAnimation
    };

}(jQuery);