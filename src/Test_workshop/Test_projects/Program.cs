
int number = 5;
Increment(ref number);
Console.WriteLine($"Число после метода Increment: {number}");

Console.ReadLine();


void Increment(ref readonly int n)
{
    // n++; // нельзя, иначе будет очишка компиляции
    Console.WriteLine($"Число в методе Increment: {n}");
}

