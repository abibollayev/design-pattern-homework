using System;

class Program
{
    static void Main()
    {
        var director = new ReportDirector();

        var textBuilder = new TextReportBuilder();
        var textReport = director.ConstructReport(
            textBuilder,
            "Sales Report 2025",
            "Total sales increased by 20%.",
            "Generated on 2025-10-15"
        );
        Console.WriteLine("TEXT REPORT:");
        Console.WriteLine(textReport);

        Console.WriteLine("\n----------------\n");

        var htmlBuilder = new HtmlReportBuilder();
        var htmlReport = director.ConstructReport(
            htmlBuilder,
            "Sales Report 2025",
            "Total sales increased by 20%.",
            "Generated on 2025-10-15"
        );
        Console.WriteLine("HTML REPORT:");
        Console.WriteLine(htmlReport);
    }
}

