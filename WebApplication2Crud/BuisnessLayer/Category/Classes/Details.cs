using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebApplication2Crud.BuisnessLayer.Interfaces;
using WebApplication2Crud.Models;

namespace WebApplication2Crud.BuisnessLayer.Clasees
{
    public class Details : IDetails
    {
        CategoryDbContext Database = new CategoryDbContext();
        public async Task<Category> ProductDetail(int id)
        {
            var data = await Database.Categories.Where(x => x.Id == id).SingleOrDefaultAsync();
            return data;
        }
    }
}