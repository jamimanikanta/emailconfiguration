

using System;

namespace Smps.Core.BusinessObjects.Seeker
{
   public  class SeekerPerson
    {
        public int SeekerDetailId { get; set; }
        public int EmpNo { get; set; }
        public string ParkingSlotNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime SlotReleasedDate { get; set; }
        public int AllocationType { get; set; }
        public short OperationType { get; set; }


    }
}
