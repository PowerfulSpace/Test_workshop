namespace MovieMirgations_Fl_API.Models
{
    public class MoviesActors
    {
        public Guid MovieId { get; set; }
        public Movie? Movie { get; set; }

        public Guid ActorId { get; set; }
        public Actor? Actor { get; set; }
    }
}
