using Microsoft.EntityFrameworkCore;

namespace Test_Owner.Models
{
    [Owned]
    public class UserProfile
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
