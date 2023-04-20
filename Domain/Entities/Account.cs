using Application.Domain.Enums;
using SharedKernel.Domain.Enums;
using SharedKernel.Domain.Primitives;

namespace Domain.Entities
{
    public class Account : Entity
    {
        //TODO: Set caching mechanism for calculating balances based on transactions
        public string Name { get; protected set; }
        public AccountType Type { get; protected set; }
        public string Number { get; protected set; }
        public CurrencyCode Currency { get; protected set; }
        public DateTime OpenedDate { get; protected set; }
        public decimal OpeningBalance { get; private set; }
        public bool IsCash { get; protected set; }
        public bool IsElegibleForPayment { get; protected set; }


        protected Account() { }

        public Account(string name, AccountType type, string number, CurrencyCode currency, DateTime openedDate, decimal openingBalance, bool isCash = false, bool isElegibleForPayment = false) : base()
        {
            if (OpenedDate > DateTime.Now) throw new Exception("Error creating account. OpenedDate can't be in the future.");
            if (OpeningBalance < 0) throw new Exception("Error creating account. OpeningBalance can't be negative.");
            if (isCash && type != AccountType.Asset) throw new Exception("Error creating account. Account cannot be marked as cash if is not of type asset.");
            if (IsElegibleForPayment && (type == AccountType.Expense || type == AccountType.Income)) throw new Exception("Income and Expenses accounts cannot be mark as payment eligible.");

            Name = name;
            Type = type;
            Number = number;
            Currency = currency;
            OpenedDate = openedDate;
            OpeningBalance = openingBalance;
            IsCash = isCash;
            IsElegibleForPayment = isElegibleForPayment;
        }
    }
}
