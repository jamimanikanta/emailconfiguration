using Smps.Core.BusinessObjects.Holder;
using System.Collections.Generic;

namespace Smps.Core.Interfaces.Holder.Repositories
{
   public interface IHolderServiceRepository
    {
        List<HolderPerson> Releaseslot(HolderPerson hld);

        List<HolderPerson> GetHoldersTabledetail(int? id);
    }
}
