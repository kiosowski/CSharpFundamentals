using System;
using System.Linq;

namespace _08.CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            var evenNumbers = input.FindAll(x => x % 2 == 0);
            evenNumbers.Sort();
            var oddNumbers = input.FindAll(x => x % 2 != 0);
            oddNumbers.Sort();

            Console.WriteLine(string.Join(" ",evenNumbers.Concat(oddNumbers)));
        }
    }
}
