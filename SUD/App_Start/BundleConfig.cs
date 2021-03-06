﻿using System.Web;
using System.Web.Optimization;

namespace SUD
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery-unobtrusive-ajax").Include(
                        "~/Scripts/jquery.unobtrusive-ajax.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/notify.min.js",
                      "~/Scripts/jasny-bootstrap.js",
                      "~/Scripts/moment.js",
                      "~/Scripts/datetime.js",
                      "~/Scripts/DataTables/jquery.dataTables.js",
                      "~/Scripts/DataTables/dataTables.bootstrap.js",
                      "~/Scripts/fastclick.js",
                      "~/Scripts/select2.js",
                      "~/Scripts/sweetalert2.all.js",
                      "~/Scripts/adminlte.min.js",
                      "~/Scripts/jquery.sparkline.min.js",
                      "~/Scripts/jquery-jvectormap-1.2.2.min.js",
                      "~/Scripts/jquery-jvectormap-world-mill-en.js",
                      "~/Scripts/jquery.slimscroll.min.js",
                      "~/Scripts/Chart.js",
                      "~/Scripts/pages/dashboard2.js",
                      "~/Scripts/demo.js",
                      "~/Scripts/icheck.min.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/jquery-3.3.1-dt.js",
                      "~/Scripts/jquery.dataTables-dt.min.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/jasny-bootstrap.css",
                      "~/Content/font-awesome.css",
                      "~/Content/ionicons.css",
                      "~/Content/DataTables/css/dataTables.bootstrap.css",
                      "~/Content/jquery-jvectormap.css",
                      "~/Content/select2.css",
                      "~/Content/loading.css",
                      "~/Content/loading-btn.css",
                      "~/Content/AdminLTE.css",
                      "~/Content/hint.min.css",
                      "~/Content/skins/_all-skins.min.css",
                      "~/Content/blue.css",
                      "~/Content/skins/Site.css",
                      "~/Content/click-form-control-feedback.css",
                      "~/Content/jquery.dataTables-dt.min.css"
                      ));

        }
    }
}
