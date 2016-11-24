using System;
using System.Linq;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Smps.Core.Interfaces.Account;
using Smps.DAL;
using Smps.Core.BusinessObjects.Account;

namespace Smps.Core.Tests.Account
{
    /// <summary>
    /// Test class for UserAccount
    /// </summary>
    [TestClass]
    public class AccountTest  :IDisposable
    {
        private bool disposedValue = false; 
        WindsorContainer container;

        /// <summary>
        /// Register the Assemblies
        /// </summary>
        public AccountTest()
        {
            container = new WindsorContainer();
            container.Register(Classes.FromAssemblyNamed("Smps.Dal").Where(type => type.IsPublic).WithService.DefaultInterfaces().LifestyleTransient());
            container.Register(Classes.FromAssemblyNamed("Smps.core").Where(type => type.IsPublic).WithService.DefaultInterfaces().LifestyleTransient());
        }

        /// <summary>
        /// Method to test whether user is valid or not
        /// </summary>
        [TestMethod]
        public void IsValidUser()
        {
            User user;
            using (SMPSEntities objectContext = new SMPSEntities())
            {
                IQueryable<User> users = objectContext.Users;
                user = users.FirstOrDefault();
            }
            IUserAccount obj = container.Resolve<IUserAccount>();
            UserProfile userProfile = obj.ValidateUser(user.UserLoginId, user.UserLoginPassword);
            Assert.AreEqual(true, userProfile!=null);
        }

        #region IDisposable Support
        
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    this.container.Dispose();
                }

                disposedValue = true;
            }
        }
        public void Dispose()
        {            
            Dispose(true);
        }
        #endregion
    }
}
