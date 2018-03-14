using System;
using System.Collections.Generic;

namespace _05.BorderControl
{
    class Program
    {
        static void Main(string[] args)
        {
            RunControl();
        }

        private static void RunControl()
        {
            var tryintToPass = new HashSet<string>();
            var input = Console.ReadLine().Trim();

            while (input != "End")
            {
                tryintToPass.Add(input);
                input = Console.ReadLine().Trim();
            }
            var fakeIdsEndsWith = Console.ReadLine().Trim();
            PrintDetainedIds(tryintToPass, ref fakeIdsEndsWith);
        }

        private static void PrintDetainedIds(HashSet<string> tryintToPass, ref string fakeIdsEndsWith)
        {
            foreach (var entityData in tryintToPass)
            {
                if (entityData.EndsWith(fakeIdsEndsWith))
                {
                    Console.WriteLine(entityData.Substring(entityData.LastIndexOf(' ') +1));
                }
            }
        }
    }
}
