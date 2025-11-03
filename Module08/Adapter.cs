public interface IPaymentProcessor
{
    void ProcessPayment(double amount);
}

public class PayPalPaymentProcessor : IPaymentProcessor
{
    public void ProcessPayment(double amount)
    {
        Console.WriteLine($"PayPal processed payment of {amount}$");
    }
}

public class StripePaymentService
{
    public void MakeTransaction(double totalAmount)
    {
        Console.WriteLine($"Stripe completed transaction of {totalAmount}$");
    }
}

public class StripePaymentAdapter : IPaymentProcessor
{
    private readonly StripePaymentService _stripe;
    public StripePaymentAdapter(StripePaymentService stripe) => _stripe = stripe;
    public void ProcessPayment(double amount) => _stripe.MakeTransaction(amount);
}

public class SquarePaymentService
{
    public void Pay(double value)
    {
        Console.WriteLine($"Square payment done for {value}$");
    }
}

public class SquarePaymentAdapter : IPaymentProcessor
{
    private readonly SquarePaymentService _square;
    public SquarePaymentAdapter(SquarePaymentService square) => _square = square;
    public void ProcessPayment(double amount) => _square.Pay(amount);
}

