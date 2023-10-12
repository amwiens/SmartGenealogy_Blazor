using FluentAssertions;

using NUnit.Framework;

using SmartGenealogy.Domain.Exceptions;
using SmartGenealogy.Domain.ValueObjects;

namespace SmartGenealogy.Domain.UnitTests.ValueObjects;

public class ColorTests
{
    [Test]
    public void ShouldReturnCorrectColorCode()
    {
        const string code = "#FFFFFF";

        var color = Color.From(code);

        color.Code.Should().Be(code);
    }

    [Test]
    public void ToStringReturnsCode()
    {
        var color = Color.White;

        color.ToString().Should().Be(color.Code);
    }

    [Test]
    public void ShouldPerformImplicitConversionToColorCodeString()
    {
        string code = Color.White;

        code.Should().Be("#FFFFFF");
    }

    [Test]
    public void ShouldPerformExplicitConversionGivenSupportedColorCode()
    {
        var color = (Color)"#FFFFFF";

        color.Should().Be(Color.White);
    }

    [Test]
    public void ShouldThrowUnsupporedColorExceptionGivenNotSupportedColorCode()
    {
        FluentActions.Invoking(() => Color.From("##FF33CC"))
            .Should().Throw<UnsupportedColorException>();
    }
}