


using Test_Entities.Data;
using Test_Entities.Models;

using (ApplicationContext db = new ApplicationContext())
{
    // получаем объекты из бд и выводим на консоль
    var products = db.Products.ToList();
    Console.WriteLine("Список объектов:");



    foreach (Product u in products)
    {
        Console.WriteLine($"{u.Id}.{u.Name}");
    }
}


Console.ReadLine();