using Application.Abstractions;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public class ReportApp
    {
        private readonly IConsoleReader _consoleReader;
        private readonly IReportService _reportService;
        private readonly IReportWriter _reportWriter;

        public ReportApp(IConsoleReader consoleReader, IReportService service, IReportWriter reportWriter)
        {
            _consoleReader = consoleReader;
            _reportService = service;
            _reportWriter = reportWriter;
        }

        public void Run()
        {
            var clientIds = _consoleReader.ReadClientIds();
            var reports = clientIds.Select(clientId => _reportService.MakeReport(clientId)).ToArray();

            _reportWriter.WriteReports(reports);
        }
    }
}
