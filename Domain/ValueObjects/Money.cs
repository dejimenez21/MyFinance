using Domain.Enums;

namespace Domain.ValueObjects
{
    public class Money : IEquatable<Money>
    {
        public decimal Value { get; }
        public CurrencyCode Currency { get; }

        private Money() { }

        public Money(decimal amount, CurrencyCode currency)
        {
            Value = amount;
            Currency = currency;
        }

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

            return Value == other.Value && Currency == other.Currency;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = (hash * 23) + Value.GetHashCode();
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
