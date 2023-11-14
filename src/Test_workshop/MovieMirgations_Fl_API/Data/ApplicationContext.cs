using Microsoft.EntityFrameworkCore;
using MovieMirgations_Fl_API.Models;

namespace MovieMirgations_Fl_API.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options)
        {
            
        }

        public DbSet<Movie> Movies { get; set; } = null!;
        public DbSet<Genre> Genres { get; set; } = null!;
        public DbSet<Actor> Actors { get; set; } = null!;
        public DbSet<Producer> Producers { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producer>(x =>
            {
                x
                .HasMany(a => a.Movies)
                .WithOne(a => a.CurrentProducer);
            });

            modelBuilder.Entity<Actor>(x =>
            {
                x
                .HasMany(a => a.Movies)
                .WithMany(a => a.Actors);
            });
        }

        //https://metanit.com/sharp/entityframeworkcore/1.2.php
    }
}
