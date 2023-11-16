
using Test_TableMapping.Data;
using Test_TableMapping.Models;

using (ApplicationContext db = new ApplicationContext())
{
    User user1 = new User() { FirstName = "Tom", LastName = "Smith", Age = 36 };
    Console.WriteLine(user1.Name); // до добавления Name имеет значение по умолчанию
    db.Users.Add(user1);
    db.SaveChanges();

    Console.WriteLine(user1.Name); // Tom Smith
}

Console.ReadLine();

//https://metanit.com/sharp/entityframeworkcore/2.17.php