using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShoppingCart_MVC.Models
{
    public class Category
    {
        [Key]
        [Column("category_id")]
        public int category_id { get; set; }

        [Column("category_name")]
        public string category_name { get; set; }

        [Column("category_image")]
        public string category_image { get; set; }

        public ICollection<Product>? Product { get; set; }
    }
}
