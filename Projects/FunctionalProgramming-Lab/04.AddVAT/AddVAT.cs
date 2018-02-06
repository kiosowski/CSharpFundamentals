using System;
using System.Linq;
using System.Collections.Generic;
namespace _04.AddVAT
{
    class AddVAT
    {
        static void Main(string[] args)
        {
            Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse).Select(n => n * 1.2).ToList().ForEach(n => Console.WriteLine($"{n:n2}"));

         
        }
    }
}
