//-----------------------------------------------------------------------
// <copyright file="UserAccountController.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//<summary>This is the User account controller.</summary>
//As a Technical Lead I want to create a solution using N- Tier architecture in visual studio 2015 
//so that my team can start their development activity	
//Jira Id-2094
//-----------------------------------------------------------------------

namespace Smps.WebApi.Controllers
{
    using System;
    using System.Web;
    using System.Web.Http;
    using System.Web.Http.Cors;
    using Core.BusinessObjects.Account;
    using Smps.Core.Interfaces.Account;
    using SMPS.CrossCutting.CustomExceptions;

    /// <summary>
    /// As a Technical Lead I want to create a solution using N- Tier architecture in visual studio 2015 
    ///so that my team can start their development activity	
    ///Jira Id-2094
    /// This class contains the methods related to user account.
    /// Angular code invokes this method.
    /// For getting the user account details.
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserAccountController : BaseController
    {
        /// <summary>
        /// The user account object.
        //  This is used across this class.
        /// </summary>
        private IUserAccount obj;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserAccountController" /> class.
        /// The dependencies are injected using castle windsor
        /// This is implemented using strategic design pattern.
        /// </summary>
        /// <param name="obj">The user account instance</param>
        public UserAccountController(IUserAccount obj)
        {
            //Assigning the object.
            this.obj = obj;
        }

        /// <summary>
        /// This method checks if user is valid or not
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <param name="password">The password</param>
        /// <returns>true or false.</returns>
        [HttpGet]
        public UserProfile ValidateUser(string userId, string password)
        {
            try
            {
                //Getting user profile.
                UserProfile userProfile = this.obj.ValidateUser(userId, password);
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
        /// Gets the user profile.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <returns>The user profile.</returns>
        [HttpGet]
        public UserProfile GetUserProfile(string userId)
        {
            try
            {
                //Getting user profile.
                UserProfile userProfile = this.obj.GetUserProfile(userId);
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
    }
}
