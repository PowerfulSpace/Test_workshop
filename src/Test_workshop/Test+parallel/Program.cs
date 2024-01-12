Console.WriteLine("Основной поток запущен.");

var options = new ParallelOptions
{
    MaxDegreeOfParallelism = Environment.ProcessorCount > 2
                              ? Environment.ProcessorCount - 2 : 1
};

Console.WriteLine("Количество логических ядер центрального процессора:" + Environment.ProcessorCount);
//Parallel.Invoke(Method1,Method2);

Parallel.Invoke(options, Method1, Method2, Method1, Method2);


Console.WriteLine("Основной поток завершен.");

Console.ReadKey();




static void Method1()
{
    Console.WriteLine("Method1() запущен.");
    for (int count = 0; count < 5; count++)
    {
        Thread.Sleep(500);
        Console.WriteLine("В методе Method1(), счетчик равен: " + count);
    }
    Console.WriteLine("Method1() завершен.");
}

static void Method2()
{
    Console.WriteLine("Method2() запущен.");
    for (int count = 0; count < 5; count++)
    {
        Thread.Sleep(500);
        Console.WriteLine("В методе Method2(), счетчик равен: " + count);
    }
    Console.WriteLine("Method2() завершен.");
}