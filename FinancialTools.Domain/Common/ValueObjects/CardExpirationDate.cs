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

    private CardExpirationDate()
    {
        
    }
}
