using System;

public interface INotifier
{
    void Send(string message);
}

public class EmailSender : INotifier
{
    public void Send(string message)
    {
        Console.WriteLine("Email sent: " + message);
    }
}

public class SmsSender : INotifier
{
    public void Send(string message)
    {
        Console.WriteLine("SMS sent: " + message);
    }
}

public class NotificationService
{
    private readonly INotifier notifier;

    public NotificationService(INotifier notifier)
    {
        this.notifier = notifier;
    }

    public void SendNotification(string message)
    {
        notifier.Send(message);
    }
}

