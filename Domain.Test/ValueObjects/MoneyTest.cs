using FluentAssertions;
using SharedKernel.Domain.Enums;
using SharedKernel.Domain.ValueObjects;

namespace Domain.Test.ValueObjects;

public class MoneyTests
{
    [Fact]
    public void Add_WithSameCurrency_ShouldReturnNewMoneyWithSumOfAmounts()
    {
        // Arrange
        var money1 = new Money(10m, CurrencyCode.USD);
        var money2 = new Money(20m, CurrencyCode.USD);

        // Act
        var result = money1 + money2;

        // Assert
        result.Value.Should().Be(30m);
        result.Currency.Should().Be(CurrencyCode.USD);
    }

    [Fact]
    public void Add_WithDifferentCurrencies_ShouldThrowInvalidOperationException()
    {
        // Arrange
        var money1 = new Money(10m, CurrencyCode.USD);
        var money2 = new Money(20m, CurrencyCode.DOP);

        // Assert
        Assert.Throws<InvalidOperationException>(() => money1 + money2);
    }

    [Fact]
    public void Subtract_WithSameCurrency_ShouldReturnNewMoneyWithDifferenceOfAmounts()
    {
        // Arrange
        var money1 = new Money(30m, CurrencyCode.USD);
        var money2 = new Money(20m, CurrencyCode.USD);

        // Act
        var result = money1 - money2;

        // Assert
        result.Value.Should().Be(10m);
        result.Currency.Should().Be(CurrencyCode.USD);
    }

    [Fact]
    public void Subtract_WithDifferentCurrencies_ShouldThrowInvalidOperationException()
    {
        // Arrange
        var money1 = new Money(30m, CurrencyCode.USD);
        var money2 = new Money(20m, CurrencyCode.DOP);

        // Assert
        Assert.Throws<InvalidOperationException>(() => money1 + money2);
    }

    [Fact]
    public void Equals_WithEqualMoneyObjects_ShouldReturnTrue()
    {
        // Arrange
        var money1 = new Money(10m, CurrencyCode.USD);
        var money2 = new Money(10m, CurrencyCode.USD);

        // Act
        var result = money1.Equals(money2);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void Equals_WithDifferentAmounts_ShouldReturnFalse()
    {
        // Arrange
        var money1 = new Money(10m, CurrencyCode.USD);
        var money2 = new Money(20m, CurrencyCode.USD);

        // Act
        var result = money1.Equals(money2);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void Equals_WithDifferentCurrencies_ShouldReturnFalse()
    {
        // Arrange
        var money1 = new Money(10m, CurrencyCode.USD);
        var money2 = new Money(10m, CurrencyCode.DOP);

        // Act
        var result = money1.Equals(money2);

        // Assert
        result.Should().BeFalse();
    }
}