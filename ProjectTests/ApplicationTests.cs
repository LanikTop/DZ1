using Application;
using Application.Abstractions;
using Application.Services;
using Domain.Models;
using FluentAssertions;
using Moq;

namespace ProjectTests;

[TestFixture]
public class ApplicationTests
{
    private Mock<IConsoleReader> _consoleReader = null!;
    private Mock<IReportService> _reportService = null!;
    private Mock<IReportWriter> _reportWriter = null!;
    private Mock<IReportDAO> _reportDAO = null!;

    [SetUp]
    public void SetUp()
    {
        _consoleReader = new Mock<IConsoleReader>();
        _reportService = new Mock<IReportService>();
        _reportWriter = new Mock<IReportWriter>();
        _reportDAO = new Mock<IReportDAO>();
    }

    [Test]
    public void ReportApp_Run_ShouldReadClientIdsMakeReportsAndWriteReports()
    {
        var clientIds = new long[] { 1010, 1020, 1022 };
        var reports = new[] { 
            new Report() { ClientId = 1010, FavoriteItemName = "Чипсеки", OrderSum = 5412.15m },
            new Report() { ClientId = 1020, FavoriteItemName = "Сыр", OrderSum = 9809.56m },
            new Report() { ClientId = 1022, FavoriteItemName = "Дошик", OrderSum = 21195.98m }
        };
        _consoleReader.Setup(r => r.ReadClientIds()).Returns(clientIds);
        _reportService.Setup(s => s.MakeReport(1010)).Returns(reports[0]);
        _reportService.Setup(s => s.MakeReport(1020)).Returns(reports[1]);
        _reportService.Setup(s => s.MakeReport(1022)).Returns(reports[2]);

        var reportApp = new ReportApp(_consoleReader.Object, _reportService.Object, _reportWriter.Object);
        reportApp.Run();

        _consoleReader.Verify(r => r.ReadClientIds(), Times.Once);
        _reportService.Verify(s => s.MakeReport(1010), Times.Once);
        _reportService.Verify(s => s.MakeReport(1020), Times.Once);
        _reportService.Verify(s => s.MakeReport(1022), Times.Once);
        _reportWriter.Verify(w => w.WriteReports(reports), Times.Once);
    }

    [Test]
    public void ReportService_MakeReport_ReturnsExpectedReports()
    {
        var reports = new[] {
            new Report() { ClientId = 1010, FavoriteItemName = "Чипсеки", OrderSum = 5412.15m },
            new Report() { ClientId = 1020, FavoriteItemName = "Сыр", OrderSum = 9809.56m },
            new Report() { ClientId = 1022, FavoriteItemName = "Дошик", OrderSum = 21195.98m }
        };
        _reportDAO.Setup(s => s.GetClientFavoriteItemName(1010)).Returns("Чипсеки");
        _reportDAO.Setup(s => s.GetClientFavoriteItemName(1020)).Returns("Сыр");
        _reportDAO.Setup(s => s.GetClientFavoriteItemName(1022)).Returns("Дошик");
        _reportDAO.Setup(s => s.GetClientOrdersSum(1010)).Returns(5412.15m);
        _reportDAO.Setup(s => s.GetClientOrdersSum(1020)).Returns(9809.56m);
        _reportDAO.Setup(s => s.GetClientOrdersSum(1022)).Returns(21195.98m);

        var reportService = new ReportService(_reportDAO.Object);

        reportService.MakeReport(1010).Should().BeEquivalentTo(reports[0]);
        var report2 = reportService.MakeReport(1020).Should().BeEquivalentTo(reports[1]);
        var report3 = reportService.MakeReport(1022).Should().BeEquivalentTo(reports[2]);

        _reportDAO.Verify(r => r.GetClientFavoriteItemName(1010), Times.Once);
        _reportDAO.Verify(r => r.GetClientFavoriteItemName(1020), Times.Once);
        _reportDAO.Verify(r => r.GetClientFavoriteItemName(1022), Times.Once);
        _reportDAO.Verify(r => r.GetClientOrdersSum(1010), Times.Once);
        _reportDAO.Verify(r => r.GetClientOrdersSum(1020), Times.Once);
        _reportDAO.Verify(r => r.GetClientOrdersSum(1022), Times.Once);
    }
}
