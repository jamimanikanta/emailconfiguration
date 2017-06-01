

using Smps.Core.BusinessObjects.Seeker;
using System;
using System.Collections.Generic;

namespace Smps.Core.Interfaces.Seeker
{
    public interface ISeekerService
    {
        object RequestForSlot(int empNo);

        List<SeekerPerson> CheckSeekersElgibility(string userId, DateTime begindate, DateTime enddate);
    }
}
