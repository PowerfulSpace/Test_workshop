using System.ComponentModel.DataAnnotations.Schema;

namespace Test_TableMapping.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
