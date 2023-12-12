namespace Test_Movie_Many_To_Many.Models
{
    public class MovieGenre
    {
        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }

        public Guid GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
