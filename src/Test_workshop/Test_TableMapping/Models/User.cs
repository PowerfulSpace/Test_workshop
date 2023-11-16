using System.ComponentModel.DataAnnotations.Schema;

namespace Test_TableMapping.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
