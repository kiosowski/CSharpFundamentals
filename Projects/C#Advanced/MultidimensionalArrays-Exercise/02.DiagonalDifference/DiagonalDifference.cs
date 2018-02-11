using System;
using System.Linq;

namespace _02.DiagonalDifference
{
    class DiagonalDifference
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            int[][] matrix = new int[n][];
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = Console.ReadLine().Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }
            int firstDiagonal = 0;
            int secondDiagonal = 0;
            for (int i = 0; i < n; i++)
            {
                firstDiagonal += matrix[i][i];
            }
            for (int i = 0; i < n; i++)
            {
                secondDiagonal += matrix[i][matrix[i].Length - 1 - i];
            }
            Console.WriteLine(Math.Abs(firstDiagonal-secondDiagonal));
        }
    }
}
