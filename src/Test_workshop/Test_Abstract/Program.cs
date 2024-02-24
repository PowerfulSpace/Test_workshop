


System.DateTime a;
System.Numerics.BigInteger b;
System.Numerics.Complex c;

Console.ReadLine();



struct Test
{
    public static void Method()
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



abstract class Transport
{
    // абстрактное свойство для хранения скорости
    public abstract int Speed { get; set; }
}
// класс корабля




