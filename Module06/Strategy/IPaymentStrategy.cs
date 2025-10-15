using System;

public interface IPaymentStrategy
{
    void Pay(double amount);
}

public class CardPaymentStrategy : IPaymentStrategy
{
    private readonly string cardNumber;
    private readonly string cardHolder;

    public CardPaymentStrategy(string cardNumber, string cardHolder)
    {
        this.cardNumber = cardNumber;
        this.cardHolder = cardHolder;
    }

    public void Pay(double amount)
    {
        Console.WriteLine($"Paid {amount}₸ using bank card {cardNumber} (holder: {cardHolder})");
    }
}

public class PayPalPaymentStrategy : IPaymentStrategy
{
    private readonly string email;

    public PayPalPaymentStrategy(string email)
    {
        this.email = email;
    }

    public void Pay(double amount)
    {
        Console.WriteLine($"Paid {amount}₸ via PayPal account {email}");
    }
}

public class CryptoPaymentStrategy : IPaymentStrategy
{
    private readonly string walletAddress;
    private readonly string currency;

    public CryptoPaymentStrategy(string walletAddress, string currency)
    {
        this.walletAddress = walletAddress;
        this.currency = currency;
    }

    public void Pay(double amount)
    {
        Console.WriteLine($"Paid {amount}₸ using crypto {currency} wallet {walletAddress}");
    }
}

