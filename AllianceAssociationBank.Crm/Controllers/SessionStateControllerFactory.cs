using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;

namespace AllianceAssociationBank.Crm.Controllers
{
    public class SessionStateControllerFactory : DefaultControllerFactory
    {
        protected override SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, Type controllerType)
        {
            // Default session state to disabled
            if (controllerType == null || !Attribute.IsDefined(controllerType, typeof(SessionStateAttribute)))
            {
                return SessionStateBehavior.Disabled;
            }

            return base.GetControllerSessionBehavior(requestContext, controllerType);
        }
    }
}