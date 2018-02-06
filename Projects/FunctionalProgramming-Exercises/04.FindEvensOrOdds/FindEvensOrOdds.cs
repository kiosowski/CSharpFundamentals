using System;
using System.Linq;

namespace _04.FindEvensOrOdds
{
    class FindEvensOrOdds
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var minNumber = input[0];
            var maxNumber = input[1];

            var command = Console.ReadLine();

            Predicate<int> predicate = EvenOrOdd;

            for (int i = minNumber; i <= maxNumber; i++)
            {
                if (command == "even" && predicate(i))
                {
                    Console.Write(i + " ");
                    
                }
                else if (command == "odd" && !predicate(i))
                {
                    Console.Write(i + " ");
                    
                }
            }
            Console.WriteLine();
        }

        private static bool EvenOrOdd(int number)
        {
            return number % 2 == 0;
        }
    }
}
