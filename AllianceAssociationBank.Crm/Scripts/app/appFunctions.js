//$(function () {

//    // Reset save indicator on any form change
//    $("#project-form-element").on("change", function () {
//        var $saveIndicator = $("#project-form-save-indicator");
//        if ($saveIndicator.text() === "SAVED") {
//            $saveIndicator.text("UNSAVED");
//            $saveIndicator.removeClass("badge-success").addClass("badge-light");
//        }
//    });

//});

//function showModalTarget() {
//    $modalTarget = $($(this).data("modal-target"));

//    if ($modalTarget.length) {
//        $modalTarget.modal("show");

//        var $form = $modalTarget.find("form").first();
//        if ($form.length) {
//            validatorParseForm($form);
//        }
//    } else {
//        handleAjaxError();
//    }
//}

//function hideModalTarget() {
//    $modalTarget = $($(this).data("modal-target"));

//    if ($modalTarget.length) {
//        $modalTarget.modal("hide");
//    } else {
//        handleAjaxError();
//    }
//}

//function emailListCopyToClipboard() {
//    $("#users-email-list-textarea").select();
//    document.execCommand("copy");
//}

//function validatorParseForm(form) {
//    $.validator.unobtrusive.parse(form);
//}

//function handleAjaxError() {
//    alert("An error occurred while processing your request");
//}