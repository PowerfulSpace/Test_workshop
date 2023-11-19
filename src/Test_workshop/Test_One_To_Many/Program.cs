
using Microsoft.EntityFrameworkCore;
using Test_One_To_Many.Data;
using Test_One_To_Many.Models;

using (ApplicationContext db = new ApplicationContext())
{
    // пересоздадим базу данных
    db.Database.EnsureDeleted();
    db.Database.EnsureCreated();

    // создание и добавление моделей
    Company microsoft = new Company { Name = "Microsoft" };
    Company google = new Company { Name = "Google" };
    db.Companies.AddRange(microsoft, google);

    User tom = new User { Name = "Tom", Company = microsoft };
    User bob = new User { Name = "Bob", Company = microsoft };
    User alice = new User { Name = "Alice", Company = google };
    db.Users.AddRange(tom, bob, alice);
    db.SaveChanges();
}
using (ApplicationContext db = new ApplicationContext())
{
    // вывод пользователей
    var users = db.Users.Include(u => u.Company).ToList();
    foreach (User user in users)
        Console.WriteLine($"{user.Name} - {user.Company?.Name}");

    // вывод компаний
    var companies = db.Companies.Include(c => c.Users).ToList();
    foreach (Company comp in companies)
    {
        Console.WriteLine($"\n Компания: {comp.Name}");
        foreach (User user in comp.Users)
        {
            Console.WriteLine($"{user.Name}");
        }
    }
}
Console.WriteLine("----");
Console.ReadLine();