using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.KeyRevolver
{
    class KeyRevolver
    {
        static void Main(string[] args)
        {
            var bulletsPrice = int.Parse(Console.ReadLine());
            var gunBarrelSize = int.Parse(Console.ReadLine());
            var bullets = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var locks = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var value = int.Parse(Console.ReadLine());
            var bulletCount = bullets.Length;
            var counter = 0;
            Queue<int> locksQueue = new Queue<int>();
            Stack<int> bulletsStack = new Stack<int>();
            foreach (var bullet in bullets)
            {
                bulletsStack.Push(bullet);
            }
            foreach (var item in locks)
            {
                locksQueue.Enqueue(item);
            }
            while (true)
            {
                if (bulletsStack.Peek() > locksQueue.Peek())
                {
                    Console.WriteLine("Ping!");
                    bulletsStack.Pop();
                    bulletCount--;
                }
                else if (bulletsStack.Peek() <= locksQueue.Peek())
                {
                    Console.WriteLine("Bang!");
                    bulletsStack.Pop();
                    locksQueue.Dequeue();
                    bulletCount--;
                }
                counter++;
                if (counter % gunBarrelSize == 0 && bulletsStack.Count > 0)
                {
                    Console.WriteLine("Reloading!");
                }

                if (bulletsStack.Count <= 0 || locksQueue.Count <= 0)
                {
                    break;
                }
            }

            if (locksQueue.Count <= 0)
            {
                Console.WriteLine($"{bulletCount} bullets left. Earned ${value - (counter * bulletsPrice)}");
            }
            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locksQueue.Count()}");
            }
        }
    }
}
