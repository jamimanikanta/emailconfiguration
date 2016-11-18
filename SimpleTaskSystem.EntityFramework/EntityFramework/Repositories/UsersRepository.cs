using SimpleTaskSystem.EntityFramework.Repositories;
using SimpleTaskSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTaskSystem.EntityFramework.Repositories
{
    class UsersRepository : IUserRepository
    {
        public List<SMPSUser> GetAllHolders()
        {
            var holders = new List<SMPSUser>();
            using (var db = new SimpleTaskSystemDbContext())
            {
                holders = db.Users.Where(u => u.ParkingSlotNumber != null).ToList();
            }
            return holders;
        }

        public List<SMPSUser> GetAllSeekers()
        {
            var seekers = new List<SMPSUser>();

            using (var db = new SimpleTaskSystemDbContext())
            {
                seekers = db.Users.Where(u => u.ParkingSlotNumber == null).ToList();
            }

            return seekers;
        }
    }
}
