using Domain.Enums;
using Domain.ValueObjects;
using FluentAssertions;

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
        var result = money1.Add(money2);

        // Assert
        result.Amount.Should().Be(30m);
        result.Currency.Should().Be(CurrencyCode.USD);
    }

    [Fact]
    public void Add_WithDifferentCurrencies_ShouldThrowInvalidOperationException()
    {
        // Arrange
        var money1 = new Money(10m, CurrencyCode.USD);
        var money2 = new Money(20m, CurrencyCode.DOP);

        // Act
        void Action() => money1.Add(money2);

        // Assert
        Assert.Throws<InvalidOperationException>((Action)Action);
    }

    [Fact]
    public void Subtract_WithSameCurrency_ShouldReturnNewMoneyWithDifferenceOfAmounts()
    {
        // Arrange
        var money1 = new Money(30m, CurrencyCode.USD);
        var money2 = new Money(20m, CurrencyCode.USD);

        // Act
        var result = money1.Subtract(money2);

        // Assert
        result.Amount.Should().Be(10m);
        result.Currency.Should().Be(CurrencyCode.USD);
    }

    [Fact]
    public void Subtract_WithDifferentCurrencies_ShouldThrowInvalidOperationException()
    {
        // Arrange
        var money1 = new Money(30m, CurrencyCode.USD);
        var money2 = new Money(20m, CurrencyCode.DOP);

        // Act
        void Action() => money1.Subtract(money2);

        // Assert
        Assert.Throws<InvalidOperationException>((Action)Action);
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