using System;
using System.Numerics;
using System.Linq;

namespace _02.ArraySlider
{
    class ArraySlider
    {
        static void Main(string[] args)
        {
            BigInteger[] array = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(BigInteger.Parse).ToArray();
            string command = Console.ReadLine();
            int currentIndex = 0;

            while (command != "stop")
            {
                string[] commandParams = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                int offset = int.Parse(commandParams[0]) % array.Length;
                Console.WriteLine(offset);
                string operation = commandParams[1];
                int operand = int.Parse(commandParams[2]);
                if (offset < 0)
                {
                    offset += array.Length;
                }
                currentIndex = (currentIndex + offset) % array.Length;

                switch (operation)
                {
                    case "&":
                        array[currentIndex] &= operand;
                        break;
                    case "|":
                        array[currentIndex] |= operand;
                        break;
                    case "^":
                        array[currentIndex] ^= operand;
                        break;
                    case "+":
                        array[currentIndex] += operand;
                        break;
                    case "-":
                        array[currentIndex] -= operand;
                        break;
                    case "*":
                        array[currentIndex] *= operand;
                        break;
                    case "/":
                        array[currentIndex] /= operand;
                        break;
                }
                if (array[currentIndex] < 0)
                {
                    array[currentIndex] = 0;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"[{string.Join(", ", array)}]");

        }
    }
}
