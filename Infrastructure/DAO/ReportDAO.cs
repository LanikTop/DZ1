using Application.Abstractions;
using Application.Exceptions;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Infrastructure.DAO
{
    public class ReportDAO : IReportDAO
    {
        private readonly string _filePath = Path.Combine(AppContext.BaseDirectory, "orders_log.csv");

        private Order[] ReadCSVByClientId(long clientId)
        {
            var clientOrders = File.ReadAllLines(_filePath)
                .Skip(1)
                .Select(line => line.Split(','))
                .Select(fields => new Order
                {
                    ClientId = long.Parse(fields[0]),
                    Id = long.Parse(fields[1]),
                    ItemName = fields[2],
                    Quantity = int.Parse(fields[3]),
                    Price = float.Parse(fields[4], CultureInfo.InvariantCulture)
                })
                .Where(x => x.ClientId == clientId)
                .ToArray();

            if (clientOrders.Length == 0)
                throw new ClientNotFoundException(clientId);

            return clientOrders;
        }

        public string GetClientFavoriteItemName(long clientId)
        {
            return ReadCSVByClientId(clientId)
                .GroupBy(x => x.ItemName)
                .OrderByDescending(g => g.Sum(x => x.Quantity))
                .FirstOrDefault()?.Key!;
        }

        public float GetClientOrdersSum(long clientId)
        {
            return ReadCSVByClientId(clientId)
                .Sum(x => x.Quantity * x.Price);
        }
    }
}
