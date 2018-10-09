var SearchableSelectPlugin = function ($) {

    var init = function () {
        enableSelect2Plugin();
    };

    var enableSelect2Plugin = function () {
        $("#Institution").select2();
        $("#OwnerID").select2();
        $("#AFPID").select2();
        $("#BoardingManagerID").select2();
        $("#LockboxStatus").select2();
        $("#LockboxSystem").select2({
            tags: true,
            insertTag: function (data, tag) {
                data.push(tag);
            }
        });
        $("#Status").select2();
        $("#Software").select2({
            tags: true,
            insertTag: function (data, tag) {
                data.push(tag);
            }
        });
        $("#MigratingToSoftware").select2({
            tags: true,
            insertTag: function (data, tag) {
                data.push(tag);
            }
        });
        $("#XmlUsage").select2();
        $("#ReformatAQ2ID").select2();
        $("#ReformatECPID").select2();
    };

    return {
        init: init
    };

}(jQuery);