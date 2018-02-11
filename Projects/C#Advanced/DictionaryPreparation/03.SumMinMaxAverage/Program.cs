using System;
using System.Linq;
namespace _03.SumMinMaxAverage
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var nums = new int[n];
            for (int i = 0; i < n; i++)
            {
               nums[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine($"Sum = {nums.Sum()}");
            Console.WriteLine($"Min = {nums.Min()}");
            Console.WriteLine($"Max = {nums.Max()}");
            Console.WriteLine($"Average = {nums.Average()}");

        }
    }
}
