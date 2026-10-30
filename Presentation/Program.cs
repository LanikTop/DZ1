using Application;
using Application.Abstractions;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;
using Presentation;
using Infrastructure.DAO;
using Infrastructure;

var reportType = args.FirstOrDefault()?.ToLower() ?? string.Empty;
if (reportType != "console" && reportType != "file")
{
    Console.WriteLine("Нет аргумента: <console|file>");
    return;
}

var services =  new ServiceCollection();

if (reportType == "console")    
    services.AddSingleton<IReportWriter, ConsoleReportWriter>();
else
    services.AddSingleton<IReportWriter, FileReportWriter>();

services.AddSingleton<IConsoleReader, ConsoleReader>();

services.AddSingleton<IReportService, ReportService>();

services.AddSingleton<IReportDAO, ReportDAO>();

services.AddSingleton<ReportApp>();

var serviceProvider = services.BuildServiceProvider();

var app = serviceProvider.GetRequiredService<ReportApp>();
app.Run();
