using System;

public class User
{
    public string Name { get; set; }
    public string Email { get; set; }
}

public class FileReader
{
    public string ReadFile(string path)
    {
        return "file content";
    }
}

public class ReportGenerator
{
    public void GeneratePdfReport()
    {
        Console.WriteLine("PDF report generated");
    }
}

