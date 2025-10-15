using System;

class Program
{
    static void Main()
    {
        var context = new PaymentContext();

        Console.WriteLine("choose payment method: card / paypal / crypto");
        string? method = Console.ReadLine()?.Trim().ToLower();

        switch (method)
        {
            case "card":
                Console.Write("enter card number: ");
                string? cardNumber = Console.ReadLine();
                Console.Write("enter card holder: ");
                string? cardHolder = Console.ReadLine();
                context.SetStrategy(new CardPaymentStrategy(cardNumber ?? "0000", cardHolder ?? "unknown"));
                break;

            case "paypal":
                Console.Write("enter paypal email: ");
                string? email = Console.ReadLine();
                context.SetStrategy(new PayPalPaymentStrategy(email ?? "none"));
                break;

            case "crypto":
                Console.Write("enter wallet address: ");
                string? wallet = Console.ReadLine();
                Console.Write("enter currency (btc/eth/etc): ");
                string? currency = Console.ReadLine();
                context.SetStrategy(new CryptoPaymentStrategy(wallet ?? "0x0", currency ?? "btc"));
                break;

            default:
                Console.WriteLine("invalid method");
                return;
        }

        Console.Write("enter amount: ");
        if (double.TryParse(Console.ReadLine(), out double amount))
            context.ExecutePayment(amount);
        else
            Console.WriteLine("invalid amount");
    }
}

