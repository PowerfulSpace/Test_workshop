
using System.Text.RegularExpressions;

string phoneNumber = "+1(876)-234-12-98";

Regex regex = new Regex(@"\D");
string result = regex.Replace(phoneNumber, "");

Console.WriteLine(result);
