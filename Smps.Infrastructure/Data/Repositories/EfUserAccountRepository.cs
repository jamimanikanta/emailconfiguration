﻿//-----------------------------------------------------------------------
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
    using SMPS.CrossCutting.Constants;
    using SMPS.CrossCutting.CustomExceptions;
    
    /// <summary>
    /// This class contains the methods related to user account.
    /// </summary>
    public class EfUserAccountRepository : IUserAccountRepository
    {
        /// <summary>
        /// Gets the user profile
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <returns>The user profile.</returns>
        public UserProfile GetUserProfile(string userId)
        {
            try
            {
                UserProfile userProfile;
                using (SMPSEntities objectContext = new SMPSEntities())
                {
                    IQueryable<User> users = objectContext.Users;
                    var user = users.Where(u => u.UserLoginId == userId).FirstOrDefault();
                    if (user != null)
                    {
                        userProfile = MapProperties(user);
                    }
                    else
                    {
                        throw new NoDataFoundException(ErrorMessages.ApplicationErrorMessage);
                    }
                }

                return userProfile;
            }
            catch (NoDataFoundException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Validates the user and returns profile
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="password">The password.</param>
        /// <returns>The user profile.</returns>
        public UserProfile ValidateUser(string userId, string password)
        {
            UserProfile userProfile = null;
            try
            {
                using (SMPSEntities objectContext = new SMPSEntities())
                {
                    IQueryable<User> users = objectContext.Users;
                    var user = users.Where(u => u.UserLoginId == userId && u.UserLoginPassword == password).FirstOrDefault();
                    if (user != null)
                    {
                        userProfile = MapProperties(user);
                    }
                    else
                    {
                        throw new NoDataFoundException(ErrorMessages.ApplicationErrorMessage);
                    }
                }

                return userProfile;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Maps the properties between data base object and business object.
        /// </summary>
        /// <param name="user">The user details.</param>
        /// <returns>The user profile.</returns>
        private static UserProfile MapProperties(User user)
        {
            UserProfile userProfile = null;
            try
            {
                if (user != null)
                {
                    userProfile = new UserProfile();
                    userProfile.FirstName = user.FirstName;
                    userProfile.LastName = user.LastName;
                }
                else
                {
                    throw new NoDataFoundException(ErrorMessages.ApplicationErrorMessage);
                }
            }
            catch (Exception)
            {
                throw;
            }

            return userProfile;
        }
    }
}
