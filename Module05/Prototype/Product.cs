using System;

public class Product : ICloneable
{
    public string Name { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }

    public Product(string name, double price, int quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
    }

    public object Clone()
    {
        return new Product(Name, Price, Quantity);
    }

    public override string ToString()
    {
        return $"{Name} (x{Quantity}) - {Price * Quantity}₸";
    }
}

public class Discount : ICloneable
{
    public string Code { get; set; }
    public double Percentage { get; set; }

    public Discount(string code, double percentage)
    {
        Code = code;
        Percentage = percentage;
    }

    public object Clone()
    {
        return new Discount(Code, Percentage);
    }

    public override string ToString()
    {
        return $"{Code} (-{Percentage}%)";
    }
}

public class Order : ICloneable
{
    public List<Product> Products { get; set; } = new List<Product>();
    public double DeliveryCost { get; set; }
    public Discount Discount { get; set; }
    public string PaymentMethod { get; set; }

    public object Clone()
    {
        var cloned = new Order
        {
            DeliveryCost = DeliveryCost,
            PaymentMethod = PaymentMethod,
            Discount = (Discount)Discount?.Clone()
        };
        cloned.Products = Products.Select(p => (Product)p.Clone()).ToList();
        return cloned;
    }

    public double Total()
    {
        double sum = Products.Sum(p => p.Price * p.Quantity) + DeliveryCost;
        if (Discount != null)
            sum -= sum * (Discount.Percentage / 100);
        return sum;
    }

    public override string ToString()
    {
        string products = string.Join(", ", Products.Select(p => p.ToString()));
        string discount = Discount != null ? Discount.ToString() : "no discount";
        return $"Products: {products}\nDelivery: {DeliveryCost}₸\nDiscount: {discount}\nPayment: {PaymentMethod}\nTotal: {Total()}₸";
    }
}
