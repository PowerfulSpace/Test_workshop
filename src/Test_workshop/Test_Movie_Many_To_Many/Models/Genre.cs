namespace Test_Movie_Many_To_Many.Models
{
    public class Genre
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public List<Movie> Movies { get; set; } = new();
        public List<MovieGenre> MovieGenres { get; set; } = new();
    }
}
