using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AllianceAssociationBank.Crm.Extensions
{
    public static class HttpRequestExtensions
    {
        public static string GetBaseUrl(this HttpRequestBase httpRequestBase)
        {
            return httpRequestBase.Url.GetLeftPart(UriPartial.Authority);
        }

        public static string GetBaseUrl(this HttpRequest httpRequest)
        {
            return httpRequest.Url.GetLeftPart(UriPartial.Authority);
        }
    }
}