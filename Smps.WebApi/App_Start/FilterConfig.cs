//-----------------------------------------------------------------------
// <copyright file="FilterConfig.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//<summary>This is the configuration class.</summary>
//-----------------------------------------------------------------------

namespace Smps.WebApi
{
    using System.Web.Mvc;

    /// <summary>
    /// This file contains the filter config details.
    /// Filters are custom classes that provide both a declarative and programmatic 
    /// means to add pre-action and post-action behavior to controller action methods.
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
