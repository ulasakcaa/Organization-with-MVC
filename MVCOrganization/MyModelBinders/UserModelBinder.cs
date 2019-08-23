using DataAccessLayer;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCOrganization.MyModelBinders
{
    public class UserModelBinder: DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (controllerContext.RequestContext.HttpContext.Request.QueryString["UserId"] == null)
                return base.BindModel(controllerContext, bindingContext);

            UserRepository rep = new UserRepository();

            int UserId = Convert.ToInt32(controllerContext.RequestContext.HttpContext.Request.QueryString["UserId"]);
            User usr = rep.Get(UserId);
            return usr;
        }
    }
}