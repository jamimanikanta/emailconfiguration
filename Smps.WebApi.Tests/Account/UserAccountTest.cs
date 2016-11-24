//-----------------------------------------------------------------------
// <copyright file="UserAccountTest.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Smps.WebApi.Tests.Account
{
    using System;
    using System.Linq;
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Smps.Core.BusinessObjects.Account;
    using Smps.Core.Interfaces.Account;
    using Smps.Infrastructure;
    using Smps.WebApi.Controllers;

    /// <summary>
    /// Test class for UserAccountController
    /// </summary>
    [TestClass]
    public class UserAccountTest : IDisposable
    {
        /// <summary>
        /// Is disposable or not.
        /// </summary>
        private bool disposedValue = false;

        /// <summary>
        /// The container instance.
        /// </summary>
        private WindsorContainer container;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserAccountTest" /> class.
        /// </summary>
        public UserAccountTest()
        {
            this.container = new WindsorContainer();
            this.container.Register(Classes.FromAssemblyNamed("Smps.Infrastructure").Where(type => type.IsPublic).WithService.DefaultInterfaces().LifestyleTransient());
            this.container.Register(Classes.FromAssemblyNamed("Smps.core").Where(type => type.IsPublic).WithService.DefaultInterfaces().LifestyleTransient());
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

            IUserAccount obj = this.container.Resolve<IUserAccount>();
            UserAccountController userObj = new UserAccountController(obj);
            UserProfile userProfile = userObj.ValidateUser(user.UserLoginId, user.UserLoginPassword);
            Assert.AreEqual(true, userProfile != null);
        }

        /// <summary>
        /// Dispose method.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
        }

        #region IDisposable Support   
        /// <summary>
        /// Disposes the details.
        /// </summary>
        /// <param name="disposing">True or false.</param>     
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
    }
}
