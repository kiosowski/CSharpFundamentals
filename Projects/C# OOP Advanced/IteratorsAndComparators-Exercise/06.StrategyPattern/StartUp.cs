﻿using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main(string[] args)
    {
        SortedSet<Person> setOne = new SortedSet<Person>(new NameComparer());
        SortedSet<Person> setTwo = new SortedSet<Person>(new AgeComparer());
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            var tokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            Person person = new Person(tokens[0], int.Parse(tokens[1]));
            setOne.Add(person);
            setTwo.Add(person);
        }
        if (setOne.Count > 0)
        {
            Console.WriteLine(string.Join(Environment.NewLine, setOne));
            Console.WriteLine(string.Join(Environment.NewLine,setTwo));
        }
    }
}
