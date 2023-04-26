using Domain.Enums;
using SharedKernel.Domain.Primitives;

namespace Application.Domain.Enums
{
    public class AccountType : Enumeration
    {
        public OperationType DefaultOperation { get; }

        public static AccountType Asset = new AccountType("Asset", OperationType.Debit);
        public static AccountType Liability = new AccountType("Liability", OperationType.Credit);
        public static AccountType Income = new AccountType("Income", OperationType.Credit);
        public static AccountType Expense = new AccountType("Expense", OperationType.Debit);

        private AccountType(string name, OperationType defaultOperation) : base(name)
        {
            DefaultOperation = defaultOperation;
        }
    }
}
