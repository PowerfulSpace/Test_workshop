
using Test_Explicit_Loading.Models;
using Test_Explicit_Loading.Data;
using Microsoft.EntityFrameworkCore;

using (ApplicationContext db = new ApplicationContext())
{
    // пересоздадим базу данных
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
}

using (ApplicationContext db = new ApplicationContext())
{

    User user = db.Users.FirstOrDefault();  // получаем первого пользователя
    db.Entry(user).Reference(x => x.Company).Load();

    Console.WriteLine($"{user.Name} - {user.Company?.Name}");   // Tom - Microsoft
}

Console.WriteLine("___");
Console.ReadLine();

//https://metanit.com/sharp/entityframeworkcore/3.9.php