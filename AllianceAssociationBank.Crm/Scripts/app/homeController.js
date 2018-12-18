var HomeController = function ($, reportService) {

    var init = function () {
        bindGenerateReportClickEvent();
        bindGenerateExportClickEvent();
    };

    var bindGenerateReportClickEvent = function () {
        $("#btn-generate-report").on("click", function () {
            var selectedReport = $("#selected-report").val();
            if (selectedReport !== "") {
                reportService.redirectToReport(selectedReport);
            }
        });
    };

    var bindGenerateExportClickEvent = function () {
        $("#btn-generate-export").on("click", function () {
            var selectedExport = $("#selected-export").val();
            if (selectedExport !== "") {
                location.href = "Exports/" + selectedExport;
            }
        });
    };

    return {
        init: init
    };

}(jQuery, ReportService);