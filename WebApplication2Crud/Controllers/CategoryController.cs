using System;
using System.Linq;
using System.Web.Mvc;
using WebApplication2Crud.Models;
using System.Data.Entity;
using System.Threading.Tasks;
using WebApplication2Crud.StoreProcedures;
using System.Security.Claims;
using WebApplication2Crud.BuisnessLayer.Interfaces;
using WebApplication2Crud.BuisnessLayer.Clasees;

namespace WebApplication2Crud.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        readonly CategoryDbContext Database = new CategoryDbContext();
        public ActionResult Index(double b = 5, int a = 1)
        {
            IPaging paging = new PagingProcedure();
            var data = paging.IndexPagePaging(b, a, out int c);
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
            var identity = User.Identity as ClaimsIdentity;
            var claims = identity.Claims;
            var IdentifierName = claims.Where(model => model.Type == ClaimTypes.Name).SingleOrDefault();
            string name = IdentifierName.Value;
            ICreate create = new Create();
            var category = await create.UserIdentity(name);

            return View(category);
        }


        [HttpPost]
        public async Task<ActionResult> Create(Category Cata)
        {
            if (ModelState.IsValid)
            {
                ICreate create = new Create();
                await create.AddProductAsync(Cata);
                return RedirectToAction("Index");
            }
            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var details = await Database.Categories.Where(x => x.Id == id).SingleOrDefaultAsync();

            return View(details);
        }


        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<ActionResult> Edit(Category data)
        {
            if (ModelState.IsValid)
            {
                IEdit update = new Edit();
                await update.Update(data);
                return RedirectToAction("Index");
            }
            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var details = await Database.Categories.Where(x => x.Id == id).SingleOrDefaultAsync();
            return View(details);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<ActionResult> Delete(int id, Category category)
        {

            category = await Database.Categories.Where(x => x.Id == id).SingleOrDefaultAsync();
            Database.Categories.Remove(category);
            await Database.SaveChangesAsync();
            return RedirectToAction("Index");

        }
    }
}
