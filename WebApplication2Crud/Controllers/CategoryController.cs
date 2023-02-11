using System;
using System.Linq;
using System.Web.Mvc;
using WebApplication2Crud.Models;
using System.Threading.Tasks;
using System.Security.Claims;
using WebApplication2Crud.BuisnessLayer.Interfaces;

namespace WebApplication2Crud.Controllers
{

    public class CategoryController : Controller
    {
        private readonly ICreate _create;
        private readonly IEdit _edit;
        private readonly IPaging _paging;
        private readonly IDetails _details;
        private readonly IDelete _delete;
        public CategoryController(ICreate create, IEdit edit, IPaging paging, IDetails details, IDelete delete)
        {
            _create = create;
            _edit = edit;
            _paging = paging;
            _details = details;
            _delete = delete;
        }

        public ActionResult Index(double b = 5, int a = 1)
        {
            var data = _paging.IndexPagePaging(b, a, out int c);
            ViewBag.TotalPages = Math.Ceiling(c / b);
            return View(data);
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            var details = await _details.ProductDetail(id);
            return View(details);
        }

        [Authorize(Roles = "admin,customer")]
        [HttpGet]
        public async Task<ActionResult> Create()
        {
            var identity = User.Identity as ClaimsIdentity;
            var claims = identity.Claims;
            var IdentifierName = claims.Where(model => model.Type == ClaimTypes.Name).SingleOrDefault();
            string name = IdentifierName.Value;
            var category = await _create.UserIdentity(name);
            return View(category);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Category Cata)
        {
            if (ModelState.IsValid)
            {
                await _create.AddProductAsync(Cata);
                return RedirectToAction("Index");
            }
            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var details = await _details.ProductDetail(id);
            return View(details);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<ActionResult> Edit(Category data)
        {
            if (ModelState.IsValid)
            {
                await _edit.Update(data);
                return RedirectToAction("Index");
            }
            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            var details = await _details.ProductDetail(id);
            return View(details);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<ActionResult> Delete(int id, Category category)
        {
            await _delete.DeleteItem(id, category);
            return RedirectToAction("Index");
        }
    }
}
