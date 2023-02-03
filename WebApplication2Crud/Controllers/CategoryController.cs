using System;
using System.Linq;
using System.Web.Mvc;
using WebApplication2Crud.Models;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Configuration;
using WebApplication2Crud.StoreProcedures;

namespace WebApplication2Crud.Controllers
{
    [Authorize]
    public class CategoryController : Controller

    {
        readonly string Cs = ConfigurationManager.ConnectionStrings["CategoryDbContext"].ConnectionString;
        readonly CategoryDbContext Database = new CategoryDbContext();



        public ActionResult Index(double b = 5, int a = 1)
        {
            PagingProcedure pg = new PagingProcedure();
            var data = pg.IndexPagePaging(b, a, out int c);
            ViewBag.TotalPages = Math.Ceiling(c / b);

            return View(data);
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            var details = await Database.Categories.Where(x => x.Id == id).SingleOrDefaultAsync();

            return View(details);
        }


        [HttpGet]
        public async Task<ActionResult> Create()
        {
            var userid = await Database.Credentials.Where(x => x.UserName == User.Identity.Name).FirstOrDefaultAsync();
            Category category = new Category()
            {
                UserId = userid.id
            };

            return View(category);
        }


       
        [HttpPost]
        public async Task<ActionResult> Create(Category Cata)
        {

            if (ModelState.IsValid)
            {
                Database.Categories.Add(Cata);
                await Database.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var details = await Database.Categories.Where(x => x.Id == id).FirstOrDefaultAsync();

            return View(details);
        }


        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<ActionResult> Edit(Category data)
        {
            if (ModelState.IsValid)
            {
                Database.Entry(data).State = System.Data.Entity.EntityState.Modified;
                await Database.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var details = await Database.Categories.Where(x => x.Id == id).FirstOrDefaultAsync();
            return View(details);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<ActionResult> Delete(int id, Category category)
        {

            category = await Database.Categories.Where(x => x.Id == id).FirstOrDefaultAsync();
            Database.Categories.Remove(category);
            await Database.SaveChangesAsync();
            return RedirectToAction("Index");

        }
    }
}
