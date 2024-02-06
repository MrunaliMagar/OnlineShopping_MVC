using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShoppingCart_MVC.Models
{
    public class CategoryProduct
    {
        [Key]

          public int id {  get; set; }

        [ForeignKey("product_id")]
        public int product_id { get; set; }
        public Product Product { get; set; }

        [ForeignKey("category_id")]

        public int category_id { get; set; }
        public Category Category { get; set; }

       
     
    }
}