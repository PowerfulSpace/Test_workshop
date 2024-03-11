
Console.WriteLine(GetNumber(new[] { 2, 3, 5 }));        // 1
Console.WriteLine(GetNumber(new[] { 2, 4, 5 }));        // 2
Console.WriteLine(GetNumber(new[] { 2, 3, 4, 5 }));     // 3
Console.WriteLine(GetNumber(new[] { 1, 2, 3 }));        // 4
Console.WriteLine(GetNumber(new int[] { }));            // 4

int GetNumber(int[] values) => values switch
{
    [2, 3, 5] => 1,
    [2, _, 5] => 2,
    [2, .., 5] => 3,
    [..] => 4
};


Console.ReadLine();

class C
{
    [Reader<int>]
    public void M()
    {
    }
}

class ReaderAttribute<T> : Attribute
{
}