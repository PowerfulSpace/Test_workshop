using System.ComponentModel.DataAnnotations.Schema;

namespace Test_TPT.Models
{
    public class Manager : User
    {
        public string Departament { get; set; }
    }
}
