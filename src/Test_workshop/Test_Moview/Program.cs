
using Microsoft.EntityFrameworkCore;
using Test_Moview.Data;
using Test_Moview.Models;

using (ApplicationContext db = new ApplicationContext())
{
    db.Database.EnsureDeleted();
    db.Database.EnsureCreated();

    Review review = new Review()
    {
        Text = "Не плохое кино"
    };


    Genre genre = new Genre()
    {
        Name = "Комедия",
        Description = "Расмешить зрителя"
    };
    ;
    Producer producer = new Producer()
    {
        BirthDate = new DateTime(2000, 2, 15),
        Country = "USA",
        FirstName = "Ваня",
        LastName = "Бубликов",
    };

    Actor actor = new Actor()
    {
        BirthDate = new DateTime(2005, 3, 25),
        Country = "USA",
        FirstName = "Пашка",
        LastName = "Туркевич"
    };

    Movie movie = new Movie()
    {
        Name = "Терминатор",
        Country = "USA",
        Description = "СТрелялка с примисью коммедии",
        AcceptableAge = 12,
        FilmDuration = 150,
        Rating = 5,
        YearShown = new DateTime(2002, 5, 13)
    };

    movie.CurrentProducer = producer;
    movie.Actors.Add(actor);
    movie.Genres.Add(genre);
    movie.Reviews.Add(review);


    db.Reviews.Add(review);
    db.Actors.Add(actor);
    db.Genres.Add(genre);
    db.Producers.Add(producer);
    db.Movies.Add(movie);

    db.SaveChanges();
}


using (ApplicationContext db = new ApplicationContext())
{
    var moview = db.Movies
        .Include(x => x.Actors)
        .Include(x => x.Genres)
        .Include(x => x.CurrentProducer)
        .Include(x => x.Reviews)
        .ToList();

    foreach (Movie movie in moview)
    {
        Console.WriteLine("Название фильма: {0}",movie.Name);
        Console.WriteLine("Описание фильма: {0}, рэйтинг: {1}, режиссёр: {2}",movie.Description,movie.Rating,movie.CurrentProducer.LastName);
        Console.WriteLine("Актёры снимающиеся в фильме: ");
        foreach (var actor in movie.Actors)
        {
            Console.WriteLine(actor.FirstName + " " + actor.LastName);
        }
        Console.WriteLine("Жанры фильма: ");
        foreach (var genre in movie.Genres)
        {
            Console.WriteLine(genre.Name);
        }
        Console.WriteLine("Отзывы: ");
        foreach (var review in movie.Reviews)
        {
            Console.WriteLine(review.Text);
        }
    }

}






Console.WriteLine("Конец_");
Console.ReadLine();

//https://metanit.com/sharp/entityframeworkcore/4.1.php