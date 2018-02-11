using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ReverseNubmersWithAStack
{
    class ReverseNumbers 
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse);
            var stack = new Stack<int>();
            foreach (var ints in input)
            {
                stack.Push(ints);
            }
            Console.WriteLine(string.Join(" ",stack));
            

        }
    }
}
