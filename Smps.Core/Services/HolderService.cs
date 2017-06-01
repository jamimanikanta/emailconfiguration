using Smps.Core.Interfaces.Holder;

using Smps.Core.BusinessObjects.Holder;
using Smps.Core.Interfaces.Holder.Repositories;
using System.Collections.Generic;
using System;

namespace Smps.Core.Services
{
   public class HolderService : IHolderService
    {
        public readonly IHolderServiceRepository Rep;
       

        public HolderService(IHolderServiceRepository ihsr)
        {
            Rep = ihsr;


        }
        public List<HolderPerson> Releaseslot(HolderPerson hld)
        {
            return Rep.Releaseslot(hld);
        }

        public List<HolderPerson> GetHoldersTabledetail(int? id)
        {
            return Rep.GetHoldersTabledetail(id);
        }
    }
}
