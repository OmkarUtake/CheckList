using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebGrease.Configuration;
using System.Web.Http;
using WebApplication2Crud.CommonFactors;
using System.Web.Helpers;
using System.Security.Claims;

namespace WebApplication2Crud
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.Role;

        }

        protected void Application_AuthenticateRequest()
        {
            var token = Request.Cookies["token"].Value;
            if (token != null)
            {
                JWTHelper.AuthenticationRequest(token);
            }
        }




    }
}
