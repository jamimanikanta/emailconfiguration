//-----------------------------------------------------------------------
// <copyright file="IUserAccountRepository.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//<summary>This is the interface for all user account methods.</summary>
//-----------------------------------------------------------------------

namespace Smps.Core.Interfaces.Account.Repositories
{
    using Smps.Core.BusinessObjects.Account;

    /// <summary>
    /// This interface consists of methods related to user account.
    /// </summary>
    public interface IUserAccountRepository
    {
        /// <summary>
        /// Gets the user profile.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <returns>The user profile.</returns>
        UserProfile GetUserProfile(string userId);

        /// <summary>
        /// Validates the user.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="password">The password.</param>
        /// <returns>The user profile.</returns>
        UserProfile ValidateUser(string userId, string password);
    }
}
