//-----------------------------------------------------------------------
// <copyright file="UserProfile.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Smps.Core.BusinessObjects.Account
{
    /// <summary>
    /// Contains the user profile.
    /// </summary>
    public class UserProfile
    {
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the mobile number.
        /// </summary>
        public long MobileNumber { get; set; }
    }
}
