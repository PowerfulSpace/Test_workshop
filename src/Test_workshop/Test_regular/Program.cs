using System.Globalization;
using System.Text.RegularExpressions;


string dateString = DateTime.Today.ToString("d",
                                        DateTimeFormatInfo.InvariantInfo);
string resultString = MDYToDMY(dateString);
Console.WriteLine("Converted {0} to {1}.", dateString, resultString);

Console.ReadLine();

static string MDYToDMY(string input)
{
    try
    {
        return Regex.Replace(input,
               @"\b(?<month>\d{1,2})/(?<day>\d{1,2})/(?<year>\d{2,4})\b",
              "${day}-${month}-${year}", RegexOptions.None,
              TimeSpan.FromMilliseconds(150));
    }
    catch (RegexMatchTimeoutException)
    {
        return input;
    }

    Console.ReadLine();
