using System;

namespace _03.Mankind
{
    class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                var studentTokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                Student student = new Student(studentTokens[0], studentTokens[1], studentTokens[2]);
                var workerTokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                Worker worker = new Worker(workerTokens[0], workerTokens[1], decimal.Parse(workerTokens[2]), decimal.Parse(workerTokens[3]));
                Console.WriteLine(student.ToString());
                Console.WriteLine();
                Console.WriteLine(worker.ToString());
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}
