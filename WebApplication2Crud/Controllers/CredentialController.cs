using System;
using System.Web;
using System.Web.Mvc;
using WebApplication2Crud.BuisnessLayer.User.Interfaces;
using WebApplication2Crud.Models;

namespace WebApplication2Crud.Controllers
{
    [RequireHttps]
    public class CredentialController : Controller
    {
        private readonly IRegisterUser _registerUser;
        private readonly IAuthentication _authentication;
        public CredentialController(IRegisterUser registerUser, IAuthentication authentication)
        {
            _registerUser = registerUser;
            _authentication = authentication;
        }
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(Credential cd)
        {
            if (_registerUser.IsExist(cd))
            {
                _registerUser.RegisterUserDetails(cd);
                return View("Login");
            }
            else
            {
                ViewBag.message = "Please input correct details";
                return View("SignUp");
            }
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authenticate(Credential cd)
        {
            var isValid = _authentication.IsValidUser(cd, out string userToken);
            if (isValid)
            {
                Response.Cookies.Set(new HttpCookie("token", userToken));
                return RedirectToAction("Index", "Category");
            }
            else
            {
                ViewBag.message = "Enter Valid User Name & Password";
                return View("Login");
            }
        }

        public ActionResult Logout()
        {
            // FormsAuthentication.SignOut();
            if (Request.Cookies["token"] != null)
            {
                var c = new HttpCookie("token")
                {
                    Expires = DateTime.Now.AddSeconds(1)
                };
                Response.Cookies.Add(c);
            }
            return View("Login");
        }
    }
}