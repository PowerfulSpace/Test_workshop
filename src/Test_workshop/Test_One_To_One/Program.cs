
using Microsoft.EntityFrameworkCore;
using Test_One_To_One.Data;
using Test_One_To_One.Models;

using (ApplicationContext db = new ApplicationContext())
{
    // пересоздадим базу данных
    db.Database.EnsureDeleted();
    db.Database.EnsureCreated();

    User user1 = new User { Login = "login1", Password = "pass1234" };
    User user2 = new User { Login = "login2", Password = "5678word2" };
    db.Users.AddRange(user1, user2);

    UserProfile profile1 = new UserProfile { Age = 22, Name = "Tom", User = user1 };
    UserProfile profile2 = new UserProfile { Age = 27, Name = "Alice", User = user2 };
    db.UserProfiles.AddRange(profile1, profile2);

    db.SaveChanges();
}

using (ApplicationContext db = new ApplicationContext())
{
    foreach (User user in db.Users.Include(u => u.Profile).ToList())
    {
        Console.WriteLine($"Name: {user.Profile?.Name} Age: {user.Profile?.Age}");
        Console.WriteLine($"Login: {user.Login}  Password: {user.Password} \n");
    }
}

Console.WriteLine();

using (ApplicationContext db = new ApplicationContext())
{
    // удаляем первый объект User
    User user = db.Users.FirstOrDefault();
    if (user != null)
    {
        db.Users.Remove(user);
        db.SaveChanges();
    }

    // удаляем объект UserProfile c логином login2
    UserProfile profile = db.UserProfiles.FirstOrDefault(p => p.User.Login == "login2");
    if (profile != null)
    {
        db.UserProfiles.Remove(profile);
        db.SaveChanges();
    }
}


using (ApplicationContext db = new ApplicationContext())
{
    foreach (User user in db.Users.Include(u => u.Profile).ToList())
    {
        Console.WriteLine($"Name: {user.Profile?.Name} Age: {user.Profile?.Age}");
        Console.WriteLine($"Login: {user.Login}  Password: {user.Password} \n");
    }
}
Console.ReadLine();