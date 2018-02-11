using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.BasicQueueOperations
{
    class BasicQueue
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var inputQueue = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var queue = new Queue<int>();
            var NnumbersToEnqueue = input[0];
            var SnumberToDequeue = input[1];
            var XnumbersToLook = input[2];

            for (int i = 0; i < NnumbersToEnqueue; i++)
            {
                queue.Enqueue(inputQueue[i]);

            }
            for (int i = 0; i < SnumberToDequeue; i++)
            {
                queue.Dequeue();
            }
            if (queue.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (queue.Contains(XnumbersToLook))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(queue.Min());
            }

        }
    }
}