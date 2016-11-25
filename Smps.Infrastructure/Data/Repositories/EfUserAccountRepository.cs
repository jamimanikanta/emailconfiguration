//-----------------------------------------------------------------------
// <copyright file="EfUserAccountRepository.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//<summary>This is the User account repository.</summary>
//This contains all the crud operations related to user account.
//As a Technical Lead I want to create a solution using N- Tier architecture in visual studio 2015 
//so that my team can start their development activity	
//Jira Id-2094
//This is using repository pattern
//Which acts as a wrapper over the underlying entity framework
//To make it persistent ignorant
//-----------------------------------------------------------------------

namespace Smps.Infrastructure.Data.Repositories
{
    using System;
    using System.Linq;
    using Infrastructure;
    using Smps.Core.BusinessObjects.Account;
    using Smps.Core.Interfaces.Account.Repositories;
    using SMPS.CrossCutting.Constants;
    using SMPS.CrossCutting.CustomExceptions;

    /// <summary>
    /// This class contains the methods related to user account.
    /// This is consumed from core using dependency injection
    /// Which would be passed from the consumers
    /// Prefixed this with EF to represent that this is an entity framework class.
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
                //The User Profile Object.
                UserProfile userProfile;
                using (SMPSEntities objectContext = new SMPSEntities())
                {
                    //Using IQueryable for better performance.
                    IQueryable<User> users = objectContext.Users;
                    //Getting the user model.
                    var user = users.Where(u => u.UserLoginId == userId).FirstOrDefault();
                    if (user != null)
                    {
                        //Getting the user prfile from user model.
                        userProfile = MapProperties(user);
                    }
                    else
                    {
                        //Exception if user not found
                        throw new NoDataFoundException(ErrorMessages.ApplicationErrorMessage);
                    }
                }

                //return user profile
                return userProfile;
            }
            catch (NoDataFoundException)
            {
                //throw the exception
                throw;
            }
            catch (Exception)
            {
                //throw the exception
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
            //The User Profile Object.
            UserProfile userProfile = null;
            try
            {
                using (SMPSEntities objectContext = new SMPSEntities())
                {
                    //Using IQueryable for better performance.
                    IQueryable<User> users = objectContext.Users;
                    //Getting the user model.
                    var user = users.Where(u => u.UserLoginId == userId && u.UserLoginPassword == password).FirstOrDefault();
                    //Checks if user is not null.
                    if (user != null)
                    {
                        // Getting the user prfile from user model.
                        //Maps the properties from user model to user profile
                        //And return the same.
                        userProfile = MapProperties(user);
                    }
                    else
                    {
                        //throw the exception
                        //With an error message.
                        throw new NoDataFoundException(ErrorMessages.ApplicationErrorMessage);
                    }
                }

                //return user profile
                return userProfile;
            }
            catch (Exception)
            {
                //throw the exception
                //This is a generic exception
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
            //The User Profile Object.
            UserProfile userProfile = null;
            try
            {
                //Check for null condition
                if (user != null)
                {
                    //Mapping all the properties.
                    userProfile = new UserProfile();
                    //First Name
                    userProfile.FirstName = user.FirstName;
                    //Last Name
                    userProfile.LastName = user.LastName;
                    //Mobile Number
                    userProfile.MobileNumber = user.MobileNumber;
                    //Parking slot number.
                    userProfile.ParkingSlotNumber = user.ParkingSlotNumber;
                    //User Type.
                    userProfile.UserType = user.UserType;
                }
                else
                {
                    //throw the exception
                    throw new NoDataFoundException(ErrorMessages.ApplicationErrorMessage);
                }
            }
            catch (Exception)
            {
                //throw the exception
                //This is a generic exception
                throw;
            }

            //return user profile
            return userProfile;
        }
    }
}
