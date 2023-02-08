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

    public class Edit : IEdit
    {
        readonly CategoryDbContext Database = new CategoryDbContext();
        public async Task Update(Category data)
        {
            Database.Entry(data).State = System.Data.Entity.EntityState.Modified;
            await Database.SaveChangesAsync();


        }
    }
}