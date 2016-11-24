//-----------------------------------------------------------------------
// <copyright file="EfUserAccountRepositoryTest.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Smps.Infrastructure.Tests.Account
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
    /// Test class for User Account Repository
    /// </summary>
    [TestClass]
    public class EfUserAccountRepositoryTest : IDisposable
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
        /// Initializes a new instance of the <see cref="EfUserAccountRepositoryTest" /> class.
        /// </summary>
        public EfUserAccountRepositoryTest()
        {
            this.container = new WindsorContainer();
            this.container.Register(Classes.FromAssemblyNamed("Smps.Infrastructure").Where(type => type.IsPublic).WithService.DefaultInterfaces().LifestyleTransient());
            this.container.Register(Classes.FromAssemblyNamed("Smps.core").Where(type => type.IsPublic).WithService.DefaultInterfaces().LifestyleTransient());
        }

        /// <summary>
        /// Method to test whether user is valid or not
        /// </summary>
        [TestMethod]
        public void CheckValidUser()
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
        /// Tests the user profile method.
        /// </summary>
        [TestMethod]
        public void GetUserProfile()
        {
            User user;
            using (SMPSEntities objectContext = new SMPSEntities())
            {
                IQueryable<User> users = objectContext.Users;
                user = users.FirstOrDefault();
            }

            IUserAccount obj = this.container.Resolve<IUserAccount>();
            UserProfile profileuser = obj.GetUserProfile(user.UserLoginId);
            Assert.AreEqual(true, profileuser != null);
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
