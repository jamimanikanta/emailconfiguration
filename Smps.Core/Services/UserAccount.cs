using Smps.Core.Interfaces.Account;
using Smps.Core.Interfaces.Account.Repositories;
using Smps.Core.BusinessObjects.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smps.Core.Services
{
    public class UserAccount: IUserAccount
    {
        private IUserAccountRepository userAccount;
        public UserAccount(IUserAccountRepository userAccount)
        {
            try
            {
                this.userAccount = userAccount;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public UserProfile GetUserProfile(string userId)
        {
            try
            {
                return this.userAccount.GetUserProfile(userId);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public bool IsValidUser(string userId, string password)
        {
            return this.userAccount.IsValidUser(userId, password);
        }
    }
}
