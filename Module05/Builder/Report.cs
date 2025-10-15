public class Report
{
    public string Header { get; set; } = "";
    public string Content { get; set; } = "";
    public string Footer { get; set; } = "";

    public override string ToString()
    {
        return $"{Header}\n{Content}\n{Footer}";
    }
}

public class ReportDirector
{
    public Report ConstructReport(IReportBuilder builder, string header, string content, string footer)
    {
        builder.SetHeader(header);
        builder.SetContent(content);
        builder.SetFooter(footer);
        return builder.GetReport();
    }
}

