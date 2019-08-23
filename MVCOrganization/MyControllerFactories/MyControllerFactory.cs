using DataAccessLayer.Repositories;
using MVCOrganization.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVCOrganization.MyControllerFactories
{
    public class MyControllerFactory:DefaultControllerFactory
    {
        static UserRepository repUser;
        static ImageRepository repImage;

        public override IController CreateController(RequestContext requestContext , string controllerName)
        {
            if(repUser == null)
            {
                repUser = new UserRepository();
            }
            if(controllerName == "Home")
            {
                return new HomeController(repUser);
            }
            return base.CreateController(requestContext, controllerName);
        }

    }
}