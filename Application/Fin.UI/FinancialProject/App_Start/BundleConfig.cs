using System.Web;
using System.Web.Optimization;

namespace DoctorAppoinment
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap")
            .Include("~/Scripts/bootstrap.js")
            .Include("~/Scripts/DataTables/jquery.dataTables.min.js")
             .Include("~/Content/css/bootstrap-datepicker3.min.css")
            .Include("~/Content/css/bootstrap-timepicker.min.css")
            .Include("~/Content/js/plugins/datepicker/bootstrap-datepicker.js")
            .Include("~/Content/js/plugins/timepicker/bootstrap-timepicker.min.js")
            .Include("~/Scripts/toastr.min.js")
            .Include("~/Scripts/bootbox.min.js")
             .Include("~/Scripts/bootstrap-datepicker.js")
              .Include("~/Scripts/jquery.validate.min.js")
            .Include("~/Scripts/jquery.validate.unobtrusive.min.js")
        );

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/DataTables/css/jquery.dataTables.min.css", "~/Content/jquery-ui.css",
                      "~/Content/bootstrap-datepicker.css",
                      "~/Content/toastr.min.css", "~/Content/css/bootstrap-datepicker3.min.css", "~/Content/css/bootstrap-timepicker.min.css"

                      ));
        }
    }
}
