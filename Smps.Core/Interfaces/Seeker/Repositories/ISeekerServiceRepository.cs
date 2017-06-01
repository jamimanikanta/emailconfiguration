

using Smps.Core.BusinessObjects.Seeker;
using System;
using System.Collections.Generic;

namespace Smps.Core.Interfaces.Seeker.Repositories
{
   public interface ISeekerServiceRepository
    {
        object RequestForSlot(int empNo);

        List<SeekerPerson> CheckSeekersElgibility(string userId, DateTime begindate, DateTime enddate);

    }
}
