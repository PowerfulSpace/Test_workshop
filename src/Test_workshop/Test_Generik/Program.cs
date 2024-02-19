// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


// класс компании
class Company<P>
{
    public P CEO { get; set; }  // президент компании
    public Company(P ceo)
    {
        CEO = ceo;
    }
}

