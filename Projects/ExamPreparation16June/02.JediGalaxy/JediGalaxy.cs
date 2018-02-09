using System;
using System.Linq;

namespace _02.JediGalaxy
{
    class JediGalaxy
    {
        static void Main(string[] args)
        {
            int[][] matrix = GetMatrix();
            long collectedStars = CollectStars(matrix);
            Console.WriteLine(collectedStars);

        }

        private static long CollectStars(int[][] matrix)
        {
            var collectedStars = 0L;
            var line = Console.ReadLine();
            while (line != "Let the Force be with you")
            {
                var ivoCordinates = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                var evilCordinates = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                EvilMoove(matrix, evilCordinates);
                collectedStars += IvoMoove(matrix, ivoCordinates);
                line = Console.ReadLine();
            }

            return collectedStars;
        }

        private static void EvilMoove(int[][] matrix, int[] evilCordinates)
        {
            while (evilCordinates[0] >= 0 && evilCordinates[1] >= 0)
            {
                if (IsInMatrix(matrix, evilCordinates))
                {
                    matrix[evilCordinates[0]][evilCordinates[1]] = 0;
                }
                evilCordinates[0]--;
                evilCordinates[1]--;

            }
        }

        private static int[][] GetMatrix()
        {
            var matrixSize = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var matrixRow = matrixSize[0];
            var matrixCol = matrixSize[1];
            var matrix = new int[matrixRow][];
            var cellValue = 0;
            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new int[matrixCol];
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = cellValue;
                    cellValue++;
                }
            }

            return matrix;
        }

        private static long IvoMoove(int[][] matrix, int[] ivoCordinates)
        {
            var stars = 0L;
            while (ivoCordinates[0] >= 0 && ivoCordinates[1] < matrix[0].Length)
            {
                if (IsInMatrix(matrix, ivoCordinates))
                {
                    stars += matrix[ivoCordinates[0]][ivoCordinates[1]];
                }
                ivoCordinates[0]--;
                ivoCordinates[1]++;
            }
            return stars;
        }

        private static bool IsInMatrix(int[][] matrix, int[] position)
        {
            return position[0] >= 0 && position[1] >= 0 && position[0] < matrix.Length && position[1] < matrix[position[0]].Length;

        }
    }
}
