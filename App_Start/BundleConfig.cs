using System.Web;
using System.Web.Hosting;
using System.Web.Optimization;

namespace InnerMetrixWeb
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.VirtualPathProvider = HostingEnvironment.VirtualPathProvider;

            BundleTable.EnableOptimizations = false;

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*",
                        "~/Scripts/jquery.validate.unobtrusive*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/toastr.css"));

            bundles.Add(new StyleBundle("~/Content/jumbotron").Include(
                      "~/Content/jumbotron-narrow.css"));

            bundles.Add(new ScriptBundle("~/bundles/datatables").Include(
                         "~/Scripts/DataTables/jquery.dataTables.*",
                         "~/Scripts/DataTables/dataTables.bootstrap.*"));

            bundles.Add(new StyleBundle("~/Content/datatables/styles").Include(
                      "~/Content/DataTables/css/dataTables.bootstrap.*"));
            
            bundles.Add(new ScriptBundle("~/bundles/toastr").Include(
                        "~/Scripts/toastr.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery-3.3.1-min").Include(
                        "~/Scripts/jquery-3.3.1.js"));

            bundles.Add(new ScriptBundle("~/bundles/common").Include(
                        "~/Scripts/Common.js",
                        "~/Scripts/ie10-viewport-bug-workaround.js"));
        }
    }
}
