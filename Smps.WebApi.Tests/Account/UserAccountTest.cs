//-----------------------------------------------------------------------
// <copyright file="UserAccountTest.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Smps.WebApi.Tests.Account
{
    
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Core.BusinessObjects.Account;
    using Core.Interfaces.Account;
    
    using Controllers;
    using Moq;

    /// <summary>
    /// Test class for UserAccountController
    /// </summary>
    [TestClass]
    public class UserAccountTest
    {
        public UserProfile UserProfile { get; set; }

        private readonly Mock<IUserAccount> mockRepository;

        public UserAccountTest()
        {
            mockRepository = new Mock<IUserAccount>();
            UserProfile = new UserProfile() { FirstName = "venkatesh", LastName = "pydi" };
        }

        [TestMethod]
        public void ValidateUser_forvalidentries()
        {
            ////Arange  
            var objUserAccount = new UserAccountController(mockRepository.Object);
            mockRepository.Setup(u => u.ValidateUser(It.IsAny<string>(), It.IsAny<string>())).Returns(UserProfile);
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
            mockRepository.Setup(u => u.GetUserProfile(It.IsAny<string>())).Returns(UserProfile);

            //Act
            var result = objUserAccount.GetUserProfile("venkatesh");

            //Assert
            Assert.AreEqual(result.LastName, "pydi");

        }
    }
}
