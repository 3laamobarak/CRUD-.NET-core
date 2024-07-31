using System.ComponentModel.DataAnnotations;

namespace DotNETDay2.Models
{
    public class RegisteraccountViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("password",ErrorMessage="Password and Confirm not Match")]
        public string ConfirmPassword { get; set; }
        
    }
}
