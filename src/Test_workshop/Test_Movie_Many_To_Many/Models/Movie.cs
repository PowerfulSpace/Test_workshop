namespace Test_Movie_Many_To_Many.Models
{
    public class Movie
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public List<Genre> Genres { get; set; } = new();
        public List<MovieGenre> MovieGenres { get; set; } = new();
    }
}
