using Domain.ValueObjects;
using SharedKernel.Domain.Primitives;

namespace Domain.Entities
{
    public class AccountMovement : Entity
    {
        //TODO: Change constructor access modifier to protected
        public AccountMovement(Guid accountId, Guid transactionId, Money amount)
        {
            AccountId = accountId;
            TransactionId = transactionId;
            Amount = amount;
        }

        private AccountMovement()
        {
            
        }

        public Guid AccountId { get; private set; }
        public Guid TransactionId { get; private set; }
        public Money Amount { get; private set; }

        
    }
}
