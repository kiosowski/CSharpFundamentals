using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.AppendLists
{
    class Program
    {
        static void Main(string[] args)
        {
            var lists = Console.ReadLine().Split(new char[] { '|' },StringSplitOptions.RemoveEmptyEntries);
            var results = new List<int>();

            for (int i = lists.Length - 1; i >= 0; i--)
            {
                var splitted = lists[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                results.AddRange(splitted);
            }
            Console.WriteLine(string.Join(" ",results));

        }
    }
}
