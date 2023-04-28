using Ardalis.GuardClauses;
using Domain.Enums;
using SharedKernel.Domain.Primitives;
using SharedKernel.Domain.ValueObjects;

namespace Domain.Entities
{
    public class Transaction : AggregateRoot
    {
        private Transaction(string description, DateTimeOffset transactionDate)
        {
            Id = Guid.NewGuid();
            Description = description;
            TransactionDate = transactionDate;
        }

        private Transaction() { }

        public string Description { get; private set; }
        public DateTimeOffset TransactionDate { get; private set; }

        public static Transaction Create(Dictionary<Account, Money> accountOperations, DateTimeOffset transactionDate, string description)
        {
            ValidateTransaction(accountOperations, description);

            var transaction = new Transaction(
                description,
                transactionDate
            );

            foreach (var accountOperation in accountOperations)
            {
                //TODO: If exception is thrown revert changes made to domain model.
                var account = accountOperation.Key;
                var amount = accountOperation.Value;
                account.RegisterAccountMovement(transaction.Id, amount);
            }

            return transaction;
        }

        private static void ValidateTransaction(Dictionary<Account, Money> accountOperations, string description)
        {
            Guard.Against.NullOrEmpty(accountOperations, nameof(accountOperations));
            Guard.Against.NullOrWhiteSpace(description, nameof(description));

            if (accountOperations.DistinctBy(x => x.Value.Currency).Count() != 1)
            {
                throw new InvalidOperationException("All the operations have to be in the same currency");
            }

            CheckCreditDebitBalance(accountOperations);
        }

        private static void CheckCreditDebitBalance(IReadOnlyDictionary<Account, Money> accountOperations)
        {
            decimal totalCredits = 0m;
            decimal totalDebits = 0m;

            foreach (var accountOperation in accountOperations)
            {
                var account = accountOperation.Key;
                var amount = accountOperation.Value;
                var defaultOperation = account.Type.DefaultOperation;

                if (defaultOperation == OperationType.Credit)
                {
                    totalCredits += amount.Value;
                }
                else
                {
                    totalDebits += amount.Value;
                }
            }

            if (totalCredits != totalDebits) throw new InvalidOperationException("The amount of credits have to be equal to the amount of debits");
        }
    }
}
