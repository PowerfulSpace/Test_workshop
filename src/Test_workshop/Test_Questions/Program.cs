


int c = 3;
Console.Write(Sum(5, 3, out c) + " ");
Console.Write(c);
Console.ReadLine();


Console.ReadLine();



static int Sum(int a, int b, out int c)
{
    return a + b;
}