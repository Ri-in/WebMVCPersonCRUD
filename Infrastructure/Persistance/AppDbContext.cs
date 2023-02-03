using Domain;
using Infrastructure.Persistance.EntityConfigurrations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }


        public DbSet<Person> People { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
        }
    }
}
