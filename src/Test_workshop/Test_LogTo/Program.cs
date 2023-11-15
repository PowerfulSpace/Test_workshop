using Test_LogTo.Data;
using Test_LogTo.Models;



using (ApplicationContext db = new ApplicationContext())
{
    User user1 = new User { Name = "Tom", Age = 33 };
    User user2 = new User { Name = "Alice", Age = 26 };

    db.Users.Add(user1);
    db.Users.Add(user2);
    db.SaveChanges();

    var users = db.Users.ToList();
    Console.WriteLine("Данные после добавления:");
    foreach (User u in users)
    {
        Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
    }
}


Console.Read();



//https://metanit.com/sharp/entityframeworkcore/2.3.php