


interface Test2
{
    public const int a = 1;
    private const int b = 1;

    public static int MyProperty { get;set; }
    public int MyProperty1 { get; set; }
    //private int MyProperty2 { get; set; }
    protected int MyProperty3 { get; set; }
    private protected int MyProperty4 { get; set; }
    internal int MyProperty5 { get; set; }
    protected internal int MyProperty6 { get; set; }

    //public readonly int value;

    public abstract void Method();

}






