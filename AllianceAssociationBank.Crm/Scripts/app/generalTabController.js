﻿var GeneralTabController = function ($) {

    var init = function () {
        bindMailingSameAsPhysicalChangeEvent();
        initSetMailingOnPhysicalAddressChange();
        setSameAsPhysicalCheckboxOnLoad();
        toggleLockboxSystemDisabled();
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
            $mailingElement.addClass("read-only");
        } else {
            $mailingElement.val("");
            $mailingElement.removeClass("read-only");
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

        if ($status.val() == noLockbox) {
            disableFieldById(lockboxSystemElementId);
        }

        $status.on("change", function () {
            if (this.value == noLockbox) {
                disableFieldById(lockboxSystemElementId);
            } else {
                enableFieldById(lockboxSystemElementId);
            }
        });
    };

    var disableFieldById = function (elementId) {
        $(elementId).attr("disabled", "disabled");
    }

    var enableFieldById = function (elementId) {
        $(elementId).removeAttr("disabled");
    }

    return {
        init: init
    };

}(jQuery);