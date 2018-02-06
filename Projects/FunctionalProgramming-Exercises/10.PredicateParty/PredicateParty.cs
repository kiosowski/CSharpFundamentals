using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.PredicateParty
{
    class PredicateParty
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            ExecuteCommand(names);
            PrintCommingList(names);
        }

        private static void PrintCommingList(List<string> names)
        {
            if (names.Any())
            {
                var people = string.Join(", ", names);
                Console.WriteLine($"{people} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        private static void ExecuteCommand(List<string> names)
        {
            var command = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            while (command[0] != "Party!")
            {
                if (command.Length < 3)
                {
                    command = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    continue;
                }
                switch (command[1])
                {
                    case "StartsWith":
                        ForeachName(command[0], names, n => n.StartsWith(command[2]));
                        break;
                    case "EndsWith":
                        ForeachName(command[0], names, n => n.EndsWith(command[2]));
                        break;
                    case "Length":
                        ForeachName(command[0], names, n => n.Length == int.Parse(command[2]));
                        break;
                    default:
                        break;
                }
                command = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                
            }
        }

        private static void ForeachName(string command, List<string> names, Func<string, bool> condition)
        {
            for (int i = names.Count - 1; i >= 0; i--)
            {
                if (condition(names[i]))
                {
                    switch (command)
                    {
                        case "Remove":
                            names.RemoveAt(i);
                            break;
                        case "Double":
                            names.Add(names[i]);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
