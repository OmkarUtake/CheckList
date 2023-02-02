using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication2Crud.Models;

namespace WebApplication2Crud.Controllers
{
    [RequireHttps]
    public class CredentialController : Controller
    {

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
                    database.Credentials.Add(cd);
                    database.SaveChanges();
                    return View("Login");
                }
            }
            else
            {
                ViewBag.message = "User already Exist Please Select another User Name";
            }
            return View("SignUp");
        }

        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]

        public ActionResult Authenticate(Credential cd)
        {

            var isValid = database.Credentials.AnyAsync(x => x.UserName == cd.UserName && x.Password == cd.Password).Result;
            if (isValid)
            {
                FormsAuthentication.SetAuthCookie(cd.UserName, false);
                return RedirectToAction("Index", "Category");

            }
            else
            {
                ViewBag.message = "Enter Valid User Name & Password";
            }
            return View("Login");

        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return View("Login");
        }
    }
}