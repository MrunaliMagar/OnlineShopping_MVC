using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineShoppingCart_MVC.Models
{
    public class Product
    {
        [Key]
        [Column("product_id")]
        public int product_id { get; set; }

        [Column("product_name")]
        public string product_name { get; set;}

        [Column("product_description")]
        public string product_description { get; set;}

        [Column("product_mrp")]
        public string product_mrp { get; set;}

        [Column("offer_price")]
        public string product_offer_price { get; set;}

        [Column("product_quantity")]
        public int product_quantity { get; set;}

        [Column("product_image")]
        public string image_path { get; set;}

        [ForeignKey("category_id")]
        public Category? Category { get; set; }
    }
}
