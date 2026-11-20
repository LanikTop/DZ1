using Application.Exceptions;
using FluentAssertions;
using Infrastructure.DAO;

namespace ProjectTests;

[TestFixture]
public class InfrastructureTests
{
    [Test]
    public void ReportDAO_GetClientFavoriteItemName_ReturnsExpectedValue()
    {
        new ReportDAO().GetClientFavoriteItemName(1010).Should().Be("Чипсеки");
        new ReportDAO().GetClientFavoriteItemName(1020).Should().Be("Сыр");
        new ReportDAO().GetClientFavoriteItemName(1022).Should().Be("Дошик");
    }

    [Test]
    public void ReportDAO_GetClientOrdersSum_ReturnsExpectedValue()
    {
        new ReportDAO().GetClientOrdersSum(1010).Should().Be(5412.15m);
        new ReportDAO().GetClientOrdersSum(1020).Should().Be(9809.56m);
        new ReportDAO().GetClientOrdersSum(1022).Should().Be(21195.98m);
    }

    [Test]
    public void ReportDAO_GetClientFavoriteItemName_ThrowsClientNotFoundException_WhenClientNotFound()
    {
        var act = () => new ReportDAO().GetClientFavoriteItemName(228);
        act.Should().Throw<ClientNotFoundException>();
    }

    [Test]
    public void ReportDAO_GetClientOrdersSum_ThrowsClientNotFoundException_WhenClientNotFound()
    {
        var act = () => new ReportDAO().GetClientOrdersSum(228);
        act.Should().Throw<ClientNotFoundException>();
    }
}
