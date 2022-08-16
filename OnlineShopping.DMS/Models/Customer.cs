using System.ComponentModel.DataAnnotations;

namespace OnlineShopping.DMS.Models
{
    public class Customer
    {
        [Required]
        [Key]
        public int ID { get; set; }
        [Required]
        public string CompanyName { get; set; }
         


    }
}
