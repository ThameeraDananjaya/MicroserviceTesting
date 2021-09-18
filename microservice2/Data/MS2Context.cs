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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Platform>()
                .HasMany(p => p.Commands)
                .WithOne(p => p.Platform)
                .HasForeignKey(p => p.PlatformId);

            modelBuilder
                .Entity<Command>()
                .HasOne(p => p.Platform)
                .WithMany(p => p.Commands)
                .HasForeignKey(p => p.PlatformId);

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Command> Commands { get; set; }

    }
}