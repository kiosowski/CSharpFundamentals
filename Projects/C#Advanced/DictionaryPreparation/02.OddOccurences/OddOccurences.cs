using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.OddOccurences
{
    class OddOccurences
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, int>();

            var input = Console.ReadLine().ToLower().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in input)
            {
                if (dict.ContainsKey(item))
                {
                    dict[item]++;
                }
                else
                {
                    dict[item] = 1;
                }
            }
            var results = new List<string>();

            foreach (var pair in dict)
            {
                if (pair.Value % 2 == 1)
                {
                    results.Add(pair.Key);
                }
            }
            Console.WriteLine(string.Join(", ", results));
        }
    }
}
