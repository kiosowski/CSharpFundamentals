using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.StackFibonacci
{
    class StackFibonacci
    {
        static void Main(string[] args)
        {
            var n = long.Parse(Console.ReadLine());
            long a = 0;
            long b = 1;
            var stack = new Stack<long>();
            stack.Push(0);

            for (int i = 0; i < n - 1; i++)
            {
                long temp = a;
                a = b;
                b = temp + b;
                stack.Push(b);
            }
            Console.WriteLine(stack.First());
        }
    }
}
