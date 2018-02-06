using System;

namespace _02.KnightsOfHonor
{
    class KnightsOfHonor
    {
        static void Main(string[] args)
        {
            Action<string> action = (n) => Console.WriteLine(n);

            foreach (var name in Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
            {
                Console.WriteLine($"Sir {name}");
            }
        }
    }
}
