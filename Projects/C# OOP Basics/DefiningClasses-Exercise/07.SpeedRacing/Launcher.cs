using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class Launcher
{
    static void Main(string[] args)
    {
        var cars = new Queue<Car>();
        var numberOfCars = int.Parse(Console.ReadLine());
        for (int i = 0; i < numberOfCars; i++)
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            var carModel = input[0];
            var fuelAmount = double.Parse(input[1]);
            var fuelPerKm = double.Parse(input[2]);
            cars.Enqueue(new Car(carModel, fuelAmount, fuelPerKm));
        }
        var command = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

        while (command[0] != "End")
        {
            var model = command[1];
            var km = double.Parse(command[2]);
            var currentCar = cars.Where(c => c.CarModel == model).FirstOrDefault();

            if (currentCar!= null)
            {
                currentCar.Drive(km);
            }
            command = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
        }

        Console.WriteLine(string.Join(Environment.NewLine,cars.Select(c=>$"{c.CarModel} {c.FuelAmount:F2} {c.DistanceTraveled}")));
    }
}

