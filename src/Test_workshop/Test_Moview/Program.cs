
using Test_Moview.Data;
using Test_Moview.Models;


using (ApplicationContext db = new ApplicationContext())
{
    var moview = db.Movies.ToList();

    foreach (Movie movie in moview)
    {
        Console.WriteLine(movie.Name);
    }

}






Console.WriteLine("Конец_");
Console.ReadLine();

//https://metanit.com/sharp/entityframeworkcore/4.1.php