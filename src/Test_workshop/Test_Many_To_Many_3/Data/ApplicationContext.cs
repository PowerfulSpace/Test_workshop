using Microsoft.EntityFrameworkCore;
using Test_Many_To_Many_3.Models;


namespace Test_Many_To_Many2.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Movie> Courses { get; set; }
        public DbSet<Genre> Students { get; set; }

        public ApplicationContext()
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Test_Many_to_Many_3_DB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Movie>()
                .HasMany(c => c.Genres)
                .WithMany(s => s.Movies)
                .UsingEntity<MovieGenre>(
                   j => j
                    .HasOne(pt => pt.Genre)
                    .WithMany(t => t.MovieGenres)
                    .HasForeignKey(pt => pt.GenreId),
                j => j
                    .HasOne(pt => pt.Movie)
                    .WithMany(p => p.MovieGenres)
                    .HasForeignKey(pt => pt.MovieId),
                j =>
                {
                    j.HasKey(t => new { t.MovieId, t.GenreId });
                    j.ToTable("Enrollments");
                });
        }

    }
}
