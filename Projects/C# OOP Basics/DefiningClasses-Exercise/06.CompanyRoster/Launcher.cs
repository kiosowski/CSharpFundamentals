using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class Launcher
{
    static void Main(string[] args)
    {
        var employees = new Stack<Employee>();
        var n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            var email = "n/a";
            var age = -1;
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            if (input.Length > 4)
            {
                int parsed;
                var isDigit = int.TryParse(input[4], out parsed);
                if (isDigit)
                {
                    age = parsed;
                }
                else
                {
                    email = input[4];
                }
                if (input.Length>5)
                {
                    if (isDigit)
                    {
                        email = input[5];
                    }
                    else
                    {
                        age = int.Parse(input[5]);
                    }
                }
            }
            employees.Push(new Employee(
                input[0], decimal.Parse(input[1]), input[2], input[3], email, age));
        }
        var highestAverageSalaryDepartament = employees.GroupBy(e => e.Departament).OrderByDescending(g => g.Select(e => e.Salary).Sum()).First();

        Console.WriteLine($"Highest Average Salary: {highestAverageSalaryDepartament.Key}");
        Console.WriteLine(string.Join(Environment.NewLine,highestAverageSalaryDepartament.OrderByDescending(e=>e.Salary).Select(e=>$"{e.Name} {e.Salary:F2} {e.Email} {e.Age}")));
    }
}

