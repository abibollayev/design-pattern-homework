using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("choose vehicle: car / motorcycle / truck / bus");
        var type = Console.ReadLine()?.Trim().ToLower();

        IVehicle vehicle = null;

        switch (type)
        {
            case "car":
                Console.Write("brand: ");
                var brand = Console.ReadLine();
                Console.Write("model: ");
                var model = Console.ReadLine();
                Console.Write("fuel type: ");
                var fuel = Console.ReadLine();
                vehicle = new CarFactory(brand, model, fuel).CreateVehicle();
                break;

            case "motorcycle":
                Console.Write("type: ");
                var mType = Console.ReadLine();
                Console.Write("engine volume: ");
                int.TryParse(Console.ReadLine(), out var volume);
                vehicle = new MotorcycleFactory(mType, volume).CreateVehicle();
                break;

            case "truck":
                Console.Write("capacity (tons): ");
                double.TryParse(Console.ReadLine(), out var capacity);
                Console.Write("axles: ");
                int.TryParse(Console.ReadLine(), out var axles);
                vehicle = new TruckFactory(capacity, axles).CreateVehicle();
                break;

            case "bus":
                Console.Write("seats: ");
                int.TryParse(Console.ReadLine(), out var seats);
                Console.Write("route: ");
                var route = Console.ReadLine();
                vehicle = new BusFactory(seats, route).CreateVehicle();
                break;

            default:
                Console.WriteLine("unknown type");
                break;
        }

        if (vehicle != null)
        {
            vehicle.Drive();
            vehicle.Refuel();
        }
    }
}

