var DatePickerWidget = function ($) {

    var classJsDatePicker = ".js-date-picker";
    var classModal = ".modal";
    var eventModalShown = "shown.bs.modal";

    var init = function () {
        enableDatePicker();
        bindDateInputMask();
        addPlaceholderAttribute();
    };

    var enableDatePicker = function () {
        $(classJsDatePicker).datepicker();

        // initialize a datepicker for date input elements that are inside of modal
        $("body").on(eventModalShown, classModal, function () {
            $(classJsDatePicker).datepicker();
        });
    };

    var bindDateInputMask = function () {
        $("body").on("keyup", classJsDatePicker, function () {
            var replacer = function (match, p1, p2, p3, offset, string) {
                var returnValue = p1 + "/";
                if (p2) {
                    returnValue = returnValue + p2 + "/";
                }
                if (p3) {
                    returnValue = returnValue + p3;
                }
                return returnValue;
            };

            this.value = this.value.replace(/^(\d{2})[-\/]?(\d{2})?[-\/]?(\d{4})?$/, replacer);
        });
    };

    var addPlaceholderAttribute = function () {
        $(classJsDatePicker).attr("placeholder", "mm/dd/yyyy");

        // add placeholder for date input elements that are inside of modal
        $("body").on(eventModalShown, classModal, function () {
            $(classJsDatePicker).attr("placeholder", "mm/dd/yyyy");
        });
    };

    return {
        init: init
    };

}(jQuery);