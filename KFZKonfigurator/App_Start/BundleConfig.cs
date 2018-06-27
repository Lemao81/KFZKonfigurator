using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace KFZKonfigurator
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/scripts")
                .Include("~/Scripts/jquery-3.3.1.js", "~/Scripts/bootstrap.js", "~/Scripts/bootstrap.bundle.js", "~/Scripts/knockout-3.4.2.js", "~/Scripts/underscore.js",
                "~/Scripts/modernizr-2.6.2.js"));

            bundles.Add(new StyleBundle("~/bundles/styles")
                .Include("~/Content/bootstrap.css", "~/Content/Site.css"));

            BundleTable.EnableOptimizations = true;
        }
    }
}