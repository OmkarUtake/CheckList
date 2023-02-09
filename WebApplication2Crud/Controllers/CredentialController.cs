using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2Crud.BuisnessLayer.User.Interfaces;
using WebApplication2Crud.CommonFactors;
using WebApplication2Crud.Models;

namespace WebApplication2Crud.Controllers
{
    [RequireHttps]
    public class CredentialController : Controller
    {
        private readonly IRegisterUser _registerUser;
        public CredentialController(IRegisterUser registerUser)
        {
            _registerUser = registerUser;
        }

        CategoryDbContext database = new CategoryDbContext();

        public ActionResult SignUp()
        {

            return View();
        }

        [HttpPost]
        public ActionResult SignUp(Credential cd)
        {
            bool userIsUniqe = database.Credentials.Any(x => x.UserName == cd.UserName);
            bool emailIsUnique = database.Credentials.Any(x => x.EmailId == cd.EmailId);

            if (userIsUniqe == false && emailIsUnique == false)
            {
                if (ModelState.IsValid)
                {
                    cd.Password = PasswordEncoder.Encode(cd.Password);
                    database.Credentials.Add(cd);
                    database.SaveChanges();
                    return View("Login");
                }
                else
                {
                    ViewBag.message = "Please input correct details";
                }
            }
            else
            {
                ViewBag.message = "User already Exist Please Select another User Name";
            }
            return View("SignUp");
        }


        //public ActionResult SignUp(Credential cd)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        ViewBag.message = _registerUser.RegisterUserDetails(cd);
        //        return View("Index", "Category");

        //    }
        //    return View("SignUp");
        //}


        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Authenticate(Credential cd)
        {
            if (cd.UserName != null && cd.Password != null)
            {
                cd.Password = PasswordEncoder.Encode(cd.Password);
                var user = database.Credentials.SingleOrDefault(x => x.UserName == cd.UserName && x.Password == cd.Password);
                if (user != null)
                {
                    cd.UserRole = user.UserRole;
                    var token = JWTHelper.CreateJWTToken(cd);
                    Response.Cookies.Set(new HttpCookie("token", token));
                    //FormsAuthentication.SetAuthCookie(cd.UserName, false);
                    return RedirectToAction("Index", "Category");

                }
                else
                {
                    ViewBag.message = "Enter Valid User Name & Password";
                }
            }
            else
            {
                ViewBag.message = "Enter Valid User Name & Password";
            }
            return View("Login");

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