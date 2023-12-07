using System.ComponentModel.DataAnnotations;

namespace DisignProject.Models
{
    public class Movie
    {
        public Guid Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; } = null!;

        public List<Genre> Genres { get; set; } = new List<Genre>();
    }
}