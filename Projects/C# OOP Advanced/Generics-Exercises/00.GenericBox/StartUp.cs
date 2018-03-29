using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _00.GenericBox
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var n = double.Parse(Console.ReadLine());
            var box = new Box<double>();
            for (int i = 0; i < n; i++)
            {
                box.Add(double.Parse(Console.ReadLine()));
            }
            var element = double.Parse(Console.ReadLine());
            var equalElementsCnt = box.EqualsCount(element);
            Console.WriteLine(equalElementsCnt);
        }
    }

}
