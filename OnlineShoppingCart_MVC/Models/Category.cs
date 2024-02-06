using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShoppingCart_MVC.Models
{
    public class Category
    {
        [Key]
        [Column("category_id")]
        public int category_id { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Category name not be exeed")]
      
        public string category_name { get; set; }



        public ICollection<CategoryProduct> CategoryProduct { get; set; } = new List<CategoryProduct>();
    }
}
