using System.Globalization;

namespace Domain.Models;

public record Report
{
    public long ClientId { get; set; }
    public decimal OrderSum { get; set; }
    public string FavoriteItemName { get; set; }

    public override string ToString()
    {
        return $"{ClientId}\t{OrderSum.ToString("F2", CultureInfo.InvariantCulture)}\t{FavoriteItemName}";
    }
}
