
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Test_Movie_Many_To_Many.Data;
using Test_Movie_Many_To_Many.Models;

using (ApplicationContext db = new ApplicationContext())
{
    // пересоздадим базу данных
    db.Database.EnsureDeleted();
    db.Database.EnsureCreated();

    List<Genre> genres = GetGenres();
    db.Genres.AddRange(genres);

    Genre genr1 = genres.Where(x => x.Name == "аниме").FirstOrDefault()!;
    Genre genr2 = genres.Where(x => x.Name == "биографический").FirstOrDefault()!;
    Genre genr3 = genres.Where(x => x.Name == "боевик").FirstOrDefault()!;
    Genre genr4 = genres.Where(x => x.Name == "вестерн").FirstOrDefault()!;
    Genre genr5 = genres.Where(x => x.Name == "военный").FirstOrDefault()!;


    List<Movie> movie = GetMovies();
    db.Movies.AddRange(movie);

    Movie movie1 = movie.Where(x => x.Name == "Терминатор 1").FirstOrDefault()!;
    Movie movie2 = movie.Where(x => x.Name == "Терминатор 2").FirstOrDefault()!;
    Movie movie3 = movie.Where(x => x.Name == "Терминатор 3").FirstOrDefault()!;


    movie1.Genres.AddRange(new List<Genre> { genr1, genr2, genr3 });
    movie2.Genres.AddRange(new List<Genre> { genr2, genr3, genr4 });
    movie3.Genres.AddRange(new List<Genre> { genr3, genr4, genr5 });



    db.SaveChanges();

}


using (ApplicationContext db = new ApplicationContext())
{
    Movie movie1 = db.Movies.Include(s => s.Genres).FirstOrDefault(s => s.Name == "Терминатор 1")!;

    Genre genr1 = db.Genres.FirstOrDefault(c => c.Name == "аниме");
    Genre genr2 = db.Genres.FirstOrDefault(c => c.Name == "научный");

    if (movie1 != null && genr1 != null && genr2 != null)
    {
        movie1.Genres.Remove(genr1);
        movie1.Genres.Add(genr2);
        db.SaveChanges();
    }


    Movie movie2 = db.Movies.Include(s => s.Genres).FirstOrDefault(s => s.Name == "Терминатор 5")!;

    Genre genr3 = db.Genres.FirstOrDefault(c => c.Name == "аниме")!;
    Genre genr4 = db.Genres.FirstOrDefault(c => c.Name == "научный")!;
    Genre genr5 = db.Genres.FirstOrDefault(c => c.Name == "военный")!;
    Genre genr6 = db.Genres.FirstOrDefault(c => c.Name == "исторический")!;
    Genre genr7 = db.Genres.FirstOrDefault(c => c.Name == "мелодрама")!;

    if (movie2 != null)
    {
        movie2.Genres.Add(genr3);
        movie2.Genres.Add(genr4);
        movie2.Genres.Add(genr5);
        movie2.Genres.Add(genr6);
        movie2.Genres.Add(genr7);
        db.SaveChanges();
    }

}


using (ApplicationContext db = new ApplicationContext())
{
    var movies = db.Movies.Include(c => c.Genres).ToList();

    foreach (var m in movies)
    {
        Console.WriteLine($"Movie: {m.Name}");

        foreach (Genre genre in m.Genres)
            Console.WriteLine($"Name: {genre.Name}");
        Console.WriteLine("-------------------");
    }
}

Console.ReadLine();


static List<Genre> GetGenres()
{
    List<Genre> genres = new List<Genre>()
    {
        new Genre { Name = "аниме", Description = "" },
        new Genre { Name = "биографический", Description = "" },
        new Genre { Name = "боевик", Description = "" },
        new Genre { Name = "вестерн", Description = "" },
        new Genre { Name = "военный", Description = "" },
        new Genre { Name = "детектив", Description = "" },
        new Genre { Name = "детский", Description = "" },
        new Genre { Name = "документальный", Description = "" },
        new Genre { Name = "драма", Description = "" },
        new Genre { Name = "исторический", Description = "" },
        new Genre { Name = "кинокомикс", Description = "" },
        new Genre { Name = "комедия", Description = "" },
        new Genre { Name = "концерт", Description = "" },
        new Genre { Name = "короткометражный", Description = "" },
        new Genre { Name = "криминал", Description = "" },
        new Genre { Name = "мелодрама", Description = "" },
        new Genre { Name = "мистика", Description = "" },
        new Genre { Name = "музыка", Description = "" },
        new Genre { Name = "мультфильм", Description = "" },
        new Genre { Name = "мюзикл", Description = "" },
        new Genre { Name = "научный", Description = "" },
        new Genre { Name = "нуар", Description = "" },
        new Genre { Name = "приключения", Description = "" },
        new Genre { Name = "реалити", Description = "" },
        new Genre { Name = "семейный", Description = "" },
        new Genre { Name = "спорт", Description = "" },
        new Genre { Name = "ток", Description = "" },
        new Genre { Name = "триллер", Description = "" },
        new Genre { Name = "ужасы", Description = "" },
        new Genre { Name = "фантастика", Description = "" },
        new Genre { Name = "фэнтези", Description = "" },
        new Genre { Name = "эротика", Description = "" }
    };

    return genres;

}

static List<Movie> GetMovies()
{
    List<Movie> movies = new List<Movie>()
    {
        new Movie { Name = "Терминатор 1"},
        new Movie { Name = "Терминатор 2"},
        new Movie { Name = "Терминатор 3"},
        new Movie { Name = "Терминатор 4"},
        new Movie { Name = "Терминатор 5"},
    };

    return movies;
    
}
