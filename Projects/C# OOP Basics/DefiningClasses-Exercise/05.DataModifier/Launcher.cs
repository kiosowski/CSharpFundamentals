using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class Launcher
{
    static void Main(string[] args)
    {
        var firstDate = Console.ReadLine();
        var secondDate = Console.ReadLine();
        Console.WriteLine(DataModifier.GetDaysBetweenDates(firstDate, secondDate));
    }
}

