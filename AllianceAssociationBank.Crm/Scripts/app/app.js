(function () {
    $(function () {

        ErrorHandler.init();

        HomeController.init();
        GeneralTabController.init();
        UsersTabController.init();

        SearchableSelectPlugin.init();
        NavigationWidgets.init();
        SearchWidget.init();
        InputMaskHelper.init();
        DatePickerWidget.init();

    });
})();
