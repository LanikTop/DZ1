using Domain.Models;

namespace Application.Abstractions;
public interface IReportService
{
    Report MakeReport(long clientId);
}
