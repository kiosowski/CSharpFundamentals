using System;
using System.Linq;
using System.Collections.Generic;
namespace _02.CryptoMaster
{
    class CryptoMaster
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();

            long seqLenght = nums.Count;
            long maxLength = 0;

            for (int step = 1; step < seqLenght; step++)
            {
                for (int stNode = 0; stNode < seqLenght; stNode++)
                {
                    var localMax = 1;
                    var currentElementIndex = stNode;
                    var nextElementIndex = (currentElementIndex + step) % nums.Count;
                    while (nums[nextElementIndex] > nums[currentElementIndex])
                    {
                        localMax++;
                        currentElementIndex = nextElementIndex;
                        nextElementIndex = (currentElementIndex + step) % nums.Count;
                    }
                    if (maxLength<localMax)
                    {
                        maxLength = localMax;
                    }
                }
            }
            Console.WriteLine(maxLength);
        }
    }
}
