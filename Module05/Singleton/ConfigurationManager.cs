using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

public sealed class ConfigurationManager
{
    private static ConfigurationManager? instance;
    private static readonly object lockObj = new();
    private readonly Dictionary<string, string> settings = new();

    private ConfigurationManager()
    {
        Console.WriteLine("ConfigurationManager created");
    }

    public static ConfigurationManager GetInstance()
    {
        if (instance == null)
        {
            lock (lockObj)
            {
                if (instance == null)
                    instance = new ConfigurationManager();
            }
        }
        return instance;
    }

    public void LoadFromFile(string path)
    {
        if (!File.Exists(path))
            throw new FileNotFoundException("config file not found", path);

        settings.Clear();
        foreach (var line in File.ReadAllLines(path))
        {
            if (string.IsNullOrWhiteSpace(line) || !line.Contains('=')) continue;
            var parts = line.Split('=', 2);
            settings[parts[0].Trim()] = parts[1].Trim();
        }
    }

    public void SaveToFile(string path)
    {
        using var writer = new StreamWriter(path);
        foreach (var kv in settings)
            writer.WriteLine($"{kv.Key}={kv.Value}");
    }

    public string Get(string key)
    {
        if (!settings.TryGetValue(key, out var value))
            throw new KeyNotFoundException($"key '{key}' not found");
        return value;
    }

    public void Set(string key, string value)
    {
        settings[key] = value;
    }

    public void PrintAll()
    {
        Console.WriteLine("current config:");
        foreach (var kv in settings)
            Console.WriteLine($"{kv.Key} = {kv.Value}");
    }
}
