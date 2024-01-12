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


static void Regular_Multiline(string input, string pattern)
{
    SortedList<int, string> scores = new SortedList<int, string>(new DescendingComparer<int>());



    foreach (Match match in Regex.Matches(input, pattern, RegexOptions.Multiline))
        scores.Add(Convert.ToInt32(match.Groups[2].Value), match.Groups[1].Value);

    // List scores in descending order.
    foreach (KeyValuePair<int, string> score in scores)
        Console.WriteLine("{0}: {1}", score.Value, score.Key);


    //Преобразует текст в одну строку
    string pattern2 = "(?s)^.+";
    string input2 = "This is one line and" + Environment.NewLine + "this is the second.";

    foreach (Match match in Regex.Matches(input2, pattern2))
        Console.WriteLine(Regex.Escape(match.Value));

}


public class DescendingComparer<T> : IComparer<T>
{
    public int Compare(T x, T y)
    {
        return Comparer<T>.Default.Compare(x, y) * -1;
    }
}