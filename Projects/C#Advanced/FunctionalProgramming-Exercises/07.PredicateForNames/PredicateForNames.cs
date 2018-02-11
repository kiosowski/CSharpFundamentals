using System;
using System.Linq;

namespace _07.PredicateForNames
{
    class PredicateForNames
    {
        static void Main(string[] args)
        {
            var nameLength = int.Parse(Console.ReadLine());

            var names = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            names = names.FindAll(n => n.Length <= nameLength);

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
