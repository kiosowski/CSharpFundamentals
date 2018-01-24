using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.SimpleTextEditor
{
    class SimpleTextEditor
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            
            var stack = new Stack<string>();

            string text = string.Empty;
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(' ').ToArray();
                switch (input[0])
                {
                    case "1":
                        stack.Push(text);
                        text += input[1];
                        break;
                    case "2":
                        stack.Push(text);
                        text = text.Substring(0, text.Length - int.Parse(input[1]));
                        break;
                    case "3":
                        Console.WriteLine(text[int.Parse(input[1]) - 1]);
                        break;
                    case "4":
                        text = stack.Pop();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
