using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class Launcher
{
    static void Main(string[] args)
    {
        var cars = new Queue<Car>();
        var numOfCars = int.Parse(Console.ReadLine());

        for (int i = 0; i < numOfCars; i++)
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var engine = new Engine(int.Parse(input[1]), int.Parse(input[2]));
            var cargo = new Cargo(int.Parse(input[3]), input[4]);
            var tires = new Tire[]
            {
                new Tire(int.Parse(input[6]),double.Parse(input[5])),
                new Tire(int.Parse(input[8]),double.Parse(input[7])),
                new Tire(int.Parse(input[10]),double.Parse(input[9])),
                new Tire(int.Parse(input[12]),double.Parse(input[11])),
            };
            cars.Enqueue(new Car(input[0],engine, cargo, tires));
        }

        var command = Console.ReadLine();

        Console.WriteLine(string.Join(Environment.NewLine,cars.Where(c=>c.Cargo.Type == command && command == "fragile" ? 
        c.Tires.Where(t=>t.Pressure < 1).FirstOrDefault() != null : c.Engine.Power > 250).Select(c=>c.Model)));
    }
}

