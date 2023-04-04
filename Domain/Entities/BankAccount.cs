using Domain.Enums;

namespace Domain.Entities
{
    public class BankAccount : Account
    {
        public BankCode Bank { get; protected set; }

        private BankAccount()
        {
            
        }

        public BankAccount(string name, string accountNumber, BankCode bankCode)
        {
            Name = name;
            Number = accountNumber;
            Bank = bankCode;
        }
    }
}
