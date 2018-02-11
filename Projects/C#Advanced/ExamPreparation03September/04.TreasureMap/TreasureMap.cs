using System;
using System.Text.RegularExpressions;

namespace _04.TreasureMap
{
    class TreasureMap
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var pattern = @"![^#]*?\b(?<street>[A-Za-z]{4})\b[^#]*[^\d](?<number>\d{3})-(?<password>\d{6}|\d{4})(?:[^\d#][^#]*)?#|#[^!]*?\b(?<street>[A-Za-z]{4})\b[^!]*[^\d](?<number>\d{3})-(?<password>\d{6}|\d{4})(?:[^\d!][^!]*)?!";


            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                MatchCollection matches = Regex.Matches(input, pattern);
                Match toProceed = null;
                if (matches.Count != 0)
                {
                    toProceed = matches[matches.Count / 2];


                    Console.WriteLine($"Go to str. {toProceed.Groups["street"]} {toProceed.Groups["number"]}. Secret pass: {toProceed.Groups["password"]}.");
                }

            }
        }
    }
}
