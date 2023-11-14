namespace MovieMirgations_Fl_API.Models
{
    public class MoviesGenre
    {
        public Guid MovieId { get; set; }      
        public Movie? Movie { get; set; }

        public Guid GenreId { get; set; }
        public Genre? Genre { get; set; }
    }
}
