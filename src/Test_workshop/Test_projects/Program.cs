




void Increment(ref readonly int n)
{
    // n++; // нельзя, иначе будет очишка компиляции
    Console.WriteLine($"Число в методе Increment: {n}");
}
