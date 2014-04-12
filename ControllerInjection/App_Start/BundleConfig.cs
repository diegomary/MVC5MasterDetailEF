using System.Web;
using System.Web.Optimization;

namespace ControllerInjection
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
          
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryUnobtrusive").Include(
                       "~/Scripts/jquery.unobtrusive-ajax.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include("~/Scripts/jquery-ui-{version}.js"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
            "~/Content/bootstrap.min.css",          
            "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/Tables/css").Include("~/Content/Tables/style.css"));
            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include("~/Content/themes/base/jquery.ui.all.css"));
        }
    }
}
