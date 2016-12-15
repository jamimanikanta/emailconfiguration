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
    using Moq;

    /// <summary>
    /// Test class for UserAccountController
    /// </summary>
    [TestClass]
    public class UserAccountTest
    {
        public UserProfile userProfile { get; set; }

        private Mock<IUserAccount> mockRepository;

        public UserAccountTest()
        {
            mockRepository = new Mock<IUserAccount>();
            userProfile = new UserProfile() { FirstName = "venkatesh", LastName = "pydi" };
        }

        [TestMethod]
        public void ValidateUser_forvalidentries()
        {
            ////Arange  
            var objUserAccount = new UserAccountController(mockRepository.Object);
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
            var objUserAccount = new UserAccountController(mockRepository.Object);
            mockRepository.Setup(u => u.GetUserProfile(It.IsAny<string>())).Returns(userProfile);

            //Act
            var result = objUserAccount.GetUserProfile("venkatesh");

            //Assert
            Assert.AreEqual(result.LastName, "pydi");

        }
    }
}
