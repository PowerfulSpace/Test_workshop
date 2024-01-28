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


        public class DescendingComparer<T> : IComparer<T>
        {
            public int Compare(T x, T y)
            {
                return Comparer<T>.Default.Compare(x, y) * -1;
            }
        }

    }
}
