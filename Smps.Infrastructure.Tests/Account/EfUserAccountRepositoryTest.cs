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
    using Moq;
    using Core.Interfaces.Account.Repositories;
    using Smps.Infrastructure.Data.Repositories;
    using System.Collections.Generic;
    using System.Data.Entity;

    /// <summary>
    /// Test class for User Account Repository
    /// </summary>
    [TestClass]
    public class EfUserAccountRepositoryTest
    {
        public IQueryable<User> userProfile { get; set; }

        private Mock<SMPSEntities> mockContext;
        /// <summary>
        /// Initializes a new instance of the <see cref="EfUserAccountRepositoryTest" /> class.
        /// </summary>
        public EfUserAccountRepositoryTest()
        {
            //var mockSet = new Mock<DbSet<User>>();
            //mockSet.Object.Add(new User { FirstName = "Venkatesh", UserLoginId = "venkatesh", UserLoginPassword = "pydi" });
            //mockContext = new Mock<SMPSEntities>();
            //mockContext.Setup(m => m.Users).Returns(mockSet.Object);
            //// userProfile = new User() { FirstName = "venkatesh", LastName = "pydi" };

            userProfile = new List<User>
            {
                new User { FirstName = "Venkatesh",UserLoginId="venkatesh", UserLoginPassword="pydi" }
            }.AsQueryable();


        }

        //////[TestMethod]
        //////public void ValidateUser_forvalidentries()
        //////{
        //////    var mockSet = new Mock<DbSet<User>>();
        //////   // mockSet.Object.Add(new User { FirstName = "Venkatesh", UserLoginId = "venkatesh", UserLoginPassword = "pydi" });
        //////    mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(userProfile.Provider);
        //////    mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(userProfile.Expression);
        //////    mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(userProfile.ElementType);
        //////    mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(userProfile.GetEnumerator());

        //////    var mockContext = new Mock<SMPSEntities>();
        //////    mockContext.Setup(c => c.Users).Returns(mockSet.Object);
        //////    mockContext.Object.Users.Add(new User { FirstName = "Venkatesh", UserLoginId = "venkatesh", UserLoginPassword = "pydi" });
            

        //////    ////Arange  
        //////    var objUserAccount = new EfUserAccountRepository();
        //////    //var mockSet = new Mock<DbSet<User>>();
        //////    //mockSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(userProfile.Provider);
        //////    //mockSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(userProfile.Expression);
        //////    //mockSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(userProfile.ElementType);
        //////    //mockSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(userProfile.GetEnumerator());

        //////    string userName = "venkatesh", password = "pydi";
        //////    //Act
        //////    var result = objUserAccount.ValidateUser(userName, password);

        //////    //Assert
        //////    Assert.AreEqual(result.FirstName, "venkatesh");
        //////}

        //[TestMethod]
        //public void GetUserProfile_By_UserName_ForValidUserName()
        //{
        //    ////Arrange
        //    //var objUserAccount = new EfUserAccountRepository();
        //    //mockRepository.Setup(u => u.GetUserProfile(It.IsAny<string>())).Returns(userProfile);

        //    ////Act
        //    //var result = objUserAccount.GetUserProfile("venkatesh");

        //    ////Assert
        //    //Assert.AreEqual(result.LastName, "pydi");

        //}
    }
}
