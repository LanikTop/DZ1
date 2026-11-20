namespace Application.Abstractions;

public interface IReportDAO
{
    decimal GetClientOrdersSum(long clientId);

    string GetClientFavoriteItemName(long clientId);
}
