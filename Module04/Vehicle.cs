using System;

public interface IVehicle
{
    void Drive();
    void Refuel();
}

public class Car : IVehicle
{
    private string brand;
    private string model;
    private string fuelType;

    public Car(string brand, string model, string fuelType)
    {
        this.brand = brand;
        this.model = model;
        this.fuelType = fuelType;
    }

    public void Drive()
    {
        Console.WriteLine($"{brand} {model} is driving using {fuelType}");
    }

    public void Refuel()
    {
        Console.WriteLine($"{brand} {model} refueled with {fuelType}");
    }
}

public class Motorcycle : IVehicle
{
    private string type;
    private int engineVolume;

    public Motorcycle(string type, int engineVolume)
    {
        this.type = type;
        this.engineVolume = engineVolume;
    }

    public void Drive()
    {
        Console.WriteLine($"{type} motorcycle with {engineVolume}cc engine is driving");
    }

    public void Refuel()
    {
        Console.WriteLine($"{type} motorcycle refueled");
    }
}

public class Truck : IVehicle
{
    private double capacity;
    private int axles;

    public Truck(double capacity, int axles)
    {
        this.capacity = capacity;
        this.axles = axles;
    }

    public void Drive()
    {
        Console.WriteLine($"Truck with {axles} axles and capacity {capacity} tons is driving");
    }

    public void Refuel()
    {
        Console.WriteLine($"Truck with {axles} axles refueled");
    }
}

public class Bus : IVehicle
{
    private int seats;
    private string route;

    public Bus(int seats, string route)
    {
        this.seats = seats;
        this.route = route;
    }

    public void Drive()
    {
        Console.WriteLine($"Bus with {seats} seats is driving on route {route}");
    }

    public void Refuel()
    {
        Console.WriteLine($"Bus on route {route} refueled");
    }
}
