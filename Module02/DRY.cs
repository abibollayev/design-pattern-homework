using System;

public class Logger
{
    private void Log(string level, string message)
    {
        Console.WriteLine($"{level}: {message}");
    }

    public void LogError(string message) => Log("ERROR", message);
    public void LogWarning(string message) => Log("WARNING", message);
    public void LogInfo(string message) => Log("INFO", message);
}

public static class Config
{
    public static readonly string ConnectionString = "Server=myServer;Database=myDb;User Id=myUser;Password=myPass;";
}

public class DatabaseService
{
    public void Connect()
    {
        Console.WriteLine($"Connecting with {Config.ConnectionString}");
    }
}

public class LoggingService
{
    public void Log(string message)
    {
        Console.WriteLine($"Log to db {Config.ConnectionString}: {message}");
    }
}

