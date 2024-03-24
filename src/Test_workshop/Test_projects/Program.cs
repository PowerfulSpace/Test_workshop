

var welcome = (string message = "hello") => Console.WriteLine(message);

welcome("hello world"); // hello world
welcome();              // hello




Console.WriteLine(GetNumber(new[] { 2, 3, 5 }));        // 1
Console.WriteLine(GetNumber(new[] { 2, 4, 5 }));        // 2
Console.WriteLine(GetNumber(new[] { 2, 3, 4, 5 }));     // 3
Console.WriteLine(GetNumber(new[] { 1, 2, 3 }));        // 4
Console.WriteLine(GetNumber(new int[] { }));            // 4

Print();
PrintValue("hello");


Enumerable.Range(1, 10).ElementAt(^2); // 9

source.Take(..3); //вместо source.Take(3)
source.Take(3..); // вместо source.Skip(3)
source.Take(2..7); // вместо source.Take(7).Skip(2)
source.Take(^3..); // вместо source.TakeLast(3)
source.Take(..^3); // вместо source.SkipLast(3)
source.Take(^7..^3); // вместо source.TakeLast(7).SkipLast(3).


Console.ReadLine();


void Print()
{
    string text = """
              <element attr="content">
                <body>
                </body>
              </element>
              """;
    Console.WriteLine(text);
}

void PrintValue(string val)
{
    string text = $"""
              <element attr="content">
                <body>
                {val}
                </body>
              </element>
              """;
    Console.WriteLine(text);
}

int GetNumber(int[] values) => values switch
{
    [2, 3, 5] => 1,
    [2, _, 5] => 2,
    [2, .., 5] => 3,
    [..] => 4
};



 
