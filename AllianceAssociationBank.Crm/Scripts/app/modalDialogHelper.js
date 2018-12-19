var ModalDialogHelper = function ($, errorHandler) {

    var showModalDialog = function () {
        $modalTarget = $($(this).data("modal-target"));

        if ($modalTarget.length) {
            $modalTarget.modal("show");

            var $form = $modalTarget.find("form").first();
            if ($form.length) {
                parseFormValidation($form);
            }
        } else {
            errorHandler.handleAjaxError();
        }
    };

    var hideModalDialog = function () {
        $modalTarget = $($(this).data("modal-target"));

        if ($modalTarget.length) {
            $modalTarget.modal("hide");
        } else {
            errorHandler.handleAjaxError();
        }
    };

    var disableFormSubmitButton = function () {
        var $btn = $(this).find("button[type='submit']");

        if ($btn.length) {
            $btn.text("Saving...");
            $btn.attr("disabled", true);
        }
    };

    var disableDeleteLink = function () {
        var $link = $(this);
        $link.text("Deleting...");
        $link.addClass("btn-link-disabled");
    };

    var disableLinkButton = function () {
        var $link = $(this);
        $link.addClass("btn-link-disabled");
    };

    var enableLinkButton = function () {
        var $link = $(this);
        $link.removeClass("btn-link-disabled");
    };

    var parseFormValidation = function ($form) {
        $.validator.unobtrusive.parse($form);
    };

    return {
        showModalDialog: showModalDialog,
        hideModalDialog: hideModalDialog,
        disableFormSubmitButton: disableFormSubmitButton,
        disableDeleteLink: disableDeleteLink,
        disableLinkButton: disableLinkButton,
        enableLinkButton: enableLinkButton
    };

}(jQuery, ErrorHandler);