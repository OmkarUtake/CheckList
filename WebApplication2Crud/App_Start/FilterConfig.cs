using System.Web;
using System.Web.Mvc;
using WebApplication2Crud.CommonFactors;

namespace WebApplication2Crud
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new CustFilter());
        }
    }
}
