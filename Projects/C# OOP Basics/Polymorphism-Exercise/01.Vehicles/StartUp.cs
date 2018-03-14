using System;

namespace _01.Vehicles
{
    public class StartUp
    {
        private const double CarAirCondConsuption = 0.9;
        private const double TruckAirCondConsuption = 1.6;
        static void Main(string[] args)
        {
            var carDetails = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var car = new Car(double.Parse(carDetails[1]), double.Parse(carDetails[2]), CarAirCondConsuption);
            var truckDetails = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var truck = new Truck(double.Parse(truckDetails[1]), double.Parse(truckDetails[2]), TruckAirCondConsuption);

            ExecuteCommands(car, truck);
            Console.WriteLine(car);
            Console.WriteLine(truck);
        }

        private static void ExecuteCommands(Car car, Truck truck)
        {
            var numberOfCommands = int.Parse(Console.ReadLine());

            while (numberOfCommands > 0)
            {
                var command = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var action = command[0];
                var vehicleType = command[1];
                var value = double.Parse(command[2]);

                switch (action)
                {
                    case "Drive":
                        Console.WriteLine(vehicleType == "Car" ? car.Drive(value) : truck.Drive(value));
                        break;
                    case "Refuel":
                        switch (vehicleType)
                        {
                            case "Car":
                                car.Refuel(value);
                                break;
                            case "Truck":
                                truck.Refuel(value);
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }
                numberOfCommands--;
            }
        }
    }
}
