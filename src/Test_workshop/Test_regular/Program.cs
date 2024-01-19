using System.Text.RegularExpressions;

// паттерн работает так (?( выражение ) да | нет )
// Если начало строки начинает с 2 цифр за которым следует дефис то используется этот шаблон \d{2}-\d{7}
//                          если 3 цифр за которым следует дефис то используется этот шаблон \d{3}-\d{2}-\d{4})

string pattern = @"\b(?(\d{2}-)\d{2}-\d{7}|\d{3}-\d{2}-\d{4})\b";
string input = "01-9999999 020-333333 777-88-9999";
Console.WriteLine("Matches for {0}:", pattern);
foreach (Match match in Regex.Matches(input, pattern))
    Console.WriteLine("   {0} at position {1}", match.Value, match.Index);


//Работает точно так же как и предыдущий пример,только внедрён группа захвата
string pattern2 = @"\b(?<n2>\d{2}-)?(?(n2)\d{7}|\d{3}-\d{2}-\d{4})\b";
string input2 = "01-9999999 020-333333 777-88-9999";
Console.WriteLine("Matches for {0}:", pattern2);
foreach (Match match in Regex.Matches(input2, pattern2))
    Console.WriteLine("   {0} at position {1}", match.Value, match.Index);

Console.ReadLine();

//Доделать задачу 12