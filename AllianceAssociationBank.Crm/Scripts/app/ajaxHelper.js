var AjaxHelper = function ($) {

    var showLoadingAnimation = function () {
        $loadingElement = $($(this).data("loading-element-id"));
        $loadingElement.show();
    };

    var hideLoadingAnimation = function () {
        var hideElement = function (element) {
            $loadingElement = $($(element).data("loading-element-id"));
            $loadingElement.hide();
        };
        setTimeout(hideElement, 2000, this);
    };

    return {
        showLoadingAnimation: showLoadingAnimation,
        hideLoadingAnimation: hideLoadingAnimation
    };

}(jQuery);