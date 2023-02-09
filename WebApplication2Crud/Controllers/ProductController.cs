using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebApplication2Crud.BuisnessLayer.Product.Interfaces;
using WebApplication2Crud.Models;

namespace WebApplication2Crud.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IShowCategory _showCategory;
        private readonly IShowCategoryItem _showCategoryItem;
        public ProductController(IShowCategory showCategory, IShowCategoryItem showCategoryItem)
        {
            _showCategory = showCategory;
            _showCategoryItem = showCategoryItem;
        }
        public async Task<ActionResult> CategoryWise()
        {
            var list = await _showCategory.AllCategory();
            return View(list);
        }

        public async Task<ActionResult> CategoryWiseView(string category)
        {

            var query = await _showCategoryItem.CategoryItem(category);
            ViewBag.CName = category;
            return View(query);
        }

    }
}



