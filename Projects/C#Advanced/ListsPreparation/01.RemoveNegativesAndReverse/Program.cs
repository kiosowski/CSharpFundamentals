using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.RemoveNegativesAndReverse
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            while (nums[0] < 0)
            {
                Console.WriteLine("empty");
                break;
            }
            nums.RemoveAll(n => n < 0);

            nums.Reverse();

            Console.WriteLine(string.Join(" ",nums));
        }
    }
}
