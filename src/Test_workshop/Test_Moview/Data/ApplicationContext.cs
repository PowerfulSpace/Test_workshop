using Microsoft.EntityFrameworkCore;
using Test_Moview.Models;

namespace Test_Moview.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Review> Reviews { get; set; }

        public ApplicationContext()
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Test_Moview_Console_DB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Producer>()
              .HasMany(x => x.Movies)
              .WithOne(x => x.CurrentProducer)
              .HasForeignKey(x => x.ProducerId);


            modelBuilder.Entity<Actor>()
                .HasMany(x => x.Movies)
                .WithMany(x => x.Actors);

            modelBuilder.Entity<Genre>()
               .HasMany(x => x.Movies)
               .WithMany(x => x.Genres);

            modelBuilder.Entity<Review>()
                .HasOne(x => x.Movie)
                .WithMany(x => x.Reviews)
                .HasForeignKey(x => x.MovieId);



            modelBuilder.Entity<Movie>()
                .HasOne(x => x.CurrentProducer)
                .WithMany(x => x.Movies)
                .HasForeignKey(x => x.ProducerId);

            modelBuilder.Entity<Movie>()
                .HasMany(x => x.Reviews)
                .WithOne(x => x.Movie)
                .HasForeignKey(x => x.MovieId);


            modelBuilder.Entity<Movie>()
                .HasMany(x => x.Actors)
                .WithMany(x => x.Movies);

            modelBuilder.Entity<Movie>()
               .HasMany(x => x.Genres)
               .WithMany(x => x.Movies);

//            Review review = new Review()
//            {
//                Id = Guid.NewGuid(),
//                Text = "Не плохое кино"
//            };

//            Genre genre = new Genre()
//            {
//                Id = Guid.NewGuid(),
//                Name = "Комедия",
//                Description = "Расмешить зрителя"
//            };
//;
//            Producer producer = new Producer()
//            {
//                Id = Guid.NewGuid(),
//                BirthDate = new DateTime(2000, 2, 15),
//                Country = "USA",
//                FirstName = "Ваня",
//                LastName = "Бубликов",
//            };

//            Actor actor = new Actor()
//            {
//                Id = Guid.NewGuid(),
//                BirthDate = new DateTime(2005, 3, 25),
//                Country = "USA",
//                FirstName = "Пашка",
//                LastName = "Туркевич"
//            };

//            Movie movie = new Movie()
//            {
//                Id = Guid.NewGuid(),
//                Name = "Терминатор",
//                Country = "USA",
//                Description = "СТрелялка с примисью коммедии",
//                AcceptableAge = 12,
//                FilmDuration = 150,
//                Rating = 5,
//                YearShown = new DateTime(2002, 5, 13)
//            };

//            movie.CurrentProducer = producer;
//            movie.Actors.Add(actor);
//            movie.Genres.Add(genre);
//            movie.Reviews.Add(review);

//            producer.Movies.Add(movie);
//            actor.Movies.Add(movie);
//            genre.Movies.Add(movie);
//            review.Movie = movie;



//            modelBuilder.Entity<Producer>().HasData(producer);
//            modelBuilder.Entity<Actor>().HasData(actor);
//            modelBuilder.Entity<Genre>().HasData(genre);
//            modelBuilder.Entity<Review>().HasData(review);
//            modelBuilder.Entity<Movie>().HasData(movie);

        }
    }
}
