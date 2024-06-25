using Microsoft.Extensions.Options;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace DotNETDay2.Models
{
    public class Day2context:DbContext
    {
        public Day2context()
        {
            
        }
        public Day2context(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<Instructor> Instructor { get; set; }
        public DbSet<Department> Department { get; set; }
        
        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectModels;Initial Catalog=Day2;Integrated Security=True;");
        }
    }
}
