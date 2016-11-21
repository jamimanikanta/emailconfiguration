//-----------------------------------------------------------------------
// <copyright file="WebApiConfig.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Smps.WebApi
{
    using System.Web.Http;

    /// <summary>
    /// This class contains the web config details.
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// This method registers the config details.
        /// </summary>
        /// <param name="config">The details to register.</param>
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional });
        }
    }
}
