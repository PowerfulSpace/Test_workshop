



try
{
    var array = new int[] { 1, 2 };
    Console.Write(array[5]);
}
catch (ApplicationException e)
{
    Console.Write(1);
}
catch (SystemException e)
{
    Console.Write(2);
}
catch (Exception e)
{
    Console.Write(3);
}

Console.ReadLine();



