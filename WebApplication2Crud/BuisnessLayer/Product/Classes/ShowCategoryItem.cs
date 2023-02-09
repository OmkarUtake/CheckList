using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication2Crud.BuisnessLayer.Product.Interfaces;
using WebApplication2Crud.Models;

namespace WebApplication2Crud.BuisnessLayer.Product.Classes
{
    public class ShowCategoryItem : IShowCategoryItem
    {
        CategoryDbContext database = new CategoryDbContext();
        public async Task<List<Category>> CategoryItem(string category)
        {
            SqlParameter[] valu = new SqlParameter[]
     {
                new SqlParameter("@categoryName",category)
     };

            //ViewBag.CName = category;
            var query = await database.Categories.Where(x => x.Icategory == category).ToListAsync();

            return query;
        }

    }
}