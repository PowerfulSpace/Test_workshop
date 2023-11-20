using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_Moview.Models
{
    public class Movie
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public double Rating { get; set; }


        public DateTime YearShown { get; set; }

        public int FilmDuration { get; set; }

        public string Country { get; set; } = null!;

        public int AcceptableAge { get; set; }


        public string PhotoUrl { get; set; } = "noimage.png";

        [Display(Name = "MoviePhoto")]
        [NotMapped]
        public IFormFile MoviePhoto { get; set; } = null!;

        public Guid? ProducerId { get; set; }
        public Producer? CurrentProducer { get; set; }

        public List<Actor> Actors { get; set; } = new List<Actor>();

        public List<Genre> Genres { get; set; } = new List<Genre>();
        public List<Review> Reviews { get; set; } = new List<Review>();
    }
}
