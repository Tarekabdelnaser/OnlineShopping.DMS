using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopping.DMS.Models
{
    public class Item
    {

        [Required]
        public int ID { get; set; }

        public int Quantity { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(1, double.MaxValue)]
        public double Price { get; set; }



        [Required]
        public string Description { get; set; }
        [Required]
        public string image { get; set; }
        [ForeignKey("Category")]
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }


        public virtual ICollection<Order> Orders { get; set; } = new HashSet<Order>();






    }
}
