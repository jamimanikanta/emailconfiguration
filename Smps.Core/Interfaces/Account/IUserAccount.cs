//-----------------------------------------------------------------------
// <copyright file="IUserAccount.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//<summary>This is the interface for all uer account methods.</summary>
//As a Technical Lead I want to create a solution using N- Tier architecture in visual studio 2015 
//so that my team can start their development activity	
//Jira Id-2094
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
