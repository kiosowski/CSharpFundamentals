using System;
using System.Linq;

namespace _01.ArrayManipulator
{
    class ArrayManipulator
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine().Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var command = Console.ReadLine();

            while (command != "end")
            {
                var commandArgs = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                switch (commandArgs[0])
                {
                    case "exchange":
                        int index = int.Parse(commandArgs[1]);
                        if (index < 0 || index >= arr.Length)
                        {
                            Console.WriteLine("Invalid index");
                            break;
                        }
                        arr = ExchangeArray(arr, index + 1);
                        break;
                    case "max":
                    case "min":
                        Console.WriteLine(GetIndex(arr, commandArgs[0], commandArgs[1]));
                        break;
                    case "first":
                    case "last":
                        Console.WriteLine(GetSequence(arr, int.Parse(commandArgs[1]), commandArgs[0], commandArgs[2]));
                        break;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"[{string.Join(", ",arr)}]");
        }

        private static string GetSequence(int[] arr, int count, string type, string parity)
        {
            if (count > arr.Length)
            {
                return "Invalid count";
            }
            int remainder = parity == "odd" ? 1 : 0;
            int[] filtered = arr.Where(n => n % 2 == remainder).ToArray();
            return type == "first"
            ? "[" + string.Join(", ", filtered.Take(count)) + "]"
            : "[" + string.Join(", ", filtered.Reverse().Take(count).Reverse()) + "]";
        }

        private static string GetIndex(int[] arr, string type, string parity)
        {
            int remainder = parity == "odd" ? 1 : 0;
            int[] filtered = arr.Where(n => n % 2 == remainder).ToArray();
            if (!filtered.Any())
            {
                return "No matches";
            }
            return type == "min" 
                ? Array.LastIndexOf(arr, filtered.Min()).ToString()
                : Array.LastIndexOf(arr, filtered.Max()).ToString();

        }

        private static int[] ExchangeArray(int[] arr, int index)
        {
            return arr.Skip(index).Concat(arr.Take(index)).ToArray();
        }
    }
}
