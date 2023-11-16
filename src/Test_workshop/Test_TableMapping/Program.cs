
using Test_TableMapping.Data;
using Test_TableMapping.Models;

using (ApplicationContext db = new ApplicationContext())
{
    User user1 = new User() { Name = "Tom" };
    Console.WriteLine($"Age: {user1.Age}"); // 0

    db.Users.Add(user1);
    db.SaveChanges();

    Console.WriteLine($"Age: {user1.CreatedAt}"); // 18
}

Console.ReadLine();

//https://metanit.com/sharp/entityframeworkcore/2.17.php