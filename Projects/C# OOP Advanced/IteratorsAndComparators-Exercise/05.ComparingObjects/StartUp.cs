using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main(string[] args)
    {
        var input = string.Empty;
        List<Person> people = new List<Person>();
        while ((input = Console.ReadLine()) != "END")
        {
            var tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            people.Add(new Person(tokens[0], int.Parse(tokens[1]), tokens[2]));
        }
        int n = int.Parse(Console.ReadLine()) - 1;
        var specialPerson = people[n];

        if (people.Where(x=>x.CompareTo(specialPerson) == 0).Count() > 1)
        {
            int equalPeople = people.Where(p => p.CompareTo(specialPerson) == 0).Count();
            int unequalPeople = people.Where(p => p.CompareTo(specialPerson) != 0).Count();
            Console.WriteLine($"{equalPeople} {unequalPeople} {people.Count}");
        }
        else
        {
            Console.WriteLine("No matches");
        }
    }
}

