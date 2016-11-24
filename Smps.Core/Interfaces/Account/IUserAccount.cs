//-----------------------------------------------------------------------
// <copyright file="IUserAccount.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Smps.Core.Interfaces.Account
{
    using Smps.Core.BusinessObjects.Account;

    /// <summary>
    /// This interface contains the methods related to user profile.
    /// </summary>
    public interface IUserAccount
    {
        /// <summary>
        /// Gets the user profile
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <returns>The user profile.</returns>
        UserProfile GetUserProfile(string userId);

        /// <summary>
        /// Validates the user and returns profile
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="password">The password.</param>
        /// <returns>The user profile.</returns>
        UserProfile ValidateUser(string userId, string password);
    }
}
