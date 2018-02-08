using System;
using System.Linq;

namespace _02.ChangeList
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
            var commands = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            while (commands[0] != "Odd" && commands[0] != "Even")
            {
                var command = commands[0];

                if (command == "Insert")
                {
                    int element = int.Parse(commands[1]);
                    int position = int.Parse(commands[2]);

                    input.Insert(position, element);
                }
                else if (command == "Delete")
                {
                    var number = int.Parse(commands[1]);
                    input.RemoveAll(i => i == number);

                }
                commands = Console.ReadLine().Split(' ').ToList();
            }
            if (commands[0] == "Odd")
            {
                var oddInput = input.Where(n => n % 2 == 1);
                Console.WriteLine(string.Join(" ", oddInput));
            }
            else
            {
                var evenInput = input.Where(n => n % 2 == 0);
                Console.WriteLine(string.Join(" ", evenInput));
            }


        }
    }
}