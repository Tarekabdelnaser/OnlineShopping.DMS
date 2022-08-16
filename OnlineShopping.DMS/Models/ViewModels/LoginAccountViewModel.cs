using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopping.DMS.Models.ViewModels
{
    public class LoginAccountViewModel
    {
     
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool isPersisite { get; set; }

        public string ReturnUrl { get; set; }
     



    }
}
