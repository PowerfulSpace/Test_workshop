

// спользуется замена, на первую первую группу, у нас она и единсвенная (\s?\d+[.,]?\d*)
// $1 - Включает последнюю подстроку, совпадающую с захватываемой группой
using System.Text.RegularExpressions;

string pattern = @"\p{Sc}*(\s?\d+[.,]?\d*)\p{Sc}*";
string replacement = "$1";
string input = "$16.32 12.19 £16.29 €18.29  €18,29";
string result = Regex.Replace(input, pattern, replacement);
Console.WriteLine(result);

// используется замена на группу с именем amount (?<amount>\s?\d+[.,]?\d*)
string pattern2 = @"\p{Sc}*(?<amount>\s?\d+[.,]?\d*)\p{Sc}*";
string replacement2 = "${amount}";
string input2 = "$16.32 12.19 £16.29 €18.29  €18,29";
string result2 = Regex.Replace(input2, pattern2, replacement2);
Console.WriteLine(result2);

Console.ReadLine();