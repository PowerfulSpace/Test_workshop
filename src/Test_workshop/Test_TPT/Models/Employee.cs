using System.ComponentModel.DataAnnotations.Schema;

namespace Test_TPT.Models
{
    public class Employee : User
    {
        public int Salary { get; set; }
    }
}
