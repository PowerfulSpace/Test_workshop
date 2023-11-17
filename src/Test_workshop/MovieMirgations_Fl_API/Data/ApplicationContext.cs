using Microsoft.EntityFrameworkCore;
using MovieMirgations_Fl_API.Data.Configurations;
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
            modelBuilder.ApplyConfiguration(new ActorConfiguration());
            modelBuilder.ApplyConfiguration(new GenreConfiguration());
            modelBuilder.ApplyConfiguration(new MovieConfiguration());
            modelBuilder.ApplyConfiguration(new ProducerConfiguration());
        }

        //https://metanit.com/sharp/entityframeworkcore/1.2.php
    }
}
