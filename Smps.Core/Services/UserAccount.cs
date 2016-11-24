//-----------------------------------------------------------------------
// <copyright file="UserAccount.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//<summary>This is the User account class.</summary>
//-----------------------------------------------------------------------

namespace Smps.Core.Services
{
    using System;
    using Smps.Core.BusinessObjects.Account;
    using Smps.Core.Interfaces.Account;
    using Smps.Core.Interfaces.Account.Repositories;
    using SMPS.CrossCutting.CustomExceptions;
    
    /// <summary>
    /// This class contains the methods related to user account.
    /// </summary>
    public class UserAccount : IUserAccount
    {
        /// <summary>
        /// The object instance.
        /// </summary>
        private IUserAccountRepository userAccount;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserAccount" /> class.
        /// </summary>
        /// <param name="userAccount">The object instance.</param>
        public UserAccount(IUserAccountRepository userAccount)
        {
            try
            {
                this.userAccount = userAccount;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Gets the user profile.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <returns>The user profile.</returns>
        public UserProfile GetUserProfile(string userId)
        {
            try
            {
               return this.userAccount.GetUserProfile(userId);
            }
            catch (NoDataFoundException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Validates the user and returns profile
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="password">The password.</param>
        /// <returns>The user profile.</returns>
        public UserProfile ValidateUser(string userId, string password)
        {
            try
            {
                return this.userAccount.ValidateUser(userId, password);
            }
            catch (NoDataFoundException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
