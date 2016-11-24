//-----------------------------------------------------------------------
// <copyright file="UserAccountController.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
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
    /// This class contains the methods related to user account.
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserAccountController : BaseController
    {
        /// <summary>
        /// The user account object.
        /// </summary>
        private IUserAccount obj;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserAccountController" /> class.
        /// </summary>
        /// <param name="obj">The user account instance</param>
        public UserAccountController(IUserAccount obj)
        {
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
                UserProfile userProfile = this.obj.ValidateUser(userId, password);
                HttpContext.Current.Session["userDetails"] = userProfile;
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
        /// Gets the user profile.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <returns>The user profile.</returns>
        [HttpGet]
        public UserProfile GetUserProfile(string userId)
        {
            try
            {
                UserProfile userProfile = this.obj.GetUserProfile(userId);
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
    }
}
