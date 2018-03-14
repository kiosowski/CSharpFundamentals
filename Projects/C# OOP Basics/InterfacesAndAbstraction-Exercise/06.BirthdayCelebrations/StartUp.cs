using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.BirthdayCelebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var input = string.Empty;
            ICollection<IBeing> aiBeings = new List<IBeing>();
            ICollection<IBirthable> livingBeings = new List<IBirthable>();
            while ((input = Console.ReadLine()) != "End")
            {
                var tokens = input.Split().ToList();
                var type = tokens[0];
                tokens.Remove(tokens.First());

                if (type == "Citizen")
                {
                    livingBeings.Add(new Citizen(tokens[0], int.Parse(tokens[1]), tokens[2], tokens[3]));
                }
                else if (type == "Robot")
                {
                    aiBeings.Add(new Robot(tokens[0], tokens[1]));
                }
                else if (type == "Pet")
                {
                    livingBeings.Add(new Pet(tokens[0], tokens[1]));
                }
            }
            string year = Console.ReadLine();
            livingBeings.Where(l => l.BirthDate.EndsWith(year)).ToList().ForEach(x => Console.WriteLine(x.BirthDate));

        }
    }
}
