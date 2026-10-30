using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Abstractions
{
    public interface IReportService
    {
        Report MakeReport(long clientId);
    }
}
