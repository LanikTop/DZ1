using Domain.Models;
using FluentAssertions;
using Presentation;

namespace ProjectTests;

[TestFixture]
public class PresentationTests
{
    [Test]
    public void ConsoleReader_ReadClientIds_ReturnsExpectedValue()
    {
        Console.SetIn(new StringReader("1010 1020"));
        var result = new ConsoleReader().ReadClientIds();
        result.Should().BeEquivalentTo(new long[] { 1010, 1020 });
    }

    [Test]
    public void ConsoleReader_ReadClientIds_ReturnsExpectedValue_WhenManySeparators()
    {
        Console.SetIn(new StringReader("1010\t1020    123 44  \t \t 1\t"));
        var result = new ConsoleReader().ReadClientIds();
        result.Should().BeEquivalentTo(new long[] { 1010, 1020, 123, 44, 1 });
    }

    [Test]
    public void ConsoleReader_ReadClientIds_ReturnsExpectedValue_WhenEmptyInput()
    {
        Console.SetIn(new StringReader("   \t " + Environment.NewLine + "123"));
        var result = new ConsoleReader().ReadClientIds();
        result.Should().BeEquivalentTo(new long[] { 123 });
    }

    [Test]
    public void ConsoleReader_ReadClientIds_ReturnsExpectedValue_WhenIncorrectInput()
    {
        Console.SetIn(new StringReader("123.45" + Environment.NewLine + "54"));
        var result = new ConsoleReader().ReadClientIds();
        result.Should().BeEquivalentTo(new long[] { 54 });
    }

    [Test]
    public void ConsoleReportWriter_WriteReports_ReturnsExpectedValue_WhenOneReport()
    {
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        var reports = new List<Report> { new Report() { ClientId = 12345, FavoriteItemName = "test", OrderSum = 100 } };
        new ConsoleReportWriter().WriteReports(reports);
        var result = stringWriter.ToString();
        result.Should().Be($"12345\t100.00\ttest" + Environment.NewLine);
    }

    [Test]
    public void ConsoleReportWriter_WriteReports_ReturnsExpectedValue_WhenManyReports()
    {
        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        var reports = new List<Report> { 
            new Report() { ClientId = 12345, FavoriteItemName = "test", OrderSum = 100 },
            new Report() { ClientId = 67890, FavoriteItemName = "test2", OrderSum = 200.14m }
        };
        new ConsoleReportWriter().WriteReports(reports);
        var result = stringWriter.ToString();
        result.Should().Be($"12345\t100.00\ttest{Environment.NewLine}67890\t200.14\ttest2" + Environment.NewLine);
    }
}
