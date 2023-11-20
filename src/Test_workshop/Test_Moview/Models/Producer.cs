using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Test_Moview.Models
{
    public class Producer
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Country { get; set; } = null!;

        public DateTime BirthDate { get; set; }

        public string PhotoUrl { get; set; } = "noimage.png";

        [Display(Name = "ProducerPhoto")]
        [NotMapped]
        public IFormFile ProducerPhoto { get; set; } = null!;

        public virtual List<Movie>? Movies { get; set; }
    }
}
