//-----------------------------------------------------------------------
// <copyright file="NoDataFoundException.cs" company="CompanyName">
//     Company copyright tag.
// </copyright>
//-----------------------------------------------------------------------

namespace SMPS.CrossCutting.CustomExceptions
{
    using System;

    /// <summary>
    /// This is a custom exception class.
    /// </summary>
    public class NoDataFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NoDataFoundException" /> class.
        /// </summary>
        public NoDataFoundException() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NoDataFoundException" /> class.
        /// </summary>
        /// <param name="errorMessage">The error message.</param>
        public NoDataFoundException(string errorMessage) : base(errorMessage)
        {
        }
    }
}
