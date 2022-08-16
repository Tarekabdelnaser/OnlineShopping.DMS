using System.ComponentModel.DataAnnotations;

namespace OnlineShopping.DMS.Models
{
    public class UnitOfMeasure
    {

        [Key]
        public int ID { get; set; }


        public string UOM { get; set; }

        public string Description { get; set; }

        public ICollection<Item> Items { get; set; }




    }
}
