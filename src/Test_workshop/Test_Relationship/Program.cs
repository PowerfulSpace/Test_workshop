
using Test_Relationship.Data;
using Test_Relationship.Models;



using (ApplicationContext db = new ApplicationContext())
{
    // добавляем начальные данные
    Company microsoft = new Company { Name = "Microsoft" };
    Company google = new Company { Name = "Google" };
    db.Companies.AddRange(microsoft, google);
    db.SaveChanges();
    User tom = new User { Name = "Tom", Company = microsoft };
    User bob = new User { Name = "Bob", Company = google };
    User alice = new User { Name = "Alice", Company = microsoft };
    User kate = new User { Name = "Kate", Company = google };
    db.Users.AddRange(tom, bob, alice, kate);
    db.SaveChanges();


    // получаем пользователей
    var users = db.Users.ToList();
    foreach (var user in users) Console.WriteLine($"{user.Name}");

    // Удаляем первую компанию
    var comp = db.Companies.FirstOrDefault();
    db.Companies.Remove(comp);
    db.SaveChanges();
    Console.WriteLine("\nСписок пользователей после удаления компании");
    // снова получаем пользователей
    users = db.Users.ToList();
    foreach (var user in users) Console.WriteLine($"{user.Name}");
}

Console.ReadKey();

//https://metanit.com/sharp/entityframeworkcore/3.2.php



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
