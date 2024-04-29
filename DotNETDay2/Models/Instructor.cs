using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace DotNETDay2.Models
{
    public class Instructor
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public int salary { get; set; }
        public string address { get; set; }
        [ForeignKey("dept")]
        public int dept_id { get; set; }
        public Department dept { get; set; }
    }
}
