using Smps.Core.BusinessObjects.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smps.Core.Interfaces.Account.Repositories
{
    public interface IUserAccountRepository
    {
        UserProfile GetUserProfile(string userId);
        bool IsValidUser(string userId, string password);
    }
}
