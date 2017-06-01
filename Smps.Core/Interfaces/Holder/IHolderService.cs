using Smps.Core.BusinessObjects.Holder;
using System.Collections.Generic;

namespace Smps.Core.Interfaces.Holder
{
   public  interface IHolderService
    {
        List<HolderPerson> Releaseslot(HolderPerson hld);
        List<HolderPerson> GetHoldersTabledetail(int? id);
    }
}
