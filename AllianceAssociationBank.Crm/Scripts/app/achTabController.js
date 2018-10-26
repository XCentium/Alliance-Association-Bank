var AchTabController = function ($) {

    var init = function () {
        $(".js-uncheck-radio").on("click", uncheckRadioButton);
    };

    var lastCheckedRadio;

    var uncheckRadioButton = function (e) {
        var radio = e.target;
        if (lastCheckedRadio === radio) {
            radio.checked = false;
            lastCheckedRadio = null;
        } else {
            lastCheckedRadio = radio;
        }
    };

    return {
        init: init
    };

}(jQuery);