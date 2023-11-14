namespace MovieMirgations_Fl_API.Models
{
    public class Genre
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public virtual List<Movie>? Movies { get; set; }
    }
}
