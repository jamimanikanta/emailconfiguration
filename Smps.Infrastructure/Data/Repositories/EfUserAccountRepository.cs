//-----------------------------------------------------------------------
// <copyright file="EfUserAccountRepository.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Smps.DAL.Data.Repositories
{
    using System;
    using System.Linq;
    using Smps.Core.BusinessObjects.Account;
    using Smps.Core.Interfaces.Account.Repositories;
    using System.Data.Entity.SqlServer;

    public class EfUserAccountRepository : IUserAccountRepository
    {
        public UserProfile GetUserProfile(string userId)
        {
            try
            {
                UserProfile userProfile;
                using (SMPSEntities objectContext = new SMPSEntities())
                {
                    IQueryable<User> users = objectContext.Users;
                    var user = users.Where(u => u.UserLoginId == userId).FirstOrDefault();
                    userProfile=mapProperties(user);
                }
                return userProfile;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool IsValidUser(string userId, string password)
        {

            bool IsValidUser = false;
            try
            {
                using (SMPSEntities objectContext = new SMPSEntities())
                {
                    IQueryable<User> users = objectContext.Users;
                    IsValidUser = users.Where(u => u.UserLoginId == userId && u.UserLoginPassword == password).Count() > 0;
                }
                return IsValidUser;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        private UserProfile mapProperties(User user)
        {
            UserProfile userProfile = null;
            if (user != null)
            {
                userProfile = new UserProfile();
                userProfile.FirstName = user.FirstName;
                userProfile.LastName = user.LastName;
            }
            return userProfile;
        }
    }
}
