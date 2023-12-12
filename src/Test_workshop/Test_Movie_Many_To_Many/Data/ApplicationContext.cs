using Microsoft.EntityFrameworkCore;
using Test_Movie_Many_To_Many.Models;

namespace Test_Movie_Many_To_Many.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public ApplicationContext()
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Test_MovieGenre_DB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Movie>()
                .HasMany(c => c.Genres)
                .WithMany(s => s.Movies)
                .UsingEntity<MovieGenre>(
                    j => j
                        .HasOne(mg => mg.Movie)
                        .WithMany(m => m.MovieGenres)
                        .HasForeignKey(mg => mg.MovieId),
                    j => j
                        .HasOne(mg => mg.Genre)
                        .WithMany(g => g.MovieGenres)
                        .HasForeignKey(mg => mg.GenreId),
                    j =>
                    {
                        j.HasKey(x => new { x.MovieId, x.GenreId });
                        j.ToTable("MovieGenre");
                    });
        }

    }
}
