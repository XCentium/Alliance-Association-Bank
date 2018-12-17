using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace AllianceAssociationBank.Crm.Constants
{
    public static class UserErrorContent
    {
        public static class Title
        {
            public const string BadRequest = "Invalid Operation";
            public const string NotFound = "Not Found";
            public const string InternalServerError = "Error";

            public static string GetByStatusCode(HttpStatusCode statusCode)
            {
                switch (statusCode)
                {
                    case HttpStatusCode.BadRequest:
                        return BadRequest;
                    case HttpStatusCode.NotFound:
                        return NotFound;
                    case HttpStatusCode.InternalServerError:
                        return InternalServerError;
                    default:
                        return InternalServerError;
                }
            }
        }

        public static class Message
        {
            public const string BadRequest = "Your request resulted in a error.";
            public const string CreateProjectFirst = "Please save a project record before performing this operation.";
            public const string NotFound = "The resource you are looking for has been removed or is temporarily unavailable.";
            public const string RecordNotFound = "The requested record was not found.";
            public const string InternalServerError = "An error occurred while processing your request. Please try again later.";

            public static string GetByStatusCode(HttpStatusCode statusCode)
            {
                switch (statusCode)
                {
                    case HttpStatusCode.BadRequest:
                        return BadRequest;
                    case HttpStatusCode.NotFound:
                        return NotFound;
                    case HttpStatusCode.InternalServerError:
                        return InternalServerError;
                    default:
                        return InternalServerError;
                }
            }

            public static string FormatMessageForRecordNotFound(string recordType, int recordId)
            {
                return string.Format("The requested {0} record with ID of {1} was not found.", recordType, recordId);
            }
        }
    }
}