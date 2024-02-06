using Microsoft.EntityFrameworkCore;
using OnlineShoppingCart_MVC.Models;

namespace OnlineShoppingCart_MVC.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryProduct>()
                .HasOne(d => d.Product)
                .WithMany(e => e.CategoryProduct)
                .HasForeignKey(d => d.product_id);
        }
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<CategoryProduct> CategoryProduct { get; set; }
        public DbSet<Admin> Admin { get; set; } 


    }
}
