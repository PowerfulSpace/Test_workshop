




lock (syncObject)
{
    Write();
}


Console.ReadLine();



internal partial class Program
{
    private static Object syncObject = new Object();
    private static void Write()
    {
        lock (syncObject)
        {
            Console.WriteLine("test");
        }
    }
}