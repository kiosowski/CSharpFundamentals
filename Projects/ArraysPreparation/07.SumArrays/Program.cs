using System;
using System.Linq;

namespace _07.SumArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr1 = Console.ReadLine().Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var arr2 = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            if (arr1.Length <= arr2.Length)
            {
                var maxArr = arr2.Length;
                for (int i = 0; i <= arr2.Length; i++)
                {
                    maxArr = (arr1[i % arr1.Length] + arr2[i % arr2.Length]);
                    if (i >= arr2.Length)
                    {
                        break;
                    }
                    Console.Write(maxArr + " ");
                }
            }
            else
            {
                var maxArr = arr1.Length;
                for (int i = 0; i <= arr1.Length; i++)
                {
                    maxArr = (arr1[i % arr1.Length] + arr2[i % arr2.Length]);
                    if (i >= arr1.Length)
                    {
                        break;
                    }
                    Console.Write(maxArr + " ");
                }
            }
            Console.WriteLine();
        }
    }
}
