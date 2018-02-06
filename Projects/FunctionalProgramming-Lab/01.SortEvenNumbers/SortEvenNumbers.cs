using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.SortEvenNumbers
{
    class SortEvenNumbers
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var evenNumbers = new List<int>();

            var newEvenNumber = input.Where(x => x % 2 == 0);

            foreach (var number in newEvenNumber)
            {
                evenNumbers.Add(number);
            }

            Console.WriteLine(string.Join(", ",evenNumbers.OrderBy(num => num)));
        }
    }
}
