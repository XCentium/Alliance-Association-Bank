var InputMaskHelper = function ($) {

    var init = function () {
        bindUsaZipCodeInputMask();
        bindPhoneInputMask();
        bindTinInputMask();
    };

    var bindUsaZipCodeInputMask = function () {
        $(".body-content").on("keyup", ".js-zipcode-mask", function () {
            this.value = this.value.replace(/^([0-9]{5})-?([0-9]{4})$/, '$1-$2');
        });
    };

    var bindPhoneInputMask = function () {
        $(".body-content").on("keyup onchange", ".js-phone-mask", function () {
            this.value = this.value.replace(/^1?[ .-]?\(?([0-9]{3})\)?[ .-]?([0-9]{3})[ .-]?([0-9]{4})/, '($1) $2-$3');
        });
    };
    
    var bindTinInputMask = function () {
        $(".body-content").on("keyup", "#TIN", function () {
            this.value = this.value.replace(/^([0-9]{2})-?([0-9]{7})$/, '$1-$2');
        });
    };


    return {
        init: init
    };

}(jQuery);