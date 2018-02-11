using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _03.CubicsMessages
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"^(?<frontIndex>\d*)(?<text>[a-zA-Z]+)(?<backIndex>[^a-zA-Z]*)$");
            var line = Console.ReadLine();
            while (line != "Over!")
            {
                var n = int.Parse(Console.ReadLine());
                
                if (!regex.IsMatch(line))
                {
                    line = Console.ReadLine();
                    continue;
                }
                Match match = regex.Match(line);

                string txtMsg = match.Groups["text"].Value;
                if (txtMsg.Length!= n)
                {
                    line = Console.ReadLine();
                    continue;
                }
                string group1 = match.Groups["frontIndex"].Value;
                string group2 = match.Groups["backIndex"].Value;
                string numbers = match.Groups["frontIndex"].Value + match.Groups["backIndex"].Value;
                List<int> indexes = new List<int>();
                for (int i = 0; i < numbers.Length; i++)
                {
                    int currentIndex;
                    bool isNumber = int.TryParse(numbers[i].ToString(), out currentIndex);
                    if (isNumber)
                    {
                        indexes.Add(currentIndex);
                    }
                }
                StringBuilder result = new StringBuilder();
                foreach (var index in indexes)
                {
                    if (index < n && index>= 0)
                    {
                        result.Append(txtMsg[index]);
                    }
                    else
                    {
                        result.Append(" ");
                    }
                }
                Console.WriteLine($"{txtMsg} == {result.ToString()}");
                line = Console.ReadLine();

            }
        }
    }
}
