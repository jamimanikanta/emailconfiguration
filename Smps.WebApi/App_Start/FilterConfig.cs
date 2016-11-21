//-----------------------------------------------------------------------
// <copyright file="FilterConfig.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace Smps.WebApi
{
    using System.Web.Mvc;

    /// <summary>
    /// This file contains the filter config details.
    /// </summary>
    public class FilterConfig
    {
        /// <summary>
        /// This method registers the filters
        /// </summary>
        /// <param name="filters">The filters to register</param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
