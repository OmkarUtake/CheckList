using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2Crud.BuisnessLayer.Interfaces;
using WebApplication2Crud.Models;

namespace WebApplication2Crud.BuisnessLayer.Clasees
{
    public class Delete : IDelete
    {
        CategoryDbContext Database = new CategoryDbContext();
        public async Task DeleteItem(int id, Category category)
        {
            category = await Database.Categories.Where(x => x.Id == id).SingleOrDefaultAsync();
            Database.Categories.Remove(category);
            await Database.SaveChangesAsync();
        }

    }
}