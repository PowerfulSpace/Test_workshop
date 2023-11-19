
using Microsoft.EntityFrameworkCore;
using Test_Many_To_Many2.Data;
using Test_Many_To_Many2.Models;

using (ApplicationContext db = new ApplicationContext())
{
    // пересоздадим базу данных
    db.Database.EnsureDeleted();
    db.Database.EnsureCreated();

    // создание и добавление моделей
    Student tom = new Student { Name = "Tom" };
    Student alice = new Student { Name = "Alice" };
    Student bob = new Student { Name = "Bob" };
    db.Students.AddRange(tom, alice, bob);

    Course algorithms = new Course { Name = "Алгоритмы" };
    Course basics = new Course { Name = "Основы программирования" };
    db.Courses.AddRange(algorithms, basics);

    tom.Enrollments.Add(new Enrollment { Course = algorithms, EnrollmentDate = DateTime.Now });
    tom.Courses.Add(basics);
    alice.Enrollments.Add(new Enrollment { Course = algorithms, EnrollmentDate = DateTime.Now, Mark = 4 });
    bob.Enrollments.Add(new Enrollment { Course = basics, EnrollmentDate = DateTime.Now });

    db.SaveChanges();

}

//using (ApplicationContext db = new ApplicationContext())
//{
//    var courses = db.Courses.Include(c => c.Students).ToList();
//    // выводим все курсы
//    foreach (var c in courses)
//    {
//        Console.WriteLine($"Course: {c.Name}");
//        // выводим всех студентов для данного кура
//        foreach (Student s in c.Students)
//            Console.WriteLine($"Name: {s.Name}");
//        Console.WriteLine("-------------------");
//    }
//}

using (ApplicationContext db = new ApplicationContext())
{
    var courses = db.Courses.Include(c => c.Students).ToList();
    // выводим все курсы
    foreach (var c in courses)
    {
        Console.WriteLine($"Course: {c.Name}");
        // выводим всех студентов для данного кура
        foreach (var s in c.Enrollments)
            Console.WriteLine($"Name: {s.Student.Name}  Date: {s.EnrollmentDate.ToShortDateString()}  Mark: {s.Mark}");
        Console.WriteLine("-------------------");
    }
}

Console.ReadLine();

//https://metanit.com/sharp/entityframeworkcore/3.7.php