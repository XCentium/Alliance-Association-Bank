using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace AllianceAssociationBank.Crm.Exceptions
{
    public class InvalidReportException : Exception
    {
        public InvalidReportException()
        {
        }

        public InvalidReportException(string message) 
            : base(message)
        {
        }

        public InvalidReportException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }
    }
}