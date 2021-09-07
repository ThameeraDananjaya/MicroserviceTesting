using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace microservice1
{
    public class MS1Context : DbContext
    {
        public MS1Context(DbContextOptions<MS1Context> options) : base(options)
        {
            
        }
 
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder )
        {           
         //   optionBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(optionBuilder);

        } 

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Platform> Platforms { get; set; }
    }
}