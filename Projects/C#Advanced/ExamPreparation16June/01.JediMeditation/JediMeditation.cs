using System;
using System.Text;

namespace _01.JediMeditation
{
    class JediMeditation
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var masterJedis = new StringBuilder();
            var knightJedis = new StringBuilder();
            var padawanJedis = new StringBuilder();
            var toshkoSlav = new StringBuilder();
            var isThereYoda = false;
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var jedi in input)
                {
                    switch (jedi[0])
                    {
                        case 'm':
                            masterJedis.Append($"{jedi} ");
                            break;
                        case 'k':
                            knightJedis.Append($"{jedi} ");
                            break;
                        case 'p':
                            padawanJedis.Append($"{jedi} ");
                            break;
                        case 't':
                        case 's':
                            toshkoSlav.Append($"{jedi} ");
                            break;
                        case 'y':
                            isThereYoda = true;
                            break;
                        default:
                            break;
                    }
                }
            }
            if (isThereYoda)
            {
                Console.WriteLine(masterJedis.Append(knightJedis).Append(toshkoSlav).Append(padawanJedis));
                
            }
            else
            {
                Console.WriteLine(toshkoSlav.Append(masterJedis).Append(knightJedis).Append(padawanJedis));
            }
        }
    }
}
