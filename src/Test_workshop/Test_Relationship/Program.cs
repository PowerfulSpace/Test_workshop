
using Microsoft.EntityFrameworkCore;
using Test_Relationship.Data;
using Test_Relationship.Models;



using (ApplicationContext db = new ApplicationContext())
{

    db.Database.EnsureDeleted();
    db.Database.EnsureCreated();

    // добавляем начальные данные
    Company microsoft = new Company { Name = "Microsoft" };
    Company google = new Company { Name = "Google" };
    db.Companies.AddRange(microsoft, google);

    User tom = new User { Name = "Tom", Company = microsoft };
    User bob = new User { Name = "Bob", Company = google };
    User alice = new User { Name = "Alice", Company = microsoft };
    User kate = new User { Name = "Kate", Company = google };
    db.Users.AddRange(tom, bob, alice, kate);

    db.SaveChanges();

    // получаем пользователей
    var users = db.Users
        .Include(u => u.Company)  // подгружаем данные по компаниям
        .ToList();
    foreach (var user in users)
        Console.WriteLine($"{user.Name} - {user.Company?.Name}");
}
Console.WriteLine("---");
using (ApplicationContext db = new ApplicationContext())
{
    //var companies = db.Companies.ToList();
    // получаем пользователей
    var users = db.Users
        .Include(u => u.Company)  // подгружаем данные по компаниям
        .ToList();
    foreach (var user in users)
        Console.WriteLine($"{user.Name} - {user.Company?.Name}");
}

Console.ReadKey();

//ThenInclude

//https://metanit.com/sharp/entityframeworkcore/3.3.php



//using (ApplicationContext db = new ApplicationContext())
//{
//    // получаем объекты из бд и выводим на консоль
//    var users = db.Users.ToList();
//    Console.WriteLine("Список объектов:");
//    foreach (User u in users)
//    {
//        Console.WriteLine($"{u.Name}");
//    }
//}
//Console.ReadKey();
