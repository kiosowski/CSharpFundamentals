using System;
using System.Linq;
using System.Collections.Generic;

namespace _04.PopulationCounter
{
    class PopulationCounter
    {
        static void Main(string[] args)
        {
            var data = new Dictionary<string, Dictionary<string, long>>();

            var command = Console.ReadLine();

            while (command != "report")
            {
                var input = command.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                var town = input[0];
                var country = input[1];
                var population = long.Parse(input[2]);

                if (!data.ContainsKey(country))
                {
                    data.Add(country, new Dictionary<string, long>());
                }
                data[country].Add(town, population);
                command = Console.ReadLine();
            }
            var sortedData = data.OrderByDescending(x => x.Value.Sum(y => y.Value));

            foreach (var countryInfo in sortedData)
            {
                long totalPopulation = countryInfo.Value.Sum(x => x.Value);
                Console.WriteLine($"{countryInfo.Key} (total population: {totalPopulation})");
                var orderedCityData = countryInfo.Value.OrderByDescending(x => x.Value);
                foreach (var townInfo in orderedCityData)
                {
                    Console.WriteLine($"=>{townInfo.Key}: {townInfo.Value}");
                }
            }
        }
    }
}
