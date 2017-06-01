//-----------------------------------------------------------------------
// <copyright file="UserAccountController.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//<summary>This is the User account controller.</summary>
//As a Technical Lead I want to create a solution using N- Tier architecture in visual studio 2015 
//so that my team can start their development activity	
//Jira Id-2094
//-----------------------------------------------------------------------

using System;
using System.Linq;
using Smps.Core.BusinessObjects.Seeker;
using Smps.Core.Interfaces.Holder;
using Smps.Core.Interfaces.Seeker;
using SMPS.CrossCutting.CustomExceptions;

namespace Smps.WebApi.Controllers
{


    using System.Web.Http;

    using Core.BusinessObjects.Account;
    using Core.Interfaces.Account;
    using Core.BusinessObjects.Holder;
    using System.Collections.Generic;


    /// <summary>
    /// As a Technical Lead I want to create a solution using N- Tier architecture in visual studio 2015 
    ///so that my team can start their development activity	
    ///Jira Id-2094
    /// This class contains the methods related to user account.
    /// Angular code invokes this method.
    /// For getting the user account details.
    /// </summary>
    public class UserAccountController : BaseController
    {
        /// <summary>
        /// The user account object.
        //  This is used across this class.
        /// </summary>
        private readonly IUserAccount obj;

        private readonly IHolderService ihs;
        private readonly ISeekerService iss;
        object resultMsg;
        private UserProfile userProfile;
        private List<SeekerPerson> sekerPerson;
        private List<UserProfile> listofuserProfile;
        /// <summary>
        /// Initializes a new instance of the <see cref="UserAccountController" /> class.
        /// The dependencies are injected using castle windsor
        /// This is implemented using strategic design pattern.
        /// </summary>
        /// <param name="obj">The user account instance</param>
        public UserAccountController(IUserAccount obj, IHolderService ihs, ISeekerService iss)
        {
            //Assigning the object.
            this.obj = obj;
            this.ihs = ihs;
            this.iss = iss;

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
            //Getting user profile.
            userProfile = obj.ValidateUser(userId, password);
            return userProfile;
        }

        /// <summary>
        /// Gets the user profile.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <returns>The user profile.</returns>
        [HttpGet]
        public UserProfile GetUserProfile(string userId)
        {
            //Getting user profile.
            userProfile = obj.GetUserProfile(userId);
            return userProfile;
        }



        [HttpGet]
        public List<SeekerPerson> CheckSeekersElgibility(string userId, DateTime begindate, DateTime enddate)
        {

            sekerPerson = iss.CheckSeekersElgibility(userId, begindate, enddate);
            return sekerPerson;
        }

        [HttpGet]
        
        public List<HolderPerson> GetHoldersTabledetail(int? id)
        {




            return ihs.GetHoldersTabledetail(id);
        }







        [HttpGet]
        public List<UserProfile> GetAllSeekers()
        {

            listofuserProfile = obj.GetAllSeekers();

            return listofuserProfile.ToList();

        }


        [HttpGet]
        public object RequestSlot(int empno)
        {
            resultMsg = iss.RequestForSlot(empno);

            return resultMsg;


        }

        [HttpPost]
        public List<HolderPerson> Releaseslot(HolderPerson usr)
        {
            try
            {
                List<HolderPerson> res = ihs.Releaseslot(usr);
                
                return res;

            }
            catch (NoDataFoundException)
            {
                //throw the exception
                throw;
            }
            catch (Exception)
            {
                //throw the exception
                throw new NotImplementedException();
            }
        }





    }
}
