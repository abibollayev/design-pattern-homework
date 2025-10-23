public class Tea : Beverage
{
    protected override void Brew() => Console.WriteLine("steeping the tea");
    protected override void AddCondiments() => Console.WriteLine("adding lemon");
}

public class Coffee : Beverage
{
    private readonly string _wants;
    public Coffee(string wants) => _wants = wants?.Trim().ToLower();
    protected override void Brew() => Console.WriteLine("brewing the coffee");
    protected override void AddCondiments() => Console.WriteLine("adding milk and sugar");

    protected override bool CustomerWantsCondiments()
    {
        if (string.IsNullOrEmpty(_wants)) return false;
        if (_wants == "y" || _wants == "yes") return true;
        if (_wants == "n" || _wants == "no") return false;
        Console.WriteLine("invalid input for condiments, skipping");
        return false;
    }
}

public class HotChocolate : Beverage
{
    protected override void Brew() => Console.WriteLine("mixing hot chocolate powder");
    protected override void AddCondiments() => Console.WriteLine("adding whipped cream");
}
