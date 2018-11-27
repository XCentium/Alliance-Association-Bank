using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AllianceAssociationBank.Crm.Tests.TestHelpers
{
    public static class ActionResultExtensions
    {
        public static TModel GetModelFromActionResult<TModel>(this ActionResult actionResult)
        {
            return (TModel)((ViewResult)actionResult).Model;
        }
    }
}
