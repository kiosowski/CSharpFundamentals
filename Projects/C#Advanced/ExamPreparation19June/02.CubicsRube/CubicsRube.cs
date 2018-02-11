using System;
using System.Linq;

namespace _02.CubicsRube
{
    class CubicsRube
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var allCells = n * n * n;
            string line = Console.ReadLine();
            long sum = 0;
            while (line != "Analyze")
            {
                var input = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                var firstNum = input[0];
                var secondNum = input[1];
                var thirdNum = input[2];
                var particles = input[3];
                if (firstNum >= 0 && firstNum < allCells && secondNum >= 0 && secondNum < allCells
                    && thirdNum >= 0 && thirdNum < allCells && particles != 0)
                {
                    sum += particles;
                    allCells--;
                }
                line = Console.ReadLine();
            }
            Console.WriteLine(sum);
            Console.WriteLine(allCells);
        }
    }
}
