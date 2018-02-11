﻿using System;
using System.Linq;

namespace _01.DangerousFloor
{
    class DangerousFloor
    {
        static void Main(string[] args)
        {
            char[,] table = new char[8, 8];
            for (int row = 0; row < table.GetLength(0); row++)
            {
                var line = Console.ReadLine().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < table.GetLength(1); col++)
                {
                    table[row, col] = line[col];
                }
            }

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                var piece = input[0];
                var currRow = int.Parse(input[1].ToString());
                var currCol = int.Parse(input[2].ToString());
                var endRow = int.Parse(input[4].ToString());
                var endCol = int.Parse(input[5].ToString());

                if (table[currRow, currCol] != piece)
                {
                    Console.WriteLine("There is no such a piece!");
                }
                else if (!IsOnBoard(endRow, endCol, table))
                {
                    Console.WriteLine("Move go out of board!");
                }
                else
                {
                    switch (piece)
                    {
                        case 'K':
                            var isValid = (endRow == currRow - 1 && endCol == currCol - 1) ||
                                          (endRow == currRow && endCol == currCol - 1) ||
                                          (endRow == currRow + 1 && endCol == currCol - 1) ||
                                          (endRow == currRow - 1 && endCol == currCol) ||
                                          (endRow == currRow + 1 && endCol == currCol) ||
                                          (endRow == currRow + 1 && endCol == currCol + 1) ||
                                          (endRow == currRow - 1 && endCol == currCol - 1) ||
                                          (endRow == currRow - 1 && endCol == currCol + 1) ||
                                          (endRow == currRow && endCol == currCol + 1);
                            if (!isValid)
                            {
                                PrintInvalidMessage();
                                continue;
                            }
                            table[currRow, currCol] = 'x';
                            table[endRow, endCol] = 'K';
                            break;
                        case 'R':
                            if (currCol != endCol && endRow != currRow)
                            {
                                PrintInvalidMessage();
                                continue;
                            }
                            table[currRow, currCol] = 'x';
                            table[endRow, endCol] = 'R';
                            break;
                        case 'B':
                            if (Math.Abs(endRow - currRow) != Math.Abs(endCol - currCol))
                            { 
                                PrintInvalidMessage();
                                continue;
                            }
                            table[currRow, currCol] = 'x';
                            table[endRow, endCol] = 'B';
                            break;
                        case 'Q':
                            if (currCol != endCol && endRow != currRow && Math.Abs(endRow - currRow) != Math.Abs(endCol - currCol))
                            {
                                PrintInvalidMessage();
                                continue;
                            }
                            table[currRow, currCol] = 'x';
                            table[endRow, endCol] = 'Q';
                            break;
                        case 'P':
                            if (endRow == currRow - 1 && endCol == currCol)
                            {
                                table[currRow, currCol] = 'x';
                                table[endRow, endCol] = 'P';
                            }
                            else
                            {
                                PrintInvalidMessage();
                                continue;
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private static bool IsOnBoard(int finalRow, int finalCol, char[,] matrix)
        {
            if (finalRow < 0 || finalRow >= matrix.GetLength(0) || finalCol < 0 || finalCol >= matrix.GetLength(1))
            {
                return false;
            }
            return true;
        }
        private static void PrintInvalidMessage()
        {
            Console.WriteLine("Invalid move!");
        }
    }
}
