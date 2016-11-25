//-----------------------------------------------------------------------
// <copyright file="BundleConfig.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//<summary>This is the configuration class.</summary>
//-----------------------------------------------------------------------

namespace Smps.WebApi
{
    using System.Web.Optimization;

    /// <summary>
    /// This class contains the bundle config details.
    /// Bundling and minification are two techniques you can use in ASP.NET 4.5 to improve request load time.  
    /// Bundling and minification improves load time by reducing the number of requests to the server and reducing the size of requested assets (such as CSS and JavaScript.)
    /// </summary>
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862

        /// <summary>
        /// This method registers the bundles
        /// </summary>
        /// <param name="bundles">The bundle details</param>
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
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
