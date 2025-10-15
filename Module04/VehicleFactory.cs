public abstract class VehicleFactory
{
    public abstract IVehicle CreateVehicle();
}

public class CarFactory : VehicleFactory
{
    private string brand;
    private string model;
    private string fuelType;

    public CarFactory(string brand, string model, string fuelType)
    {
        this.brand = brand;
        this.model = model;
        this.fuelType = fuelType;
    }

    public override IVehicle CreateVehicle()
    {
        return new Car(brand, model, fuelType);
    }
}

public class MotorcycleFactory : VehicleFactory
{
    private string type;
    private int engineVolume;

    public MotorcycleFactory(string type, int engineVolume)
    {
        this.type = type;
        this.engineVolume = engineVolume;
    }

    public override IVehicle CreateVehicle()
    {
        return new Motorcycle(type, engineVolume);
    }
}

public class TruckFactory : VehicleFactory
{
    private double capacity;
    private int axles;

    public TruckFactory(double capacity, int axles)
    {
        this.capacity = capacity;
        this.axles = axles;
    }

    public override IVehicle CreateVehicle()
    {
        return new Truck(capacity, axles);
    }
}

public class BusFactory : VehicleFactory
{
    private int seats;
    private string route;

    public BusFactory(int seats, string route)
    {
        this.seats = seats;
        this.route = route;
    }

    public override IVehicle CreateVehicle()
    {
        return new Bus(seats, route);
    }
}


