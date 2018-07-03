using System.Web.Optimization;

namespace KFZKonfigurator
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/knockout").Include("~/Scripts/knockout-3.4.2.js", "~/Scripts/knockout.mapping-latest.debug.js"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/bootstrap.js", "~/Scripts/bootstrap.bundle.js"));
            bundles.Add(new ScriptBundle("~/bundles/divers").Include("~/Scripts/jquery-3.3.1.js", "~/Scripts/underscore.js", "~/Scripts/modernizr-2.6.2.js", "~/Scripts/Custom/binding.js"));

            bundles.Add(new StyleBundle("~/bundles/styles").Include("~/Content/bootstrap.css", "~/Content/Site.css"));

//            BundleTable.EnableOptimizations = true;
        }
    }
}