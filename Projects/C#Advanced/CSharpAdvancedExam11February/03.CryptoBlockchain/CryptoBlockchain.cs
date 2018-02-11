using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace _03.CryptoBlockchain
{
    class CryptoBlockchain
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var input = string.Empty;
            var pattern = @"\{[\x00-\x7F].*?\}|\[[\x00-\x7F].*?\]";
            var numsPattern = @"\d{3}";
            var allSymRgx = new Regex(pattern);
            var matchNums = new Regex(numsPattern);
            var blocks = new List<int>();
            var check = new List<string>();

            for (int i = 0; i < n; i++)
            {
                input += Console.ReadLine();
            }

            MatchCollection matches = allSymRgx.Matches(input);

            foreach (Match match in matches)
            {
                var blockLength = match.Length;

                Match allNumsInMatch = matchNums.Match(match.ToString());
                check.Add(allNumsInMatch.ToString());


                MatchCollection numMatches = matchNums.Matches(match.ToString());

                foreach (Match item in numMatches)
                {
                    if (item.Length % 3 == 0)
                    {
                        int num = int.Parse(item.Value);

                        num -= blockLength;

                        blocks.Add(num);
                    }
                    


                }


            }

            foreach (var item in blocks)
            {
                var word = (char)item;
                Console.Write(word);
            }
            Console.WriteLine();
        }
    }
}
