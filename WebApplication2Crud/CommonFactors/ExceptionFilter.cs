using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.ExceptionHandling;
using System.Web.Mvc;

namespace WebApplication2Crud.CommonFactors
{
    public class CustomExceptionFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(System.Web.Mvc.ExceptionContext filterContext)
        {
            filterContext.Result = new ViewResult()
            {
                ViewName = "Error"
            };
            filterContext.ExceptionHandled = true;
        }
    }
}