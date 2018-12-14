using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;
using System.Web.Mvc;

namespace AllianceAssociationBank.Crm.Providers
{
    public class CookieTempDataProvider : ITempDataProvider
    {
        internal const string TempDataCookieKey = "__ControllerTempData";

        public CookieTempDataProvider()
        {
        }

        protected virtual IDictionary<string, object> LoadTempData(ControllerContext controllerContext)
        {
            var httpContext = controllerContext.HttpContext;
            var cookie = httpContext.Request.Cookies[TempDataCookieKey];
            if (cookie != null && !string.IsNullOrEmpty(cookie.Value))
            {
                var deserializedDictionary = Base64StringToDictionary(cookie.Value);

                cookie.Expires = DateTime.MinValue;
                cookie.Value = string.Empty;


                if (httpContext.Response != null && httpContext.Response.Cookies != null)
                {
                    var responseCookie = httpContext.Response.Cookies[TempDataCookieKey];
                    if (responseCookie != null)
                    {
                        cookie.Expires = DateTime.MinValue;
                        cookie.Value = string.Empty;
                    }
                }

                return deserializedDictionary;
            }

            return new Dictionary<string, object>();
        }

        IDictionary<string, object> ITempDataProvider.LoadTempData(ControllerContext controllerContext)
        {
            return LoadTempData(controllerContext);
        }

        protected virtual void SaveTempData(ControllerContext controllerContext, IDictionary<string, object> values)
        {
            var cookieValue = DictionaryToBase64String(values);

            var cookie = new HttpCookie(TempDataCookieKey);
            cookie.HttpOnly = true;
            cookie.Value = cookieValue;

            controllerContext.HttpContext.Response.Cookies.Add(cookie);
        }

        void ITempDataProvider.SaveTempData(ControllerContext controllerContext, IDictionary<string, object> values)
        {
            SaveTempData(controllerContext, values);
        }

        public static IDictionary<string, object> Base64StringToDictionary(string base64EncodedSerializedTempData)
        {
            var bytes = Convert.FromBase64String(base64EncodedSerializedTempData);
            using (var memStream = new MemoryStream(bytes))
            {
                var binFormatter = new BinaryFormatter();
                return binFormatter.Deserialize(memStream, null) as IDictionary<string, object>;
            }
        }

        public static string DictionaryToBase64String(IDictionary<string, object> values)
        {
            using (MemoryStream memStream = new MemoryStream())
            {
                memStream.Seek(0, SeekOrigin.Begin);
                var binFormatter = new BinaryFormatter();
                binFormatter.Serialize(memStream, values);
                memStream.Seek(0, SeekOrigin.Begin);
                var bytes = memStream.ToArray();
                return Convert.ToBase64String(bytes);
            }
        }
    }
}