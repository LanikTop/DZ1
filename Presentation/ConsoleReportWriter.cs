using Application.Abstractions;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presentation
{
    public class ConsoleReportWriter : IReportWriter
    {
        public void WriteReports(IEnumerable<Report> reports)
        {
            foreach (var report in reports)
            {
                Console.WriteLine(report);
            }
        }
    }
}
