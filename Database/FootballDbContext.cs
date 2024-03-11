using CatalogFooball.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogFooball.Database
{
    public class FootballDbContext: DbContext
    {
        public FootballDbContext(DbContextOptions<FootballDbContext> options): base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<FootballPlayer> FootballPlayers { get; set; } = null;
            
        public DbSet<FootballCommand> FootballCommands { get; set; } = null;

        public DbSet<Country> Countries { get; set; } = null;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Country>().HasData(new Country[] {
                new Country(){ Id=1, Name ="Россия" },
                new Country(){ Id=2, Name ="США" },
                new Country(){ Id=3, Name ="Италия" },

            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
