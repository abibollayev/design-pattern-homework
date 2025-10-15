using System;

class Program
{
    static void Main()
    {
        var exchange = new CurrencyExchange();

        var console = new ConsoleObserver();
        var alert = new AlertObserver(500);
        var log = new LogObserver();

        exchange.Attach(console);
        exchange.Attach(alert);
        exchange.Attach(log);

        while (true)
        {
            Console.Write("enter currency (or exit): ");
            var name = Console.ReadLine();
            if (name == null || name.ToLower() == "exit") break;

            Console.Write("enter new rate: ");
            if (double.TryParse(Console.ReadLine(), out double rate))
                exchange.SetRate(name.ToUpper(), rate);
            else
                Console.WriteLine("invalid rate");
        }
    }
}

