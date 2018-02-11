using System;

namespace _02.Sneaking
{
    class Sneaking
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var matrix = new char[n][];
            for (int i = 0; i < n; i++)
            {
                matrix[i] = Console.ReadLine().ToCharArray();
            }
            var directions = Console.ReadLine().ToCharArray().ToList();
        }
    }
}
