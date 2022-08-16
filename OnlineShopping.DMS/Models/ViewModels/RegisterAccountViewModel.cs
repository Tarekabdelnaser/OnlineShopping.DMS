using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopping.DMS.Models.ViewModels
{
    [Keyless]
    public class RegisterAccountViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password, ErrorMessage = "Invalid Password")]
        [Compare("Password", ErrorMessage = "Not Matched Password")]
        public string ConfirmPassword { get; set; }



    }
}
