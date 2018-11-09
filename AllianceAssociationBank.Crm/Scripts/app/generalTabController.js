var GeneralTabController = function ($) {

    var init = function () {
        bindPrintFormContentEvent();
        bindMailingSameAsPhysicalChangeEvent();
        initSetMailingOnPhysicalAddressChange();
        setSameAsPhysicalCheckboxOnLoad();
        toggleLockboxSystemDisabled();
        bindResetSaveIdicatorOnChangeEvent();
    };

    var bindPrintFormContentEvent = function () {
        $("#btn-print-form-content").on("click", function () {
            window.print();
            window.close;
        });
    };

    // Set Same As Physical checkbox to true if Mailing and Physical are populated with the same address
    var setSameAsPhysicalCheckboxOnLoad = function () {
        var $sameAsPhysical = $("#MailingSameAsPhysical");

        if ($("#Address").val() !== $("#MailingAddress").val() ||
            $("#City").val() !== $("#MailingCity").val() ||
            $("#State").val() !== $("#MailingState").val() ||
            $("#ZipCode").val() !== $("#MailingZipCode").val()) {
            $sameAsPhysical.attr("checked", false);
        } else {
            $sameAsPhysical.attr("checked", true).trigger("change");
        }
    };

    // Handle Same As Physical checkbox changes
    var bindMailingSameAsPhysicalChangeEvent = function () {
        $("#MailingSameAsPhysical").on("change", function () {
            setMailingAddress(this.checked, "#MailingAddress", "#Address");
            setMailingAddress(this.checked, "#MailingCity", "#City");
            setMailingAddress(this.checked, "#MailingState", "#State");
            setMailingAddress(this.checked, "#MailingZipCode", "#ZipCode");
        });
    };

    var setMailingAddress = function (sameAsPhysical, mailingElementId, physicalElementId) {
        var $mailingElement = $(mailingElementId);

        if (sameAsPhysical) {
            $mailingElement.val($(physicalElementId).val());
            $mailingElement.attr("readonly", true);
        } else {
            $mailingElement.val("");
            $mailingElement.removeAttr("readonly");
        }
    };

    // Handle changes to Physical Address by updating Mailing Address when Same As Physical checkbox is checked
    var initSetMailingOnPhysicalAddressChange = function () {
        bindPhysicalAddressElementChangeEvent("#Address", "#MailingAddress");
        bindPhysicalAddressElementChangeEvent("#City", "#MailingCity");
        bindPhysicalAddressElementChangeEvent("#State", "#MailingState");
        bindPhysicalAddressElementChangeEvent("#ZipCode", "#MailingZipCode");
    };

    var bindPhysicalAddressElementChangeEvent = function (physicalElementId, mailingElementId) {
        $(physicalElementId).on("change", function () {
            if ($("#MailingSameAsPhysical").is(":checked")) {
                $(mailingElementId).val(this.value);
            }
        });
    };

    // Set Lockbox System field as disabled if Lockbox Status is set to 'No Lockbox'
    var toggleLockboxSystemDisabled = function () {
        var noLockbox = "No Lockbox";
        var lockboxSystemElementId = "#LockboxSystem";

        var $status = $("#LockboxStatus");

        if ($status.val() === noLockbox) {
            disableElementById(lockboxSystemElementId);
        }

        $status.on("change", function () {
            if (this.value === noLockbox) {
                disableElementById(lockboxSystemElementId);
            } else {
                enableElementById(lockboxSystemElementId);
            }
        });
    };

    // Reset save indicator on any form change
    var bindResetSaveIdicatorOnChangeEvent = function () {
        $("#project-form-element").on("change", function () {
            var $saveIndicator = $("#project-form-save-indicator");
            if ($saveIndicator.text() === "SAVED" || $saveIndicator.text() === "ERROR") {
                $saveIndicator.text("UNSAVED");
                $saveIndicator.removeClass("badge-success").removeClass("badge-danger").addClass("badge-light");
            }
        });
    };

    var disableElementById = function (elementId) {
        $(elementId).attr("disabled", true);
    };

    var enableElementById = function (elementId) {
        $(elementId).removeAttr("disabled");
    };

    return {
        init: init
    };

}(jQuery);