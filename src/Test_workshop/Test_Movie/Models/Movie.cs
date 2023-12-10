using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_Movie.Models
{
    public class Movie
    {
        public Guid Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; } = null!;

        public List<Genre> Genres { get; set; } = new List<Genre>();

        [NotMapped]
        public List<string> GenresString { get; set; } = new List<string>();
    }
}