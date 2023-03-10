using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebApplication2Crud.CommonFactors;
using System.Web.Helpers;
using System.Security.Claims;
using System;
using System.Web.Http.Results;
using WebApplication2Crud.Models;
using System.Web;

namespace WebApplication2Crud
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            UnityConfig.RegisterComponents();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.Name;
        }

        protected void Application_AuthenticateRequest()
        {
            var token = Request.Cookies["token"]?.Value;
            if (token != null)
            {
                JWTHelper.AuthenticationRequest(token);
            }
        }



    }
}
