//-----------------------------------------------------------------------
// <copyright file="AccountTest.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Smps.Core.Tests.Account
{
    using System;
    using System.Linq;
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Smps.Core.BusinessObjects.Account;
    using Smps.Core.Interfaces.Account;
    using Smps.Infrastructure;

    /// <summary>
    /// Test class for UserAccount
    /// </summary>
    [TestClass]
    public class AccountTest : IDisposable
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
        /// Initializes a new instance of the <see cref="AccountTest" /> class.
        /// </summary>
        public AccountTest()
        {
            this.container = new WindsorContainer();
            this.container.Register(Classes.FromAssemblyNamed("Smps.Infrastructure").Where(type => type.IsPublic).WithService.DefaultInterfaces().LifestyleTransient());
            this.container.Register(Classes.FromAssemblyNamed("Smps.core").Where(type => type.IsPublic).WithService.DefaultInterfaces().LifestyleTransient());
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

            IUserAccount obj = this.container.Resolve<IUserAccount>();
            UserProfile userProfile = obj.ValidateUser(user.UserLoginId, user.UserLoginPassword);
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
