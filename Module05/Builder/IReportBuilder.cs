public interface IReportBuilder
{
    void SetHeader(string header);
    void SetContent(string content);
    void SetFooter(string footer);
    Report GetReport();
}

public class TextReportBuilder : IReportBuilder
{
    private Report report = new Report();

    public void SetHeader(string header)
    {
        report.Header = header;
    }

    public void SetContent(string content)
    {
        report.Content = content;
    }

    public void SetFooter(string footer)
    {
        report.Footer = footer;
    }

    public Report GetReport()
    {
        return report;
    }
}

public class HtmlReportBuilder : IReportBuilder
{
    private Report report = new Report();

    public void SetHeader(string header)
    {
        report.Header = $"<h1>{header}</h1>";
    }

    public void SetContent(string content)
    {
        report.Content = $"<p>{content}</p>";
    }

    public void SetFooter(string footer)
    {
        report.Footer = $"<footer>{footer}</footer>";
    }

    public Report GetReport()
    {
        return report;
    }
}
