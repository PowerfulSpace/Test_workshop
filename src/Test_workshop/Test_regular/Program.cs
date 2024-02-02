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










Console.ReadLine();
