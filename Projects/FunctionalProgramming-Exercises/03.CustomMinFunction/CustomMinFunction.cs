using System;
using System.Linq;

namespace _03.CustomMinFunction
{
    class CustomMinFunction
    {
        static void Main(string[] args)
        {
            Func<int[], int> min = FindMinNumber;
            int[] arrayOfNumbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            Console.WriteLine(min(arrayOfNumbers));
        }

        private static int FindMinNumber(int[] array)
        {
            int minNumber = int.MaxValue;
            foreach (var number in array)
            {
                if (number < minNumber)
                {
                    minNumber = number;
                }
            }
            return minNumber;
        }
    }
}
