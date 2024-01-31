using Microsoft.AspNetCore.Mvc;

namespace OnlineShoppingCart_MVC.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
