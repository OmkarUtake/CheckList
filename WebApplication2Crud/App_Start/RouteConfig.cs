using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication2Crud
{
    public class RouteConfig
    {

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{Id}",
                defaults: new { controller = "Credential", action = "Login", id = UrlParameter.Optional }
            );
        }
    }
}
