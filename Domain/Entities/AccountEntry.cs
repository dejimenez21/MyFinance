using Domain.Enums;
using SharedKernel.Domain.Primitives;
using SharedKernel.Domain.ValueObjects;

namespace Domain.Entities
{
    public class AccountEntry : Entity
    {
        //TODO: Change constructor access modifier to protected
        internal AccountEntry(Guid accountId, Guid transactionId, Money amount)
        {
            Id = Guid.NewGuid();
            AccountId = accountId;
            TransactionId = transactionId;
            Amount = amount;
        }

        private AccountEntry()
        {
            
        }

        public Guid AccountId { get; private set; }
        public Guid TransactionId { get; private set; }
        public Money Amount { get; private set; }
    }
}
