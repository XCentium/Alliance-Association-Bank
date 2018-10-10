var SearchWidget = function ($, errorUtil) {

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
                        search: request.term
                    },
                    success: function (data) {
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
                    error: function () {
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

                if (ui.item.value === -1) {
                    $(this).val("");
                } else {
                    this.value = ui.item.label;
                    location.href = "/Projects/Edit/" + ui.item.value;
                }
            }
        });
    };

    // Redirect to Search Results page on Enter keypress
    var bindRedirectToSearchPage = function (searchElementId) {
        $(searchElementId).on("keydown", function (event) {
            if (event.which === 13 && this.value.length > 0) {
                event.preventDefault();
                location.href = "/Search/Results?term=" + this.value;
            }
        });
    };

    return {
        init: init
    };

}(jQuery, ErrorHandler);