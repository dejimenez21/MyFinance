using SharedKernel.Domain.Primitives;
using SharedKernel.Domain.ValueObjects;

namespace Domain.Entities
{
    public class AccountEntry : Entity
    {
        //TODO: Change constructor access modifier to internal
        internal AccountEntry(Guid accountId, Guid transactionId, Money amount)
        {
            Id = Guid.NewGuid();
            AccountId = accountId;
            TransactionId = transactionId;
            Amount = amount;
        }

        public Guid AccountId { get; private set; }
        public Guid TransactionId { get; private set; }
        public Money Amount { get; private set; }


#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private AccountEntry()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {

        }
    }
}
