using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebApplication2Crud.BuisnessLayer.Product.Interfaces;
using WebApplication2Crud.Models;

namespace WebApplication2Crud.BuisnessLayer.Product.Classes
{
    public class ShowCategory : IShowCategory
    {
        CategoryDbContext database = new CategoryDbContext();
        public async Task<List<Category>> AllCategory()
        {
            List<Category> list = new List<Category>();
            var query =
               await (from p in database.Categories
                      select p.Icategory).Distinct().ToListAsync();

            foreach (var item in query)
            {
                Category obj = new Category
                {
                    Icategory = item
                };
                list.Add(obj);
            }
            return list;
        }
    }
}