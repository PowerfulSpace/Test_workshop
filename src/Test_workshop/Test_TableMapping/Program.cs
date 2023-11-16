
using Test_TableMapping.Data;
using Test_TableMapping.Models;

using (ApplicationContext db = new ApplicationContext())
{
    var users = db.Users.ToList();
    foreach (User u in users)
    {
        Console.WriteLine($"{u.Id}.{u.Name}");
    }
}

Console.ReadLine();