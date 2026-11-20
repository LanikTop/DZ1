using Application.Abstractions;
using Domain.Models;

namespace Application.Services;

public class ReportService : IReportService
{
    private readonly IReportDAO _reportDAO;

    public ReportService(IReportDAO reportDAO)
    {
        _reportDAO = reportDAO;
    }

    public Report MakeReport(long clientId)
    {
        return new Report
        {
            ClientId = clientId,
            OrderSum = _reportDAO.GetClientOrdersSum(clientId),
            FavoriteItemName = _reportDAO.GetClientFavoriteItemName(clientId)
        };
    }
}
