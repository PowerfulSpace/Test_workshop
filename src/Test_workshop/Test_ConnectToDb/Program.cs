



using Test_ConnectToDb;

using (TestBaseProjectDbContext db = new TestBaseProjectDbContext())
{
    // получаем объекты из бд и выводим на консоль
    var users = db.Users.ToList();
    Console.WriteLine("Список объектов:");
    foreach (User u in users)
    {
        Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
    }
}
Console.ReadKey();

//Scaffold-DbContext "Server=(localdb)\\mssqllocaldb;Database=Test_BaseProject_DB;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer
