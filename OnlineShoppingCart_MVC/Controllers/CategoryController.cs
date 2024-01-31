using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShoppingCart_MVC.Data;
using OnlineShoppingCart_MVC.Models;

namespace OnlineShoppingCart_MVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext context;
        public CategoryController(ApplicationDbContext context) 
        { 
            this.context = context;
        }

        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await context.Category.ToListAsync();
            return View(categories);
        }
    }
}
