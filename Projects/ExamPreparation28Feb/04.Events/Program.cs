using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
namespace _04.Events
{
    class Program
    {
        private static DateTime eventTime;
        static void Main(string[] args)
        {
            string pattern = @"^#([A-Za-z]+):\s*@([A-Za-z]+)\s*(\d+:\d+)$";
            Regex rgx = new Regex(pattern);
            var n = int.Parse(Console.ReadLine());
            var data = new SortedDictionary<string, SortedDictionary<string, List<DateTime>>>();

            for (int i = 1; i <= n; i++)
            {
                Match match = rgx.Match(Console.ReadLine());
                if (match.Success && IsValidate(match.Groups[3].Value))
                {
                    string person = match.Groups[1].Value;
                    string location = match.Groups[2].Value;
                    if (!data.ContainsKey(location))
                    {
                        data[location] = new SortedDictionary<string, List<DateTime>>();
                    }
                    if (!data[location].ContainsKey(person))
                    {
                        data[location][person] = new List<DateTime>();
                    }
                    data[location][person].Add(eventTime);
                }
            }
            string[] locations = Console.ReadLine().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var pair in data)
            {
                if (locations.Contains(pair.Key))
                {
                    Console.WriteLine(pair.Key + ":");
                    int lineNumber = 1;
                    foreach (var personData in pair.Value)
                    {
                        var formattedEventTime = personData.Value.OrderBy(v => v).Select(v => v.ToString("HH:mm"));
                        Console.WriteLine($"{lineNumber++}. {personData.Key} -> {string.Join(", ",formattedEventTime)}");
                    }
                }
            }
        }

        private static bool IsValidate(string d)
        {
            return DateTime.TryParse(d, out eventTime);
        }
    }
}
