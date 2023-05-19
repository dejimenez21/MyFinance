using Ardalis.GuardClauses;
using SharedKernel.Domain.Primitives;

namespace FinancialTools.Domain.Common.ValueObjects;

public record CardExpirationDate : ValueObject
{
    public int Month { get; init; }
    public int Year { get; init; }

    public CardExpirationDate(int month, int year, DateTime now)
    {
        Month = Guard.Against.OutOfRange(month, nameof(month), 1, 12, $"The month {month} doesn't exists");
        Year = Guard.Against.OutOfRange(year, nameof(year), now.Year - 1, DateTime.MaxValue.Year, $"The year {year} is lower than the current year");
    }

    public override string ToString()
    {
        return $"{Month}/{Year}";
    }

    #region EF Core parameterless constructor
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private CardExpirationDate() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    #endregion
}