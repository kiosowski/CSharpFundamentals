using System;
using System.Linq;

namespace _02.OddFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Where(x=> x%2 == 0).ToList();
            var average = input.Average();
            

            for (int i = 0; i < input.Count; i++)
            {
                if (input[i] > average)
                {
                    input[i] += 1;
                }
                else if(input[i] <= average)
                {
                    input[i] -= 1;
                }
            }
            Console.WriteLine(string.Join(" ",input));
        }
    }
}
