using System;
using System.Linq;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Smps.Core.Interfaces.Account;
using Smps.DAL;
using Smps.WebApi.Controllers;

namespace Smps.WebApi.Tests.UserAccountTest
{
    /// <summary>
    /// Test class for UserAccountController
    /// </summary>
    [TestClass]
    public class UserAccountTest : IDisposable
    {
        private bool disposedValue = false;
        WindsorContainer container;

        /// <summary>
        /// Register the Assemblies
        /// </summary>
        public UserAccountTest()
        {
            container = new WindsorContainer();
            container.Register(Classes.FromAssemblyNamed("Smps.Dal").Where(type => type.IsPublic).WithService.DefaultInterfaces().LifestyleTransient());
            container.Register(Classes.FromAssemblyNamed("Smps.core").Where(type => type.IsPublic).WithService.DefaultInterfaces().LifestyleTransient());
        }
        /// <summary>
        /// Method to test whether User is valid or not
        /// </summary>
        [TestMethod]
        public void IsUserValid()
        {
            User user;
            using (SMPSEntities objectContext = new SMPSEntities())
            {
                IQueryable<User> users = objectContext.Users;
                user = users.FirstOrDefault();
            }
            IUserAccount obj = container.Resolve<IUserAccount>();
            UserAccountController userObj = new UserAccountController(obj);
            bool returnval = userObj.IsUserValid(user.UserLoginId, user.UserLoginPassword);
            Assert.AreEqual(true, returnval);
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
