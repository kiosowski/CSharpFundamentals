using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _03.ShmoogleCounter
{
    class ShmoogleCounter
    {
        static void Main(string[] args)
        {
            var rgx = new Regex("(double|int)\\s+([a-z][a-zA-Z]*)");
            var doubles = new List<string>();
            var ints = new List<string>();

            var input = string.Empty;

            while (!(input = Console.ReadLine()).StartsWith("//"))
            {
                var variables = rgx.Matches(input);
                foreach (Match variable in variables)
                {
                    var type = variable.Groups[1].Value;
                    var name = variable.Groups[2].Value;

                    if (type == "double")
                    {
                        doubles.Add(name);
                    }
                    else
                    {
                        ints.Add(name);
                    }
                }
            }
            Console.WriteLine($"Doubles: {FormatOutput(doubles)}");
            Console.WriteLine($"Ints: {FormatOutput(ints)}");
        }
        private static string FormatOutput(List<string> vars)
        {
            if (vars.Count>0)
            {
                return string.Join(", ", vars.OrderBy(v => v));
            }
            else
            {
                return "None";
            }
       
        }
    }
}
