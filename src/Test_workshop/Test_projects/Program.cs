global using System;
global using static System.Console;
global using Env = System.Environment;
using System.Text.Json;




using Stream stream = Console.OpenStandardOutput();
var data = new { Data = PrintNumbers(3) };
await JsonSerializer.SerializeAsync(stream, data); // {"Data":[0,1,2]}


Console.ReadLine();





static async IAsyncEnumerable<int> PrintNumbers(int n)
{
    for (int i = 0; i < n; i++) yield return i;
}






