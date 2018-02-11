using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CountRealNumbers
{
    class CountRealNumbers
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse).ToList();

            var counts = new SortedDictionary<double, int>();

            foreach (var num in input)
            {
                if (counts.ContainsKey(num))
                {
                    counts[num]++;
                }
                else
                {
                    counts[num] = 1;
                }
            }

            foreach (var dict in counts.Keys)
            {
                Console.WriteLine($"{dict} -> {counts[dict]}");
            } 
        }
    }
}
