using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2Crud.CommonFactors
{
    public class CustFilter : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.Controller.ViewBag.message2 = "Report Generated Successfully...!";
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {

        }
    }
}