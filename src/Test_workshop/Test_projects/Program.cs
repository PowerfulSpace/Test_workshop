
int number = 5;
Increment(ref number);
Console.WriteLine($"Число после метода Increment: {number}");

var welcome = (string message = "hello") => Console.WriteLine(message);

welcome("hello world"); // hello world
welcome();              // hello




Console.ReadLine();


void Increment(ref readonly int n)
{
    // n++; // нельзя, иначе будет очишка компиляции
    Console.WriteLine($"Число в методе Increment: {n}");
}

class Person
{

}