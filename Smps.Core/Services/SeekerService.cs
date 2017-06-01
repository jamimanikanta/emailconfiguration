using System;
using Smps.Core.BusinessObjects.Seeker;
using Smps.Core.Interfaces.Seeker;

using Smps.Core.Interfaces.Seeker.Repositories;
using System.Collections.Generic;

namespace Smps.Core.Services
{
  public  class SeekerService : ISeekerService
    {
        private readonly ISeekerServiceRepository rep;

        public SeekerService(ISeekerServiceRepository issr)
        {

            rep = issr;


        }

        public List<SeekerPerson> CheckSeekersElgibility(string userId, DateTime begindate, DateTime enddate)
        {
           return  rep.CheckSeekersElgibility(userId, begindate, enddate);
        }

        public object RequestForSlot(int empNo)
        {
            return rep.RequestForSlot(empNo); 
        }
    }
}
