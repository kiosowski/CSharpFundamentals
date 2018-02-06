using System;

namespace _01.ActionPoint
{
    class ActionPoint
    {
        static void Main(string[] args)
        {
            Action<string> action = (n) => Console.WriteLine(n);

            foreach (var name in Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
            {
                action(name);
            }
        }
    }
}
