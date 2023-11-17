using System.ComponentModel.DataAnnotations.Schema;

namespace Test_Relationship.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CompanyInfoKey { get; set; }      // внешний ключ
        public Company Company { get; set; }    // навигационное свойство
    }
}
