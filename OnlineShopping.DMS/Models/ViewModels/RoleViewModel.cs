using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopping.DMS.Models.ViewModels
{
    [Keyless]
    public class RoleViewModel
    {
        [Required]
        public string RoleName { get; set; }




    }
}
