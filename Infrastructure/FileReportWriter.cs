using Application.Abstractions;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public class FileReportWriter : IReportWriter
    {
        public void WriteReports(IEnumerable<Report> reports)
        {
            var filePath = Path.Combine(AppContext.BaseDirectory,
                $"report_{DateTime.Now:dd-MM-yyyy_HH-mm-ss-fff}.txt");
            var content = string.Join(Environment.NewLine, reports.Select(r => r.ToString())) 
                + Environment.NewLine;
            File.WriteAllText(filePath, content);
        }
    }
}
