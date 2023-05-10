using SharedKernel.Domain.Enums;

namespace SharedKernel.Domain.ValueObjects;

public record Money(decimal Value, CurrencyCode Currency)
{
    public static Money operator +(Money left, Money right)
    {
        if (left.Currency != right.Currency)
        {
            throw new InvalidOperationException("Cannot add Money objects with different currencies.");
        }

        return new Money(left.Value + right.Value, left.Currency);
    }

    public static Money operator -(Money left, Money right)
    {
        if (left.Currency != right.Currency)
        {
            throw new InvalidOperationException("Cannot subtract Money objects with different currencies.");
        }

        return new Money(left.Value - right.Value, left.Currency);
    }

    public static Money operator -(Money current)
    {
        return new Money(-current.Value, current.Currency);
    }
}