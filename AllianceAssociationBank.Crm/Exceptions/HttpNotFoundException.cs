using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Web;

namespace AllianceAssociationBank.Crm.Exceptions
{
    public class HttpNotFoundException : HttpException
    {
        public HttpNotFoundException() 
            : base((int)HttpStatusCode.NotFound, "The requested resource is not found.")
        {
        }

        public HttpNotFoundException(string message) 
            : base((int)HttpStatusCode.NotFound, message)
        {
        }
    }
}