//-----------------------------------------------------------------------
// <copyright file="WindsorCompositionRoot.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//<summary>This is the castle windsor resolver class.</summary>
//-----------------------------------------------------------------------

namespace Smps.WebApi.WindsorCastleResolver
{
    using System;
    using System.Net.Http;
    using System.Web.Http.Controllers;
    using System.Web.Http.Dispatcher;
    using Castle.Windsor;
    
    /// <summary>
    /// This class contains castle windsor container resolver logic.
    /// </summary>
    public class WindsorCompositionRoot : IHttpControllerActivator, IDisposable
    {
        /// <summary>
        /// The container instance
        /// </summary>
        private readonly IWindsorContainer container;

        /// <summary>
        /// Whether disposed or not.
        /// </summary>
        private bool disposedValue = false; // To detect redundant calls

        /// <summary>
        /// Initializes a new instance of the <see cref="WindsorCompositionRoot" /> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public WindsorCompositionRoot(IWindsorContainer container)
        {
            this.container = container;
        }
        
        /// <summary>
        /// Registers the assembly details.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="controllerDescriptor">The controller descriptor.</param>
        /// <param name="controllerType">The controller type.</param>
        /// <returns>The Http Controller.</returns>
        public IHttpController Create(
            HttpRequestMessage request,
            HttpControllerDescriptor controllerDescriptor,
            Type controllerType)
        {
            var controller =
                (IHttpController)this.container.Resolve(controllerType);

            request.RegisterForDispose(
                new Release(
                    () => this.container.Release(controller)));

            return controller;
        }

        #region IDisposable Support

        /// <summary>
        /// This method disposes the objects.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
        }

        /// <summary>
        /// This method is used to dispose all objects.
        /// </summary>
        /// <param name="disposing">Disposing or not.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    this.container.Dispose();
                }

                this.disposedValue = true;
            }
        }
        #endregion

        /// <summary>
        /// This class handles the disposition of objects.
        /// </summary>
        private class Release : IDisposable
        {
            /// <summary>
            /// The action to release.
            /// </summary>
            private readonly Action release;

            /// <summary>
            /// Initializes a new instance of the <see cref="Release" /> class.
            /// </summary>
            /// <param name="release">The action to release.</param>
            public Release(Action release)
            {
                this.release = release;
            }

            /// <summary>
            /// Disposes the objects.
            /// </summary>
            public void Dispose()
            {
                this.release();
            }
        }
    }
}