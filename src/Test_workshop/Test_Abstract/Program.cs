

Person person = new Person();
Car car = new Car();

System.DateTime a;
System.Numerics.BigInteger b;
System.Numerics.Complex c;

Console.ReadLine();




abstract class Test1 : Test2
{
    public static int MyProperty { get; set; }
    public Test1()
    {
        
    }
}

interface Test2
{
    public static int MyProperty { get; set; }
    public int MyProperty1 { get; set; }
    private int MyProperty2 { get; set; }
    protected int MyProperty3 { get; set; }
    private protected int MyProperty4 { get; set; }
    internal int MyProperty5 { get; set; }
    protected internal int MyProperty6 { get; set; }

    public readonly int value;

    public abstract void Method();

}


interface IMovable
{
    void Move();
}
class Person : IMovable
{
    public void Move() => Console.WriteLine("Человек идет");
}
struct Car : IMovable
{
    public void Move() => Console.WriteLine("Машина едет");
}