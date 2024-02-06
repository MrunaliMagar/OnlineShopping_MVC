using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OnlineShoppingCart_MVC.Models
{
    public class Admin
    {
        [Key]
        public int admin_id { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Admin should contain only letters.")]
        public string admin_name { get; set; }
        [Required]  
        public string admin_password { get; set;}

    }
}
