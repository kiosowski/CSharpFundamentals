using System;
using System.Linq;

namespace _01.ArrangeIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] integerNames =
            {
                "zero",
                "one",
                "two",
                "three",
                "four",
                "five",
                "six",
                "seven",
                "eight",
                "nine"
                
            };
            Console.WriteLine(string.Join(", ", Console.ReadLine()
                .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .OrderBy(str => string.Join(string.Empty, str.Select(ch => integerNames[ch - '0'])))));
        }
    }
}
