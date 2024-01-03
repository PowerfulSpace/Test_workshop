

// Define array of decimal values.
using System.Globalization;
using System.Text.RegularExpressions;

string[] values = { "16.35", "19.72", "1234", "0.99" };
// Determine whether currency precedes (True) or follows (False) number.
bool precedes = NumberFormatInfo.CurrentInfo.CurrencyPositivePattern % 2 == 0;
// Get decimal separator.
string cSeparator = NumberFormatInfo.CurrentInfo.CurrencyDecimalSeparator;
// Get currency symbol.
string symbol = NumberFormatInfo.CurrentInfo.CurrencySymbol;
// If symbol is a "$", add an extra "$".
if (symbol == "$") symbol = "$$";

// Define regular expression pattern and replacement string.
string pattern = @"\b(\d+)(" + cSeparator + @"(\d+))?";
string replacement = "$1$2";
replacement = precedes ? symbol + " " + replacement : replacement + " " + symbol;
foreach (string value in values)
    Console.WriteLine("{0} --> {1}", value, Regex.Replace(value, pattern, replacement));


Console.ReadLine();