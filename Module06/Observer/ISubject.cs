using System;
using System.Collections.Generic;

public interface ISubject
{
    void Attach(IObserver observer);
    void Detach(IObserver observer);
    void Notify();
}

public class CurrencyExchange : ISubject
{
    private readonly List<IObserver> observers = new();
    private readonly Dictionary<string, double> rates = new();

    public void Attach(IObserver observer)
    {
        observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void SetRate(string currency, double rate)
    {
        rates[currency] = rate;
        Notify();
    }

    public double GetRate(string currency)
    {
        return rates.ContainsKey(currency) ? rates[currency] : 0;
    }

    public void Notify()
    {
        foreach (var currency in rates)
            foreach (var observer in observers)
                observer.Update(currency.Key, currency.Value);
    }
}
