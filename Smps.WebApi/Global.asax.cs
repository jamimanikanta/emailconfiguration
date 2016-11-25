//-----------------------------------------------------------------------
// <copyright file="Global.asax.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//<summary>This is the global asax file.</summary>
//This will be the global file which contains methods to enable session state
//Register any containers like castle windsor.
//This will be called only the first time when server starts
//-----------------------------------------------------------------------

namespace Smps.WebApi
{
    using System;
    using System.Web.Http;
    using System.Web.Http.Dispatcher;
    using System.Web.SessionState;
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using Smps.WebApi.WindsorCastleResolver;
   
    /// <summary>
    /// This class contains the web application details.
    /// </summary>
    public class WebApiApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// Overriding the initialize method to enable session state.
        /// </summary>
        public override void Init()
        {
            //Registering the post authenticate request
            this.PostAuthenticateRequest += MvcApplication_PostAuthenticateRequest;
            //Calling base method.
            base.Init();
        }

        /// <summary>
        /// This method contains the application start logic.
        /// Windsor castle assemblies are registered.
        /// </summary>
        protected void Application_Start()
        {
            //Register the windsor container
            //its assemblies
            //Its resolver.
            GlobalConfiguration.Configure(WebApiConfig.Register);
            WindsorContainer container = new WindsorContainer();
            container.Register(Classes.FromAssemblyNamed("Smps.WebApi").Where(type => type.IsPublic).WithService.DefaultInterfaces().LifestyleTransient());
            container.Register(Classes.FromAssemblyNamed("Smps.Infrastructure").Where(type => type.IsPublic).WithService.DefaultInterfaces().LifestyleTransient());
            container.Register(Classes.FromAssemblyNamed("Smps.core").Where(type => type.IsPublic).WithService.DefaultInterfaces().LifestyleTransient());
            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator), new WindsorCompositionRoot(container));
        }

        /// <summary>
        /// Enabling the session state.
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event of the caller</param>
        private static void MvcApplication_PostAuthenticateRequest(object sender, EventArgs e)
        {
            //Enabling the session state.
            System.Web.HttpContext.Current.SetSessionStateBehavior(
                SessionStateBehavior.Required);
        }
    }
}
