using System.Web.Optimization;

namespace RegularExpressionsCalculator
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.validate.unobtrusive.js"));
            
            // use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/calculator").Include(
                        "~/Scripts/calculator-scripts.js"));

            bundles.Add(new ScriptBundle("~/bundles/layout").Include(
                        "~/Scripts/layout-scripts.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/bootstrap.css",
                        "~/Content/site.css"));

            // sets optimization based on whether build is development or publish
            #if DEBUG
                BundleTable.EnableOptimizations = false;
            #else
                BundleTable.EnableOptimizations = true;
            #endif
        }
    }
}
