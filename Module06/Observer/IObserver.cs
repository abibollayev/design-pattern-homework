using System;

public interface IObserver
{
    void Update(string currency, double rate);
}

public class ConsoleObserver : IObserver
{
    public void Update(string currency, double rate)
    {
        Console.WriteLine($"[console] {currency} updated: {rate}");
    }
}

public class AlertObserver : IObserver
{
    private readonly double alertThreshold;

    public AlertObserver(double alertThreshold)
    {
        this.alertThreshold = alertThreshold;
    }

    public void Update(string currency, double rate)
    {
        if (rate > alertThreshold)
            Console.WriteLine($"[alert] {currency} exceeded {alertThreshold}: now {rate}");
    }
}

public class LogObserver : IObserver
{
    private readonly string logPath = "rates.log";

    public void Update(string currency, double rate)
    {
        File.AppendAllText(logPath, $"{DateTime.Now}: {currency} = {rate}\n");
    }
}

