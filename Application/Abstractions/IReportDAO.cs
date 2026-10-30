using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Abstractions
{
    public interface IReportDAO
    {
        float GetClientOrdersSum(long clientId);

        string GetClientFavoriteItemName(long clientId);
    }
}
