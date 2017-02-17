//-----------------------------------------------------------------------
// <copyright file="BaseController.cs" company="EPAM">
//     EPAM copyright tag.
// </copyright>
//<summary>This is the base controller.</summary>
//-----------------------------------------------------------------------

namespace Smps.WebApi.Controllers
{
    using System.Web.Http;
    using System.Web.Http.Cors;
    
    /// <summary>
    /// This class is the base controller for all web application controllers
    /// This will contain all the common methods related to all the controllers
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BaseController : ApiController
    {
    }
}
