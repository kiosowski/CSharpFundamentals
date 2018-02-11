using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04.SrubskoUnleashed
{
    class SrubskoUnleashed
    {
        static void Main(string[] args)
        {
            var rgx = new Regex(@"(\D+)\s@(\D+)\s(\d+)\s(\d+)");

            var data = new Dictionary<string, Dictionary<string, int>>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                var match = rgx.Match(input);
                if (match.Success)
                {
                    var singer = match.Groups[1].Value.Trim();
                    var town = match.Groups[2].Value.Trim();
                    var ticketPrice = int.Parse(match.Groups[3].Value);
                    var ticketsCount = int.Parse(match.Groups[4].Value);

                    if (!data.ContainsKey(town))
                    {
                        data[town] = new Dictionary<string, int>();
                    }
                    if (!data[town].ContainsKey(singer))
                    {
                        data[town][singer] = 0;
                    }
                    data[town][singer] += ticketPrice * ticketsCount;
                }
            }
            foreach (var pair in data)
            {
                Console.WriteLine(pair.Key);
                foreach (var info in pair.Value.OrderByDescending(c=>c.Value))
                {
                    Console.WriteLine($"#  {info.Key} -> {info.Value}");
                }
            }

        }
    }
}
