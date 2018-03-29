using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp

{
    public static void Main(string[] args)
    {
        SortedSet<Person> sortedSet = new SortedSet<Person>();
        HashSet<Person> hashSet = new HashSet<Person>();
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            var tokens = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            Person person = new Person(tokens[0], int.Parse(tokens[1]));

            sortedSet.Add(person);
            hashSet.Add(person);
        }
        Console.WriteLine($"{sortedSet.Count}{Environment.NewLine}{hashSet.Count}");
    }
}

