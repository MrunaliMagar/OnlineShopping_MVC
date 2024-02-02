using Microsoft.EntityFrameworkCore;
using OnlineShoppingCart_MVC.Models;

namespace OnlineShoppingCart_MVC.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
    }
}
