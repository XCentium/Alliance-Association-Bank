var ReportService = function ($, errorHandler) {

    var REPORTS_URL = "Reports/";
    var PROJECTS_BY_OPS = "Projects-By-Ops";

    var PARAMS_PROMPT_CONTAINER = "#report-params-prompt-container";
    var PARAMS_PROMPT_MODAL_ELEMENT = "#report-params-prompt-modal";
    var SUBMIT_BUTTON = "#btn-generate-report-with-params";
    var PARAMS_FORM_ELEMENT = "#report-params-form";
    var REPORT_NAME_ELEMENT = "#report-name";

    var init = function () {
        bindSubmitReportParamsEvent();
    };

    var redirectToReport = function (reportName) {
        if (reportName === PROJECTS_BY_OPS) {
            showReportParameterPrompt(reportName);
        } else {
            redirectToReportViewer(reportName);
        }
    };

    var redirectToReportViewer = function (reportName, reportParams) {
        var pathAndQuery = reportName;
        if (reportParams) {
            pathAndQuery = pathAndQuery + "?" + reportParams;
        }
        location.href = REPORTS_URL  + pathAndQuery;
    };

    var showReportParameterPrompt = function (reportName) {
        var paramsPromptAction = REPORTS_URL + reportName + "/Parameters";

        $.get(paramsPromptAction, { report: reportName })
            .done(function (response) {
                $(PARAMS_PROMPT_CONTAINER).html(response);
                $.validator.unobtrusive.parse($(PARAMS_FORM_ELEMENT));
                $(PARAMS_PROMPT_MODAL_ELEMENT).modal("show");
            })
            .fail(function () {
                errorHandler.handleAjaxError();
            });
    };

    var bindSubmitReportParamsEvent = function () {
        $(PARAMS_PROMPT_CONTAINER).on("submit", PARAMS_FORM_ELEMENT, function (e) {
            e.preventDefault();
            var reportName = $(REPORT_NAME_ELEMENT).val();
            var reportParams = $(this).serialize();
            $(PARAMS_PROMPT_MODAL_ELEMENT).modal("hide");
            redirectToReportViewer(reportName, reportParams);
        });
    };

    return {
        init: init,
        redirectToReport: redirectToReport
    };

}(jQuery, ErrorHandler);