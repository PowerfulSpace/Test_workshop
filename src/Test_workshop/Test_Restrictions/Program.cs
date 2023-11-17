
using Test_Restrictions.Data;
using Test_Restrictions.Models;


using (ApplicationContext db = new ApplicationContext())
{
    // получаем объекты из бд и выводим на консоль
    var products = db.Products.ToList();
    Console.WriteLine("Список объектов:");
    foreach (Product u in products)
    {
        Console.WriteLine($"{u.Name}");
    }
}
Console.ReadKey();



