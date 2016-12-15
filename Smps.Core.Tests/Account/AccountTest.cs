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
    using Moq;
    using Interfaces.Account.Repositories;
    using Services;

    /// <summary>
    /// Test class for UserAccount
    /// </summary>
    [TestClass]
    public class AccountTest 
    {
        public UserProfile userProfile { get; set; }

        private Mock<IUserAccountRepository> mockRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountTest" /> class.
        /// </summary>
        public AccountTest()
        {
            mockRepository = new Mock<IUserAccountRepository>();
            userProfile = new UserProfile() { FirstName = "venkatesh", LastName = "pydi" };
        }

        [TestMethod]
        public void ValidateUser_forvalidentries()
        {
            ////Arange  
            var objUserAccount = new UserAccount(mockRepository.Object);
            mockRepository.Setup(u => u.ValidateUser(It.IsAny<string>(), It.IsAny<string>())).Returns(userProfile);
            string userName = "venkatesh", password = "pydi";
            //Act
            var result = objUserAccount.ValidateUser(userName, password);

            //Assert
            Assert.AreEqual(result.FirstName, "venkatesh");
        }

        [TestMethod]
        public void GetUserProfile_By_UserName_ForValidUserName()
        {
            //Arrange
            var objUserAccount = new UserAccount(mockRepository.Object);
            mockRepository.Setup(u => u.GetUserProfile(It.IsAny<string>())).Returns(userProfile);

            //Act
            var result = objUserAccount.GetUserProfile("venkatesh");

            //Assert
            Assert.AreEqual(result.LastName, "pydi");

        }
    }
}
