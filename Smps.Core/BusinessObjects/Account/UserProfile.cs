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
<<<<<<< HEAD
        public long? MobileNumber { get; set; }

        /// <summary>
        /// Gets or sets the Parking slot number.
        /// </summary>
        public string ParkingSlotNumber { get; set; }

        /// <summary>
        /// Gets or sets the User type.
        /// </summary>
        public string UserType { get; set; }
=======
        /// <value>The mobile number of the customer.</value>
        public long MobileNumber { get; set; }
>>>>>>> d0d77699bff73393bc872cf0c047d8becd822c47
    }
}
