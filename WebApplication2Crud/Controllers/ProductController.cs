using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebApplication2Crud.Models;

namespace WebApplication2Crud.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        CategoryDbContext database = new CategoryDbContext();


        public async Task<ActionResult> CategoryWise()
        {
            List<Category> list = new List<Category>();

            var query = await
                (from p in database.Categories
                 select p.Icategory).Distinct().ToListAsync();

            foreach (var item in query)
            {
                Category obj = new Category();
                obj.Icategory = item;
                list.Add(obj);
            }
            return View(list);
        }

        public async Task<ActionResult> CategoryWiseView(string category)
        {
            SqlParameter[] valu = new SqlParameter[]
        {
                new SqlParameter("@categoryName",category)
        };

            ViewBag.CName = category;
            var query = await database.Categories.Where(x => x.Icategory == category).ToListAsync();
            return View(query);
        }

    }
}



