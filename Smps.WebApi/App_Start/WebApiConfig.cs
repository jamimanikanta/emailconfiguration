//-----------------------------------------------------------------------
// <copyright file="WebApiConfig.cs" company="EPAM">
//     EPAM copyright tag.
// </copyright>
//<summary>This is the configuration class.</summary>
//-----------------------------------------------------------------------

namespace Smps.WebApi
{
    using System.Net.Http.Headers;
    using System.Web.Http;

    /// <summary>
    /// This class contains the web config details.
    /// This is a static class which registers all the required configurations.
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// This method registers the config details.
        /// </summary>
        /// <param name="config">The details to register.</param>
        public static void Register(HttpConfiguration config)
        {
            //Registering all the required configuration
            config.EnableCors(); 
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional });

            config.Formatters.JsonFormatter.SupportedMediaTypes
    .Add(new MediaTypeHeaderValue("text/html"));
        }
    }
}
