using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace JWTApi.Controllers
{

    public class AccountController : ApiController
    {
        public string Newaction()
        {
            return "Hello";
        }

        [System.Web.Mvc.HttpGet]
        public HttpResponseMessage ValidLogin(string username, string password)
        {
            if (username == "admin" && password == "admin")
            {
                return Request.CreateResponse(HttpStatusCode.OK, value: TokenManager.GenerateToken(username));
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadGateway, message: "Invalid user");
            }

        }
    }
}
