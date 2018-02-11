using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.InfernoIII
{
    class InfernoIII
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            Queue<KeyValuePair<string, int>> excludeCommands = new Queue<KeyValuePair<string, int>>();
            while (TakeCommand(out string[] commandParameter))
            {
                string command = commandParameter[0];
                var filterType = commandParameter[1];
                int filterParameter = int.Parse(commandParameter[2]);
                switch (command)
                {
                    case "Exclude":
                        excludeCommands.Enqueue(new KeyValuePair<string, int>(filterType, filterParameter));
                        break;
                    case "Reverse":
                        excludeCommands.Dequeue();
                        break;
                }
            }

            foreach (var currentCommand in excludeCommands.Reverse())
            {
                string filterType = currentCommand.Key;
                int filterParameter = currentCommand.Value;

                switch (filterType)
                {
                    case "Sum Left":
                        SumLeft(input, filterParameter);
                        break;
                    case "SumRight":
                        SumRight(input, filterParameter);
                        break;
                    case "Sum Left Right":
                        SumLeftRight(input, filterParameter);
                        break;
                }
            }
            Console.WriteLine(string.Join(" ", input));
        }

        private static void SumLeftRight(List<int> input, int filterParameter)
        {
            for (int i = 0; i < input.Count; i++)
            {
                var left = (i == 0) ? 0 : input[i - 1];
                var right = (i == input.Count - 1) ? 0 : input[i + 1];
                if (left + input[i] + right == filterParameter)
                {
                    input.RemoveAt(i);
                    i--;
                }
            }
        }

        private static void SumRight(List<int> input, int filterParameter)
        {
            while (input.Last() == filterParameter && input.Count > 0)
            {
                input.RemoveAt(input.Count - 1);
            }
            for (int i = 0; i < input.Count; i++)
            {
                if (input[i] + input[i + 1] == filterParameter)
                {
                    input.RemoveAt(i);
                    i--;
                }
            }
        }

        private static void SumLeft(List<int> input, int filterParameter)
        {
            while (input.Count > 0 && input.First() == filterParameter)
            {
                input.RemoveAt(0);
            }
            for (int i = input.Count - 1; i > 0; i--)
            {
                if (input[i] + input[i - 1] == filterParameter)
                {
                    input.RemoveAt(i);
                }
            }
        }

        private static bool TakeCommand(out string[] command)
        {
            command = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            if (command[0] == "Forge")
            {
                return false;
            }
            return true;
        }
    }

}

