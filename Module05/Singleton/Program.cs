using System;
using System.IO;
using System.Threading;

class Program
{
    static void Main()
    {
        string path = "config.txt";

        var config = ConfigurationManager.GetInstance();
        config.Set("db_host", "localhost");
        config.Set("db_port", "5432");
        config.Set("env", "dev");
        config.SaveToFile(path);

        Console.WriteLine("initial config saved");

        var cfg2 = ConfigurationManager.GetInstance();
        cfg2.LoadFromFile(path);
        cfg2.PrintAll();

        Console.WriteLine($"same instance: {ReferenceEquals(config, cfg2)}");

        Console.WriteLine("\nchecking in multithreaded mode...");
        Thread[] threads = new Thread[5];
        for (int i = 0; i < threads.Length; i++)
        {
            threads[i] = new Thread(() =>
            {
                var inst = ConfigurationManager.GetInstance();
                Console.WriteLine($"instance hash: {inst.GetHashCode()}");
            });
            threads[i].Start();
        }

        foreach (var t in threads) t.Join();

        Console.WriteLine("done");
    }
}

