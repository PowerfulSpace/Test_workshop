

using Microsoft.EntityFrameworkCore;
using Test_LINQ_To_Entities.Data;
using Test_LINQ_To_Entities.Models;

//using (ApplicationContext db = new ApplicationContext())
//{
//    // пересоздаем базу данных
//    db.Database.EnsureDeleted();
//    db.Database.EnsureCreated();

//    Company microsoft = new Company { Name = "Microsoft" };
//    Company google = new Company { Name = "Google" };
//    db.Companies.AddRange(microsoft, google);

//    User tom = new User { Name = "Tom", Age = 36, Company = microsoft };
//    User bob = new User { Name = "Bob", Age = 39, Company = google };
//    User alice = new User { Name = "Alice", Age = 28, Company = microsoft };
//    User kate = new User { Name = "Kate", Age = 25, Company = google };

//    db.Users.AddRange(tom, bob, alice, kate);
//    db.SaveChanges();
//}


using (ApplicationContext db = new ApplicationContext())
{

    var users = from u in db.Users
                join c in db.Companies on u.CompanyId equals c.Id
                select new { Name = u.Name, Company = c.Name, Age = u.Age };

    foreach (var u in users)
        Console.WriteLine($"{u.Name} ({u.Company}) - {u.Age}");
}


Console.ReadLine();

//https://metanit.com/sharp/entityframeworkcore/5.2.php