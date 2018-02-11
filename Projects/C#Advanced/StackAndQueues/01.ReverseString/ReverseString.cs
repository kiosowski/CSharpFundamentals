using System;
using System.Collections;
using System.Collections.Generic;

namespace _01.ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var stack = new Stack<char>(input.ToCharArray());

            foreach (var char in stack)
            {
				Console.Write(stack.Pop().ToString());
            }
        }
    }
}
