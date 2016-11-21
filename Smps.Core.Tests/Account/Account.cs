using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Smps.Core.Services;
using Smps.DAL.Data;
using Smps.Core.BusinessObjects.Account;
using Smps.DAL.Data.Repositories;
using Smps.Core.Interfaces.Account;
using Castle.Windsor;
using Castle.MicroKernel.Registration;

namespace Smps.Core.Tests.Account
{
    [TestClass]
    public class Account  :IDisposable
    {
        WindsorContainer container;
        public Account()
        {
            container = new WindsorContainer();
            container.Register(Classes.FromAssemblyNamed("Smps.Dal").Where(type => type.IsPublic).WithService.DefaultInterfaces().LifestyleTransient());
            container.Register(Classes.FromAssemblyNamed("Smps.core").Where(type => type.IsPublic).WithService.DefaultInterfaces().LifestyleTransient());
        }
        [TestMethod]
        public void TestProfile()
        {
            IUserAccount obj = container.Resolve<IUserAccount>();
            
            UserProfile profileuser = obj.GetUserProfile("test");
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    this.container.Dispose();
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~Account() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
