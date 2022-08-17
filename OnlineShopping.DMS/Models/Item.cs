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
        public decimal Price { get; set; }



        [Required]
        public string Description { get; set; }
        [Required]
        public string image { get; set; }
        [ForeignKey("Category")]
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; } 


        [ForeignKey("Tax")]

        public int? TaxId { get; set; }
        public virtual Tax Tax { get; set; }

        [ForeignKey("Discount")]
        public int? DiscountId { get; set; }
        public virtual Discount Discount { get; set; }

      public  decimal totalPrice { set; get; }




        public virtual ICollection<Order> Orders { get;} = new HashSet<Order>();






    }
}
