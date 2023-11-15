


using Test_scheme.Data;
using Test_scheme.Models;

using (ApplicationContext db = new ApplicationContext())
{
    var users = db.Users.ToList();
    foreach (User u in users)
    {
        Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
    }
}


Console.ReadLine();

//https://metanit.com/sharp/entityframeworkcore/2.4.php