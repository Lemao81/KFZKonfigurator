using System.Web.Optimization;

namespace KFZKonfigurator {
    public class BundleConfig {
        public static void RegisterBundles(BundleCollection bundles) {
            bundles.Add(new ScriptBundle("~/bundles/knockout").Include("~/Scripts/Framework/knockout-3.4.2.js", "~/Scripts/Framework/knockout.mapping-latest.debug.js"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/Framework/bootstrap.js", "~/Scripts/Framework/bootstrap.bundle.js"));
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/Framework/jquery-3.3.1.js", "~/Scripts/Framework/jquery.validate.js"));
            bundles.Add(new ScriptBundle("~/bundles/divers").Include("~/Scripts/Framework/underscore.js", "~/Scripts/Framework/modernizr-2.6.2.js"));
            bundles.Add(new ScriptBundle("~/bundles/custom").Include("~/Scripts/Custom/binding.js", "~/Scripts/Custom/utils.js"));

            bundles.Add(new StyleBundle("~/bundles/styles").Include("~/Content/bootstrap.css", "~/Content/Site.less"));
        }
    }
}