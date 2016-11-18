using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTaskSystem.Services
{
    public interface IUserRepository : IRepository
    {
        List<SMPSUser> GetAllHolders();

        List<SMPSUser> GetAllSeekers();
    }
}
