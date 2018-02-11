using System;

namespace _04.PascalTriangle
{
    class PascalTriangle
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            long[][] triangle = new long[n][];

            var width = 1;

            for (int height = 0; height < n; height++)
            {
                triangle[height] = new long[width];
                long[] currentRow = triangle[height];
                currentRow[0] = 1;
                currentRow[currentRow.Length - 1] = 1;
                width++;

                if (currentRow.Length > 2)
                {
                    for (int i = 1; i < currentRow.Length - 1; i++)
                    {
                        long[] previousRow = triangle[height - 1];
                        long sum = previousRow[i] + previousRow[i - 1];
                        currentRow[i] = sum;
                    }
                }
            }

            for (long i = 0; i < n; i++)
            {
                Console.WriteLine(string.Join(" ", triangle[i]));
            }
        }
    }
}