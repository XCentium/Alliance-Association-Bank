using AllianceAssociationBank.Crm.Filters;
using Serilog;
using System;
using System.Web;
using System.Web.Mvc;

namespace AllianceAssociationBank.Crm
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new MvcDefaultExceptionFilter(Log.Logger));
            //filters.Add(new HandleErrorAttribute());
        }
    }
}
