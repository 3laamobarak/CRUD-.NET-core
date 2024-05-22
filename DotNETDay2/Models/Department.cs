using System.ComponentModel.DataAnnotations;

namespace DotNETDay2.Models
{
    public class Department
    {
        public int ID { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string manager { get; set; }       
    }
}
