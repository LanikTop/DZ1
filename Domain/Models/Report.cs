using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Domain.Models
{
    public class Report
    {
        public long ClientId { get; set; }
        public float OrderSum { get; set; }
        public string FavoriteItemName { get; set; }

        public override string ToString()
        {
            return $"{ClientId}\t{OrderSum.ToString("F2", CultureInfo.InvariantCulture)}\t{FavoriteItemName}";
        }
    }
}
