using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Test_Moview.Models
{
    public class Actor
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Country { get; set; } = null!;

        public DateTime BirthDate { get; set; }

        public string PhotoUrl { get; set; } = "noimage.png";

        [Display(Name = "ActorPhoto")]
        [NotMapped]
        public IFormFile ActorPhoto { get; set; } = null!;

        public List<Movie> Movies { get; set; } = new List<Movie>();
    }
}
