//-----------------------------------------------------------------------
// <copyright file="Global.asax.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Smps.WebApi
{
    using System.Web.Http;
    using System.Web.Http.Dispatcher;
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using Smps.WebApi.WindsorCastleResolver;

    /// <summary>
    /// This class contains the web application details.
    /// </summary>
    public class WebApiApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// This method contains the application start logic.
        /// </summary>
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            WindsorContainer container = new WindsorContainer();
            container.Register(Classes.FromAssemblyNamed("Smps.WebApi").Where(type => type.IsPublic).WithService.DefaultInterfaces().LifestyleTransient());
            container.Register(Classes.FromAssemblyNamed("Smps.Dal").Where(type => type.IsPublic).WithService.DefaultInterfaces().LifestyleTransient());
            container.Register(Classes.FromAssemblyNamed("Smps.core").Where(type => type.IsPublic).WithService.DefaultInterfaces().LifestyleTransient());
            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator), new WindsorCompositionRoot(container));
        }
    }
}
