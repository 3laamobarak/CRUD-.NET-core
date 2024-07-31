using Microsoft.Extensions.Options;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace DotNETDay2.Models
{
    public class Day2context:IdentityDbContext
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
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectModels;Initial Catalog=FirstTraining;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
    }
}
