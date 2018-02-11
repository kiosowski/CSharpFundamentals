using System;
using System.Collections.Generic;

namespace _03.AMinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var resources = Console.ReadLine();
            var dict = new Dictionary<string, long>();
            while (resources!="stop")
            {
                var quantity = long.Parse(Console.ReadLine());
                if (dict.ContainsKey(resources))
                {
                    dict[resources] += quantity;
                }
                else
                {
                    dict[resources] = quantity;
                }
                if (resources == "stop")
                {
                    break;
                }
                resources = Console.ReadLine();
            }
            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
