using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using OnlineShopping.DMS.Data.Status;

namespace OnlineShopping.DMS.Models
{
    public class Order
    {
        public int ID { get; set; }
     
        public bool InCart { get; set; }

        [DataType(DataType.Date)]

        [Column(TypeName = "Date")]

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]

        public DateTime OrderDate { get; set; }

        [DataType(DataType.Date)]

        [Column(TypeName = "Date")]

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]

        public DateTime DueDate { get; set; }

        [Range(0, int.MaxValue)]
        public int ItemQuantity { get; set; }
        [ForeignKey("Item")]
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }
    
        public Status status { get; set; }

        public virtual ICollection<OrderDetail> OrdersDetails { get; set; }




        [ForeignKey("IdentityUser")]

        public string UserId { get; set; }

        public virtual IdentityUser User { get; set; }




    }
}
