namespace MovieMirgations_Fl_API.Models
{
    public class Review
    {
        public Guid Id { get; set; }
        public string Login { get; set; } = "Anonim";
        public string Text { get; set; }
        public Guid MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
