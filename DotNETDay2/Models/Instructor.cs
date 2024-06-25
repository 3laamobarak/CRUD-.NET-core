using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace DotNETDay2.Models
{
    public class Instructor
    {
        public int ID { get; set; }
        [Required]
        [RegularExpression(pattern:"[a-zA-z_]{3,}")]
        [Remote (controller:"instructor",action:"NameExist",AdditionalFields ="ID")]
        public string name { get; set; }
//        [RegularExpression(@"\w+\.(jpg|png)")]
        public string? image { get; set; }
        [Required]
        [Range(minimum:8000,maximum:16000)]
        public int salary { get; set; }
        [Required]
        [MaxLength(100)]
        [addressvalidator]
        public string address { get; set; }
        [ForeignKey("dept")]
        public int dept_id { get; set; }
        public Department? dept { get; set; }
    }
}
