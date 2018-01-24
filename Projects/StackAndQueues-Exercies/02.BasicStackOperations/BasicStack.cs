using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.BasicStackOperations
{
    class BasicStack
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var inputStack = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var stack = new Stack<int>();
            var NnumbersToPush = input[0];
            var SnumbersToPop = input[1];
            var XnumbersToLook = input[2];

            for (int i = 0; i < NnumbersToPush; i++)
            {
                stack.Push(inputStack[i]);
                
            }
            for (int i = 0; i < SnumbersToPop; i++)
            {
                stack.Pop();
            }
            if (stack.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (stack.Contains(XnumbersToLook))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(stack.Min());
            }
            
        }
    }
}
