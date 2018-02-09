using System;
using System.Linq;

namespace _02.Monopoly
{
    class Monopoly
    {
        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[0]);
            var startMoney = 50;
            var numberOfHotels = 0;
            var turns = 0;

            for (int row = 0; row < rows; row++)
            {
                var commands = Console.ReadLine();
                for (int col = 0; col < commands.Length; col++)
                {
                    var index = row % 2 == 0 ? col : commands.Length - col - 1;
                    switch (commands[index])
                    {
                        case 'H':
                            Console.WriteLine($"Bought a hotel for {startMoney}. Total hotels: {++numberOfHotels}.");
                            startMoney = 0;
                                break;
                        case 'J':
                            Console.WriteLine($"Gone to jail at turn {turns}.");
                            turns += 2;
                            startMoney += 2 * (numberOfHotels * 10);
                            break;
                        case 'S':
                            int columnIndex = row % 2 == 0 ? col : index;
                            int moneyToSpend = Math.Min((columnIndex + 1) * (row + 1), startMoney);
                            startMoney -= moneyToSpend;
                            Console.WriteLine($"Spent {moneyToSpend} money at the shop.");
                            break;
                        default:
                            break;
                    }
                    startMoney += numberOfHotels * 10;
                    turns++;
                }
            }
            Console.WriteLine($"Turns {turns}");
            Console.WriteLine($"Money {startMoney}");
        }
    }
}
