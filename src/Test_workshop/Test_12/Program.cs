var tom = new Person("Tom", 38);
Console.WriteLine(tom);

Console.ReadLine();

public class Person(string name, int age)
{
    public Person(string name) : this(name, 18) { }
    public string Name => name;
    public int Age => age;

    public override string ToString() => $"name: {name}, age: {age}";
}