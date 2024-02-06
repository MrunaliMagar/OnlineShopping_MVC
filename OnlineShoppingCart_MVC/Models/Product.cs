using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace OnlineShoppingCart_MVC.Models
{
    public class Product
    {
        [Key]
        [Column("product_id")]
        public int product_id { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Product name not be exeed")]
        [Column("product_name")]
        public string product_name { get; set;}

        [Required]
        [StringLength(20, ErrorMessage ="Description not be exeed")]
        [Column("product_description")]
        public string product_description { get; set;}

        [Required]
        [Range(200, 999999, ErrorMessage ="Please evter the price within range")]
        [Column("product_mrp")]
        public string product_mrp { get; set;}

        [Required]
        [Range(200, 999999, ErrorMessage = "Please evter the price within range")]

        [Column("offer_price")]
        public string product_offer_price { get; set;}

        [Required]
        [Range(1, 20, ErrorMessage = "Please evter the quantity within range")]
        [Column("product_quantity")]
        public int product_quantity { get; set;}

        [Column("product_image")]
        [ValidateNever]
        public string product_image { get; set;}

        [NotMapped]
        [Display(Name = "ChooseProductImage")]
        [ValidateNever]
        public IFormFile product_imagepath { get; set; }

        [Display(Name = "Category")]
        [ValidateNever]
        public int? category_id { get; set; }

   
        public ICollection<CategoryProduct> CategoryProduct { get; set; }=new List<CategoryProduct>();
    }
}
