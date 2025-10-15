using System;

class Program
{
    static void Main()
    {
        var baseOrder = new Order
        {
            Products = new()
            {
                new Product("Laptop", 500000, 1),
                new Product("Mouse", 10000, 2)
            },
            DeliveryCost = 2000,
            Discount = new Discount("WELCOME10", 10),
            PaymentMethod = "Card"
        };

        Console.WriteLine("BASE ORDER:");
        Console.WriteLine(baseOrder);
        Console.WriteLine("\n--------------------\n");

        var clonedOrder = (Order)baseOrder.Clone();
        clonedOrder.Products.Add(new Product("Keyboard", 15000, 1));
        clonedOrder.Discount = new Discount("VIP15", 15);
        clonedOrder.PaymentMethod = "Crypto";

        Console.WriteLine("CLONED ORDER (modified):");
        Console.WriteLine(clonedOrder);
        Console.WriteLine("\n--------------------\n");

        Console.WriteLine("ORIGINAL ORDER (unchanged):");
        Console.WriteLine(baseOrder);
    }
}

