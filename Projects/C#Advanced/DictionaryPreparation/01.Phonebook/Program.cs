using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Phonebook
{
    class Program
    {
        static void Main(string[] args)
        {
            var line = Console.ReadLine();
            var phoneBook = new Dictionary<string, string>();
            while (line != "END")
            {
                var commands = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (commands[0] == "S")
                {
                    var name = commands[1];
                    if (!phoneBook.ContainsKey(name))
                    {
                        Console.WriteLine($"Contact {name} does not exist.");
                    }
                    else
                    {
                        Console.WriteLine($"{name} -> {phoneBook[name]}");
                    }
                }
                else
                {
                    var name = commands[1];
                    var number = commands[2];

                    phoneBook[name] = number;
                }
                line = Console.ReadLine();
            }

        }
    }
}
