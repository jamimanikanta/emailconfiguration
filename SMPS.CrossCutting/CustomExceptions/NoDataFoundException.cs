using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMPS.CrossCutting.CustomExceptions
{
    public class NoDataFoundException : Exception
    {
        public NoDataFoundException():base()
        {

        }

        public NoDataFoundException(string errorMessage) : base(errorMessage)
        {

        }
    }
}
