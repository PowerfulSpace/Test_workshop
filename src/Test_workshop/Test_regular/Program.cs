using System.Text.RegularExpressions;


//Вычитаем из группы от 0-9 все чётные цифры 2468
string[] inputs = { "123", "13579753", "3557798", "335599901" };
string pattern = @"^[0-9-[2468]]+$";

foreach (string input in inputs)
{
    Match match = Regex.Match(input, pattern);
    if (match.Success)
        Console.WriteLine(match.Value);
}

Console.ReadLine();