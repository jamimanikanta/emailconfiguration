using System;
using System.Linq;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Smps.Core.Interfaces.Account;
using Smps.DAL;

namespace SMPA.DAL.Tests
{
    /// <summary>
    /// Test class for EfUserAccountRepository
    /// </summary>
    [TestClass]
    public class EfUserAccountRepositoryTest: IDisposable
    {
        private bool disposedValue = false;
        WindsorContainer container;

        /// <summary>
        /// Register the Assemblies
        /// </summary>
        public EfUserAccountRepositoryTest()
        {
            container = new WindsorContainer();
            container.Register(Classes.FromAssemblyNamed("Smps.Dal").Where(type => type.IsPublic).WithService.DefaultInterfaces().LifestyleTransient());
            container.Register(Classes.FromAssemblyNamed("Smps.core").Where(type => type.IsPublic).WithService.DefaultInterfaces().LifestyleTransient());
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
            IUserAccount obj = container.Resolve<IUserAccount>();
            bool profileuser = obj.IsValidUser(user.UserLoginId, user.UserLoginPassword);
            Assert.AreEqual(true, profileuser);
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
