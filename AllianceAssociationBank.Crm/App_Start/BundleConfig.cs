using System.Web;
using System.Web.Optimization;

namespace AllianceAssociationBank.Crm
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/ajaxhelper").Include(
                      "~/Scripts/jquery.unobtrusive-ajax*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/themes/base/jquery-ui.min.css",
                      "~/Content/select2.min.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/popper").Include(
                      "~/Scripts/umd/popper.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                      "~/Scripts/jquery-ui-1.12.1.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/select2").Include(
                      "~/Scripts/select2.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                      "~/Scripts/app/errorHandler.js",
                      "~/Scripts/app/searchableSelectPlugin.js",
                      "~/Scripts/app/generalTabController.js",
                      "~/Scripts/app/usersTabController.js",
                      "~/Scripts/app/achTabController.js",
                      "~/Scripts/app/navigationWidgets.js",
                      "~/Scripts/app/searchWidget.js",
                      "~/Scripts/app/modalDialogHelper.js",
                      "~/Scripts/app/app.js",
                      "~/Scripts/app/appFunctions.js"));
        }
    }
}
