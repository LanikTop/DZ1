using Application.Abstractions;
using Domain.Models;

namespace Presentation;

public class ConsoleReportWriter : IReportWriter
{
    public void WriteReports(IEnumerable<Report> reports)
    {
        foreach (var report in reports)
        {
            Console.WriteLine(report);
        }
    }
}
