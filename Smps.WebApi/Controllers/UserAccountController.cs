//-----------------------------------------------------------------------
// <copyright file="UserAccountController.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Smps.WebApi.Controllers
{
    using System.Web.Http;
    using Smps.Core.Interfaces.Account;
    using System.Web.Http.Cors;

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
        public bool IsUserValid(string userId, string password)
        {
            bool isUserValid = this.obj.IsValidUser(userId, password);
            return isUserValid;
        }
    }
}
