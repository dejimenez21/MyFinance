using Domain.Enums;

namespace Domain.ValueObjects
{
    public class Money : IEquatable<Money>
    {
        public decimal Amount { get; }
        public CurrencyCode Currency { get; }

        public Money(decimal amount, CurrencyCode currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public Money Add(Money other)
        {
            if (Currency != other.Currency)
            {
                throw new InvalidOperationException("Cannot add amounts with different currencies");
            }

            return new Money(Amount + other.Amount, Currency);
        }

        public Money Subtract(Money other)
        {
            if (Currency != other.Currency)
            {
                throw new InvalidOperationException("Cannot subtract amounts with different currencies");
            }

            return new Money(Amount - other.Amount, Currency);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Money);
        }

        public bool Equals(Money other)
        {
            if (other == null)
            {
                return false;
            }

            return Amount == other.Amount && Currency == other.Currency;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = (hash * 23) + Amount.GetHashCode();
                hash = (hash * 23) + Currency.GetHashCode();
                return hash;
            }
        }

        public static bool operator ==(Money left, Money right)
        {
            if (left is null)
            {
                return right is null;
            }

            return left.Equals(right);
        }

        public static bool operator !=(Money left, Money right)
        {
            return !(left == right);
        }
    }
}
