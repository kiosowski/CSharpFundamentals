﻿using System;
using System.Linq;

namespace _04.MaximalSum
{
    class MaximalSum
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            var rows = input[0];
            var cols = input[1];
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var values = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = values[col];
                }
            }
            int sum = 0;
            int rowIndex = 0; int colIndex = 0;
            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    int tempsum = matrix[row, col]
                                + matrix[row, col + 1]
                                + matrix[row, col + 2]
                                + matrix[row + 1, col]
                                + matrix[row + 1, col + 1]
                                + matrix[row + 1, col + 2]
                                + matrix[row + 2, col]
                                + matrix[row + 2, col + 1]
                                + matrix[row + 2, col + 2];
                    if (tempsum > sum)
                    {
                        sum = tempsum;
                        rowIndex = row;
                        colIndex = col;
                    }
                }
            }
            Console.WriteLine($"Sum = {sum}");
            Console.WriteLine(matrix[rowIndex, colIndex] + " " + matrix[rowIndex, colIndex+1] + " " + matrix[rowIndex,colIndex+2]);
            Console.WriteLine(matrix[rowIndex+1,colIndex] + " " + matrix[rowIndex+1,colIndex+1] + " " + matrix[rowIndex+1,colIndex+2]);
            Console.WriteLine(matrix[rowIndex+2,colIndex] + " " + matrix[rowIndex+2,colIndex+1] + " " + matrix[rowIndex+2,colIndex+2]);


        }
    }
}
