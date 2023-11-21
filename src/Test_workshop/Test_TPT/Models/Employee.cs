using System.ComponentModel.DataAnnotations.Schema;

namespace Test_TPT.Models
{
    [Table("Employees")]
    public class Employee : User
    {
        public int Salary { get; set; }
    }
}
