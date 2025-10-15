public class PaymentContext
{
    private IPaymentStrategy strategy;

    public void SetStrategy(IPaymentStrategy strategy)
    {
        this.strategy = strategy;
    }

    public void ExecutePayment(double amount)
    {
        if (strategy == null)
            throw new System.InvalidOperationException("Payment strategy not set");
        strategy.Pay(amount);
    }
}

