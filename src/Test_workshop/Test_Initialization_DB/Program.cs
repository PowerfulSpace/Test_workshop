
using Test_Initialization_DB.Data;
using Test_Initialization_DB.Models;


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
