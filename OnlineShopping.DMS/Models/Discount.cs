using System.ComponentModel.DataAnnotations;

namespace OnlineShopping.DMS.Models
{
    public class Discount
    {

        [Key]
        public int ID { get; set; }
        public decimal value { get; set; }

        public ICollection<Item> Items { get; set; }



    }
}
