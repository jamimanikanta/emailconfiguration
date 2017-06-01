



namespace Smps.Core.BusinessObjects.Holder
{
  public  class HolderPerson
    {

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

        public string Username { get; set; }


        public int? EmpNo { get; set; }

        public int OperationType { get; set; }

        public string Startdate { get; set; }

        public string Enddate { get; set; }

        public string SeekerId { set; get; }


    }
}
