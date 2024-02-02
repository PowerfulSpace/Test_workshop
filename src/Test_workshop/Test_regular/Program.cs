//Без ленивого совпадения не корректно отрабатывает код
using System.Text.RegularExpressions;

string regexp = @""".+?"" ";
string str = "a \"witch\" and her \"broom\" is one";
Regex regex = new Regex(regexp);
var result = regex.Matches(str);

foreach (var item in result)
{
    Console.WriteLine(item);
}

Console.WriteLine();

//Демонстративно показано как рабоатет ленивое совпадение
string pattern = @"^\s*(System.)??Console.Write(Line)??\(??";
string input = "System.Console.WriteLine(\"Hello!\")\n" +
                      "Console.Write(\"Hello!\")\n" +
                      "Console.WriteLine(\"Hello!\")\n" +
                      "Console.ReadLine()\n" +
                      "   Console.WriteLine";

Console.WriteLine();
foreach (Match match in Regex.Matches(input, pattern,
                                      RegexOptions.IgnorePatternWhitespace |
                                      RegexOptions.IgnoreCase |
                                      RegexOptions.Multiline))
    Console.WriteLine("'{0}' found at position {1}.", match.Value, match.Index);
Console.WriteLine();








Console.ReadLine();
