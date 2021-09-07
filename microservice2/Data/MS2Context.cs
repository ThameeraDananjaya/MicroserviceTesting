using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace microservice2
{
    public class MS2Context : DbContext
    {
        public MS2Context(DbContextOptions<MS2Context> options) : base(options)
        {
        }
 
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder )
        {

            optionBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(optionBuilder);

        } 

        public DbSet<Employee> Employees { get; set; }
    }
}