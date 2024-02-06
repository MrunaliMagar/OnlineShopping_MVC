using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineShoppingCart_MVC.Models;

namespace OnlineShoppingCart_MVC.ViewModel
{
    public class ProductVM
    {
        public Product Product { get; set; }
        public IEnumerable<SelectListItem> MyProperty { get; set; }
    }
}
