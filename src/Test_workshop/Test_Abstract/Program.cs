



Console.ReadLine();





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






class Counter
{
    public int Value { get; set; }

    public static Counter operator +(Counter counter1, Counter counter2)
    {
        return new Counter { Value = counter1.Value + counter2.Value };
    }
    public static bool operator >(Counter counter1, Counter counter2)
    {
        return counter1.Value > counter2.Value;
    }
    public static bool operator <(Counter counter1, Counter counter2)
    {
        return counter1.Value < counter2.Value;
    }
}