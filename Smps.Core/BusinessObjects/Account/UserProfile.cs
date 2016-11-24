//-----------------------------------------------------------------------
// <copyright file="UserProfile.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//<summary>This is the User Profile class.</summary>
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
        /// <value>The first name of the customer.</value>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>The last name of the customer.</value>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the mobile number.
        /// </summary>
        /// <value>The mobile number of the customer.</value>
        public long? MobileNumber { get; set; }

        /// <summary>
        /// Gets or sets the Parking slot number.
        /// </summary>
        /// <value>The parking slot number of the customer.</value>
        public string ParkingSlotNumber { get; set; }

        /// <summary>
        /// Gets or sets the User type.
        /// </summary>
        /// <value>The user type of the customer.</value>
        public string UserType { get; set; }

    }
}
