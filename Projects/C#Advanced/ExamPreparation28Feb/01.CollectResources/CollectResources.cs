using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CollectResources
{
    class CollectResources
    {
        private static ISet<string> validResources = new HashSet<string>()
        {
            "stone","gold","wood","food"
        };
        private static bool[] cellsVisited;
        private static string[] resourceField;
        static void Main(string[] args)
        {
            resourceField = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var n = int.Parse(Console.ReadLine());
            int bestQuantity = 0;
            for (int i = 1; i <= n; i++)
            {
                cellsVisited = new bool[resourceField.Length];
                var path = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                var start = int.Parse(path[0]);
                var step = int.Parse(path[1]);

                int currentQuantity = TryGetResource(start);
                int currentIndex = (start + step) % resourceField.Length;
                while (!cellsVisited[currentIndex])
                {
                    currentQuantity += TryGetResource(currentIndex);
                    currentIndex = (currentIndex + step) % resourceField.Length;
                }
                if (currentQuantity > bestQuantity)
                {
                    bestQuantity = currentQuantity;
                }
            }
            Console.WriteLine(bestQuantity);
        }

        private static int TryGetResource(int index)
        {
            var resourceTokens = resourceField[index].Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
            var resource = resourceTokens[0];
            if (validResources.Contains(resource))
            {
                cellsVisited[index] = true;
                return resourceTokens.Length > 1 ? int.Parse(resourceTokens[1]) : 1;
            }
            return 0;
        }
    }
}
