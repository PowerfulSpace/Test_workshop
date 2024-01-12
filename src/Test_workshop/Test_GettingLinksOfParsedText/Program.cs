using System.Text.RegularExpressions;

string input = "";
input += "<a href='https://test.com'>HomePage</a>";
input += "<a href='https://google.com'>Search</a>";
input += "<a href='https://ya.ru'>Yandex</a>";
input += "<a href='https://yandex.ru'>Yandex Full</a>";
input += "<a href='https://microsoft.com'>Micrasoft</a>";

Regex regex = new Regex(@"<a href='(?<link>\S+)'>(?<text>\S+)</a>");

Console.WriteLine(input);
Console.WriteLine();


for (Match m = regex.Match(input); m.Success; m = m.NextMatch())
{
    Console.WriteLine("Ссылка: {0:-25} на: {1:-4} позиции с именем {2}", m.Groups["link"], m.Groups["link"].Index, m.Groups["text"]);
}

Console.WriteLine();

foreach (Match m in regex.Matches(input))
{
    Console.WriteLine("Ссылка: {0:-25} на: {1:-4} позиции с именем {2}", m.Groups["link"], m.Groups["link"].Index, m.Groups["text"]);
}

Console.WriteLine();

var htmlQuery = from Match m in regex.Matches(input)
                where m.Groups["link"].Value.StartsWith("https")
                select m;

foreach (var m in htmlQuery)
{
    Console.WriteLine("Ссылка: {0:-25} на: {1:-4} позиции с именем {2}", m.Groups["link"], m.Groups["link"].Index, m.Groups["text"]);
}
Console.WriteLine();


Console.ReadLine();


static void ExecudedGroup(string input,string pattern)
{
    Match match = Regex.Match(input, pattern);
    if (match.Success)
        Console.WriteLine(match.Value);
}


static void Regular_ExpressionMatching(string input, string pattern)
{
    pattern = @"\b(?(\d{2}-)\d{2}-\d{7}|\d{3}-\d{2}-\d{4})\b";
    input = "01-9999999 020-333333 777-88-9999";
    Console.WriteLine("Matches for {0}:", pattern);
    foreach (Match match in Regex.Matches(input, pattern))
        Console.WriteLine("   {0} at position {1}", match.Value, match.Index);


    //Работает точно так же как и предыдущий пример,только внедрён группа захвата
    pattern = @"\b(?<n2>\d{2}-)?(?(n2)\d{7}|\d{3}-\d{2}-\d{4})\b";
    input = "01-9999999 020-333333 777-88-9999";
    Console.WriteLine("Matches for {0}:", pattern);
    foreach (Match match in Regex.Matches(input, pattern))
        Console.WriteLine("   {0} at position {1}", match.Value, match.Index);

}