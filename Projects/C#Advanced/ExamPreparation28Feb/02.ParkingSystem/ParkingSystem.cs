using System;
using System.Collections.Generic;
using System.Linq;
namespace _02.ParkingSystem
{
    class ParkingSystem
    {
        private static Dictionary<int, List<int>> spotsTaken;
        private static int rows;
        private static int cols;
        static void Main(string[] args)
        {
            spotsTaken = new Dictionary<int, List<int>>();
            var dimensions = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            rows = int.Parse(dimensions[0]);
            cols = int.Parse(dimensions[1]);
            string command = Console.ReadLine();
            while (command != "stop")
            {
                var commandArgs = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int entryRow = int.Parse(commandArgs[0]);
                int targetRow = int.Parse(commandArgs[1]);
                int targetCol = int.Parse(commandArgs[2]);

                if (IsSpotTaken(targetRow,targetCol))
                {
                    targetCol = TryFindFreeSpot(targetRow, targetCol);
                }
                if (targetCol > 0)
                {
                    MarkSpotAsTaken(targetRow, targetCol);
                    int distance = Math.Abs(targetRow - entryRow) + targetCol + 1;
                    Console.WriteLine(distance);
                }
                else
                {
                    Console.WriteLine($"Row {targetRow} full");
                }
                command = Console.ReadLine();
            }
        }

        private static void MarkSpotAsTaken(int row, int col)
        {
            if (!spotsTaken.ContainsKey(row))
            {
                spotsTaken[row] = new List<int>();
            }
            spotsTaken[row].Add(col);
        }

        private static int TryFindFreeSpot(int row, int col)
        {
            int newCol = 0;
            int bestLength = int.MaxValue;
            for (int columnIndex = 1; columnIndex < cols; columnIndex++)
            {
                if (!IsSpotTaken(row,columnIndex))
                {
                    int newLength = Math.Abs(col - columnIndex);
                    if (newLength < bestLength)
                    {
                        bestLength = newLength;
                        newCol = columnIndex;
                    }
                }
            }
            return newCol;
        }

        private static bool IsSpotTaken(int row, int col)
        {
            return spotsTaken.ContainsKey(row) && spotsTaken[row].Contains(col);
        }
    }
}
