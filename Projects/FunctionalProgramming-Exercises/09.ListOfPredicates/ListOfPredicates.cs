using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.ListOfPredicates
{
    class ListOfPredicates
    {
        static void Main(string[] args)
        {
            var range = int.Parse(Console.ReadLine());
            var dividers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            List<int> numbers = new List<int>();
            for (int i = 1; i <= range; i++)
            {
                numbers.Add(i);
            }

            for (int i = 0; i < dividers.Count; i++)
            {
                numbers = numbers.FindAll(x => x % dividers[i] == 0).ToList();
            }
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
