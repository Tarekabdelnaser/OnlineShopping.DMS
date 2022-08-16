using System.ComponentModel.DataAnnotations;

namespace OnlineShopping.DMS.Models
{
    public class Category
    {

        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string image { get; set; }


        public virtual ICollection<Item> Items { get; set; } =
            new HashSet<Item>();
    }
}
