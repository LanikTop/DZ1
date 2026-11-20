using Domain.Models;

namespace Application.Abstractions;

public interface IReportWriter
{
    void WriteReports(IEnumerable<Report> reports);
}
