//-----------------------------------------------------------------------
// <copyright file="EfUserAccountRepository.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Smps.DAL.Data.Repositories
{

    using Smps.Core.BusinessObjects.Account;
    using Smps.Core.Interfaces.Account.Repositories;

    public class EfUserAccountRepository : IUserAccountRepository
    {
        public UserProfile GetUserProfile(string userId)
        {
            return null;
        }

        public bool IsValidUser(string userId, string password)
        {
            return true;
        }
    }
}
