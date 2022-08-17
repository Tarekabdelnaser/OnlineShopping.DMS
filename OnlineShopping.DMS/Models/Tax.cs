using System.ComponentModel.DataAnnotations;

namespace OnlineShopping.DMS.Models
{
    public class Tax
    {
        [Key]
        public int ID { get; set; }
        public decimal value { get; set; }

        public ICollection<Item> Items { get; }=new List<Item>();


    }
}
