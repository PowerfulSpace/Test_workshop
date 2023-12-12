namespace Test_Many_To_Many_3.Models
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Genre> Genres { get; set; } = [];
        public List<MovieGenre> MovieGenres { get; set; } = new List<MovieGenre>();
    }
}
