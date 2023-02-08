using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.ModelBinding;
using WebApplication2Crud.BuisnessLayer.Interfaces;
using WebApplication2Crud.Models;

namespace WebApplication2Crud.BuisnessLayer.Clasees
{

    public class Create : ICreate
    {
        readonly CategoryDbContext Database = new CategoryDbContext();

        public async Task AddProductAsync(Category category)
        {
            Database.Categories.Add(category);
            await Database.SaveChangesAsync();

        }

        public async Task<Category> UserIdentity(string name)
        {

            // var useridentity = User.Identity.Name;     //used for from authentication
            var userid = await Database.Credentials.Where(x => x.UserName == name).FirstOrDefaultAsync();

            Category category = new Category()
            {
                UserId = userid.id,
                Date = DateTime.Now.Date


            };

            return category;
        }


    }


}