using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CourseWork
{
    class Parse
    {
        public static int ParseInt()
        {
            string input = Console.ReadLine();
            int myInt;

            if (!Int32.TryParse(input, out myInt))
            {
                Console.WriteLine("Введите целое число");
                return ParseInt();
            }

            return myInt;
        }

        public static double ParseDouble()
        {
            string input = Console.ReadLine();
            double myDouble;

            if (!Double.TryParse(input, out myDouble))
            {
                Console.WriteLine("Введите дробное число");
                return ParseDouble();
            }

            return myDouble;
        }

        public static string ParseString()
        {
            Regex pattern1 = new Regex(@"[A-Z]{1}[a-z]+");
            Regex pattern2 = new Regex(@"[А-Я]{1}[а-я]+");

            string myString = Console.ReadLine();

            if (!pattern1.IsMatch(myString) && !pattern2.IsMatch(myString))
            {
                Console.WriteLine("Введите по шаблону(Вася или Marry)");
                return ParseString();
            }

            return myString;
        }
    }
}
