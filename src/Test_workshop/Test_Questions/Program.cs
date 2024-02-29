
Person tom = new Person();
tom.Print();    // Имя:Tom  Возраст: 1


var test = new Test();
try
{
    test.Print();
}
catch (Exception)
{
    Console.Write("5");
}
finally
{
    Console.Write("4");
}



Console.ReadLine();



class Test
{
    public void Print()
    {
        try
        {
            throw new Exception();
        }
        catch (Exception)
        {
            Console.Write("9");
            throw new Exception();
        }
        finally
        {
            Console.Write("2");
        }
    }
}

struct Person
{
    // инициализация полей значениями по умолчанию - доступна с C#10
    public string name = "Tom";
    public int age = 1;
    public Person() { }
    public void Print() => Console.WriteLine($"Имя: {name}  Возраст: {age}");
}