using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.AppliedArithmetics
{
    class AppliedArithmetics
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }).Select(int.Parse).ToArray();
            var command = string.Empty;

            while (command != "end")
            {
                command = Console.ReadLine();
                if (command == "add")
                {
                    input = input.Select(n => n + 1).ToArray();
                }
                else if (command == "multiply")
                {
                    input = input.Select(n => n * 2).ToArray();
                }
                else if (command == "subtract")
                {
                    input = input.Select(n => n - 1).ToArray();
                }
                else if (command == "print")
                {
                    Console.WriteLine(string.Join(" ", input));
                }
            }
        }
    }
}
