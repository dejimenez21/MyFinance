using Domain.Enums;
using SharedKernel.Domain.Primitives;

namespace Application.Domain.Enums
{
    public class AccountType : Enumeration
    {
        public OperationType DefaultOperation { get; }
        public string DefaultAccountName { get; }

        public static AccountType Asset = new AccountType("Asset", OperationType.Debit, "Default Assets");
        public static AccountType Liability = new AccountType("Liability", OperationType.Credit, "Default Liabilities");
        public static AccountType Income = new AccountType("Income", OperationType.Credit, "Default Incomes");
        public static AccountType Expense = new AccountType("Expense", OperationType.Debit, "Default Expenses");

        private AccountType(string name, OperationType defaultOperation, string defaultAccountName) : base(name)
        {
            DefaultOperation = defaultOperation;
            DefaultAccountName = defaultAccountName;
        }
    }
}
