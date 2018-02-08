using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.CubicAssault
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, long>> assault = new Dictionary<string, Dictionary<string, long>>();
            long transformNum = 1000000;

            var line = Console.ReadLine();
            while (line != "Count em all")
            {
                var input = line.Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                string[] meteorTypes = new string[] { "Green", "Red", "Black" };
                var regionName = input[0];
                var type = input[1];
                var typeCount = long.Parse(input[2]);

                if (assault.ContainsKey(regionName))
                {
                    assault[regionName][type] += typeCount;
                }
                else
                { 
                    assault[regionName] = new Dictionary<string, long>()
                    {
                        {"Green",0L },
                        {"Red",0L },
                        {"Black",0L }
                    };
                    assault[regionName][type] = typeCount;
                }

                if (assault[regionName]["Green"] >= transformNum)
                {
                    assault[regionName]["Red"] += assault[regionName]["Green"] / transformNum;
                    assault[regionName]["Green"] %= transformNum;
                }
                if (assault[regionName]["Red"] >= transformNum)
                {
                    assault[regionName]["Black"] += assault[regionName]["Red"] / transformNum;
                    assault[regionName]["Red"] %= transformNum;
                }

              
                line = Console.ReadLine();  
            }
            foreach (var ass in assault.OrderByDescending(a => a.Value["Black"]).ThenBy(a => a.Key.Length).ThenBy(a => a.Key))
            {
                Console.WriteLine(ass.Key);
                foreach (var item in ass.Value.OrderByDescending(a => a.Value).ThenBy(a => a.Key))
                {
                    Console.WriteLine($"-> {item.Key} : {item.Value}");
                }
            }

        }
    }
}

