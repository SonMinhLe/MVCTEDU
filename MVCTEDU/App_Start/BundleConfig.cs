using System.Web;
using System.Web.Optimization;

namespace MVCTEDU
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Areas/Assets/client/js/jquery-1.11.3.min.js",
                        "~/Areas/Assets/client/js/jquery-ui.js",
                        "~/Areas/Assets/client/js/bootstrap.min.js",
                        "~/Areas/Assets/client/js/move-top.js",
                        "~/Areas/Assets/client/js/easing.js",
                        "~/Areas/Assets/client/js/startstop-slider.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/controller").Include(
                "~/Areas/Assets/client/js/Controller/BaseController.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Areas/Assets/client/css/style.css",
                      "~/Areas/Assets/client/css/slider.css",
                      "~/Areas/Assets/client/css/jquery-ui.css",
                      "~/Areas/Assets/admin/vendor/fontawesome-free/css/all.min.css"
                      ));
            BundleTable.EnableOptimizations = true;
        }
    }
}
