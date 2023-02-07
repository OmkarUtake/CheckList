using System.Data.Entity;

namespace WebApplication2Crud.Models
{
    public class CategoryDbContext : DbContext
    {
        
        public DbSet<Category> Categories { get; set; }

        public DbSet<Credential> Credentials { get; set; }

       




    }
}