using System.ComponentModel.DataAnnotations.Schema;

namespace Test_TPT.Models
{
    [Table("Managers")]
    public class Manager : User
    {
        public string Departament { get; set; }
    }
}
