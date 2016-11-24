/// <summary>
/// This class contains the test cases for testing the user account details.
/// </summary>

namespace Smps.WebApi.Tests.Account
{
    using System;
    using System.Linq;
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Smps.Core.BusinessObjects.Account;
    using Smps.Core.Interfaces.Account;
    using Smps.DAL;
    using Smps.WebApi.Controllers;

    /// <summary>
    /// Test class for UserAccountController
    /// </summary>
    [TestClass]
    public class UserAccountTest : IDisposable
    {
        /// <summary>
        /// Get or sets true or false.
        /// </summary>
        private bool disposedValue = false;

        /// <summary>
        /// The container object.
        /// </summary>
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
            UserProfile userProfile = userObj.ValidateUser(user.UserLoginId, user.UserLoginPassword);
            Assert.AreEqual(true, userProfile != null);
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
