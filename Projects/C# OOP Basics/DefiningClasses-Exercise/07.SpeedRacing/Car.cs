using System;
using System.Collections.Generic;
using System.Text;

public class Car
{
    private string carModel;
    private double fuelAmount;
    private double fuelConsumptionFor1km;
    private double distanceTraveled;
    public Car(string carModel,double fuelAmount,double fuelConsumptionFor1km)
    {
        this.carModel = carModel;
        this.fuelAmount = fuelAmount;
        this.fuelConsumptionFor1km = fuelConsumptionFor1km;
        this.distanceTraveled = 0.0;
    }
    public string CarModel
    {
        get { return carModel; }
    }
    public double FuelAmount
    {
        get { return fuelAmount; }
        set { fuelAmount = value; }
    }
    public double FuelConsumptionFor1km
    {
        get { return fuelConsumptionFor1km; }
    }
    public double DistanceTraveled
    {
        get { return distanceTraveled; }
        set { distanceTraveled = value; }
    }

    public void Drive(double kilometers)
    {
        var needFuel = kilometers * this.fuelConsumptionFor1km;
        if (this.fuelAmount < needFuel)
        {
            Console.WriteLine("Insufficient fuel for the drive");
            return;
        }
        this.fuelAmount -= needFuel;
        this.distanceTraveled += kilometers;
    }
}

