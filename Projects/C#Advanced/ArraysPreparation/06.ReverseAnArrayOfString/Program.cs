using System;
using System.Linq;

namespace _06.ReverseAnArrayOfString
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            Console.WriteLine(string.Join(" ",input.Reverse()));
        }
    }
}
