﻿global using System;
global using static System.Console;
global using Env = System.Environment;
using System.Net;
using System.Text.Json;




using Stream stream = Console.OpenStandardOutput();
var data = new { Data = PrintNumbers(3) };
await JsonSerializer.SerializeAsync(stream, data); // {"Data":[0,1,2]}

var handler = new HttpClientHandler
{
    Proxy = new WebProxy("socks5://127.0.0.1", 9050)
};
var httpClient = new HttpClient(handler);




Console.ReadLine();





static async IAsyncEnumerable<int> PrintNumbers(int n)
{
    for (int i = 0; i < n; i++) yield return i;
}






