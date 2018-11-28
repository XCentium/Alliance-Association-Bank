var SearchWidget = function ($, errorUtil) {

    var ACTIVE_PROJECTS_ONLY = true;
    var ENTER_KEY = 13;

    var init = function () {
        var searchInputId = "#project-search";
        bindAutocomplete(searchInputId);
        bindRedirectToSearchPage(searchInputId);
    };

    // Projects search main autocomplete logic
    var bindAutocomplete = function (searchElementId) {
        $(searchElementId).autocomplete({
            source: function (request, response) {
                $.ajax({
                    url: "/api/Projects",
                    method: "GET",
                    dataType: "json",
                    data: {
                        search: request.term,
                        activeOnly: ACTIVE_PROJECTS_ONLY
                    },
                    success: function (data, textStatus, jqXHR) {
                        if (data.length > 0) {
                            response($.map(data, function (item) {
                                return {
                                    label: item.name,
                                    value: item.id
                                };
                            }));
                        } else {
                            response([{
                                label: 'No results found',
                                value: -1
                            }]);
                        }
                    },
                    error: function (jqXHR, textStatus, errorThrown) {
                        errorUtil.handleAjaxError();
                        response([]);
                    }
                });
            },
            minLength: 1,
            focus: function (event, ui) {
                event.preventDefault();
            },
            select: function (event, ui) {
                event.preventDefault();

                if (event.type === "autocompleteselect" && event.which === ENTER_KEY) {
                    // prevent propagation of the event for bindRedirectToSearchPage function
                    // when Enter is pressed to select the item
                    event.stopImmediatePropagation();
                }

                if (ui.item.value === -1) {
                    $(this).val("");
                } else {
                    this.value = ui.item.label;
                    location.href = "/Projects/Edit/" + ui.item.value;
                }
            }
        });
    };

    // Redirect to Search Results page on Enter keydown
    var bindRedirectToSearchPage = function (searchElementId) {
        $(searchElementId).on("keydown", function (event) {
            if (event.which === ENTER_KEY && this.value.length > 0) {
                event.preventDefault();

                var query = "?term=" + encodeURIComponent(this.value.trim());
                var url = location.href.toLowerCase();
                if (url.indexOf("/projects/edit/") > 0) {
                    query = query + "&previousId=" + url.substring(url.lastIndexOf("/") + 1);
                }
                location.href = "/Search/Results" + query;
            }
        });
    };

    return {
        init: init
    };

}(jQuery, ErrorHandler);