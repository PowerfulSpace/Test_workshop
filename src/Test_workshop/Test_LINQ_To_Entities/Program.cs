using Test_LINQ_To_Entities.Data;
using Test_LINQ_To_Entities.Models;

using (ApplicationContext db = new ApplicationContext())
{
    // пересоздаем базу данных
    db.Database.EnsureDeleted();
    db.Database.EnsureCreated();

    Company microsoft = new Company { Name = "Microsoft" };
    Company google = new Company { Name = "Google" };
    db.Companies.AddRange(microsoft, google);

    User tom = new User { Name = "Tom", Age = 36, Company = microsoft };
    User bob = new User { Name = "Bob", Age = 39, Company = google };
    User alice = new User { Name = "Alice", Age = 28, Company = microsoft };
    User kate = new User { Name = "Kate", Age = 25, Company = google };

    db.Users.AddRange(tom, bob, alice, kate);
    db.SaveChanges();
}



using (ApplicationContext db = new ApplicationContext())
{
    var users = db.Users.Where(u => u.Age < 30)
        .Union(db.Users.Where(u => u.Name.Contains("Tom")));

    foreach (var user in users)
        Console.WriteLine(user.Name);
}

Console.ReadLine();

//https://metanit.com/sharp/entityframeworkcore/5.2.php