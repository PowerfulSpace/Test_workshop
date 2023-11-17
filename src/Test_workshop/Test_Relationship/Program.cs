
using Test_Relationship.Data;
using Test_Relationship.Models;


using (ApplicationContext db = new ApplicationContext())
{
    // получаем объекты из бд и выводим на консоль
    var users = db.Users.ToList();
    Console.WriteLine("Список объектов:");
    foreach (User u in users)
    {
        Console.WriteLine($"{u.Name}");
    }
}
Console.ReadKey();

//https://metanit.com/sharp/entityframeworkcore/3.1.php