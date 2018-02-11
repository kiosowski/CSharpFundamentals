using System;

namespace _03.LastKNumbersSumsSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var k = int.Parse(Console.ReadLine());

            var array = new long[n];
            array[0] = 1;
            for (int i = 1; i < n; i++)
            {
                long sum = 0;
                int startIndex = Math.Max(0, i - k);
                for (int j = startIndex; j < i; j++)
                {
                    sum += array[j];
                }
                array[i] = sum;
            }
            Console.WriteLine(string.Join(" ",array));
        }
    }
}
