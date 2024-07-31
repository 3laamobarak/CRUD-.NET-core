using System.ComponentModel.DataAnnotations;

namespace DotNETDay2.Models
{
    public class RoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
