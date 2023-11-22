using Test_LINQ_To_Entities.Data;
using Test_LINQ_To_Entities.Models;

using (ApplicationContext db = new ApplicationContext())
{
    // пересоздаем базу данных
    db.Database.EnsureDeleted();
    db.Database.EnsureCreated();

    Country usa = new Country { Name = "USA" };

    Company microsoft = new Company { Name = "Microsoft", Country = usa };
    Company google = new Company { Name = "Google", Country = usa };
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
    var users = from user in db.Users
                join company in db.Companies on user.CompanyId equals company.Id
                join country in db.Countries on company.CountryId equals country.Id
                select new
                {
                    Name = user.Name,
                    Company = company.Name,
                    Age = user.Age,
                    Country = country.Name
                };
    foreach (var u in users)
        Console.WriteLine($"{u.Name} ({u.Company} - {u.Country}) - {u.Age}");
}

Console.ReadLine();

//https://metanit.com/sharp/entityframeworkcore/5.2.php