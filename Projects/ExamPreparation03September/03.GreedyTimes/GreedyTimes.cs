using System;
using System.Linq;
using System.Collections.Generic;
namespace _03.GreedyTimes
{
    class GreedyTimes
    {
        static void Main(string[] args)
        {
            var bagCapacity = long.Parse(Console.ReadLine());
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var cashDict = new Dictionary<string, long>();
            var gemDict = new Dictionary<string, long>();
            var goldDict = new Dictionary<string, long>();

            for (int i = 0; i < input.Length; i += 2)
            {
                var name = input[i];
                var money = long.Parse(input[i + 1]);
                var currGold = goldDict.Values.Sum();
                var currCash = cashDict.Values.Sum();
                var currGem = gemDict.Values.Sum();

                if (currCash + currGem + currGold + money > bagCapacity)
                {
                    continue;
                }
                if (name.Equals("Gold"))
                {
                    if (!goldDict.ContainsKey(name))
                    {
                        goldDict[name] = 0;
                    }
                    goldDict[name] += money;
                }
                else if (name.Length > 3 && name.Substring(name.Length - 3).ToLower() == "gem")
                {
                    if (currGem + money <= currGold)
                    {
                        if (!gemDict.ContainsKey(name))
                        {
                            gemDict[name] = 0;
                        }
                        gemDict[name] += money;
                    }

                }
                else if (name.Length == 3)
                {
                    if (currCash + money <= currGem)
                    {
                        if (!cashDict.ContainsKey(name))
                        {
                            cashDict[name] = 0;
                        }
                        cashDict[name] += money;
                    }

                }
            }

            List<Dictionary<string, long>> bag = new List<Dictionary<string, long>>();
            if (goldDict.Count > 0)
            {
                bag.Add(goldDict);
            }
            if (gemDict.Count > 0)
            {
                bag.Add(gemDict);
            }
            if (cashDict.Count > 0)
            {
                bag.Add(cashDict);
            }

            foreach (var item in bag.OrderByDescending(x => x.Values.Sum()))
            {
                var groupName = string.Empty;
                if (item.Count > 0)
                {
                    if (item.Keys.First().ToLower() == "gold")
                    {
                        groupName = "Gold";
                    }
                    else if (item.Keys.First().Length == 3)
                    {
                        groupName = "Cash";
                    }
                    else
                    {
                        groupName = "Gem";
                    }
                }
                Console.WriteLine($"<{groupName}> ${item.Values.Sum()}");
                foreach (var item2 in item.OrderByDescending(x => x.Key).ThenBy(x => x.Value))
                {
                    Console.WriteLine($"##{item2.Key} - {item2.Value}");
                }
            }
        }
    }
}
