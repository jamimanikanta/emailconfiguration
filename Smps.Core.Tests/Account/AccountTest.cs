//-----------------------------------------------------------------------
// <copyright file="AccountTest.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Smps.Core.Tests.Account
{
    
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BusinessObjects.Account;
    using Moq;
    using Interfaces.Account.Repositories;
    using Services;

    /// <summary>
    /// Test class for UserAccount
    /// </summary>
    [TestClass]
    public class AccountTest 
    {
        public UserProfile UserProfile { get; set; }

        private readonly Mock<IUserAccountRepository> mockRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountTest" /> class.
        /// </summary>
        public AccountTest()
        {
            mockRepository = new Mock<IUserAccountRepository>();
            UserProfile = new UserProfile() { FirstName = "venkatesh", LastName = "pydi" };
        }

        [TestMethod]
        public void ValidateUser_forvalidentries()
        {
            ////Arange  
            var objUserAccount = new UserAccount(mockRepository.Object);
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
            var objUserAccount = new UserAccount(mockRepository.Object);
            mockRepository.Setup(u => u.GetUserProfile(It.IsAny<string>())).Returns(UserProfile);

            //Act
            var result = objUserAccount.GetUserProfile("venkatesh");

            //Assert
            Assert.AreEqual(result.LastName, "pydi");

        }
    }
}
