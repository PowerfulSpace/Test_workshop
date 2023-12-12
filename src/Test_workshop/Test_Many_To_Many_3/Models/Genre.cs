namespace Test_Many_To_Many_3.Models
{
    public class Genre
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Movie> Movies { get; set; } = new List<Movie>();
        public List<MovieGenre> MovieGenres { get; set; } = new List<MovieGenre>();
    }
}
