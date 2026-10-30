using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Abstractions
{
    public interface IReportWriter
    {
        void WriteReports(IEnumerable<Report> reports);
    }
}
