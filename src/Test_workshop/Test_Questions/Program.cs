


object sync = new object();

var thread = new Thread(() =>
{
    try
    {
        Work();
    }
    finally
    {
        lock (sync)
        {
            Monitor.PulseAll(sync);
        }
    }
});
thread.Start();

lock (sync)
{
    Monitor.Wait(sync);
}
Console.WriteLine("test");


Console.ReadLine();


static void Work()
{
    Thread.Sleep(1000);
}