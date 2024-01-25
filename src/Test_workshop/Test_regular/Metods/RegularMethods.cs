using System.Text.RegularExpressions;

namespace Test_regular.Metods
{
    public static class RegularMethods
    {

        public static void WordDivisions()
        {
            string text = "Бык тупогуб, тупогубенький бычок, у быка губа бела была тупа";

            Regex regex = new Regex(@"[а-яА-Я]\w*\D?\s?");

            MatchCollection result = regex.Matches(text);

            if (result.Count > 0)
            {
                foreach (var item in result)
                {
                    Console.WriteLine(item);
                }
            }
        } 
        public static void SubtractFromTheGroup()
        {

            //Вычитаем из группы от 0-9 все чётные цифры 2468
            //string[] inputs = { "123", "13579753", "3557798", "335599901" };
            //string pattern = @"^[0-9-[2468]]+$";

            //foreach (string input in inputs)
            //{
            //    Match match = Regex.Match(input, pattern);
            //    if (match.Success)
            //        Console.WriteLine(match.Value);
            //}

        }


    }
}
