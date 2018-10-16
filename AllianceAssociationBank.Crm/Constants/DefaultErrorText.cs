﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace AllianceAssociationBank.Crm.Constants
{
    public static class DefaultErrorText
    {
        public static class Title
        {
            public const string BadRequest = "Invalid Request";
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
                        return "Error";
                }
            }
        }

        public static class Message
        {
            public const string BadRequest = "Your request resulted in a error.";
            public const string CreateProjectFirst = "Please create a Project record before performing this operation.";
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
                        return "An error occurred while processing your request. Please try again later.";
                }
            }
        }
    }
}