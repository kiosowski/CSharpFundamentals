using System;
using System.Linq;
using System.Collections.Generic;
namespace _04.HitList
{
    class HitList
    {
        static void Main(string[] args)
        {
            var data = new SortedDictionary<string, SortedDictionary<string, string>>();

            var indexInfo = int.Parse(Console.ReadLine());
            var indexSum = 0;
            var line = Console.ReadLine();

            while (line != "end transmissions")
            {
                var inputForName = line.Split(new char[] { '=', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var name = inputForName[0];

                if (!data.ContainsKey(name))
                {
                    data[name] = new SortedDictionary<string, string>();
                }
                var tokens = line.Split(new char[] {'=',';'}, StringSplitOptions.RemoveEmptyEntries).Skip(1).Take((line.Length-1) / 2).ToList();
               
                if (tokens.Count == 1)
                {
                    var infoName = tokens[0].Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                    if (!data[name].ContainsValue(infoName[0]))
                    {
                        data[name][infoName[0]] = infoName[1];
                    }
                    
                }
                else
                {
                    foreach (var item in tokens)
                    {
                        var infoName = item.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                        if (!data[name].ContainsValue(infoName[0]))
                        {
                            data[name][infoName[0]] = infoName[1];
                        }
                    }
                }
                line = Console.ReadLine();
            }

            var whoKill = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            var killName = whoKill[1];

            Console.WriteLine($"Info on {killName}:");
            foreach (var infoKey in data[killName])
            {
                Console.WriteLine($"---{infoKey.Key}: {infoKey.Value}");
                indexSum += infoKey.Key.Count();
                indexSum += infoKey.Value.Count();
            }
          
            Console.WriteLine($"Info index: {indexSum}");
            if (indexSum >= indexInfo)
            {
                Console.WriteLine("Proceed");
            }
            else
            {
                var needIndex = indexInfo - indexSum;
                Console.WriteLine($"Need {needIndex} more info.");
            }
        }
    }
}

