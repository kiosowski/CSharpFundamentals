using System;
using System.Linq;

namespace _06.ReverseAndExclude
{
    class ReverseAndExclude
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);
            
            var divideNumber = int.Parse(Console.ReadLine());
            Func<int, bool> filter = n => n % divideNumber != 0;

            var newNumbers = numbers.Reverse().Where(filter);
            Console.WriteLine(string.Join(" ",newNumbers));
        }
      
    }
}
