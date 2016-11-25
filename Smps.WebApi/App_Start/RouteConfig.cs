//-----------------------------------------------------------------------
// <copyright file="RouteConfig.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//<summary>This is the configuration class.</summary>
//-----------------------------------------------------------------------

namespace Smps.WebApi
{
    using System.Web.Mvc;
    using System.Web.Routing;

    /// <summary>
    /// This class contains the route config details.
    /// Route defines the URL pattern and handler information.
    /// All the configured routes of an application stored in RouteTable 
    /// And will be used by Routing engine to determine appropriate handler class or file for an incoming request.
    /// Every MVC application must configure (register) at least one route, 
    /// Which is configured by MVC framework by default
    /// </summary>
    public class RouteConfig
    {
        /// <summary>
        /// This method registers routes.
        /// </summary>
        /// <param name="routes">The routes to register.</param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { action = "Index", id = UrlParameter.Optional });
        }
    }
}
