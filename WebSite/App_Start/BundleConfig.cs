﻿using System.Web;
using System.Web.Optimization;

namespace WebSite
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
                      //"~/Scripts/bootstrap.min.js",
                      "~/Scripts/bootstrap-select.js",
                      "~/Scripts/bootbox.js",
                      "~/Scripts/bootstrap-datetimepicker.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap-select.css",
                     // "~/Content/bootstrap-select.min.css",
                      "~/Content/bootstrap-datetimepicker.css",
                      "~/Content/site.css"));

            //calendar style
            bundles.Add(new StyleBundle("~/Content/fullcalendarcss").Include(
                      "~/Content/themes/jquery.ui.all.css",
                      "~/Content/fullcalendar.css")); 
            //calendar script
            bundles.Add(new ScriptBundle("~/bundles/fullcalendarjs").Include(
                      "~/Scripts/jquery-ui-{version}.min.js",
                      "~/Scripts/moment.min.js",
                      "~/Scripts/fullcalendar.min.js",
                      "~/Scripts/ViewsScripts/calendar.js"));

            bundles.Add(new ScriptBundle("~/bundles/searchjs").Include(
                      "~/Scripts/ViewsScripts/search.js"));
        }
    }
}
