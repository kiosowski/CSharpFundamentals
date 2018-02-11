using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.PartyReservationFilterModule
{
    class PartyReservationFilterModule
    {
        public static List<string> removedNames = new List<string>();
        static void Main(string[] args)
        {
            var names = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            ExecuteCommands(names);
            
        }

        private static void ExecuteCommands(List<string> names)
        {
            while (TakeCommand(out string[] command))
            {
                switch (command[1])
                {
                    case "Starts with":
                        ForeachName(names, command[0], n => n.StartsWith(command[2]));
                        break;
                    case "Ends with":
                        ForeachName(names, command[0], n => n.EndsWith(command[2]));
                        break;
                    case "Length":
                        ForeachName(names, command[0], n => n.Length == int.Parse(command[2]));
                        break;
                    case "Contains":
                        ForeachName(names, command[0], n => n.Contains(command[2]));
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine(string.Join(" ",names));
        }

        private static void ForeachName(List<string> names, string command, Func<string, bool> condition)
        {
            if (command == "Add filter")
            {
                for (int i = names.Count - 1; i >= 0; i--)
                {
                    if (condition(names[i]))
                    {
                        removedNames.Add(names[i]);
                        names.RemoveAt(i);
                    }
                }  
            }
            else if (command == "Remove filter")
            {
                for (int i = 0; i < removedNames.Count; i++)
                {
                    if (condition(removedNames[i]))
                    {
                        names.Add(removedNames[i]);
                    }
                }
            }
        }
        private static bool TakeCommand(out string[] command)
        {
            command = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            if (command[0] == "Print")
            {
                return false;
            }
            return true;
        }
    }
}
