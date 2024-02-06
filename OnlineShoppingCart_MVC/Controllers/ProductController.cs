using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineShoppingCart_MVC.Data;
using OnlineShoppingCart_MVC.Models;

namespace OnlineShoppingCart_MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Product
        public async Task<IActionResult> IndexProduct()
        {
            var applicationDbContext = _context.Product.Include(p => p.CategoryProduct);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Product/Details/5
        public async Task<IActionResult> DetailsProduct(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.CategoryProduct)
                .FirstOrDefaultAsync(m => m.product_id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Product/Create
        public IActionResult CreateProduct()
        {
            IEnumerable<SelectListItem> CategoryList = _context.Category
                .Select(u => new SelectListItem
                {
                    Text = u.category_name,
                    Value = u.category_id.ToString()
                });

            ViewBag.CategoryList = CategoryList;
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProduct(Product product, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"CategoriesImgs\Product");

                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    product.product_image = @"\CategoriesImgs\Product\" + fileName;
                }
                _context.Add(product);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Product created Successfully";
                return RedirectToAction(nameof(IndexProduct));
            }
            return View(product);
        }

        // GET: Product/Edit/5
        public async Task<IActionResult> EditProduct(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            IEnumerable<SelectListItem> CategoryList = _context.Category
                .Select(u => new SelectListItem
                {
                    Text = u.category_name,
                    Value = u.category_id.ToString()
                });

            ViewBag.CategoryList = CategoryList;
            return View(product);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProduct(int id,  Product product, IFormFile file)
        {

            if (ModelState.IsValid)
            {
               // var data = _context.Product.Find(id);
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"CategoriesImgs\Product");

                    if (!string.IsNullOrEmpty(product.product_image))
                    {
                        var oldImgPath = Path.Combine(wwwRootPath, product.product_image.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImgPath))
                        {
                            System.IO.File.Delete(oldImgPath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    product.product_image = @"\CategoriesImgs\Product\" + fileName;
                }

                _context.Update(product);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Product updated Successfully";
                return RedirectToAction(nameof(IndexProduct));

            }
            return View(product);
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> DeleteProduct(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.CategoryProduct)
                .FirstOrDefaultAsync(m => m.product_id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("DeleteProduct")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product != null)
            {
                _context.Product.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(IndexProduct));
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.product_id == id);
        }
    }
}
