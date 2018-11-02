var UsersTabController = function ($, errorUtil) {

    var init = function () {
        bindUserFilterChangeEvent();
        bindUserListPageChangeEvent();
        bindEmailListCopyToClipboardEvent();
    };

    // Bind Users tab radio buttons filter change logic
    var bindUserFilterChangeEvent = function () {
        $("input[name='user-filter-option']").on("change", function (e) {
            var $radios = $(this);
            var projectId = $radios.attr("data-project-id");
            var filter = $radios.val();

            getUsersAndRefreshList(projectId, 1, filter);
        });
    };

    // Bind Users tab pagination change page logic
    var bindUserListPageChangeEvent = function () {
        $("#project-users-list").on("click", '[data-toggle="users-change-page"]', function () {
            $this = $(this);
            var projectId = $this.data("project-id");
            var pageNumber = $this.data("page-number");
            var userFilter = $("input[name='user-filter-option']:checked").val();

            getUsersAndRefreshList(projectId, pageNumber, userFilter);
        });
    };

    var getUsersAndRefreshList = function (projectId, page, filter) {
        var url = "/Projects/" + projectId + "/Users/Index"

        $.get(url, { page: page, filter: filter })
            .done(function (responseData) {
                $("#project-users-list").html(responseData);
            })
            .fail(function () {
                errorUtil.handleAjaxError();
            });
    };

    var bindEmailListCopyToClipboardEvent = function () {
        $("#users-email-list-modal-location").on("click", ".js-copy-to-clipboard", function () {
            $("#users-email-list-textarea").select();
            document.execCommand("copy");
        });
    };

    return {
        init: init
    };

}(jQuery, ErrorHandler);